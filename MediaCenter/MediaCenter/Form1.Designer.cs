namespace MediaCenter
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		public void InitializeComponent()
		{
			this.nestedSidebar1 = new MaterialAPI.Controls.NestedSidebar();
			this.nestedSidebar2 = new MaterialAPI.Controls.NestedSidebar();
			this.SuspendLayout();
			// 
			// nestedSidebar1
			// 
			this.nestedSidebar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.nestedSidebar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.nestedSidebar1.Location = new System.Drawing.Point(0, 0);
			this.nestedSidebar1.MinimumSize = new System.Drawing.Size(75, 600);
			this.nestedSidebar1.Name = "nestedSidebar1";
			this.nestedSidebar1.Size = new System.Drawing.Size(75, 600);
			this.nestedSidebar1.TabIndex = 2;
			// 
			// nestedSidebar2
			// 
			this.nestedSidebar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.nestedSidebar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.nestedSidebar2.Location = new System.Drawing.Point(75, 0);
			this.nestedSidebar2.MinimumSize = new System.Drawing.Size(75, 600);
			this.nestedSidebar2.Name = "nestedSidebar2";
			this.nestedSidebar2.Size = new System.Drawing.Size(75, 600);
			this.nestedSidebar2.TabIndex = 3;
			// 
			// Form1
			// 
			this.Accent = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(29)))), ((int)(((byte)(22)))));
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.nestedSidebar2);
			this.Controls.Add(this.nestedSidebar1);
			this.Name = "Form1";
			this.Controls.SetChildIndex(this.nestedSidebar1, 0);
			this.Controls.SetChildIndex(this.nestedSidebar2, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private MaterialAPI.Controls.NestedSidebar nestedSidebar1;
		private MaterialAPI.Controls.NestedSidebar nestedSidebar2;
	}
}