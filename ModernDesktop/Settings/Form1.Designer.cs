namespace Settings
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
			this.components = new System.ComponentModel.Container();
			this.SideBar = new System.Windows.Forms.Panel();
			this.lblUserAccounts = new MaterialAPI.Label();
			this.lblPersonalize = new MaterialAPI.Label();
			this.lblSystem = new MaterialAPI.Label();
			this.pageSystem = new System.Windows.Forms.Panel();
			this.pagePersonalize = new System.Windows.Forms.Panel();
			this.PersonalizeWallpaperContainer = new System.Windows.Forms.Panel();
			this.btnPersonalizeWallpaperCancel = new System.Windows.Forms.Button();
			this.btnPersonalizeWallpaperApply = new System.Windows.Forms.Button();
			this.PersonalizeTabs = new System.Windows.Forms.Panel();
			this.PersonalizeWallpaper = new System.Windows.Forms.Label();
			this.pageUserAccounts = new System.Windows.Forms.Panel();
			this.btnPersonalizeWallpaperBrowse = new System.Windows.Forms.Button();
			this.PersonalizeWallpaperList = new System.Windows.Forms.ListView();
			this.PersonalizeWallpaperImageList = new System.Windows.Forms.ImageList(this.components);
			this.SideBar.SuspendLayout();
			this.pagePersonalize.SuspendLayout();
			this.PersonalizeWallpaperContainer.SuspendLayout();
			this.PersonalizeTabs.SuspendLayout();
			this.SuspendLayout();
			// 
			// SideBar
			// 
			this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.SideBar.Controls.Add(this.lblUserAccounts);
			this.SideBar.Controls.Add(this.lblPersonalize);
			this.SideBar.Controls.Add(this.lblSystem);
			this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
			this.SideBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SideBar.ForeColor = System.Drawing.Color.White;
			this.SideBar.Location = new System.Drawing.Point(0, 40);
			this.SideBar.Name = "SideBar";
			this.SideBar.Size = new System.Drawing.Size(200, 560);
			this.SideBar.TabIndex = 1;
			// 
			// lblUserAccounts
			// 
			this.lblUserAccounts.BackColor = System.Drawing.Color.Transparent;
			this.lblUserAccounts.DefaultColor = System.Drawing.Color.Transparent;
			this.lblUserAccounts.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblUserAccounts.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lblUserAccounts.Location = new System.Drawing.Point(0, 60);
			this.lblUserAccounts.Name = "lblUserAccounts";
			this.lblUserAccounts.PassThroughClick = false;
			this.lblUserAccounts.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lblUserAccounts.Size = new System.Drawing.Size(200, 30);
			this.lblUserAccounts.TabIndex = 2;
			this.lblUserAccounts.Text = "User Accounts";
			this.lblUserAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblUserAccounts.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.lblUserAccounts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SwitchPage);
			// 
			// lblPersonalize
			// 
			this.lblPersonalize.BackColor = System.Drawing.Color.Transparent;
			this.lblPersonalize.DefaultColor = System.Drawing.Color.Transparent;
			this.lblPersonalize.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblPersonalize.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lblPersonalize.Location = new System.Drawing.Point(0, 30);
			this.lblPersonalize.Name = "lblPersonalize";
			this.lblPersonalize.PassThroughClick = false;
			this.lblPersonalize.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lblPersonalize.Size = new System.Drawing.Size(200, 30);
			this.lblPersonalize.TabIndex = 1;
			this.lblPersonalize.Text = "Personalize";
			this.lblPersonalize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblPersonalize.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.lblPersonalize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SwitchPage);
			// 
			// lblSystem
			// 
			this.lblSystem.BackColor = System.Drawing.Color.Transparent;
			this.lblSystem.DefaultColor = System.Drawing.Color.Transparent;
			this.lblSystem.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblSystem.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lblSystem.Location = new System.Drawing.Point(0, 0);
			this.lblSystem.Name = "lblSystem";
			this.lblSystem.PassThroughClick = false;
			this.lblSystem.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lblSystem.Size = new System.Drawing.Size(200, 30);
			this.lblSystem.TabIndex = 0;
			this.lblSystem.Text = "System";
			this.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblSystem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			this.lblSystem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SwitchPage);
			// 
			// pageSystem
			// 
			this.pageSystem.BackColor = System.Drawing.Color.White;
			this.pageSystem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pageSystem.Location = new System.Drawing.Point(200, 40);
			this.pageSystem.Name = "pageSystem";
			this.pageSystem.Size = new System.Drawing.Size(600, 560);
			this.pageSystem.TabIndex = 2;
			// 
			// pagePersonalize
			// 
			this.pagePersonalize.BackColor = System.Drawing.Color.White;
			this.pagePersonalize.Controls.Add(this.PersonalizeWallpaperContainer);
			this.pagePersonalize.Controls.Add(this.PersonalizeTabs);
			this.pagePersonalize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pagePersonalize.Location = new System.Drawing.Point(200, 40);
			this.pagePersonalize.Name = "pagePersonalize";
			this.pagePersonalize.Size = new System.Drawing.Size(600, 560);
			this.pagePersonalize.TabIndex = 3;
			// 
			// PersonalizeWallpaperContainer
			// 
			this.PersonalizeWallpaperContainer.Controls.Add(this.PersonalizeWallpaperList);
			this.PersonalizeWallpaperContainer.Controls.Add(this.btnPersonalizeWallpaperBrowse);
			this.PersonalizeWallpaperContainer.Controls.Add(this.btnPersonalizeWallpaperCancel);
			this.PersonalizeWallpaperContainer.Controls.Add(this.btnPersonalizeWallpaperApply);
			this.PersonalizeWallpaperContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PersonalizeWallpaperContainer.Location = new System.Drawing.Point(0, 50);
			this.PersonalizeWallpaperContainer.Name = "PersonalizeWallpaperContainer";
			this.PersonalizeWallpaperContainer.Size = new System.Drawing.Size(600, 510);
			this.PersonalizeWallpaperContainer.TabIndex = 1;
			this.PersonalizeWallpaperContainer.VisibleChanged += new System.EventHandler(this.PersonalizeWallpaperContainer_VisibleChanged);
			// 
			// btnPersonalizeWallpaperCancel
			// 
			this.btnPersonalizeWallpaperCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPersonalizeWallpaperCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.btnPersonalizeWallpaperCancel.FlatAppearance.BorderSize = 0;
			this.btnPersonalizeWallpaperCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPersonalizeWallpaperCancel.ForeColor = System.Drawing.Color.White;
			this.btnPersonalizeWallpaperCancel.Location = new System.Drawing.Point(380, 470);
			this.btnPersonalizeWallpaperCancel.Name = "btnPersonalizeWallpaperCancel";
			this.btnPersonalizeWallpaperCancel.Size = new System.Drawing.Size(100, 30);
			this.btnPersonalizeWallpaperCancel.TabIndex = 2;
			this.btnPersonalizeWallpaperCancel.Text = "Revert";
			this.btnPersonalizeWallpaperCancel.UseVisualStyleBackColor = false;
			this.btnPersonalizeWallpaperCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPersonalizeWallpaperCancel_MouseClick);
			// 
			// btnPersonalizeWallpaperApply
			// 
			this.btnPersonalizeWallpaperApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPersonalizeWallpaperApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.btnPersonalizeWallpaperApply.FlatAppearance.BorderSize = 0;
			this.btnPersonalizeWallpaperApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPersonalizeWallpaperApply.ForeColor = System.Drawing.Color.White;
			this.btnPersonalizeWallpaperApply.Location = new System.Drawing.Point(490, 470);
			this.btnPersonalizeWallpaperApply.Name = "btnPersonalizeWallpaperApply";
			this.btnPersonalizeWallpaperApply.Size = new System.Drawing.Size(100, 30);
			this.btnPersonalizeWallpaperApply.TabIndex = 1;
			this.btnPersonalizeWallpaperApply.Text = "Apply";
			this.btnPersonalizeWallpaperApply.UseVisualStyleBackColor = false;
			this.btnPersonalizeWallpaperApply.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPersonalizeWallpaperApply_MouseClick);
			// 
			// PersonalizeTabs
			// 
			this.PersonalizeTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.PersonalizeTabs.Controls.Add(this.PersonalizeWallpaper);
			this.PersonalizeTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this.PersonalizeTabs.Location = new System.Drawing.Point(0, 0);
			this.PersonalizeTabs.Name = "PersonalizeTabs";
			this.PersonalizeTabs.Size = new System.Drawing.Size(600, 50);
			this.PersonalizeTabs.TabIndex = 0;
			// 
			// PersonalizeWallpaper
			// 
			this.PersonalizeWallpaper.Dock = System.Windows.Forms.DockStyle.Left;
			this.PersonalizeWallpaper.ForeColor = System.Drawing.Color.White;
			this.PersonalizeWallpaper.Location = new System.Drawing.Point(0, 0);
			this.PersonalizeWallpaper.Name = "PersonalizeWallpaper";
			this.PersonalizeWallpaper.Size = new System.Drawing.Size(150, 50);
			this.PersonalizeWallpaper.TabIndex = 0;
			this.PersonalizeWallpaper.Text = "Wallpaper";
			this.PersonalizeWallpaper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.PersonalizeWallpaper.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PersonalizeInternalTab_MouseClick);
			// 
			// pageUserAccounts
			// 
			this.pageUserAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pageUserAccounts.Location = new System.Drawing.Point(200, 40);
			this.pageUserAccounts.Name = "pageUserAccounts";
			this.pageUserAccounts.Size = new System.Drawing.Size(600, 560);
			this.pageUserAccounts.TabIndex = 4;
			// 
			// btnPersonalizeWallpaperBrowse
			// 
			this.btnPersonalizeWallpaperBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPersonalizeWallpaperBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.btnPersonalizeWallpaperBrowse.FlatAppearance.BorderSize = 0;
			this.btnPersonalizeWallpaperBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPersonalizeWallpaperBrowse.ForeColor = System.Drawing.Color.White;
			this.btnPersonalizeWallpaperBrowse.Location = new System.Drawing.Point(270, 470);
			this.btnPersonalizeWallpaperBrowse.Name = "btnPersonalizeWallpaperBrowse";
			this.btnPersonalizeWallpaperBrowse.Size = new System.Drawing.Size(100, 30);
			this.btnPersonalizeWallpaperBrowse.TabIndex = 3;
			this.btnPersonalizeWallpaperBrowse.Text = "Browse";
			this.btnPersonalizeWallpaperBrowse.UseVisualStyleBackColor = false;
			this.btnPersonalizeWallpaperBrowse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPersonalizeWallpaperBrowse_MouseClick);
			// 
			// PersonalizeWallpaperList
			// 
			this.PersonalizeWallpaperList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PersonalizeWallpaperList.LargeImageList = this.PersonalizeWallpaperImageList;
			this.PersonalizeWallpaperList.Location = new System.Drawing.Point(10, 10);
			this.PersonalizeWallpaperList.Name = "PersonalizeWallpaperList";
			this.PersonalizeWallpaperList.Size = new System.Drawing.Size(580, 450);
			this.PersonalizeWallpaperList.TabIndex = 0;
			this.PersonalizeWallpaperList.UseCompatibleStateImageBehavior = false;
			// 
			// PersonalizeWallpaperImageList
			// 
			this.PersonalizeWallpaperImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.PersonalizeWallpaperImageList.ImageSize = new System.Drawing.Size(150, 75);
			this.PersonalizeWallpaperImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.pagePersonalize);
			this.Controls.Add(this.pageSystem);
			this.Controls.Add(this.pageUserAccounts);
			this.Controls.Add(this.SideBar);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "Settings";
			this.Controls.SetChildIndex(this.SideBar, 0);
			this.Controls.SetChildIndex(this.pageUserAccounts, 0);
			this.Controls.SetChildIndex(this.pageSystem, 0);
			this.Controls.SetChildIndex(this.pagePersonalize, 0);
			this.SideBar.ResumeLayout(false);
			this.pagePersonalize.ResumeLayout(false);
			this.PersonalizeWallpaperContainer.ResumeLayout(false);
			this.PersonalizeTabs.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel SideBar;
		private MaterialAPI.Label lblSystem;
		private MaterialAPI.Label lblUserAccounts;
		private MaterialAPI.Label lblPersonalize;
		private System.Windows.Forms.Panel pageSystem;
		private System.Windows.Forms.Panel pagePersonalize;
		private System.Windows.Forms.Panel pageUserAccounts;
		private System.Windows.Forms.Panel PersonalizeTabs;
		private System.Windows.Forms.Label PersonalizeWallpaper;
		private System.Windows.Forms.Panel PersonalizeWallpaperContainer;
		private System.Windows.Forms.Button btnPersonalizeWallpaperCancel;
		private System.Windows.Forms.Button btnPersonalizeWallpaperApply;
		private System.Windows.Forms.Button btnPersonalizeWallpaperBrowse;
		private System.Windows.Forms.ListView PersonalizeWallpaperList;
		private System.Windows.Forms.ImageList PersonalizeWallpaperImageList;
	}
}

