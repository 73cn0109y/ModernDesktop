using System;
using System.Drawing;
using System.Windows.Forms;

using MaterialAPI.Extensions.General;

namespace MaterialAPI
{
	public partial class Form : System.Windows.Forms.Form
	{
		public new string Text { get { return base.Text; } set { Title.Text = base.Text = value; } }
		public bool ShowHeader { get { return showHeader; } set { showHeader = value; UpdateHeaderVisible(); } }

		private bool showHeader = true;
		private bool canDragWindow = false;
		private Point dragStartPosition = new Point(-1, -1);

		public Form()
		{
			InitializeComponent();

			if (Header != null)
				Header.Visible = ShowHeader;
		}

		public new void SendToBack()
		{
			Extensions.Windows.Extensions.SendToBack(this);
		}

		private void UpdateHeaderVisible()
		{
			if (Header != null)
				Header.Visible = ShowHeader;
		}

		private void Header_MouseDown(object sender, MouseEventArgs e)
		{
			dragStartPosition = e.Location;
		}

		private void Header_MouseUp(object sender, MouseEventArgs e)
		{
			if (Cursor.Position.AtTopOfScreen() && WindowState != FormWindowState.Maximized)
				WindowState = FormWindowState.Maximized;

			dragStartPosition = new Point(-1, -1);
			canDragWindow = false;
		}

		private void Header_MouseMove(object sender, MouseEventArgs e)
		{
			if (dragStartPosition != new Point(-1, -1) && !canDragWindow)
				canDragWindow = true;

			else if(canDragWindow)
			{
				Point screenPoint = PointToScreen(e.Location);

				if (WindowState == FormWindowState.Maximized && screenPoint.Y > 10)
				{
					double maxPercent = e.X / (double)Width * 100;
					WindowState = FormWindowState.Normal;
					double normX = Width * maxPercent / 100;

					dragStartPosition = new Point((int)normX, e.Y);
					screenPoint = PointToScreen(dragStartPosition);
				}
				Location = new Point(screenPoint.X - dragStartPosition.X, screenPoint.Y - dragStartPosition.Y);
			}
		}

		private void ExitButton_MouseClick(object sender, MouseEventArgs e)
		{
			Close();
		}

		private void StateButton_MouseClick(object sender, MouseEventArgs e)
		{
			WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
		}

		private void MinimizeButton_MouseClick(object sender, MouseEventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
	}
}
