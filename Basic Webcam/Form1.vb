Public Class Form1
    Public Touchless As New TouchlessLib.TouchlessMgr
    Public Camera1 As TouchlessLib.camera = Touchless.Cameras.Item(0)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Touchless.CurrentCamera = Camera1
        Touchless.CurrentCamera.CaptureHeight = 480
        Touchless.CurrentCamera.CaptureWidth = 640
        Timer1.Start()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim originalImage As Image = Touchless.CurrentCamera.GetCurrentImage()
        If originalImage IsNot Nothing Then
            Dim mirroredBitmap As New Bitmap(originalImage.Width, originalImage.Height)
            Dim g As Graphics = Graphics.FromImage(mirroredBitmap)
            g.ScaleTransform(-1, 1)
            g.TranslateTransform(-originalImage.Width, 0)
            g.DrawImage(originalImage, New Point(0, 0))
            PictureBox1.Image = mirroredBitmap
            g.Dispose()
        End If
    End Sub
    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Basic Webcam 1.1 - Coded By: Emir Alp Koçak - emiralpkocak@gmail.com", MsgBoxStyle.DefaultButton1, "About")
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub TakePhotoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakePhotoToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image.Save(SaveFileDialog1.FileName)
        End If
    End Sub
    Private Sub EnableAlwaysOnTopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableAlwaysOnTopToolStripMenuItem.Click
        If EnableAlwaysOnTopToolStripMenuItem.Checked = False Then
            Me.TopMost = False
        Else
            Me.TopMost = True
        End If
    End Sub

    Private Sub EnableSmallerViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableSmallerViewToolStripMenuItem.Click
        If EnableSmallerViewToolStripMenuItem.Checked = False Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        End If
    End Sub
End Class
