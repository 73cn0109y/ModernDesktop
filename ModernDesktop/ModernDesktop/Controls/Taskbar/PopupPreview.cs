using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ModernDesktop.Misc;
using MaterialAPI.Extensions.General;
using MaterialAPI.Extensions.Windows;
using WindowExtensions = MaterialAPI.Extensions.Windows.Extensions;

namespace ModernDesktop.Controls.Taskbar
{
	public class PopupPreview : MaterialAPI.Form
	{
		private const int PREVIEW_WIDTH = 200;
		private const int PREVIEW_HEIGHT = 100;

		public ProcessInfo TargetWindow { get { return targetWindow; }set { targetWindow = value; UpdateTargetWindow(); } }

		private System.Timers.Timer UpdatePreview;
		private ProcessInfo targetWindow = null;
		private MaterialAPI.PictureBox PreviewBox;

		public PopupPreview()
		{
			ShowHeader = false;
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.Manual;
			Size = new Size(PREVIEW_WIDTH, PREVIEW_HEIGHT);
			TopMost = true;
			BackColor = Color.Black;

			Initialize();

			UpdatePreview = new System.Timers.Timer();
			UpdatePreview.Interval = 1000 / 20;
			UpdatePreview.AutoReset = true;
			UpdatePreview.Elapsed += UpdatePreview_Elapsed;
			UpdatePreview.Start();
		}

		private void Initialize()
		{
			PreviewBox = new MaterialAPI.PictureBox();
			PreviewBox.Size = new Size(PREVIEW_WIDTH, PREVIEW_HEIGHT);
			PreviewBox.Location = new Point(0, 0);
			PreviewBox.SizeMode = PictureBoxSizeMode.StretchImage;
			PreviewBox.BackColor = Color.Black;

			MaterialAPI.Label l = new MaterialAPI.Label();
			l.AutoSize = false;
			l.AutoEllipsis = true;
			l.UseCompatibleTextRendering = true;
			l.Size = new Size(PREVIEW_WIDTH, 25);
			l.Location = PreviewBox.Location;
			l.TextAlign = ContentAlignment.MiddleCenter;
			l.BackColor = Color.FromArgb(200, 30, 30, 30);
			l.ForeColor = Color.White;
			l.Font = new Font("Segoe UI", 12, FontStyle.Regular);
			l.Name = "PopupTitle";

			PreviewBox.Controls.Add(l);
			Controls.Add(PreviewBox);
		}

		private void UpdateTargetWindow()
		{
			PreviewBox.Name = TargetWindow.MainHandle.ToString();
			PreviewBox.Controls["PopupTitle"].Text = TargetWindow.Title;
		}

		private void UpdatePreview_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if (TargetWindow == null || !Visible)
				return;

			if (TargetWindow.MainHandle == IntPtr.Zero)
				return;

			if (TargetWindow.MainHandle.GetWindowState() == WindowExtensions.WindowState.Minimized)
				return;

			Bitmap img = WindowCaptureUtility.CaptureWindow(TargetWindow.MainHandle) as Bitmap;
			img.OptimizeImage();

			PreviewBox.Image?.Dispose();
			PreviewBox.Image = img;
		}
	}
}
