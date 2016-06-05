using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace MaterialAPI
{
	public static class Extensions
	{
		public enum GraphicsType : int
		{
			Triangle = 0,
			Square = 1
		}

		public enum Direction : int
		{
			NULL,
			North,
			NorthEast,
			East,
			SouthEast,
			South,
			SouthWest,
			West,
			NorthWest
		}

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		private static Dictionary<Control, double> ControlLastClick = new Dictionary<Control, double>();

		public static void MakeDraggable(this Control Target, Form Container)
		{
			ControlLastClick.Add(Target, 0);

			Target.Disposed += (se, ev) =>
			{
				ControlLastClick.Remove(se as Control);
			};

			Target.MouseDown += (se, ev) =>
			{
				if(ev.Button == MouseButtons.Left)
				{
					double epoch = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;

					if (epoch - ControlLastClick[se as Control] <= 300 && ControlLastClick[se as Control] > 0)
					{
						Container.WindowState = FormWindowState.Maximized;
					}
					else
					{
						ReleaseCapture();
						SendMessage(Container.Handle, 0xA1, 0x2, 0);
					}

					ControlLastClick[se as Control] = epoch;
				}
			};
		}

		public static GraphicsPath GenerateGraphicsPath(GraphicsType type, Rectangle rectangle, Direction direction = Direction.NULL)
		{
			if (type == GraphicsType.Triangle && direction != Direction.NULL)
				return GenerateTrianglePath(rectangle, direction);
			else if (type == GraphicsType.Square)
				return GenerateSquarePath(rectangle);

			return null;
		}

		public static GraphicsPath GenerateTrianglePath(Rectangle rect, Direction direction)
		{
			GraphicsPath gp = new GraphicsPath();

			switch (direction)
			{
				case Direction.North:
					gp.AddLine(new Point(rect.Width / 2, rect.Top), new Point(rect.Width, rect.Bottom));
					gp.AddLine(new Point(rect.Width, rect.Bottom), new Point(rect.Left, rect.Bottom));
					gp.AddLine(new Point(rect.Left, rect.Bottom), new Point(rect.Width / 2, rect.Top));
					break;
				case Direction.NorthEast:
					gp.AddLine(new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));
					gp.AddLine(new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
					gp.AddLine(new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Top));
					break;
				case Direction.East:
					gp.AddLine(new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Height / 2));
					gp.AddLine(new Point(rect.Right, rect.Height / 2), new Point(rect.Left, rect.Bottom));
					gp.AddLine(new Point(rect.Left, rect.Bottom), new Point(rect.Left, rect.Top));
					break;
				case Direction.SouthEast:
					gp.AddLine(new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
					gp.AddLine(new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Bottom));
					gp.AddLine(new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Top));
					break;
				case Direction.South:
					gp.AddLine(new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));
					gp.AddLine(new Point(rect.Right, rect.Top), new Point(rect.Width / 2, rect.Bottom));
					gp.AddLine(new Point(rect.Width / 2, rect.Bottom), new Point(rect.Left, rect.Top));
					break;
				case Direction.SouthWest:
					gp.AddLine(new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Bottom));
					gp.AddLine(new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Bottom));
					gp.AddLine(new Point(rect.Left, rect.Bottom), new Point(rect.Left, rect.Top));
					break;
				case Direction.West:
					gp.AddLine(new Point(rect.Right, rect.Top), new Point(rect.Right, rect.Bottom));
					gp.AddLine(new Point(rect.Right, rect.Bottom), new Point(rect.Left, rect.Height / 2));
					gp.AddLine(new Point(rect.Left, rect.Height / 2), new Point(rect.Right, rect.Top));
					break;
				case Direction.NorthWest:
					gp.AddLine(new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));
					gp.AddLine(new Point(rect.Right, rect.Top), new Point(rect.Left, rect.Bottom));
					gp.AddLine(new Point(rect.Left, rect.Bottom), new Point(rect.Left, rect.Top));
					break;
			}

			return gp;
		}

		public static GraphicsPath GenerateSquarePath(Rectangle rectangle)
		{
			GraphicsPath gp = new GraphicsPath();

			gp.AddRectangle(rectangle);

			return gp;
		}
	}
}
