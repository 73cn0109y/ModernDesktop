using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernDesktop
{
	public class PictureBox : System.Windows.Forms.PictureBox
	{
		public new Image Image { get { return base.Image; } set { base.Image = value; } }
		public Image HoverImage { get; set; }
		public Image PressImage { get; set; }

		protected override void OnMouseEnter(EventArgs e)
		{
			if (HoverImage != null)
				base.Image = HoverImage;
			else
				base.Image = Image;

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
				return;

			if (Image != null)
				base.Image = Image;

			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (PressImage != null)
				base.Image = PressImage;
			else
				base.Image = Image;

			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (HoverImage != null)
				base.Image = HoverImage;
			else
				base.Image = Image;

			base.OnMouseUp(e);
		}
	}
}
