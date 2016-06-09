using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ModernDesktop.Applications;
using MaterialAPI;

namespace ModernDesktop.Controls.StartMenu
{
	public class RecentItem : Panel
	{
		private string FileName = null;
		private MaterialAPI.PictureBox Icon;
		private MaterialAPI.Label Title;

		public RecentItem(RecentInfo info, int parentWidth, string fileName)
		{
			FileName = fileName;

			Size = new Size(parentWidth - 10, 30);
			BackColor = Color.Transparent;

			Bitmap icon = new Bitmap(info.FileName.GetLargeIcon(), new Size(30, 30));
			icon.OptimizeImage();

			Icon = new MaterialAPI.PictureBox();
			Icon.Size = new Size(30, 30);
			Icon.Location = new Point(0, 0);
			Icon.BackgroundImage = icon;
			Icon.BackgroundImageLayout = ImageLayout.Center;
			Icon.BackColor = Color.Transparent;
			Icon.MouseEnter += (se, ev) => { OnMouseEnter(ev); };
			Icon.MouseLeave += (se, ev) => { OnMouseLeave(ev); };
			Icon.MouseClick += (se, ev) => { OnMouseClick(ev); };

			Title = new MaterialAPI.Label();
			Title.AutoSize = false;
			Title.AutoEllipsis = true;
			Title.Size = new Size(Width - 30, Height);
			Title.Location = new Point(30, 0);
			Title.BackColor = Color.Transparent;
			Title.Text =  FileData.GetDescription(info.FileName);
			Title.TextAlign = ContentAlignment.MiddleLeft;
			Title.Font = new Font("Segoe UI", 12, FontStyle.Regular);
			Title.Padding = new Padding(15, 0, 15, 0);
			Title.MouseEnter += (se, ev) => { OnMouseEnter(ev); };
			Title.MouseLeave += (se, ev) => { OnMouseLeave(ev); };
			Title.MouseClick += (se, ev) => { OnMouseClick(ev); };

			Controls.Add(Icon);
			Controls.Add(Title);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			BackColor = Color.FromArgb(25, 255, 255, 255);

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
				return;

			BackColor = Color.Transparent;

			base.OnMouseLeave(e);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && FileName != null)
			{
				Process.Start(new ProcessStartInfo()
				{
					FileName = FileName
				});

				BackColor = Color.Transparent;
			}

			base.OnMouseClick(e);
		}
	}
}
