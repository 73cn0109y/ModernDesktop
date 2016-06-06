using System;
using System.Drawing;
using System.Windows.Forms;

using ModernDesktop.Misc;

namespace ModernDesktop.Controls.Taskbar
{
	public class TaskbarItem : Panel
	{
		public ProcessInfo ProcessInformation { get { return processInformation; } set { processInformation = value; UpdateProcessInformation(); } }

		private PopupPreview ProcessPreview;
		private ProcessInfo processInformation;

		public TaskbarItem()
		{
			BackColor = Color.Transparent;
			BackgroundImageLayout = ImageLayout.Center;

			ProcessPreview = new PopupPreview();
		}

		public void HidePreview()
		{
			ProcessPreview?.Hide();
		}

		private void UpdateProcessInformation()
		{
			ProcessPreview.TargetWindow = ProcessInformation;
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				IntPtr handle = ProcessInformation.MainHandle;
				bool top = Extensions.GetTopWindow() == handle;

				Extensions.WindowState state = handle.GetWindowState();
				switch (state)
				{
					case Extensions.WindowState.Normal:
						if (top)
							handle.Minimize();
						else
							handle.BringToFromt();
						break;
					case Extensions.WindowState.Maximized:
						if (top)
							handle.Restore(true);
						else
							handle.BringToFromt();
						break;
					case Extensions.WindowState.Minimized:
						handle.Restore();
						break;
				}
			}

			base.OnMouseClick(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			BackColor = Color.FromArgb(150, 50, 50, 50);

			int X = Location.X + ((ProcessPreview.Width / 2) - (Width / 2));

			Point scrPoint = PointToScreen(Location);
			scrPoint.Y -= ProcessPreview.Height;
			scrPoint.X -= (scrPoint.X - X < 0 ? Location.X + 50 : X);
			ProcessPreview.Location = scrPoint;
			ProcessPreview.BringToFront();
			ProcessPreview.Show();

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
				return;

			ProcessPreview?.Hide();

			BackColor = Color.Transparent;

			base.OnMouseLeave(e);
		}
	}
}
