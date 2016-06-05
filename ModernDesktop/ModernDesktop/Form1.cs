using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDesktop
{
	public partial class Desktop : Form
	{
		public Applications.Taskbar.Taskbar Taskbar { get; private set; }

		public Desktop(int i = 0)
		{
			InitializeComponent();

			Size = Screen.PrimaryScreen.Bounds.Size;
			Location = Screen.PrimaryScreen.Bounds.Location;
			BackgroundImage = Properties.Settings.Default.Desktop_WallpaperLocation.LoadImage(ClientSize);

			SendToBack();

			Taskbar = new Applications.Taskbar.Taskbar();
			Taskbar.Show();

			if (i == 0)
			{
				foreach (Screen scr in Screen.AllScreens)
				{
					Extensions.SetWorkspace(new Rectangle(scr.Bounds.Left, scr.Bounds.Top, scr.Bounds.Right, scr.Bounds.Bottom - (scr.Bounds.Location == default(Point) ? Taskbar.Height : 0)));
				}
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams baseParams = base.CreateParams;

				const int WS_EX_NOACTIVATE = 0x08000000;
				const int WS_EX_TOOLWINDOW = 0x00000080;
				baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);

				return baseParams;
			}
		}
	}
}
