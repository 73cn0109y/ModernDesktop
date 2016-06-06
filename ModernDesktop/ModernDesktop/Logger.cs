using System;
using System.IO;

namespace ModernDesktop
{
	public static class Logger
	{
		private const string LOGGER_PATH = "C:/ModernDesktop/System/Logger/";

		public static string CurrentFile
		{
			get
			{
				return Path.Combine(LOGGER_PATH, DateTime.Now.ToString("d").Replace("/", "-") + ".txt");
			}
		}

		private static void Check()
		{
			if (!Directory.Exists(LOGGER_PATH))
				Directory.CreateDirectory(LOGGER_PATH);

			if (!File.Exists(CurrentFile))
				using (StreamWriter writer = new StreamWriter(CurrentFile))
					writer.Write("Log Created - " + DateTime.Now.ToString("F") + "\r\n\r\n");
		}

		public static Guid Log(string e)
		{
			Check();

			Guid guid = Guid.NewGuid();

			using (StreamWriter writer = File.AppendText(CurrentFile))
				writer.Write(guid.ToString() + " - " + e + "\r\n\r\n");

			return guid;
		}
	}
}
