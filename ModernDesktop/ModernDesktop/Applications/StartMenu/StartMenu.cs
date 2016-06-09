using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using ModernDesktop.Controls.StartMenu;
using ModernDesktop.Misc;

namespace ModernDesktop.Applications
{
	public partial class StartMenu : MaterialAPI.Form
	{
		private readonly string RECENTAPPS_FILELOCATION = Environment.CurrentUser.SystemSettings + "/recentapplications.txt";
		private readonly Color GENERALLABEL_HOVERCOLOR = Color.FromArgb(25, 255, 255, 255);
		private readonly Color GENERALLABEL_PRESSCOLOR = Color.FromArgb(50, 255, 255, 255);

		public StartMenu()
		{
			InitializeComponent();

			BuildRecent();
		}

		public void ProgramLaunched(string fileName)
		{
			bool modified = false;
			HashSet<string> Lines = new HashSet<string>();

			foreach (string line in File.ReadAllLines(RECENTAPPS_FILELOCATION))
			{
				string currentLine = line;

				if (currentLine.Split(",")[0] == fileName)
				{
					currentLine = currentLine.Split(",")[0] + "," + (int.Parse(currentLine.Split(",")[1]) + 1).ToString();
					modified = true;
				}

				Lines.Add(currentLine);
			}

			if (!modified)
				Lines.Add(fileName + "," + 0);

			File.WriteAllLines(RECENTAPPS_FILELOCATION, Lines.ToArray());
		}

		private void Check()
		{
			if (!Directory.Exists(Path.GetDirectoryName(RECENTAPPS_FILELOCATION)))
				Directory.CreateDirectory(Path.GetDirectoryName(RECENTAPPS_FILELOCATION));

			if (!File.Exists(RECENTAPPS_FILELOCATION))
				using (StreamWriter writer = new StreamWriter(RECENTAPPS_FILELOCATION))
					writer.Write("");
		}

		private void BuildRecent()
		{
			Check();

			SortedSet<RecentInfo> RecentApplications = new SortedSet<RecentInfo>();

			foreach (string line in File.ReadAllLines(RECENTAPPS_FILELOCATION))
			{
				string[] info = line.Split(',');
				string fileName = info[0];
				int popularity = 0;

				if (!File.Exists(fileName))
					continue;

				int.TryParse(info[1], out popularity);

				RecentApplications.Add(new RecentInfo(fileName, popularity));
			}

			int top = 5;

			foreach (RecentInfo obj in RecentApplications.Reverse())
			{
				RecentItem item = new RecentItem(obj, pnlRecentPrograms.Width, obj.FileName);
				item.Location = new Point(5, top);

				pnlRecentPrograms.Controls.Add(item);

				top += item.Height + 5;
			}
		}

		private void lblShutdown_MouseClick(object sender, MouseEventArgs e)
		{
			Process.Start(new ProcessStartInfo()
			{
				FileName = "cmd.exe",
				Arguments = "/c shutdown -s",
				CreateNoWindow = true
			});
		}

		private void lblRestart_MouseClick(object sender, MouseEventArgs e)
		{
			Process.Start(new ProcessStartInfo()
			{
				FileName = "cmd.exe",
				Arguments = "/c shutdown -r",
				CreateNoWindow = true
			});
		}

		private void lblLogOff_MouseClick(object sender, MouseEventArgs e)
		{
			Process.Start(new ProcessStartInfo()
			{
				FileName = "cmd.exe",
				Arguments = "/c shutdown -l",
				CreateNoWindow = true
			});
		}

		private void pnlContainerRight_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(Pens.White, new Point(0, 0), new Point(Width, 0));
			e.Graphics.DrawLine(Pens.White, new Point(0, 0), new Point(0, Height));
		}

		private void pnlContainerLeft_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(Pens.White, new Point(0, 0), new Point(Width, 0));
		}

		private void GeneralLabel_MouseEnter(object sender, EventArgs e)
		{
			((Label)sender).BackColor = GENERALLABEL_HOVERCOLOR;
		}

		private void GeneralLabel_MouseLeave(object sender, EventArgs e)
		{
			((Label)sender).BackColor = Color.Transparent;
		}

		private void GeneralLabel_MouseDown(object sender, MouseEventArgs e)
		{
			((Label)sender).BackColor = GENERALLABEL_PRESSCOLOR;
		}

		private void GeneralLAbel_MouseUp(object sender, MouseEventArgs e)
		{
			((Label)sender).BackColor = GENERALLABEL_HOVERCOLOR;
		}

		protected override void OnDeactivate(EventArgs e)
		{
			Hide();

			base.OnDeactivate(e);
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			if (Visible)
			{
				Focus();
				Activate();
			}

			base.OnVisibleChanged(e);
		}
	}

	public class RecentInfo : IComparable
	{
		public RecentInfo() { }
		public RecentInfo(string filename, int popularity)
		{
			FileName = filename;
			Popularity = popularity;
		}

		public string FileName { get; set; } = null;
		public int Popularity { get; set; } = 0;

		public int CompareTo(object obj)
		{
			if (obj == null)
				return Popularity;

			RecentInfo other = obj as RecentInfo;
			if (other != null)
			{
				int result = Popularity.CompareTo(other.Popularity);
				return result == 0 ? 1 : result;
			}
			else
				throw new ArgumentException("Object is not a RecentInfo");
		}
	}
}
