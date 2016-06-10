using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialAPI
{
	public class PictureBox : System.Windows.Forms.PictureBox
	{
		public new Image Image { get { return image; }set { image = value; UpdateImage(); } }
		public Image HoverImage { get; set; }
		public Image PressImage { get; set; }

		private Image image;

		public PictureBox()
		{
			base.Image = Image;
		}

		private void UpdateImage()
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
			base.Image = HoverImage ?? Image;

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.Image = Image ?? base.Image;

			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.Image = PressImage ?? Image;

			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.Image = HoverImage ?? Image;

			base.OnMouseUp(e);
		}
	}
}
