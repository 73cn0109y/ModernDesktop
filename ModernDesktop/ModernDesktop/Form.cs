namespace ModernDesktop
{
	public class Form : System.Windows.Forms.Form
	{
		public new void SendToBack()
		{
			Extensions.SendToBack(this);
		}
	}
}
