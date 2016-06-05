using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialAPI.Controls
{
	public partial class AccentHeader : Panel
	{
		public event EventHandler CloseClicked;
		public event EventHandler StateClicked;
		public event EventHandler MinimizeClicked;
		public event EventHandler SearchClicked;
		public event MouseEventHandler HeaderDoubleClicked;

		public new string Text { get { return Title.Text; } set { Title.Text = value; } }

		public int NestedSidebarCount { get { return nestedSidebarCount; } set { nestedSidebarCount = value; Title.Location = new Point(value * 75, Title.Location.Y); } }

		public bool ShowSearchBar { get { return SearchBar.Visible; } set { SearchBar.Visible = value; } }

		private int nestedSidebarCount = 0;

		public AccentHeader()
		{
			InitializeComponent();
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			CloseClicked?.Invoke(sender, e);
		}

		private void StateButton_Click(object sender, EventArgs e)
		{
			StateClicked?.Invoke(sender, e);
		}

		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			MinimizeClicked?.Invoke(sender, e);
		}

		private void SearchButton_MouseClick(object sender, EventArgs e)
		{
			SearchClicked?.Invoke(sender, e);
		}

		private void HeaderBar_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			HeaderDoubleClicked?.Invoke(sender, e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			CloseButton.Location = new Point(Width - CloseButton.Width - 10, CloseButton.Location.Y);
			StateButton.Location = new Point(CloseButton.Left - StateButton.Width - 10, StateButton.Location.Y);
			MinimizeButton.Location = new Point(StateButton.Left - StateButton.Width - 10, MinimizeButton.Location.Y);
			SearchBar.Location = new Point(MinimizeButton.Right - SearchBar.Width, SearchBar.Location.Y);
			RefreshButton.Location = new Point(StateButton.Left, SearchBar.Top);
			OptionsButton.Location = new Point(CloseButton.Left, SearchBar.Top);

			base.OnSizeChanged(e);
		}
	}
}
