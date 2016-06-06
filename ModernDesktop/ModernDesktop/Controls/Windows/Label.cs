namespace ModernDesktop
{
	public class Label : System.Windows.Forms.Label
	{
		private System.Drawing.Text.TextRenderingHint textRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
		public System.Drawing.Text.TextRenderingHint TextRenderingHint { get { return textRenderingHint; } set { textRenderingHint = value; } }

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = TextRenderingHint;
			base.OnPaint(e);
		}
	}
}
