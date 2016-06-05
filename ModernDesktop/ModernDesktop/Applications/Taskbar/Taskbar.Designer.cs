namespace ModernDesktop.Applications.Taskbar
{
	partial class Taskbar
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
			this.components = new System.ComponentModel.Container();
			this.lblTimeDate = new System.Windows.Forms.Label();
			this.applicationWatcher1 = new ModernDesktop.Components.Taskbar.ApplicationWatcher(this.components);
			this.SuspendLayout();
			// 
			// lblTimeDate
			// 
			this.lblTimeDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblTimeDate.Location = new System.Drawing.Point(1845, 0);
			this.lblTimeDate.Name = "lblTimeDate";
			this.lblTimeDate.Size = new System.Drawing.Size(75, 35);
			this.lblTimeDate.TabIndex = 0;
			this.lblTimeDate.Text = "12:00 PM\r\n1/01/1970";
			this.lblTimeDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Taskbar
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(1920, 35);
			this.Controls.Add(this.lblTimeDate);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Taskbar";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Taskbar";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblTimeDate;
		private Components.Taskbar.ApplicationWatcher applicationWatcher1;
	}
}