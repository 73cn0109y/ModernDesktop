using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Windows.Forms;
using ModernDesktop.Misc;
using System.Text;

namespace ModernDesktop
{
	public static class Extensions
	{
		private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		#region DLLImport
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		#endregion

		#region Struct
		[StructLayout(LayoutKind.Sequential)]
		struct WNDCLASSEX
		{
			public uint cbSize;
			public ClassStyles style;
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public WndProc lpfnWndProc;
			public int cbClsExtra;
			public int cbWndExtra;
			public IntPtr hInstance;
			public IntPtr hIcon;
			public IntPtr hCursor;
			public IntPtr hbrBackground;
			public string lpszMenuName;
			public string lpszClassName;
			public IntPtr hIconSm;
		}
		#endregion

		#region Enum
		[Flags]
		private enum ClassStyles : uint
		{
			ByteAlignClient = 0x1000,
			ByteAlignWindow = 0x2000,
			ClassDC = 0x40,
			DoubleClicks = 0x8,
			DropShadow = 0x20000,
			GlobalClass = 0x4000,
			HorizontalRedraw = 0x2,
			NoClose = 0x200,
			OwnDC = 0x20,
			ParentDC = 0x80,
			SaveBits = 0x800,
			VerticalRedraw = 0x1
		}
		#endregion

		public static bool HasWindowStyle(this Process p)
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

		public static void Add<T1, T2>(this Dictionary<T1, T2> parent, params Dictionary<T1, T2>[] obj)
		{
			foreach (Dictionary<T1, T2> entry in obj)
				foreach (KeyValuePair<T1, T2> item in entry)
					parent.Add(item.Key, item.Value);
		}

		public static string[] ToArray<T>(this IEnumerable<T> array)
		{
			List<string> arr = new List<string>();
			foreach (var e in array)
				arr.Add(e.ToString());
			return arr.ToArray();
		}

		public static bool ContainsThreadID(this HashSet<ProcessInfo> info, uint id)
		{
			foreach (ProcessInfo pi in info)
				if (pi.ThreadID == id)
					return true;
			return false;
		}
	}
}
