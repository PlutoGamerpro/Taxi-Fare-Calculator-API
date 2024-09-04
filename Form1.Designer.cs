using System;

namespace TAX_OPGAVEN
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser21 = new System.Windows.Forms.WebBrowser();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webViewMap = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtKilometers1 = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.cmbVehicleType1 = new System.Windows.Forms.ComboBox();
            this.cmbVehicleType = new System.Windows.Forms.Label();
            this.cmbTimeOfDay1 = new System.Windows.Forms.ComboBox();
            this.cmbTimeOfDay = new System.Windows.Forms.Label();
            this.startLocation1 = new System.Windows.Forms.TextBox();
            this.Destination = new System.Windows.Forms.TextBox();
            this.startLocation = new System.Windows.Forms.Label();
            this.Destinatioe = new System.Windows.Forms.Label();
            this.PRICE = new System.Windows.Forms.Label();
            this.LBLPRICE = new System.Windows.Forms.Label();
            this.lablet = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser21
            // 
            this.webBrowser21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser21.Location = new System.Drawing.Point(0, 0);
            this.webBrowser21.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser21.Name = "webBrowser21";
            this.webBrowser21.Size = new System.Drawing.Size(1602, 683);
            this.webBrowser21.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1602, 683);
            this.webBrowser1.TabIndex = 1;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(802, 106);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(493, 197);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
            // 
            // webViewMap
            // 
            this.webViewMap.AllowExternalDrop = true;
            this.webViewMap.CreationProperties = null;
            this.webViewMap.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewMap.Location = new System.Drawing.Point(771, 12);
            this.webViewMap.Name = "webViewMap";
            this.webViewMap.Size = new System.Drawing.Size(776, 661);
            this.webViewMap.TabIndex = 5;
            this.webViewMap.ZoomFactor = 1D;
            // 
            // txtKilometers1
            // 
            this.txtKilometers1.Location = new System.Drawing.Point(63, 247);
            this.txtKilometers1.Name = "txtKilometers1";
            this.txtKilometers1.ReadOnly = true;
            this.txtKilometers1.Size = new System.Drawing.Size(139, 20);
            this.txtKilometers1.TabIndex = 6;
            this.txtKilometers1.TextChanged += new System.EventHandler(this.txtKilometers1_TextChanged);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(63, 399);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(139, 23);
            this.calculateButton.TabIndex = 8;
            this.calculateButton.Text = "Beregn Afstand";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // cmbVehicleType1
            // 
            this.cmbVehicleType1.FormattingEnabled = true;
            this.cmbVehicleType1.Location = new System.Drawing.Point(63, 302);
            this.cmbVehicleType1.Name = "cmbVehicleType1";
            this.cmbVehicleType1.Size = new System.Drawing.Size(139, 21);
            this.cmbVehicleType1.TabIndex = 9;
            // 
            // cmbVehicleType
            // 
            this.cmbVehicleType.AutoSize = true;
            this.cmbVehicleType.Location = new System.Drawing.Point(60, 286);
            this.cmbVehicleType.Name = "cmbVehicleType";
            this.cmbVehicleType.Size = new System.Drawing.Size(86, 13);
            this.cmbVehicleType.TabIndex = 10;
            this.cmbVehicleType.Text = "cmbVehicleType";
            // 
            // cmbTimeOfDay1
            // 
            this.cmbTimeOfDay1.FormattingEnabled = true;
            this.cmbTimeOfDay1.Location = new System.Drawing.Point(63, 350);
            this.cmbTimeOfDay1.Name = "cmbTimeOfDay1";
            this.cmbTimeOfDay1.Size = new System.Drawing.Size(139, 21);
            this.cmbTimeOfDay1.TabIndex = 11;
            // 
            // cmbTimeOfDay
            // 
            this.cmbTimeOfDay.AutoSize = true;
            this.cmbTimeOfDay.Location = new System.Drawing.Point(60, 334);
            this.cmbTimeOfDay.Name = "cmbTimeOfDay";
            this.cmbTimeOfDay.Size = new System.Drawing.Size(80, 13);
            this.cmbTimeOfDay.TabIndex = 12;
            this.cmbTimeOfDay.Text = "cmbTimeOfDay";
            // 
            // startLocation1
            // 
            this.startLocation1.Location = new System.Drawing.Point(257, 303);
            this.startLocation1.Name = "startLocation1";
            this.startLocation1.Size = new System.Drawing.Size(117, 20);
            this.startLocation1.TabIndex = 13;
            // 
            // Destination
            // 
            this.Destination.Location = new System.Drawing.Point(257, 350);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(117, 20);
            this.Destination.TabIndex = 14;
            // 
            // startLocation
            // 
            this.startLocation.AutoSize = true;
            this.startLocation.Location = new System.Drawing.Point(257, 284);
            this.startLocation.Name = "startLocation";
            this.startLocation.Size = new System.Drawing.Size(74, 13);
            this.startLocation.TabIndex = 15;
            this.startLocation.Text = "startLocation3";
            // 
            // Destinatioe
            // 
            this.Destinatioe.AutoSize = true;
            this.Destinatioe.Location = new System.Drawing.Point(257, 333);
            this.Destinatioe.Name = "Destinatioe";
            this.Destinatioe.Size = new System.Drawing.Size(71, 13);
            this.Destinatioe.TabIndex = 16;
            this.Destinatioe.Text = "txtDestination";
            // 
            // PRICE
            // 
            this.PRICE.AutoSize = true;
            this.PRICE.Location = new System.Drawing.Point(257, 399);
            this.PRICE.Name = "PRICE";
            this.PRICE.Size = new System.Drawing.Size(24, 13);
            this.PRICE.TabIndex = 17;
            this.PRICE.Text = "Pris";
            // 
            // LBLPRICE
            // 
            this.LBLPRICE.AutoSize = true;
            this.LBLPRICE.Location = new System.Drawing.Point(261, 428);
            this.LBLPRICE.Name = "LBLPRICE";
            this.LBLPRICE.Size = new System.Drawing.Size(22, 13);
            this.LBLPRICE.TabIndex = 18;
            this.LBLPRICE.Text = "KR";
            // 
            // lablet
            // 
            this.lablet.AutoSize = true;
            this.lablet.Location = new System.Drawing.Point(60, 221);
            this.lablet.Name = "lablet";
            this.lablet.Size = new System.Drawing.Size(29, 13);
            this.lablet.TabIndex = 19;
            this.lablet.Text = "KM: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 683);
            this.Controls.Add(this.lablet);
            this.Controls.Add(this.LBLPRICE);
            this.Controls.Add(this.PRICE);
            this.Controls.Add(this.Destinatioe);
            this.Controls.Add(this.startLocation);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.startLocation1);
            this.Controls.Add(this.cmbTimeOfDay);
            this.Controls.Add(this.cmbTimeOfDay1);
            this.Controls.Add(this.cmbVehicleType);
            this.Controls.Add(this.cmbVehicleType1);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.txtKilometers1);
            this.Controls.Add(this.webViewMap);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.webBrowser21);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser21;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMap;
        private System.Windows.Forms.TextBox txtKilometers1;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.ComboBox cmbVehicleType1;
        private System.Windows.Forms.Label cmbVehicleType;
        private System.Windows.Forms.ComboBox cmbTimeOfDay1;
        private System.Windows.Forms.Label cmbTimeOfDay;
        private System.Windows.Forms.TextBox startLocation1;
        private System.Windows.Forms.TextBox Destination;
        private System.Windows.Forms.Label startLocation;
        private System.Windows.Forms.Label Destinatioe;
        private System.Windows.Forms.Label PRICE;
        private System.Windows.Forms.Label LBLPRICE;
        private System.Windows.Forms.Label lablet;
    }

}

