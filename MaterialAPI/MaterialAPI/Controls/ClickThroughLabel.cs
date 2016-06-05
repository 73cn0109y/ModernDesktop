using System;
using System.Windows.Forms;

namespace MaterialAPI.Controls
{
	public class ClickThroughLabel : Label
	{
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0084)
				m.Result = (IntPtr)(-1);
			else
				base.WndProc(ref m);
		}
	}
}
