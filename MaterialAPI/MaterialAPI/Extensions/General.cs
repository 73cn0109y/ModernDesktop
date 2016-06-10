using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace MaterialAPI.Extensions.General
{
	public static class Extensions
	{
		#region DLL Import
		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
		[DllImport("shell32.dll")]
		private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
		[DllImport("User32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SystemParametersInfo(int uiAction, IntPtr uiParam, ref RECT pvParam, int fWinIni);
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
		#endregion

		/// <summary>
		/// Get's a large (high quality) icon from a file. Good for getting an *.exe icon.
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
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

		public static uint GetThreadProcessId(this IntPtr handle)
		{
			uint threadID = 0;
			GetWindowThreadProcessId(handle, out threadID);
			return threadID;
		}

		/// <summary>
		/// Loads an image directly from a file without any formatting or optimizations
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
		public static Bitmap LoadRAWImage(this string location)
		{
			if (!File.Exists(location))
				return null;
			return Image.FromFile(location) as Bitmap;
		}

		/// <summary>
		/// Loads an image from a file, optimizes it and resizes it to the given size
		/// </summary>
		/// <param name="location"></param>
		/// <param name="Size"></param>
		/// <returns></returns>
		public static Bitmap LoadImage(this string location, Size Size)
		{
			Bitmap img = LoadRAWImage(location);
			if (img == null)
				return null;
			using (Bitmap bmp = img.Clone(new Rectangle(new Point(0, 0), img.Size), System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
				img = new Bitmap(bmp, Size);
			return img;
		}

		/// <summary>
		/// Change a Bitmap's PixelFormat to Formar32BppPArgb for faster drawing
		/// </summary>
		/// <param name="bmp"></param>
		public static void OptimizeImage(this Bitmap bmp)
		{
			using (Bitmap clone = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
			using (Graphics g = Graphics.FromImage(clone))
				g.DrawImage(bmp, new Rectangle(0, 0, clone.Width, clone.Height));
		}

		/// <summary>
		/// Changes the WorkArea of a monitor that contains the specified rectangle
		/// </summary>
		/// <param name="rect"></param>
		/// <returns>True if a WorkArea was updated. False if there was an error.</returns>
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

		/// <summary>
		/// Checks to see if a Point is at the top of it's respected monitor
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
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
	}
}