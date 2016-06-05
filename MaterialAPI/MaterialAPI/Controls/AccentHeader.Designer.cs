using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialAPI.Controls
{
	public partial class AccentHeader
	{
		public void InitializeComponent()
		{
			this.Title = new System.Windows.Forms.Label();
			this.HeaderBar = new System.Windows.Forms.Panel();
			this.MinimizeButton = new System.Windows.Forms.PictureBox();
			this.StateButton = new System.Windows.Forms.PictureBox();
			this.CloseButton = new System.Windows.Forms.PictureBox();
			this.SearchBar = new System.Windows.Forms.Panel();
			this.SearchButton = new System.Windows.Forms.PictureBox();
			this.RefreshButton = new System.Windows.Forms.PictureBox();
			this.OptionsButton = new System.Windows.Forms.PictureBox();
			this.HeaderBar.SuspendLayout();
			//
			// Title
			//
			this.Title.AutoSize = true;
			this.Title.Location = new System.Drawing.Point(0, 40);
			this.Title.Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Regular);
			this.Title.Text = "Youtube";
			// 
			// HeaderBar
			// 
			this.HeaderBar.BackColor = System.Drawing.Color.Transparent;
			this.HeaderBar.Controls.Add(this.MinimizeButton);
			this.HeaderBar.Controls.Add(this.StateButton);
			this.HeaderBar.Controls.Add(this.CloseButton);
			this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.HeaderBar.Location = new System.Drawing.Point(0, 0);
			this.HeaderBar.Name = "HeaderBar";
			this.HeaderBar.Size = new System.Drawing.Size(800, 40);
			this.HeaderBar.TabIndex = 0;
			this.HeaderBar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(HeaderBar_MouseDoubleClick);
			// 
			// MinimizeButton
			// 
			this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MinimizeButton.BackColor = System.Drawing.Color.Transparent;
			this.MinimizeButton.Location = new System.Drawing.Point(0, 0);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.Size = new System.Drawing.Size(30, 40);
			this.MinimizeButton.TabIndex = 2;
			this.MinimizeButton.TabStop = false;
			this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
			this.MinimizeButton.Image = MaterialAPI.Properties.Resources.Minimize;
			this.MinimizeButton.SizeMode = PictureBoxSizeMode.CenterImage;
			// 
			// StateButton
			// 
			this.StateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.StateButton.BackColor = System.Drawing.Color.Transparent;
			this.StateButton.Location = new System.Drawing.Point(0, 0);
			this.StateButton.Name = "StateButton";
			this.StateButton.Size = new System.Drawing.Size(30, 40);
			this.StateButton.TabIndex = 1;
			this.StateButton.TabStop = false;
			this.StateButton.Click += new System.EventHandler(this.StateButton_Click);
			this.StateButton.Image = MaterialAPI.Properties.Resources.Maximize;
			this.StateButton.SizeMode = PictureBoxSizeMode.CenterImage;
			// 
			// CloseButton
			// 
			this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseButton.BackColor = System.Drawing.Color.Transparent;
			this.CloseButton.Location = new System.Drawing.Point(0, 0);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(30, 40);
			this.CloseButton.TabIndex = 0;
			this.CloseButton.TabStop = false;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			this.CloseButton.Image = MaterialAPI.Properties.Resources.Close;
			this.CloseButton.SizeMode = PictureBoxSizeMode.CenterImage;
			//
			// SearchBar
			//
			this.SearchBar.BackColor = System.Drawing.Color.FromArgb(150, 255, 255, 255);
			this.SearchBar.Controls.Add(this.SearchButton);
			this.SearchBar.Location = new System.Drawing.Point(600, 40);
			this.SearchBar.Name = "SearchBar";
			this.SearchBar.Size = new System.Drawing.Size(200, 30);
			this.SearchBar.TabIndex = 1;
			//
			// SearchButton
			//
			this.SearchButton.BackColor = System.Drawing.Color.FromArgb(50, Color.Red);
			this.SearchButton.Location = new System.Drawing.Point(170, 0);
			this.SearchButton.Size = new System.Drawing.Size(30, 30);
			this.SearchButton.Click += new System.EventHandler(SearchButton_MouseClick);
			this.SearchButton.TabIndex = 0;
			//
			// RefreshButton
			//
			this.RefreshButton.Size = new System.Drawing.Size(30, 30);
			this.RefreshButton.Location = new System.Drawing.Point(0, 0);
			this.RefreshButton.Image = MaterialAPI.Properties.Resources.Refresh;
			this.RefreshButton.SizeMode = PictureBoxSizeMode.CenterImage;
			//
			// OptionsButton
			//
			this.OptionsButton.Size = new System.Drawing.Size(30, 30);
			this.OptionsButton.Location = new System.Drawing.Point(0, 0);
			this.OptionsButton.Image = MaterialAPI.Properties.Resources.Options;
			this.OptionsButton.SizeMode = PictureBoxSizeMode.CenterImage;
			//
			// AccentHeader
			//
			this.Controls.Add(this.HeaderBar);
			this.Controls.Add(this.Title);
			this.Controls.Add(this.SearchBar);
			this.Controls.Add(this.RefreshButton);
			this.Controls.Add(this.OptionsButton);
		}

		internal Panel HeaderBar;
		private PictureBox CloseButton;
		private PictureBox MinimizeButton;
		private PictureBox StateButton;
		private Label Title;
		private Panel SearchBar;
		private PictureBox SearchButton;
		private PictureBox RefreshButton;
		private PictureBox OptionsButton;
	}
}
