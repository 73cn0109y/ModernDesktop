namespace ModernDesktop.Widgets
{
	partial class Weather
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
			this.picCurrentCondition = new System.Windows.Forms.PictureBox();
			this.lblCurrentLocation = new System.Windows.Forms.Label();
			this.lblLastUpdated = new System.Windows.Forms.Label();
			this.lblCurrentTemp = new System.Windows.Forms.Label();
			this.lblMinMaxHum = new System.Windows.Forms.Label();
			this.lblMinMaxHumValues = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picCurrentCondition)).BeginInit();
			this.SuspendLayout();
			// 
			// picCurrentCondition
			// 
			this.picCurrentCondition.Image = global::ModernDesktop.Properties.Resources.Widget_Weather_Sunny;
			this.picCurrentCondition.Location = new System.Drawing.Point(15, 25);
			this.picCurrentCondition.Name = "picCurrentCondition";
			this.picCurrentCondition.Size = new System.Drawing.Size(50, 50);
			this.picCurrentCondition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCurrentCondition.TabIndex = 0;
			this.picCurrentCondition.TabStop = false;
			// 
			// lblCurrentLocation
			// 
			this.lblCurrentLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCurrentLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrentLocation.Location = new System.Drawing.Point(160, 150);
			this.lblCurrentLocation.Name = "lblCurrentLocation";
			this.lblCurrentLocation.Size = new System.Drawing.Size(126, 15);
			this.lblCurrentLocation.TabIndex = 1;
			this.lblCurrentLocation.Text = "Location Unknown";
			this.lblCurrentLocation.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lblLastUpdated
			// 
			this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLastUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastUpdated.Location = new System.Drawing.Point(15, 150);
			this.lblLastUpdated.Name = "lblLastUpdated";
			this.lblLastUpdated.Size = new System.Drawing.Size(126, 15);
			this.lblLastUpdated.TabIndex = 2;
			this.lblLastUpdated.Text = "12:00PM 01/01/1970";
			this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblCurrentTemp
			// 
			this.lblCurrentTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCurrentTemp.Location = new System.Drawing.Point(155, 15);
			this.lblCurrentTemp.Name = "lblCurrentTemp";
			this.lblCurrentTemp.Size = new System.Drawing.Size(131, 26);
			this.lblCurrentTemp.TabIndex = 3;
			this.lblCurrentTemp.Text = "Updating...";
			this.lblCurrentTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMinMaxHum
			// 
			this.lblMinMaxHum.AutoSize = true;
			this.lblMinMaxHum.Location = new System.Drawing.Point(186, 41);
			this.lblMinMaxHum.Name = "lblMinMaxHum";
			this.lblMinMaxHum.Size = new System.Drawing.Size(50, 39);
			this.lblMinMaxHum.TabIndex = 4;
			this.lblMinMaxHum.Text = "Min:\r\nMax:\r\nHumidity:";
			this.lblMinMaxHum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMinMaxHumValues
			// 
			this.lblMinMaxHumValues.Location = new System.Drawing.Point(242, 41);
			this.lblMinMaxHumValues.Name = "lblMinMaxHumValues";
			this.lblMinMaxHumValues.Size = new System.Drawing.Size(44, 39);
			this.lblMinMaxHumValues.TabIndex = 5;
			this.lblMinMaxHumValues.Text = "9999°K\r\n9999°K\r\n100%";
			this.lblMinMaxHumValues.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Weather
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(300, 175);
			this.Controls.Add(this.lblMinMaxHumValues);
			this.Controls.Add(this.lblMinMaxHum);
			this.Controls.Add(this.lblCurrentTemp);
			this.Controls.Add(this.lblLastUpdated);
			this.Controls.Add(this.lblCurrentLocation);
			this.Controls.Add(this.picCurrentCondition);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Weather";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ModernDesktop - Weather";
			((System.ComponentModel.ISupportInitialize)(this.picCurrentCondition)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picCurrentCondition;
		private System.Windows.Forms.Label lblCurrentLocation;
		private System.Windows.Forms.Label lblLastUpdated;
		private System.Windows.Forms.Label lblCurrentTemp;
		private System.Windows.Forms.Label lblMinMaxHum;
		private System.Windows.Forms.Label lblMinMaxHumValues;
	}
}
