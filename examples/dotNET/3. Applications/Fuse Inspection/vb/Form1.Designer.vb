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
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer3 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.defineCoordinateSystemButton = New System.Windows.Forms.Button
        Me.defineTemplatesButton = New System.Windows.Forms.Button
        Me.runButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.imageNumberLabel = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.passOrFail = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(531, 399)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(12, 447)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(123, 104)
        Me.imageViewer2.TabIndex = 1
        '
        'imageViewer3
        '
        Me.imageViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer3.Location = New System.Drawing.Point(12, 581)
        Me.imageViewer3.Name = "imageViewer3"
        Me.imageViewer3.Size = New System.Drawing.Size(123, 104)
        Me.imageViewer3.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 431)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Template Image 1"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 565)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(92, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Template Image 2"
        '
        'defineCoordinateSystemButton
        '
        Me.defineCoordinateSystemButton.Location = New System.Drawing.Point(422, 424)
        Me.defineCoordinateSystemButton.Name = "defineCoordinateSystemButton"
        Me.defineCoordinateSystemButton.Size = New System.Drawing.Size(138, 42)
        Me.defineCoordinateSystemButton.TabIndex = 3
        Me.defineCoordinateSystemButton.Text = "Define Coordinate System"
        Me.defineCoordinateSystemButton.UseVisualStyleBackColor = True
        '
        'defineTemplatesButton
        '
        Me.defineTemplatesButton.Enabled = False
        Me.defineTemplatesButton.Location = New System.Drawing.Point(422, 472)
        Me.defineTemplatesButton.Name = "defineTemplatesButton"
        Me.defineTemplatesButton.Size = New System.Drawing.Size(138, 42)
        Me.defineTemplatesButton.TabIndex = 3
        Me.defineTemplatesButton.Text = "Define Templates"
        Me.defineTemplatesButton.UseVisualStyleBackColor = True
        '
        'runButton
        '
        Me.runButton.Enabled = False
        Me.runButton.Location = New System.Drawing.Point(422, 520)
        Me.runButton.Name = "runButton"
        Me.runButton.Size = New System.Drawing.Size(138, 42)
        Me.runButton.TabIndex = 3
        Me.runButton.Text = "Run"
        Me.runButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(422, 693)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(138, 42)
        Me.quitButton.TabIndex = 3
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.passOrFail)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.imageNumberLabel)
        Me.groupBox1.Location = New System.Drawing.Point(141, 621)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(257, 80)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Results"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(16, 24)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(76, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Image Number"
        '
        'imageNumberLabel
        '
        Me.imageNumberLabel.Location = New System.Drawing.Point(19, 40)
        Me.imageNumberLabel.Name = "imageNumberLabel"
        Me.imageNumberLabel.ReadOnly = True
        Me.imageNumberLabel.Size = New System.Drawing.Size(40, 20)
        Me.imageNumberLabel.TabIndex = 0
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(157, 418)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 13)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Instructions:"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(157, 439)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(241, 44)
        Me.label6.TabIndex = 7
        Me.label6.Text = "1. The example loads an image used to define the coordinate system for the inspec" & _
            "tion task.  Click Define Coordinate System."
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(157, 487)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(241, 64)
        Me.label7.TabIndex = 7
        Me.label7.Text = "2. Click Define Templates.  The example displays two templates containing definin" & _
            "g features of the part.  Two templates are necessary because the part is not sym" & _
            "metric.  Click Run."
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(157, 551)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(241, 64)
        Me.label8.TabIndex = 7
        Me.label8.Text = "3. The example loads a new image, finds the new coordinate system by locating the" & _
            " edges of the fuse, matches the region of inspection against the template images" & _
            ", and returns the results."
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'passOrFail
        '
        Me.passOrFail.Caption = "Pass?"
        Me.passOrFail.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen
        Me.passOrFail.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.passOrFail.Location = New System.Drawing.Point(101, 11)
        Me.passOrFail.Name = "passOrFail"
        Me.passOrFail.Size = New System.Drawing.Size(51, 63)
        Me.passOrFail.TabIndex = 2
        Me.passOrFail.Value = True
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(404, 568)
        Me.DelaySlider1.Maximum = 2000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 8
        Me.DelaySlider1.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 737)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.runButton)
        Me.Controls.Add(Me.defineTemplatesButton)
        Me.Controls.Add(Me.defineCoordinateSystemButton)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer3)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Fuse Inspection Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer3 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private WithEvents defineCoordinateSystemButton As System.Windows.Forms.Button
    Private WithEvents defineTemplatesButton As System.Windows.Forms.Button
    Private WithEvents runButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label4 As System.Windows.Forms.Label
    Private imageNumberLabel As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents passOrFail As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class