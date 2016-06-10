using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

namespace Settings
{
	public partial class Form1 : MaterialAPI.Form
	{
		public event EventHandler PersonalizeWallpaperChanged;

		private MaterialAPI.Label CurrentTab;
		private Dictionary<string, string> Information;
		private BackgroundWorker PersonalizeWallpaperWorker;
		private readonly string[] SupportedPictures = new string[]
		{
			"png",
			"jpg",
			"jpeg",
			"bmp"
		};

		public Form1(Dictionary<string, string> info)
		{
			Information = info;
			InitializeComponent();

			MaximumSize = Screen.FromHandle(Handle).WorkingArea.Size;

			SwitchPage(lblSystem, null);

			#region Background Workers
			// Personalize Wallpaper
			PersonalizeWallpaperWorker = new BackgroundWorker();
			PersonalizeWallpaperWorker.DoWork += PersonalizeWallpaperWorker_DoWork;
			PersonalizeWallpaperWorker.WorkerSupportsCancellation = true;
			#endregion
		}

		private void PersonalizeWallpaperWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while(!e.Cancel && !PersonalizeWallpaperWorker.CancellationPending)
			{
				Invoke(new MethodInvoker(() =>
				{
					PersonalizeWallpaperList.Clear();
					PersonalizeWallpaperImageList.Images.Clear();
				}));

				FileInfo[] pictures = new DirectoryInfo(Information["WallpaperDirectory"]).GetFiles().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();

				if(pictures.Length <= 0)
					return;

				foreach (FileInfo pic in pictures)
				{
					Invoke(new MethodInvoker(() =>
					{
						PersonalizeWallpaperImageList.Images.Add(Image.FromFile(pic.FullName));
						PersonalizeWallpaperList.Items.Add(pic.FullName, PersonalizeWallpaperImageList.Images.Count - 1);
					}));

					Application.DoEvents();
				}

				return;
			}
		}

		private void SwitchPage(object sender, MouseEventArgs e)
		{
			string name = ((Label)sender).Text;

			foreach(Panel pnl in Controls.OfType<Panel>().Where(x=>x.Name.ToLower().StartsWith("page")))
			{
				string pnlName = pnl.Name.Substring(4, pnl.Name.Length - 4);
				if (pnlName == name)
					pnl.Show();
				else
					pnl.Hide();
			}

			if (CurrentTab != null)
				CurrentTab.DefaultColor = Color.Transparent;

			CurrentTab = ((MaterialAPI.Label)sender);
			CurrentTab.DefaultColor = Color.FromArgb(75, 255, 255, 255);
		}

		private void btnPersonalizeWallpaperApply_MouseClick(object sender, MouseEventArgs e)
		{
			PersonalizeWallpaperChanged.Invoke(PersonalizeWallpaperList.SelectedItems[0].Text, null);
		}

		private void btnPersonalizeWallpaperCancel_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void PersonalizeInternalTab_MouseClick(object sender, MouseEventArgs e)
		{
			string name = ((Label)sender).Text;

			foreach(Panel pnl in pagePersonalize.Controls.OfType<Panel>())
			{
				if (pnl.Name == "PersonalizeTabs")
					continue;

				if (pnl.Name == "Personalize" + name + "Container")
					pnl.Show();
				else
					pnl.Hide();
			}
		}

		private void PersonalizeWallpaperContainer_VisibleChanged(object sender, EventArgs e)
		{
			if (!Visible)
				return;

			PersonalizeWallpaperWorker.RunWorkerAsync();
		}

		private void btnPersonalizeWallpaperBrowse_MouseClick(object sender, MouseEventArgs e)
		{
			using (FolderBrowserDialog ofd = new FolderBrowserDialog())
			{
				ofd.ShowNewFolderButton = false;

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					Information["WallpaperDirectory"] = ofd.SelectedPath;
					PersonalizeWallpaperWorker.RunWorkerAsync();
				}
			}
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			MaximumSize = Screen.FromHandle(Handle).WorkingArea.Size;

			base.OnLocationChanged(e);
		}
	}
}
