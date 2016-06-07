using System;

namespace ModernDesktop.Misc
{
	public class ProcessInfo
	{
		public ProcessInfo() { }

		public string Name { get; set; }
		public string Title { get; set; }
		public string Location { get; set; }
		public IntPtr MainHandle { get; set; }
		public IntPtr TargetHandle { get; set; }
		public bool RestoreMaximized { get; set; }
		public uint ThreadID { get; set; } = 0;
	}
}
