using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Xml.Linq;

using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Security.Policy;
using System.Collections.Generic;
using static System.Windows.Forms.AxHost;

namespace TAX_OPGAVEN
{
    public partial class Form1 : Form
    {


        private const string apiKey = ""; // // find key i google api 
        private double kilometer { get; set; }
        private double pris { get; set; }
        private double basePrice = 0;


        private Dictionary<string, double> basePriceByVehicleType = new Dictionary<string, double>
        {
            { "Almindelige Day Vogne", 37 },
             { "Almindelige Night Vogne", 47 },
            { "Store Vogne Day – minibus", 77 },
            { "Store Vogne Night – minibus", 87 },
        };

        private Dictionary<string, double> kilometerByVehicleTypeAndTimeOfDay = new Dictionary<string, double>
        {
            { "Almindelige Vogne_Day", 12.75 },
            { "Almindelige Vogne_Night", 16 },
            { "Store Vogne – minibus_Day", 17 },
            { "Store Vogne – minibus_Night", 19 },
        };

        public Form1()
        {
            InitializeComponent();
            InitializeWebView();

            cmbVehicleType1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeOfDay1.DropDownStyle = ComboBoxStyle.DropDownList;


            // Populate vehicle types and time of day options
            cmbVehicleType1.Items.AddRange(new object[] { "Almindelige Day Vogne", "Almindelige Nat Vogne Night", "Store Vogne Day – minibus", "Store Vogne Night – minibus" });
            cmbTimeOfDay1.Items.AddRange(new object[] { "Day", "Night" });



            cmbVehicleType1.SelectedIndex = 0;
            cmbTimeOfDay1.SelectedIndex = 0;

        }
        private async void InitializeWebView()
        {
            // Ensure WebView2 is initialized
            if (webView21 != null)
            {
                await webView21.EnsureCoreWebView2Async(null);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // UpdatePrice(vehicleType, timeOfDay);
        }

        private void LoadMap(string startAddress, string endAddress)
        {
            // Ensure webViewMap is not null
            if (webViewMap != null)
            {
                string url = $"https://www.google.com/maps/dir/?api=1&origin={Uri.EscapeDataString(startAddress)}&destination={Uri.EscapeDataString(endAddress)}&travelmode=driving";
                webViewMap.Source = new Uri(url);
            }
        }

        private async void btnCalculate_Click(object sender, EventArgs e) // button knap 
        {
            try
            {
                // Ensure text boxes are not null and have valid text
                double kilometers = double.Parse(txtKilometers1.Text, CultureInfo.InvariantCulture);
                string vehicleType = cmbVehicleType1.SelectedItem?.ToString();
                string timeOfDay = cmbTimeOfDay1.SelectedItem?.ToString();
                string startLocation = startLocation1?.Text;
                string endLocation = Destination?.Text;

                // Validate inputs
                if (string.IsNullOrEmpty(startLocation) || string.IsNullOrEmpty(endLocation))
                {
                    MessageBox.Show("Please enter both origin and destination.");
                    return;
                }

                // Update price based on selections
                UpdatePrice(vehicleType, timeOfDay);

                // Calculate fare
                double fare = CalculateFare(kilometers, vehicleType, timeOfDay);
                pris = basePrice + fare;

                // Display the result
                LBLPRICE.Text = pris.ToString("C", CultureInfo.CurrentCulture);

                txtKilometers1.Text = $"{kilometers} km";
                // Load the map with directions
                LoadMap(startLocation, endLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private double CalculateFare(double kilometers, string vehicleType, string timeOfDay)
        {
            return kilometers * this.kilometer;
        }

        private void UpdatePrice(string vehicleType, string timeOfDay)
        {
            if (basePriceByVehicleType.TryGetValue(vehicleType, out double basePrice))
            {
                this.basePrice = basePrice;

                string key = $"{vehicleType}_{timeOfDay}";
                if (kilometerByVehicleTypeAndTimeOfDay.TryGetValue(key, out double kilometer))
                {
                    this.kilometer = kilometer;
                }
                else
                {
                    MessageBox.Show("Invalid time of day selection.");
                }
            }
            else
            {
                MessageBox.Show("Invalid vehicle type selection.");
            }
        }
        private async void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get user inputs
                string vehicleType = cmbVehicleType1.SelectedItem?.ToString();
                string timeOfDay = cmbTimeOfDay1.SelectedItem?.ToString();
                string startLocation = startLocation1.Text;
                string endLocation = Destination.Text;

                // Validate inputs
                if (string.IsNullOrEmpty(startLocation) || string.IsNullOrEmpty(endLocation))
                {
                    MessageBox.Show("Please enter both origin and destination.");
                    return;
                }

                if (string.IsNullOrEmpty(vehicleType))
                {
                    MessageBox.Show("Please select a vehicle type.");
                    return;
                }

                // Update base price and kilometer based on selections
                UpdatePrice(vehicleType, timeOfDay);

                // Load the map with directions
                LoadMap(startLocation, endLocation);

                // Fetch and display distance from API
                double? distanceInKm = await FetchAndDisplayDistance(startLocation, endLocation);

                if (distanceInKm.HasValue)
                {
                    // Display the distance in the TextBox
                    txtKilometers1.Text = $"{distanceInKm} km";

                    // Calculate fare based on the distance
                    double fare = CalculateFare(distanceInKm.Value, vehicleType, timeOfDay);
                    pris = basePrice + fare;

                    // Display the result
                    LBLPRICE.Text = pris.ToString("C", CultureInfo.CurrentCulture);
                }
                else
                {
                    MessageBox.Show("Unable to retrieve distance. Please try again.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async Task<double?> FetchAndDisplayDistance(string startLocation, string endLocation)
        {
            try
            {
                string apiKey = ""; // find key i google api 
                string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={Uri.EscapeDataString(startLocation)}&destination={Uri.EscapeDataString(endLocation)}&mode=driving&key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseBody);
                    var distanceText = json["routes"][0]["legs"][0]["distance"]["text"]?.ToString();
                    double distanceValue = 0;

                    if (distanceText != null)
                    {
                        if (distanceText.EndsWith(" km"))
                        {
                            distanceValue = double.Parse(distanceText.Replace(" km", ""), CultureInfo.InvariantCulture);
                        }
                        else if (distanceText.EndsWith(" m"))
                        {
                            distanceValue = double.Parse(distanceText.Replace(" m", ""), CultureInfo.InvariantCulture) / 1000;
                        }

                        return distanceValue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching distance: {ex.Message}");
            }

            return null;
        }


        private void txtKilometers1_TextChanged(object sender, EventArgs e)
        {
            // Handle text changes if needed
        }

        private void cmbVehicleType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  UpdatePrice();
        }

        private void cmbTimeOfDay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   UpdatePrice();
        }
    }
}





















































