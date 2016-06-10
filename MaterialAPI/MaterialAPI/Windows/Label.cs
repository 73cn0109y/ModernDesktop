using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MaterialAPI
{
	public class Label : System.Windows.Forms.Label
	{
		public TextRenderingHint TextRenderingHint { get { return textRenderingHint; } set { textRenderingHint = value; } }
		public bool PassThroughClick { get; set; } = false;
		public Color DefaultColor { get { return defaultColor; }set { defaultColor = value; UpdateColor(); } }
		public Color HoverColor { get; set; }
		public Color PressColor { get; set; }

		private TextRenderingHint textRenderingHint = TextRenderingHint.SystemDefault;
		private Color defaultColor;

		private void UpdateColor()
		{
			BackColor = DefaultColor;
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			BackColor = HoverColor;

			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (ClientRectangle.Contains(PointToClient(Cursor.Position)))
				return;

			BackColor = DefaultColor;

			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			BackColor = PressColor;

			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			BackColor = HoverColor;

			base.OnMouseUp(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint;

			base.OnPaint(e);
		}

		protected override void WndProc(ref Message m)
		{
			if (PassThroughClick)
			{
				const int WM_NCHITTEST = 0x0084;
				const int HTTRANSPARENT = (-1);

				if (m.Msg == WM_NCHITTEST)
					m.Result = (IntPtr)HTTRANSPARENT;
				else
					base.WndProc(ref m);
			}
			else
				base.WndProc(ref m);
		}
	}
}
