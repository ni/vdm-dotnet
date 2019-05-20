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
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.distanceBox = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.radiusBox = New System.Windows.Forms.TextBox
        Me.centerYBox = New System.Windows.Forms.TextBox
        Me.centerXBox = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.defineCoordinateSystemButton = New System.Windows.Forms.Button
        Me.defineMeasurementsButton = New System.Windows.Forms.Button
        Me.runButton = New System.Windows.Forms.Button
        Me.label10 = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.quitButton = New System.Windows.Forms.Button
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(622, 436)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(643, 29)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(247, 237)
        Me.imageViewer2.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(640, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(142, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Coordinate System Template"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.distanceBox)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.groupBox2)
        Me.groupBox1.Location = New System.Drawing.Point(643, 284)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(246, 128)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Results"
        '
        'distanceBox
        '
        Me.distanceBox.Location = New System.Drawing.Point(199, 33)
        Me.distanceBox.Name = "distanceBox"
        Me.distanceBox.ReadOnly = True
        Me.distanceBox.Size = New System.Drawing.Size(41, 20)
        Me.distanceBox.TabIndex = 2
        Me.distanceBox.Text = "0.00"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(145, 36)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 1
        Me.label6.Text = "Distance:"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.radiusBox)
        Me.groupBox2.Controls.Add(Me.centerYBox)
        Me.groupBox2.Controls.Add(Me.centerXBox)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(11, 18)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(128, 100)
        Me.groupBox2.TabIndex = 0
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Best Circle"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(18, 64)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(43, 13)
        Me.label5.TabIndex = 3
        Me.label5.Text = "Radius:"
        '
        'radiusBox
        '
        Me.radiusBox.Location = New System.Drawing.Point(67, 61)
        Me.radiusBox.Name = "radiusBox"
        Me.radiusBox.ReadOnly = True
        Me.radiusBox.Size = New System.Drawing.Size(55, 20)
        Me.radiusBox.TabIndex = 2
        Me.radiusBox.Text = "0.00"
        '
        'centerYBox
        '
        Me.centerYBox.Location = New System.Drawing.Point(67, 37)
        Me.centerYBox.Name = "centerYBox"
        Me.centerYBox.ReadOnly = True
        Me.centerYBox.Size = New System.Drawing.Size(55, 20)
        Me.centerYBox.TabIndex = 2
        Me.centerYBox.Text = "0.00"
        '
        'centerXBox
        '
        Me.centerXBox.Location = New System.Drawing.Point(67, 15)
        Me.centerXBox.Name = "centerXBox"
        Me.centerXBox.ReadOnly = True
        Me.centerXBox.Size = New System.Drawing.Size(55, 20)
        Me.centerXBox.TabIndex = 2
        Me.centerXBox.Text = "0.00"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(44, 40)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(17, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Y:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(44, 18)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(17, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "X:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(41, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Center "
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(10, 455)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(64, 13)
        Me.label7.TabIndex = 4
        Me.label7.Text = "Instructions:"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(10, 470)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(455, 13)
        Me.label8.TabIndex = 4
        Me.label8.Text = "1. Click Define Coordinate System to load a template image that is matched in eac" & _
            "h new image."
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(9, 502)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(359, 13)
        Me.label9.TabIndex = 4
        Me.label9.Text = "2. Click Define Measurements to define the regions of interest in the image."
        '
        'defineCoordinateSystemButton
        '
        Me.defineCoordinateSystemButton.Location = New System.Drawing.Point(494, 464)
        Me.defineCoordinateSystemButton.Name = "defineCoordinateSystemButton"
        Me.defineCoordinateSystemButton.Size = New System.Drawing.Size(140, 25)
        Me.defineCoordinateSystemButton.TabIndex = 5
        Me.defineCoordinateSystemButton.Text = "Define Coordinate System"
        Me.defineCoordinateSystemButton.UseVisualStyleBackColor = True
        '
        'defineMeasurementsButton
        '
        Me.defineMeasurementsButton.Enabled = False
        Me.defineMeasurementsButton.Location = New System.Drawing.Point(494, 496)
        Me.defineMeasurementsButton.Name = "defineMeasurementsButton"
        Me.defineMeasurementsButton.Size = New System.Drawing.Size(140, 25)
        Me.defineMeasurementsButton.TabIndex = 5
        Me.defineMeasurementsButton.Text = "Define Measurements"
        Me.defineMeasurementsButton.UseVisualStyleBackColor = True
        '
        'runButton
        '
        Me.runButton.Enabled = False
        Me.runButton.Location = New System.Drawing.Point(494, 528)
        Me.runButton.Name = "runButton"
        Me.runButton.Size = New System.Drawing.Size(140, 25)
        Me.runButton.TabIndex = 5
        Me.runButton.Text = "Run"
        Me.runButton.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(9, 534)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(479, 32)
        Me.label10.TabIndex = 4
        Me.label10.Text = "3. Click Run.  The example loads a new image, finds the new coordinate system by " & _
            "matching the pattern, adjusts the regions of interest, and returns the results."
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(822, 536)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(68, 31)
        Me.quitButton.TabIndex = 8
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(643, 418)
        Me.DelaySlider1.Maximum = 2000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 9
        Me.DelaySlider1.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 575)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.runButton)
        Me.Controls.Add(Me.defineMeasurementsButton)
        Me.Controls.Add(Me.defineCoordinateSystemButton)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Battery Clamp Inspection Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private centerYBox As System.Windows.Forms.TextBox
    Private centerXBox As System.Windows.Forms.TextBox
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private radiusBox As System.Windows.Forms.TextBox
    Private distanceBox As System.Windows.Forms.TextBox
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private WithEvents defineCoordinateSystemButton As System.Windows.Forms.Button
    Private WithEvents defineMeasurementsButton As System.Windows.Forms.Button
    Private WithEvents runButton As System.Windows.Forms.Button
    Private label10 As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class