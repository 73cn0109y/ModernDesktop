using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace MaterialAPI
{
	public partial class Form : System.Windows.Forms.Form
	{
		public Color Accent
		{
			get { return accent; }
			set { accent = value; UpdateAccent(); }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AccentList<Control> AccentControls { get; set; } = new AccentList<Control>();

		public new string Text { get { return AccentHeader.Text; } set { AccentHeader.Text = value; } }

		private Color accent = Color.Transparent;
		private bool isResizing = false;

		public Form()
		{
			AccentControls.ItemAdded += (se, ev) => { UpdateAccent(); };

			InitializeComponent();

			AccentHeader.HeaderBar.MakeDraggable(this);
			AccentControls.Add(AccentHeader);
			SizeDrag.Region = new Region(Extensions.GenerateGraphicsPath(Extensions.GraphicsType.Triangle, SizeDrag.ClientRectangle, Extensions.Direction.SouthEast));
		}

		private void UpdateAccent()
		{
			foreach (Control ctrl in AccentControls)
				if(ctrl.BackColor != Accent)
					ctrl.BackColor = Accent;
		}

		private void SizeDrag_MouseDown(object sender, MouseEventArgs e)
		{
			isResizing = true;
		}

		private void SizeDrag_MouseUp(object sender, MouseEventArgs e)
		{
			isResizing = false;
		}

		private void SizeDrag_MouseMove(object sender, MouseEventArgs e)
		{
			if (!isResizing)
				return;

			Size = new Size(e.X + Width, e.Y + Height);
		}

		private void Form_Layout(object sender, LayoutEventArgs e)
		{
			foreach (Control ctrl in Controls)
				if (ctrl.GetType() == typeof(Controls.NestedSidebar))
					ctrl.BringToFront();
			SizeDrag.Location = new Point(Width - SizeDrag.Width, Height - SizeDrag.Height);
		}

		private void AccentHeader_CloseClicked(object sender, EventArgs e)
		{
			Close();
		}

		private void AccentHeader_StateClicked(object sender, EventArgs e)
		{
			WindowState = (WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized);
		}

		private void AccentHeader_MinimizeClicked(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			if(e.GetType() == typeof(Controls.NestedSidebar))
				AccentHeader.NestedSidebarCount += 1;

			base.OnControlAdded(e);
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			if (e.GetType() == typeof(Controls.NestedSidebar))
				AccentHeader.NestedSidebarCount -= 1;

			base.OnControlRemoved(e);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			foreach (Control ctrl in Controls)
				if (ctrl.GetType() == typeof(Controls.NestedSidebar))
					AccentHeader.NestedSidebarCount += 1;

			base.OnHandleCreated(e);
		}

		private void AccentHeader_HeaderDoubleClicked(object sender, MouseEventArgs e)
		{
			WindowState = (WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal);
		}
	}

	public class AccentList<T> : List<T>
	{
		public event EventHandler ItemAdded;
		public delegate void OnItemAdded();

		public new void Add(T e)
		{
			base.Add(e);

			ItemAdded?.Invoke(null, EventArgs.Empty);
		}
	}
}
