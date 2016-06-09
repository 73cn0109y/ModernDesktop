using System;
using System.Diagnostics;
using System.IO;

namespace ModernDesktop
{
	public static class FileData
	{
		public static string GetDescription(string e)
		{
			if (!File.Exists(e))
				return null;
			return FileVersionInfo.GetVersionInfo(e).FileDescription;
		}
	}
}
