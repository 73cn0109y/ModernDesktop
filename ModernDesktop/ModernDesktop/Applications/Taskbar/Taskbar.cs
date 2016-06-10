using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using ModernDesktop.Misc;
using MaterialAPI.Extensions.Windows;

namespace ModernDesktop.Applications
{
	public partial class Taskbar : MaterialAPI.Form
	{
		public StartMenu StartMenu { get; private set; }

		private BackgroundWorker TimeKeeper;

		public Taskbar()
		{
			InitializeComponent();

			MinimumSize = MaximumSize = Size = new Size(Screen.PrimaryScreen.Bounds.Width, 40);
			Location = new Point(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Height - Height);

			this.SetTopMost();

			StartMenu = new StartMenu();
			StartMenu.Location = new Point(Location.X, Location.Y - StartMenu.Height);

			TimeKeeper = new BackgroundWorker();
			TimeKeeper.DoWork += TimeKeeper_DoWork;
			TimeKeeper.RunWorkerAsync();

			applicationWatcher1.ApplicationLaunched += (se, ev) =>
			{
				//StartMenu.ProgramLaunched(((ProcessInfo)se).Location);
			};
			applicationWatcher1.Run(this);
		}

		private void TimeKeeper_DoWork(object sender, DoWorkEventArgs e)
		{
			while(true)
			{
				Invoke(new MethodInvoker(() =>
				{
					DateTime Now = DateTime.Now;
					lblTimeDate.Text = string.Format("{0}:{1} {2}\r\n{3}/{4}/{5}", (Now.Hour == 0 ? 12 : (Now.Hour % 12 == 0 ? 12 : Now.Hour % 12)), Now.Minute.ToString("D2"), (Now.Hour >= 12 ? "PM" : "AM"), Now.Day, Now.Month.ToString("D2"), Now.Year);
				}));

				System.Threading.Thread.Sleep(100);
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

		protected override void OnDeactivate(EventArgs e)
		{
			applicationWatcher1.HidePreview();

			base.OnDeactivate(e);
		}

		private void picStartButton_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			StartMenu.Show();
		}
	}
}
