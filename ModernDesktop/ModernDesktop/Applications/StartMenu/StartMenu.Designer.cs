﻿namespace ModernDesktop.Applications.StartMenu
{
	partial class StartMenu
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
			this.pnlContainerLeft = new System.Windows.Forms.Panel();
			this.lblAllPrograms = new ModernDesktop.Label();
			this.pnlRecentPrograms = new System.Windows.Forms.Panel();
			this.pnlContainerRight = new System.Windows.Forms.Panel();
			this.lblLogOff = new ModernDesktop.Label();
			this.lblRestart = new ModernDesktop.Label();
			this.lblShutdown = new ModernDesktop.Label();
			this.lblUserName = new ModernDesktop.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlContainerLeft.SuspendLayout();
			this.pnlContainerRight.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlContainerLeft
			// 
			this.pnlContainerLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlContainerLeft.BackColor = System.Drawing.Color.Transparent;
			this.pnlContainerLeft.Controls.Add(this.lblAllPrograms);
			this.pnlContainerLeft.Controls.Add(this.pnlRecentPrograms);
			this.pnlContainerLeft.Location = new System.Drawing.Point(0, 50);
			this.pnlContainerLeft.Name = "pnlContainerLeft";
			this.pnlContainerLeft.Size = new System.Drawing.Size(300, 550);
			this.pnlContainerLeft.TabIndex = 0;
			this.pnlContainerLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainerLeft_Paint);
			// 
			// lblAllPrograms
			// 
			this.lblAllPrograms.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblAllPrograms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAllPrograms.Location = new System.Drawing.Point(0, 520);
			this.lblAllPrograms.Name = "lblAllPrograms";
			this.lblAllPrograms.Size = new System.Drawing.Size(300, 30);
			this.lblAllPrograms.TabIndex = 1;
			this.lblAllPrograms.Text = "All Programs";
			this.lblAllPrograms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblAllPrograms.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.lblAllPrograms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralLabel_MouseDown);
			this.lblAllPrograms.MouseEnter += new System.EventHandler(this.GeneralLabel_MouseEnter);
			this.lblAllPrograms.MouseLeave += new System.EventHandler(this.GeneralLabel_MouseLeave);
			this.lblAllPrograms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralLAbel_MouseUp);
			// 
			// pnlRecentPrograms
			// 
			this.pnlRecentPrograms.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlRecentPrograms.Location = new System.Drawing.Point(0, 0);
			this.pnlRecentPrograms.Name = "pnlRecentPrograms";
			this.pnlRecentPrograms.Size = new System.Drawing.Size(300, 520);
			this.pnlRecentPrograms.TabIndex = 0;
			// 
			// pnlContainerRight
			// 
			this.pnlContainerRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlContainerRight.BackColor = System.Drawing.Color.Transparent;
			this.pnlContainerRight.Controls.Add(this.lblLogOff);
			this.pnlContainerRight.Controls.Add(this.lblRestart);
			this.pnlContainerRight.Controls.Add(this.lblShutdown);
			this.pnlContainerRight.Location = new System.Drawing.Point(300, 50);
			this.pnlContainerRight.Name = "pnlContainerRight";
			this.pnlContainerRight.Size = new System.Drawing.Size(200, 550);
			this.pnlContainerRight.TabIndex = 1;
			this.pnlContainerRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainerRight_Paint);
			// 
			// lblLogOff
			// 
			this.lblLogOff.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblLogOff.Location = new System.Drawing.Point(0, 460);
			this.lblLogOff.Name = "lblLogOff";
			this.lblLogOff.Size = new System.Drawing.Size(200, 30);
			this.lblLogOff.TabIndex = 3;
			this.lblLogOff.Text = "LOGOFF";
			this.lblLogOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLogOff.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.lblLogOff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblLogOff_MouseClick);
			this.lblLogOff.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralLabel_MouseDown);
			this.lblLogOff.MouseEnter += new System.EventHandler(this.GeneralLabel_MouseEnter);
			this.lblLogOff.MouseLeave += new System.EventHandler(this.GeneralLabel_MouseLeave);
			this.lblLogOff.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralLAbel_MouseUp);
			// 
			// lblRestart
			// 
			this.lblRestart.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblRestart.Location = new System.Drawing.Point(0, 490);
			this.lblRestart.Name = "lblRestart";
			this.lblRestart.Size = new System.Drawing.Size(200, 30);
			this.lblRestart.TabIndex = 2;
			this.lblRestart.Text = "RESTART";
			this.lblRestart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblRestart.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.lblRestart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblRestart_MouseClick);
			this.lblRestart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralLabel_MouseDown);
			this.lblRestart.MouseEnter += new System.EventHandler(this.GeneralLabel_MouseEnter);
			this.lblRestart.MouseLeave += new System.EventHandler(this.GeneralLabel_MouseLeave);
			this.lblRestart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralLAbel_MouseUp);
			// 
			// lblShutdown
			// 
			this.lblShutdown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblShutdown.Location = new System.Drawing.Point(0, 520);
			this.lblShutdown.Name = "lblShutdown";
			this.lblShutdown.Size = new System.Drawing.Size(200, 30);
			this.lblShutdown.TabIndex = 1;
			this.lblShutdown.Text = "SHUTDOWN";
			this.lblShutdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblShutdown.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.lblShutdown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblShutdown_MouseClick);
			this.lblShutdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GeneralLabel_MouseDown);
			this.lblShutdown.MouseEnter += new System.EventHandler(this.GeneralLabel_MouseEnter);
			this.lblShutdown.MouseLeave += new System.EventHandler(this.GeneralLabel_MouseLeave);
			this.lblShutdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralLAbel_MouseUp);
			// 
			// lblUserName
			// 
			this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserName.Location = new System.Drawing.Point(0, 0);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(200, 50);
			this.lblUserName.TabIndex = 1;
			this.lblUserName.Text = "Administrator";
			this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblUserName.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblUserName);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(500, 50);
			this.panel1.TabIndex = 2;
			// 
			// StartMenu
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(500, 600);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlContainerRight);
			this.Controls.Add(this.pnlContainerLeft);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 400);
			this.Name = "StartMenu";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "StartMenu";
			this.TopMost = true;
			this.pnlContainerLeft.ResumeLayout(false);
			this.pnlContainerRight.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlContainerLeft;
		private System.Windows.Forms.Panel pnlContainerRight;
		private ModernDesktop.Label lblUserName;
		private System.Windows.Forms.Panel panel1;
		private ModernDesktop.Label lblShutdown;
		private ModernDesktop.Label lblLogOff;
		private ModernDesktop.Label lblRestart;
		private ModernDesktop.Label lblAllPrograms;
		private System.Windows.Forms.Panel pnlRecentPrograms;
	}
}