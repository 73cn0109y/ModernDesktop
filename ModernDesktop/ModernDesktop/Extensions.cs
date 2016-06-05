using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;

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
		static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
		#endregion

		#region Constants
		private const Int32 SPIF_SENDWININICHANGE = 2;
		private const Int32 SPIF_UPDATEINIFILE = 1;
		private const Int32 SPIF_change = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;
		private const Int32 SPI_SETWORKAREA = 47;
		private const Int32 SPI_GETWORKAREA = 48;
		#endregion

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public Int32 Left;
			public Int32 Top;   // top is before right in the native struct
			public Int32 Right;
			public Int32 Bottom;
		}

		public static void SendToBack(this Form ctrl)
		{
			SetWindowPos(ctrl.Handle, new IntPtr(1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0040);
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

		public static bool SetWorkspace(this Rectangle rect)
		{
			RECT _rect = new RECT();
			_rect.Left = rect.Left;
			_rect.Top = rect.Top;
			_rect.Right = rect.Right;
			_rect.Bottom = rect.Bottom;

			Console.WriteLine(rect);

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
	}
}
