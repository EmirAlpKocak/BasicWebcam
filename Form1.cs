using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Basic_Webcam
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection cameras;
        private VideoCaptureDevice captureDevice;
        private bool mirrorEnabled = true;
        private bool isBorderlessModeEnabled = false;
        private volatile bool isClosing = false;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCameras();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            }
        }
        private void LoadCameras()
        {
            comboBox1.Items.Clear();
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (cameras.Count == 0)
            {
                MessageBox.Show("No camera devices found. Please connect a camera and try again.", "No Camera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = false;
                return;
            }
            
            foreach (FilterInfo camera in cameras)
            {
                comboBox1.Items.Add(camera.Name);
            }
            comboBox1.SelectedIndex = 0;
            button1.Enabled = true;
        }
        private void source_content(object sender, NewFrameEventArgs e)
        {
            if (isClosing || pictureBox1.IsDisposed || !pictureBox1.IsHandleCreated) return;

            Bitmap frame = null;
            try
            {
                frame = (Bitmap)e.Frame.Clone();

                if (mirrorEnabled)
                {
                    frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                pictureBox1.BeginInvoke((MethodInvoker)delegate
                {
                    if (isClosing || pictureBox1.IsDisposed)
                    {
                        frame.Dispose();
                        return;
                    }
                    Image oldImage = pictureBox1.Image;
                    pictureBox1.Image = frame;
                    oldImage?.Dispose();
                });
            }
            catch
            {
                frame?.Dispose();
            }
        }
        private void StopCamera()
        {
            if (captureDevice != null)
            {
                captureDevice.NewFrame -= source_content;
                if (captureDevice.IsRunning)
                {
                    captureDevice.SignalToStop();
                    captureDevice.WaitForStop();
                }
            }
        }
        private void Form1_FormClosing(object sender, EventArgs e)
        {
            isClosing = true;
            StopCamera();
            if (pictureBox1?.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void takePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            using (Bitmap snapshot = new Bitmap(pictureBox1.Image))
            {
                saveFileDialog1.FileName = $"Webcam_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        snapshot.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to save picture. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            StopCamera();
            captureDevice = null;
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = null;

            label1.Show();
            comboBox1.Show();
            button1.Show();
            LoadCameras();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startStopCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (captureDevice == null) return;

            try
            {
                if (captureDevice.IsRunning)
                {
                    StopCamera();
                }
                else
                {
                    captureDevice.NewFrame += source_content;
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
            string aboutText =
        "BasicWebcam  •  v1.3.0\n" +
        "Lightweight Desktop Camera Viewer\n" +
        "──────────────────────────────\n" +
        "Developer:   Emir Alp Koçak\n" +
        "Website:      deuteriumsoftware.com\n" +
        "Contact:      info@deuteriumsoftware.com\n\n" +
        "Copyright © 2026 Deuterium Software";

            MessageBox.Show(
                aboutText,
                "About BasicWebcam",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://deuteriumsoftware.com/contact"
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0) return;

            try
            {
                StopCamera();
                captureDevice = new VideoCaptureDevice(cameras[comboBox1.SelectedIndex].MonikerString);

                if (captureDevice.VideoCapabilities.Length > 0)
                {
                    captureDevice.VideoResolution = captureDevice.VideoCapabilities[0];
                }

                captureDevice.NewFrame += source_content;
                captureDevice.Start();

                comboBox1.Hide();
                label1.Hide();
                button1.Hide();
            }
            catch(Exception ex )
            {
                MessageBox.Show("Cannot access camera device. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enableMirroringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableMirroringToolStripMenuItem.Checked)
            {
                mirrorEnabled = true;
            }
            else
            {
                mirrorEnabled = false;
            }
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://deuteriumsoftware.com/contact");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://deuteriumsoftware.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    const string currentVersion = "v1.3.0";
                    const string webUrl = "https://raw.githubusercontent.com/EmirAlpKocak/BasicWebcam/refs/heads/main/cameraver.txt";
                    string downloadedVersion = client.DownloadString(webUrl);
                    if (downloadedVersion.Trim() != currentVersion)
                    {
                        if (MessageBox.Show($"Version {downloadedVersion.Trim()} is available. Do you want to visit the download page?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Process.Start("https://deuteriumsoftware.com/software/basicwebcam/");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No new versions available.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cameraPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (captureDevice == null)
            {
                MessageBox.Show("Please start a camera first.", "Camera Properties", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                captureDevice.DisplayPropertyPage(this.Handle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("This camera does not support driver properties. Error: " + ex.Message, "Camera Properties", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            isBorderlessModeEnabled = !isBorderlessModeEnabled;

            if (isBorderlessModeEnabled)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = enableCompactViewToolStripMenuItem.Checked
                    ? FormBorderStyle.SizableToolWindow
                    : FormBorderStyle.Sizable;
            }
        }
    }
}