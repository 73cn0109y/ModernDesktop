namespace ModernDesktop
{
	public partial class Form
	{
		private void InitializeComponent()
		{
			this.Header = new System.Windows.Forms.Panel();
			this.Title = new ModernDesktop.Label();
			this.MinimizeButton = new ModernDesktop.PictureBox();
			this.StateButton = new ModernDesktop.PictureBox();
			this.ExitButton = new ModernDesktop.PictureBox();
			this.Header.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StateButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
			this.SuspendLayout();
			// 
			// Header
			// 
			this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.Header.Controls.Add(this.Title);
			this.Header.Controls.Add(this.MinimizeButton);
			this.Header.Controls.Add(this.StateButton);
			this.Header.Controls.Add(this.ExitButton);
			this.Header.Dock = System.Windows.Forms.DockStyle.Top;
			this.Header.ForeColor = System.Drawing.Color.White;
			this.Header.Location = new System.Drawing.Point(0, 0);
			this.Header.Name = "Header";
			this.Header.Size = new System.Drawing.Size(800, 40);
			this.Header.TabIndex = 0;
			this.Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Header_MouseDown);
			this.Header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Header_MouseMove);
			this.Header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Header_MouseUp);
			// 
			// Title
			// 
			this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Title.Location = new System.Drawing.Point(0, 0);
			this.Title.Name = "Title";
			this.Title.PassThroughClick = true;
			this.Title.Size = new System.Drawing.Size(685, 40);
			this.Title.TabIndex = 3;
			this.Title.Text = "Modern Desktop - Application";
			this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Title.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
			// 
			// MinimizeButton
			// 
			this.MinimizeButton.HoverImage = null;
			this.MinimizeButton.Image = null;
			this.MinimizeButton.Location = new System.Drawing.Point(695, 5);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.PressImage = null;
			this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
			this.MinimizeButton.TabIndex = 2;
			this.MinimizeButton.TabStop = false;
			// 
			// StateButton
			// 
			this.StateButton.HoverImage = null;
			this.StateButton.Image = null;
			this.StateButton.Location = new System.Drawing.Point(730, 5);
			this.StateButton.Name = "StateButton";
			this.StateButton.PressImage = null;
			this.StateButton.Size = new System.Drawing.Size(30, 30);
			this.StateButton.TabIndex = 1;
			this.StateButton.TabStop = false;
			// 
			// ExitButton
			// 
			this.ExitButton.HoverImage = null;
			this.ExitButton.Image = null;
			this.ExitButton.Location = new System.Drawing.Point(765, 5);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.PressImage = null;
			this.ExitButton.Size = new System.Drawing.Size(30, 30);
			this.ExitButton.TabIndex = 0;
			this.ExitButton.TabStop = false;
			// 
			// Form
			// 
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.Header);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Modern Desktop - Application";
			this.Header.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StateButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.Panel Header;
		private PictureBox ExitButton;
		private PictureBox MinimizeButton;
		private PictureBox StateButton;
		private Label Title;
	}
}
