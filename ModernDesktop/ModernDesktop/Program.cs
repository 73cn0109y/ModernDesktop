using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDesktop
{
	static class Program
	{
		static DateTime LastException = new DateTime(1970, 1, 1);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			AppDomain.CurrentDomain.FirstChanceException += FirstChanceHandler;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Desktop());
		}

		static void FirstChanceHandler(object source, FirstChanceExceptionEventArgs e)
		{
			if ((DateTime.Now - LastException).TotalSeconds > 3)
			{
				LastException = DateTime.Now;
				MessageBox.Show("There was an error! Reference GUID: " + Logger.Log(e.Exception.ToString()));
			}
		}
	}
}
