using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ModernDesktop.Applications.Taskbar
{
	public partial class Taskbar : Form
	{
		private BackgroundWorker TimeKeeper;

		public Taskbar()
		{
			InitializeComponent();

			MinimumSize = MaximumSize = Size = new Size(Screen.PrimaryScreen.Bounds.Width, 35);
			Location = new Point(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Height - Height);

			this.SetTopMost();

			TimeKeeper = new BackgroundWorker();
			TimeKeeper.DoWork += TimeKeeper_DoWork;
			TimeKeeper.RunWorkerAsync();

			applicationWatcher1.Run();
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
	}
}
