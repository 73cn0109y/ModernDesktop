using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialAPI
{
	public partial class Form
	{
		public void InitializeComponent()
		{
			this.SizeDrag = new System.Windows.Forms.Panel();
			this.AccentHeader = new MaterialAPI.Controls.AccentHeader();
			this.SuspendLayout();
			// 
			// SizeDrag
			// 
			this.SizeDrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SizeDrag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.SizeDrag.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
			this.SizeDrag.Location = new System.Drawing.Point(790, 590);
			this.SizeDrag.Name = "SizeDrag";
			this.SizeDrag.Size = new System.Drawing.Size(10, 10);
			this.SizeDrag.TabIndex = 1;
			this.SizeDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizeDrag_MouseDown);
			this.SizeDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizeDrag_MouseMove);
			this.SizeDrag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizeDrag_MouseUp);
			// 
			// AccentHeader
			// 
			this.AccentHeader.BackColor = System.Drawing.Color.Transparent;
			this.AccentHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.AccentHeader.Location = new System.Drawing.Point(0, 0);
			this.AccentHeader.MinimumSize = new System.Drawing.Size(800, 100);
			this.AccentHeader.Name = "AccentHeader";
			this.AccentHeader.NestedSidebarCount = 0;
			this.AccentHeader.ShowSearchBar = true;
			this.AccentHeader.Size = new System.Drawing.Size(800, 100);
			this.AccentHeader.TabIndex = 0;
			this.AccentHeader.CloseClicked += new System.EventHandler(this.AccentHeader_CloseClicked);
			this.AccentHeader.StateClicked += new System.EventHandler(this.AccentHeader_StateClicked);
			this.AccentHeader.MinimizeClicked += new System.EventHandler(this.AccentHeader_MinimizeClicked);
			this.AccentHeader.HeaderDoubleClicked += new System.Windows.Forms.MouseEventHandler(this.AccentHeader_HeaderDoubleClicked);
			// 
			// Form
			// 
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.AccentHeader);
			this.Controls.Add(this.SizeDrag);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form_Layout);
			this.ResumeLayout(false);

		}
		private Panel SizeDrag;
		private Controls.AccentHeader AccentHeader;
	}
}
