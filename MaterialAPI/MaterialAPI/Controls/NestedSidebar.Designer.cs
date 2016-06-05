using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialAPI.Controls
{
	public partial class NestedSidebar
	{
		public void InitializeComponent()
		{
			//
			// NestedSidebar
			//
			MinimumSize = new Size(75, 600);
			BackColor = Color.FromArgb(255, 50, 50, 50);
			Anchor =  AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
		}
	}
}
