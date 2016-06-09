namespace MaterialAPI
{
	public partial class Form
	{
		private void InitializeComponent()
		{
			this.Header = new System.Windows.Forms.Panel();
			this.Title = new MaterialAPI.Label();
			this.MinimizeButton = new MaterialAPI.PictureBox();
			this.StateButton = new MaterialAPI.PictureBox();
			this.ExitButton = new MaterialAPI.PictureBox();
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
			this.Header.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StateButton_MouseClick);
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
			this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MinimizeButton.HoverImage = global::MaterialAPI.Properties.Resources.Form_Minimize_Hover;
			this.MinimizeButton.Image = global::MaterialAPI.Properties.Resources.Form_Minimize_Default;
			this.MinimizeButton.Location = new System.Drawing.Point(695, 5);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.PressImage = global::MaterialAPI.Properties.Resources.Form_Minimize_Press;
			this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
			this.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.MinimizeButton.TabIndex = 2;
			this.MinimizeButton.TabStop = false;
			this.MinimizeButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseClick);
			// 
			// StateButton
			// 
			this.StateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.StateButton.HoverImage = global::MaterialAPI.Properties.Resources.Form_State_Hover;
			this.StateButton.Image = global::MaterialAPI.Properties.Resources.Form_State_Default;
			this.StateButton.Location = new System.Drawing.Point(730, 5);
			this.StateButton.Name = "StateButton";
			this.StateButton.PressImage = global::MaterialAPI.Properties.Resources.Form_State_Press;
			this.StateButton.Size = new System.Drawing.Size(30, 30);
			this.StateButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.StateButton.TabIndex = 1;
			this.StateButton.TabStop = false;
			this.StateButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StateButton_MouseClick);
			// 
			// ExitButton
			// 
			this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExitButton.HoverImage = global::MaterialAPI.Properties.Resources.Form_Exit_Hover;
			this.ExitButton.Image = global::MaterialAPI.Properties.Resources.Form_Exit_Default;
			this.ExitButton.Location = new System.Drawing.Point(765, 5);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.PressImage = global::MaterialAPI.Properties.Resources.Form_Exit_Press;
			this.ExitButton.Size = new System.Drawing.Size(30, 30);
			this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ExitButton.TabIndex = 0;
			this.ExitButton.TabStop = false;
			this.ExitButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseClick);
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
		private MaterialAPI.Label Title;
	}
}
