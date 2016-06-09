using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialAPI
{
	public class PictureBox : System.Windows.Forms.PictureBox
	{
		public new Image Image { get; set; }
		public Image HoverImage { get; set; }
		public Image PressImage { get; set; }

		public PictureBox()
		{
			base.Image = Image;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.Image = Image;

			base.OnHandleCreated(e);
		}

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
