using System;
using System.Runtime.InteropServices;

namespace MaterialAPI.Extensions.Windows
{
	public static class Extensions
	{
		#region DLL Import
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 Msg, int wParam, int lParam);
		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);
		[DllImport("user32.dll", EntryPoint = "GetClassLong")]
		static extern uint GetClassLong32(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
		static extern IntPtr GetClassLong64(IntPtr hWnd, int nIndex);
		#endregion

		#region Struct
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

		#region Enum
		public enum WindowState : int
		{
			Normal,
			Minimized,
			Maximized
		}
		#endregion

		#region Constants
		private const uint WM_GETICON = 0x007f;
		private static IntPtr IDI_APPLICATION = new IntPtr(0x7F00);
		private const int GCL_HICON = -14;
		#endregion

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

		public static void MakeDraggable(this System.Windows.Forms.Control Target, Form Container)
		{
			Target.MouseDown += (se, ev) =>
			{
				if (ev.Button == System.Windows.Forms.MouseButtons.Left)
				{
					ReleaseCapture();
					SendMessage(Container.Handle, 0xA1, 0x2, 0);
				}
			};
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

		public static IntPtr GetTopWindow()
		{
			return GetForegroundWindow();
		}

		private static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
		{
			if (IntPtr.Size == 4)
				return new IntPtr((long)GetClassLong32(hWnd, nIndex));
			else
				return GetClassLong64(hWnd, nIndex);
		}

		public static System.Drawing.Image GetWindowIcon(this IntPtr hWnd, bool smallIcon = false)
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
					return new System.Drawing.Bitmap(System.Drawing.Icon.FromHandle(hIcon).ToBitmap(), 32, 32);
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
