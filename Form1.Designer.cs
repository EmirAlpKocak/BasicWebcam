
namespace Basic_Webcam
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableAlwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableCompactViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableAlwaysOnTopToolStripMenuItem,
            this.enableCompactViewToolStripMenuItem,
            this.takePhotoToolStripMenuItem,
            this.selectCameraToolStripMenuItem,
            this.startStopCameraToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 158);
            // 
            // enableAlwaysOnTopToolStripMenuItem
            // 
            this.enableAlwaysOnTopToolStripMenuItem.Checked = true;
            this.enableAlwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.enableAlwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableAlwaysOnTopToolStripMenuItem.Name = "enableAlwaysOnTopToolStripMenuItem";
            this.enableAlwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.enableAlwaysOnTopToolStripMenuItem.Text = "Enable Always on Top";
            this.enableAlwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.enableAlwaysOnTopToolStripMenuItem_Click);
            // 
            // enableCompactViewToolStripMenuItem
            // 
            this.enableCompactViewToolStripMenuItem.CheckOnClick = true;
            this.enableCompactViewToolStripMenuItem.Name = "enableCompactViewToolStripMenuItem";
            this.enableCompactViewToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.enableCompactViewToolStripMenuItem.Text = "Enable Compact View";
            this.enableCompactViewToolStripMenuItem.Click += new System.EventHandler(this.enableCompactViewToolStripMenuItem_Click);
            // 
            // takePhotoToolStripMenuItem
            // 
            this.takePhotoToolStripMenuItem.Name = "takePhotoToolStripMenuItem";
            this.takePhotoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.takePhotoToolStripMenuItem.Text = "Take Photo";
            this.takePhotoToolStripMenuItem.Click += new System.EventHandler(this.takePhotoToolStripMenuItem_Click);
            // 
            // selectCameraToolStripMenuItem
            // 
            this.selectCameraToolStripMenuItem.Name = "selectCameraToolStripMenuItem";
            this.selectCameraToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.selectCameraToolStripMenuItem.Text = "Select Camera";
            this.selectCameraToolStripMenuItem.Click += new System.EventHandler(this.selectCameraToolStripMenuItem_Click);
            // 
            // startStopCameraToolStripMenuItem
            // 
            this.startStopCameraToolStripMenuItem.Name = "startStopCameraToolStripMenuItem";
            this.startStopCameraToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.startStopCameraToolStripMenuItem.Text = "Start/Stop Camera";
            this.startStopCameraToolStripMenuItem.Click += new System.EventHandler(this.startStopCameraToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PNG Files|*.png|All Files|*.*";
            this.saveFileDialog1.Title = "Save Photo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a camera device:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 227);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Webcam";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enableAlwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableCompactViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takePhotoToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem selectCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startStopCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

