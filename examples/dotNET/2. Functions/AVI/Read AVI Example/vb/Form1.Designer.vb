Partial Class Form1
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.exitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(8, 7)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(534, 320)
        Me.imageViewer1.TabIndex = 0
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(8, 341)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(534, 36)
        Me.progressBar1.TabIndex = 1
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'timer1
        '
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(432, 388)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(110, 36)
        Me.exitButton.TabIndex = 2
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 455)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Read AVI Example"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private progressBar1 As System.Windows.Forms.ProgressBar
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents exitButton As System.Windows.Forms.Button
End Class
