# TAXA Task 🚖🕒📏

Welcome to the **TAXA Task** project! 🚖✨ This application helps users calculate taxi fares based on distance, vehicle type, and time of day.🕒📏 The application also provides a visual map of the route using Google Maps. 🗺️

## 🚀 Features
- Calculate taxi fares based on kilometers traveled.
- Choose vehicle type and time of day for accurate pricing.
- View directions on Google Maps.
- User-friendly interface with dropdowns for selections.

## 📦 Getting Started

To get a copy of the project up and running on your local machine, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/TAX_OPGAVEN.git
   ```

2. **Open the project** in your preferred IDE (e.g., Visual Studio).

3. **Set up the API key**:
   - Find your Google Maps API key from [Google Cloud Platform](https://cloud.google.com/maps-platform/).
   - Replace the placeholder in the code:
     ```csharp
     private const string apiKey = ""; // Your API key here
     ```

> **⚠️ Important**: **Do not share your API key publicly!** Keep it secure to avoid unauthorized access. 🌐🔒

## 🛠️ Key Functionality

### User Input Handling
- The application takes user inputs for starting location, destination, vehicle type, and time of day. 
- It validates inputs to ensure that necessary fields are filled out correctly.

### Fare Calculation
- Fare is calculated based on:
  - Base price associated with the selected vehicle type.
  - Distance obtained from the Google Maps Directions API.
- The calculated fare is displayed in a user-friendly format.

### Map Loading
- Google Maps is loaded with the specified start and end locations, providing visual directions for the user.

### Error Handling
- The application includes error handling to manage API failures or invalid inputs gracefully, displaying relevant messages to the user. 

## 📈 Code Structure

### Main Components
- **Form1.cs**: Contains the main logic for handling user inputs, calculating fares, and loading maps.
- **Dictionaries**: Used to store base prices and kilometer rates based on vehicle type and time of day.

### Important Methods
- `CalculateFare(double kilometers, string vehicleType, string timeOfDay)`: Calculates the total fare based on user inputs.
- `UpdatePrice(string vehicleType, string timeOfDay)`: Updates the base price and kilometer rate based on selected options.
- `FetchAndDisplayDistance(string startLocation, string endLocation)`: Fetches distance data from the Google Maps API.

## 🔄 Restart and Inputs
- The application is designed to restart and handle new inputs seamlessly. Upon completing a fare calculation, users can easily enter new locations or change vehicle types without needing to reload the application.

## 📄 Contributing
Contributions are welcome! If you have suggestions or improvements, please create a pull request or open an issue in the repository.


##  Namespace and Imports
- This section imports various namespaces that provide functionality for the application, such as handling HTTP requests, working with forms, and using JSON for data manipulation.
```csharp
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.WinForms;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Collections.Generic;
  ```
## Constants and Properties
- apiKey: A placeholder for the Google API key, which is required for API calls.
kilometer, pris, and basePrice: Properties to store kilometer rates, the calculated price, and the base price for different vehicle types.
```csharp
private const string apiKey = ""; // Find key in Google API
private double kilometer { get; set; }
private double pris { get; set; }
private double basePrice = 0;

 ```
## Dictionaries for Pricing
- Two dictionaries store base prices and kilometer rates based on the vehicle type and time of day. This allows quick access to pricing information based on user selections.
```csharp
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
```
## Constructor and Initialization
- InitializeComponent(): Initializes the form's components.
- InitializeWebView(): A method to set up the WebView component.
- The code sets up dropdown lists for vehicle types and time of day, making it user-friendly.
```csharp
 InitializeComponent();
    InitializeWebView();
    
    cmbVehicleType1.DropDownStyle = ComboBoxStyle.DropDownList;
    cmbTimeOfDay1.DropDownStyle = ComboBoxStyle.DropDownList;

    // Populate vehicle types and time of day options
    cmbVehicleType1.Items.AddRange(new object[] { "Almindelige Day Vogne", "Almindelige Night Vogne", "Store Vogne Day – minibus", "Store Vogne Night – minibus" });
    cmbTimeOfDay1.Items.AddRange(new object[] { "Day", "Night" });

    cmbVehicleType1.SelectedIndex = 0;
    cmbTimeOfDay1.SelectedIndex = 0;
```
## Loading the Map
- This method takes start and end addresses, constructs a URL for Google Maps, and loads it into a WebView. The Uri.EscapeDataString method ensures that special characters in the addresses are properly encoded for the URL.
```csharp
private void LoadMap(string startAddress, string endAddress)
{
    if (webViewMap != null)
    {
        string url = $"https://www.google.com/maps/dir/?api=1&origin={Uri.EscapeDataString(startAddress)}&destination={Uri.EscapeDataString(endAddress)}&travelmode=driving";
        webViewMap.Source = new Uri(url);
    }
}
```
## Calculate Fare Button Click Event
- Parses input values.
- Validates the input fields.
- Updates pricing based on the vehicle type and time of day.
- Calculates the fare and displays it.
- Loads the route on the map.
```csharp
private async void btnCalculate_Click(object sender, EventArgs e)
{
    try
    {
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
```
## Calculate Fare
- This method calculates the fare based on the number of kilometers and the rate per kilometer defined in the UpdatePrice method.
```csharp
private double CalculateFare(double kilometers, string vehicleType, string timeOfDay)
{
    return kilometers * this.kilometer;
}
```
## Update Price Method
- This method updates the base price and the kilometer rate based on the user's selections. It uses dictionaries to find the correct pricing.
```csharp

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
```
## Fetching Distance from API
- This asynchronous method fetches the distance between two locations using the Google Maps Directions API:
   -    It constructs the request URL with the user-provided start and end locations.
   -    It handles the HTTP request and parses the JSON response to extract the distance value, converting it to kilometers if necessary.
```csharp
private async Task<double?> FetchAndDisplayDistance(string startLocation, string endLocation)
{
    try
    {
        string apiKey = ""; // Find key in Google API
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

```
### Thank you for reading!

I hope you found this project helpful. If you're interested in checking out more of my work, you can find my other projects [here](https://github.com/PlutoGamerpro?tab=stars).

