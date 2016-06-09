using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace MaterialAPI
{
	public static class Extensions
	{
		#region DLL Import
		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("shell32.dll")]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
		[DllImport("User32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SystemParametersInfo(int uiAction, IntPtr uiParam, ref RECT pvParam, int fWinIni);
		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);
		[DllImport("user32.dll", EntryPoint = "GetClassLong")]
		static extern uint GetClassLong32(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
		static extern IntPtr GetClassLong64(IntPtr hWnd, int nIndex);
		#endregion

		#region Constants
		private const Int32 SPIF_SENDWININICHANGE = 2;
		private const Int32 SPIF_UPDATEINIFILE = 1;
		private const Int32 SPIF_change = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;
		private const Int32 SPI_SETWORKAREA = 47;
		private const Int32 SPI_GETWORKAREA = 48;
		private const uint FILE_ATTRIBUTE_NORMAL = 0x80;
		private const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
		private const int WM_SETREDRAW = 11;
		private const uint WM_GETICON = 0x007f;
		private static IntPtr IDI_APPLICATION = new IntPtr(0x7F00);
		private const int GCL_HICON = -14;
		#endregion

		#region Enum
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

		public enum WindowState : int
		{
			Normal,
			Minimized,
			Maximized
		}
		#endregion

		#region Struct
		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public Int32 Left;
			public Int32 Top;   // top is before right in the native struct
			public Int32 Right;
			public Int32 Bottom;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct SHFILEINFO
		{
			public IntPtr hIcon;
			public IntPtr iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		}

		private struct WINDOWPLACEMENT
		{
			public int length;
			public int flags;
			public int showCmd;
			public System.Drawing.Point ptMinPosition;
			public System.Drawing.Point ptMaxPosition;
			public System.Drawing.Rectangle rcNormalPosition;
		}
		#endregion

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
				if (ev.Button == MouseButtons.Left)
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

		public static void SendToBack(this IntPtr handle)
		{
			SetWindowPos(handle, new IntPtr(1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0040);
		}

		public static void SendToBack(this Form ctrl)
		{
			SetWindowPos(ctrl.Handle, new IntPtr(1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0040);
		}

		public static void BottomMost(this IntPtr handle)
		{
			SetWindowPos(handle, new IntPtr(1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010);
		}

		public static void BringToFromt(this IntPtr handle)
		{
			SetForegroundWindow(handle);
		}

		public static void BringToFront(this Form ctrl)
		{
			SetWindowPos(ctrl.Handle, new IntPtr(0), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0040);
		}

		public static void SetTopMost(this Form ctrl)
		{
			SetWindowPos(ctrl.Handle, new IntPtr(-1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0040);
		}

		public static Bitmap GetLargeIcon(this string location)
		{
			SHFILEINFO info = new SHFILEINFO();
			IntPtr img = SHGetFileInfo(location, FILE_ATTRIBUTE_NORMAL, ref info, (uint)Marshal.SizeOf(info), (uint)(0x000000100 | 0x000000000 | 0x000000010));
			Icon ico = Icon.FromHandle(info.hIcon);
			Bitmap icon = new Bitmap(40, 40);
			using (Graphics g = Graphics.FromImage(icon))
				g.DrawIcon(ico, 20 - (ico.Width / 2), 20 - (ico.Height / 2));
			icon.OptimizeImage();
			DestroyIcon(info.hIcon);
			return icon;
		}

		public static IntPtr GetTopWindow()
		{
			return GetForegroundWindow();
		}

		public static uint GetThreadProcessId(this IntPtr handle)
		{
			uint threadID = 0;
			GetWindowThreadProcessId(handle, out threadID);
			return threadID;
		}

		public static WindowState GetWindowState(this IntPtr handle)
		{
			WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
			GetWindowPlacement(handle, ref placement);

			switch (placement.showCmd)
			{
				case 2:
					return WindowState.Minimized;
				case 3:
					return WindowState.Maximized;
			}

			return WindowState.Normal;
		}

		public static bool RestoreToMaximized(this IntPtr handle)
		{
			WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
			GetWindowPlacement(handle, ref placement);

			return (placement.flags == 0x0002);
		}

		public static void Minimize(this IntPtr handle)
		{
			ShowWindow(handle, 6);
			SendToBack(handle);
		}

		public static void Restore(this IntPtr handle, bool restoreOverride = false)
		{
			if (handle.RestoreToMaximized() && !restoreOverride)
				ShowWindow(handle, 3);
			else
				ShowWindow(handle, 1);
		}

		public static void Maximize(this IntPtr handle)
		{
			ShowWindow(handle, 3);
		}

		public static Bitmap LoadRAWImage(this string location)
		{
			if (!File.Exists(location))
				return null;
			return Image.FromFile(location) as Bitmap;
		}

		public static Bitmap LoadImage(this string location, Size Size)
		{
			Bitmap img = LoadRAWImage(location);
			if (img == null)
				return null;
			using (Bitmap bmp = img.Clone(new Rectangle(new Point(0, 0), img.Size), System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
				img = new Bitmap(bmp, Size);
			return img;
		}

		public static void OptimizeImage(this Bitmap bmp)
		{
			using (Bitmap clone = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
			using (Graphics g = Graphics.FromImage(clone))
				g.DrawImage(bmp, new Rectangle(0, 0, clone.Width, clone.Height));
		}

		public static bool SetWorkspace(this Rectangle rect)
		{
			RECT _rect = new RECT();
			_rect.Left = rect.Left;
			_rect.Top = rect.Top;
			_rect.Right = rect.Right;
			_rect.Bottom = rect.Bottom;

			bool result = SystemParametersInfo(SPI_SETWORKAREA, IntPtr.Zero, ref _rect, SPIF_change);

			if (!result)
				Console.WriteLine("The last error was: " + Marshal.GetLastWin32Error().ToString());

			return result;
		}

		public static void SuspendDrawing(this Control ctrl)
		{
			SendMessage(ctrl.Handle, WM_SETREDRAW, false, 0);
		}

		public static void ResumeDrawing(this Control ctrl)
		{
			SendMessage(ctrl.Handle, WM_SETREDRAW, true, 0);
			ctrl.Refresh();
		}

		public static bool AtTopOfScreen(this Point pos)
		{
			foreach (Screen scr in Screen.AllScreens)
				if (scr.Bounds.Contains(pos))
					if (pos.Y <= scr.Bounds.Top + 5)
						return true;

			return false;
		}

		public static int Magnitude(this Point p1, Point p2)
		{
			return ((p1.X - p2.X) * (p1.X - (p2.X)) + (p1.Y - p2.Y) * (p1.Y - (p2.Y)));
		}

		private static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
		{
			if (IntPtr.Size == 4)
				return new IntPtr((long)GetClassLong32(hWnd, nIndex));
			else
				return GetClassLong64(hWnd, nIndex);
		}

		public static Image GetWindowIcon(this IntPtr hWnd, bool smallIcon = false)
		{
			try
			{
				IntPtr hIcon = default(IntPtr);

				hIcon = SendMessage(hWnd, WM_GETICON, smallIcon ? new IntPtr(2) : new IntPtr(1), IntPtr.Zero);

				if (hIcon == IntPtr.Zero)
					hIcon = GetClassLongPtr(hWnd, GCL_HICON);

				if (hIcon == IntPtr.Zero)
					hIcon = LoadIcon(IntPtr.Zero, IDI_APPLICATION);

				if (hIcon != IntPtr.Zero)
					return new Bitmap(Icon.FromHandle(hIcon).ToBitmap(), 32, 32);
				else
					return null;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}