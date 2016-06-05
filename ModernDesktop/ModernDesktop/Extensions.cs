using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

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
	}
}
