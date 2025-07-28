using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Basic_Webcam
{
    public partial class Form1 : Form
    {
        public FilterInfoCollection cameras;
        private VideoCaptureDevice captureDevice;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach(FilterInfo camera in cameras)
                {
                    comboBox1.Items.Add(camera);
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot find a camera device. Please check if your camera is connected and required drivers are installed. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void source_content(object sender, NewFrameEventArgs e)
        {
            Bitmap content = (Bitmap)e.Frame.Clone();
            Bitmap mirrored = new Bitmap(content.Width, content.Height);
            using (Graphics graphic = Graphics.FromImage(mirrored))
            {
                graphic.TranslateTransform(content.Width, 0);
                graphic.ScaleTransform(-1, 1);
                graphic.DrawImage(content, 0, 0);
            }
            pictureBox1.Image = mirrored;
            content.Dispose();
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                    Application.Exit();
                    Environment.Exit(0);
                }
                Application.Exit();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void takePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Photo saved to: " + saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save picture. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void enableAlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableAlwaysOnTopToolStripMenuItem.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void enableCompactViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableCompactViewToolStripMenuItem.Checked)
            {
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void selectCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
            pictureBox1.Image = null;
            label1.Show();
            comboBox1.Show();
            button1.Show();
            comboBox1.Items.Clear();
            try
            {
                cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo camera in cameras)
                {
                    comboBox1.Items.Add(camera);
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot find a camera device. Please check if your camera is connected and required drivers are installed. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                    Application.Exit();
                    Environment.Exit(0);
                }
                Application.Exit();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void startStopCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
                else
                {
                    captureDevice.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot access camera device. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Basic Webcam v1.2.0 - Coded By: Emir Alp Koçak", "About");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                captureDevice = new VideoCaptureDevice();
                captureDevice = new VideoCaptureDevice(cameras[comboBox1.SelectedIndex].MonikerString);
                captureDevice.NewFrame += new NewFrameEventHandler(source_content);
                captureDevice.Start();
                comboBox1.Hide();
                label1.Hide();
                button1.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot access camera device. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
