﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialAPI.Extensions.General;
using MaterialAPI.Extensions.Windows;

namespace ModernDesktop
{
	public partial class Desktop : MaterialAPI.Form
	{
		public Applications.Taskbar Taskbar { get; private set; }
		public Widgets.Weather WeatherWidget { get; set; }

		public Desktop(int i = 0)
		{
			InitializeComponent();

			BackgroundImage = Properties.Settings.Default.Desktop_WallpaperLocation.LoadImage(ClientSize);
			Name = "Desktop" + i;

			SendToBack();

			if (i == 0)
			{
				Taskbar = new Applications.Taskbar();
				Taskbar.Show();

				Size = Screen.PrimaryScreen.Bounds.Size;
				Location = Screen.PrimaryScreen.Bounds.Location;

				int c = 1;
				foreach (Screen scr in Screen.AllScreens)
				{
					new Rectangle(scr.Bounds.Left, scr.Bounds.Top, scr.Bounds.Right - scr.Bounds.Left, scr.Bounds.Bottom - (scr.Bounds.Location == default(Point) ? Taskbar.Height : 0) - scr.Bounds.Top).SetWorkspace();

					if (scr == Screen.PrimaryScreen)
						continue;

					Desktop desktop = new Desktop(c++);
					desktop.Location = scr.Bounds.Location;
					desktop.Size = scr.Bounds.Size;
					desktop.Show();
				}

				Tester();

				InitializeGadgets();
			}

			Handle.BottomMost();
		}

		public void SetBackground(string location)
		{
			Bitmap img = Image.FromFile(location) as Bitmap;
			img?.OptimizeImage();

			if (img == null)
				return;

			Properties.Settings.Default.Desktop_WallpaperLocation = location;
			Properties.Settings.Default.Save();

			BackgroundImage?.Dispose();
			BackgroundImage = img;
		}

		private void Tester()
		{
			Settings.Form1 settings = new Settings.Form1(new Dictionary<string, string>() { { "WallpaperDirectory", System.IO.Path.GetDirectoryName(Properties.Settings.Default.Desktop_WallpaperLocation) } });
			settings.PersonalizeWallpaperChanged += (se, ev) => { SetBackground(((string)se)); };
			settings.Show();
			settings.BringToFront();
		}

		private void InitializeGadgets()
		{
			WeatherWidget = new Widgets.Weather();
			WeatherWidget.Location = new Point(Right - WeatherWidget.Width - 15, Top + 15);
			WeatherWidget.Show();

			WeatherWidget.UpdateCurrent();
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0007)
				Handle.BottomMost();

			base.WndProc(ref m);
		}
	}
}
