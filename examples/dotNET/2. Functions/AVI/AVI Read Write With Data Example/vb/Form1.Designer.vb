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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.browseButton = New System.Windows.Forms.Button
        Me.Path = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.stopButton = New System.Windows.Forms.Button
        Me.QuitButton = New System.Windows.Forms.Button
        Me.startButton = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.statusLabel = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(203, 279)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(57, 25)
        Me.browseButton.TabIndex = 18
        Me.browseButton.Text = "&Browse"
        '
        'Path
        '
        Me.Path.Location = New System.Drawing.Point(35, 305)
        Me.Path.MaxLength = 0
        Me.Path.Name = "Path"
        Me.Path.Size = New System.Drawing.Size(225, 20)
        Me.Path.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(-118, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(96, 14)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Path to Output AVI"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(322, 391)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 80)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(322, 343)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 41)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "2. Click Start. The sample Images, waveforms, and time stamps are acquired and sa" & _
            "ved to the AVI during the Writing phase."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(322, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 41)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "1. Select the path to save the AVI to.  The AVI you create has sample data associ" & _
            "ated with each image."
        '
        'stopButton
        '
        Me.stopButton.Enabled = False
        Me.stopButton.Location = New System.Drawing.Point(27, 382)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(57, 25)
        Me.stopButton.TabIndex = 22
        Me.stopButton.Text = "S&top"
        Me.stopButton.UseVisualStyleBackColor = False
        '
        'QuitButton
        '
        Me.QuitButton.Location = New System.Drawing.Point(27, 413)
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(57, 25)
        Me.QuitButton.TabIndex = 21
        Me.QuitButton.Text = "&Quit"
        Me.QuitButton.UseVisualStyleBackColor = False
        '
        'startButton
        '
        Me.startButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.startButton.Location = New System.Drawing.Point(27, 350)
        Me.startButton.Name = "startButton"
        Me.startButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.startButton.Size = New System.Drawing.Size(57, 25)
        Me.startButton.TabIndex = 20
        Me.startButton.Text = "&Start"
        Me.startButton.UseVisualStyleBackColor = False
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(32, 285)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(109, 13)
        Me.label6.TabIndex = 24
        Me.label6.Text = "Selected Path for AVI"
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(16, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(546, 261)
        Me.imageViewer1.TabIndex = 25
        '
        'statusLabel
        '
        Me.statusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusLabel.Location = New System.Drawing.Point(13, 486)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(553, 46)
        Me.statusLabel.TabIndex = 26
        '
        'timer1
        '
        Me.timer1.Interval = 30
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 541)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.QuitButton)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.Path)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AVI Read Write With Data Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public WithEvents browseButton As System.Windows.Forms.Button
    Public Path As System.Windows.Forms.TextBox
    Public Label1 As System.Windows.Forms.Label
    Public Label4 As System.Windows.Forms.Label
    Public Label3 As System.Windows.Forms.Label
    Public Label2 As System.Windows.Forms.Label
    Public WithEvents stopButton As System.Windows.Forms.Button
    Public WithEvents QuitButton As System.Windows.Forms.Button
    Public WithEvents startButton As System.Windows.Forms.Button
    Private label6 As System.Windows.Forms.Label
    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private statusLabel As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class