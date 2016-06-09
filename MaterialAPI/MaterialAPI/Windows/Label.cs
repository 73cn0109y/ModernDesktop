using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MaterialAPI
{
	public class Label : System.Windows.Forms.Label
	{
		public TextRenderingHint TextRenderingHint { get { return textRenderingHint; } set { textRenderingHint = value; } }
		public bool PassThroughClick { get; set; } = false;

		private TextRenderingHint textRenderingHint = TextRenderingHint.SystemDefault;


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
