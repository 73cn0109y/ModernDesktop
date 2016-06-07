using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModernDesktop
{
	public static class Extensions
	{
		#region DLLImport
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SystemParametersInfo(int uiAction, IntPtr uiParam, ref RECT pvParam, int fWinIni);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("shell32.dll")]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
		[DllImport("User32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
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
		#endregion

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

		public enum WindowState : int
		{
			Normal,
			Minimized,
			Maximized
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

		public static bool hasWindowStyle(this Process p)
		{
			IntPtr hnd = p.MainWindowHandle;
			UInt32 WS_DISABLED = 0x8000000;
			int GWL_STYLE = -16;
			bool visible = false;
			if (hnd != IntPtr.Zero)
			{
				UInt32 style = GetWindowLong(hnd, GWL_STYLE);
				visible = ((style & WS_DISABLED) != WS_DISABLED);
			}
			return visible;
		}

		public static string ToString(this Widgets.WeatherData.UnitType e)
		{
			return (e == Widgets.WeatherData.UnitType.Kelvin ? "K" : (e == Widgets.WeatherData.UnitType.Fahrenheit ? "°F" : "°C"));
		}

		public static string DownloadString(this string e)
		{
			using (WebClient client = new WebClient())
				return client.DownloadString(e);
		}

		public static string[] Split(this string e, string s)
		{
			return e.Split(new string[] { s }, StringSplitOptions.None);
		}

		public static bool CharBeforeChar(this string e, char first, char second)
		{
			bool foundFirst = false;
			foreach(char c in e)
			{
				if (foundFirst && c == second)
					return true;
				else if (c == first)
					foundFirst = true;
				else if (c == second)
					return false;
			}

			return false;
		}

		public static double Convert(this double e, Widgets.WeatherData.UnitType to)
		{
			double v = e;

			if (to == Widgets.WeatherData.UnitType.Celcius)
			{
				v = v - 273.15;
			}
			else if (to == Widgets.WeatherData.UnitType.Fahrenheit)
			{
				v = (v - 273.15) * 1.8f + 32.0f;
			}

			return v;
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

		public static void Add<T1, T2>(this Dictionary<T1, T2> parent, params Dictionary<T1, T2>[] obj)
		{
			foreach (Dictionary<T1, T2> entry in obj)
				foreach (KeyValuePair<T1, T2> item in entry)
					parent.Add(item.Key, item.Value);
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

		public static string[] ToArray<T>(this IEnumerable<T> array)
		{
			List<string> arr = new List<string>();
			foreach (var e in array)
				arr.Add(e.ToString());
			return arr.ToArray();
		}

		public static bool AtTopOfScreen(this Point pos)
		{
			foreach (Screen scr in Screen.AllScreens)
				if (scr.Bounds.Contains(pos))
					if (pos.Y <= scr.Bounds.Top + 5)
						return true;

			return false;
		}

		public static int DistanceMoved(this Point p1, Point p2)
		{
			return ((p1.X - p2.X) * (p1.X - (p2.X)) + (p1.Y - p2.Y) * (p1.Y - (p2.Y)));
		}
	}
}
