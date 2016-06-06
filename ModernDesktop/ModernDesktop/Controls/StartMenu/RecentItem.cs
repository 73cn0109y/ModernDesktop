using System;
using System.Drawing;
using System.Windows.Forms;
using ModernDesktop.Applications.StartMenu;

namespace ModernDesktop.Controls.StartMenu
{
	public class RecentItem : Panel
	{
		private PictureBox Icon;
		private Label Title;

		public RecentItem(RecentInfo info, int parentWidth)
		{
			Size = new Size(parentWidth - 10, 30);
			BackColor = Color.Transparent;

			Bitmap icon = new Bitmap(info.FileName.GetLargeIcon(), new Size(30, 30));
			icon.OptimizeImage();

			Icon = new PictureBox();
			Icon.Size = new Size(30, 30);
			Icon.Location = new Point(0, 0);
			Icon.BackgroundImage = icon;
			Icon.BackgroundImageLayout = ImageLayout.Center;
			Icon.BackColor = Color.Transparent;
			Icon.MouseEnter += (se, ev) => { OnMouseEnter(ev); };
			Icon.MouseLeave += (se, ev) => { OnMouseLeave(ev); };

			Title = new Label();
			Title.AutoSize = false;
			Title.AutoEllipsis = true;
			Title.Size = new Size(Width - 30, Height);
			Title.Location = new Point(30, 0);
			Title.BackColor = Color.Transparent;
			Title.Text = System.IO.Path.GetFileNameWithoutExtension(info.FileName);
			Title.TextAlign = ContentAlignment.MiddleLeft;
			Title.Font = new Font("Segoe UI", 12, FontStyle.Regular);
			Title.Padding = new Padding(15, 0, 15, 0);
			Title.MouseEnter += (se, ev) => { OnMouseEnter(ev); };
			Title.MouseLeave += (se, ev) => { OnMouseLeave(ev); };

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
	}
}
