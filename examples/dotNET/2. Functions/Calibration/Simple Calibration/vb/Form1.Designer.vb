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
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.calibrationOriginPixelY = New System.Windows.Forms.TextBox
        Me.calibrationOriginPixelX = New System.Windows.Forms.TextBox
        Me.calibrationAxisReference = New System.Windows.Forms.TextBox
        Me.calibrationAngle = New System.Windows.Forms.TextBox
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.label10 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.groupBox5 = New System.Windows.Forms.GroupBox
        Me.label7 = New System.Windows.Forms.Label
        Me.measurementsCalibratedY = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.measurementsCalibratedX = New System.Windows.Forms.TextBox
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.label6 = New System.Windows.Forms.Label
        Me.measurementsPixelY = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.measurementsPixelX = New System.Windows.Forms.TextBox
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.quitButton = New System.Windows.Forms.Button
        Me.DelaySlide = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(486, 410)
        Me.imageViewer1.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.groupBox2)
        Me.groupBox1.Controls.Add(Me.calibrationAxisReference)
        Me.groupBox1.Controls.Add(Me.calibrationAngle)
        Me.groupBox1.Location = New System.Drawing.Point(504, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(311, 93)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Calibration Axis Info"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(166, 64)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(82, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Axis Reference:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(87, 41)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(161, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Angle relative to horizontal (deg):"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.label1)
        Me.groupBox2.Controls.Add(Me.calibrationOriginPixelY)
        Me.groupBox2.Controls.Add(Me.calibrationOriginPixelX)
        Me.groupBox2.Location = New System.Drawing.Point(6, 19)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(78, 68)
        Me.groupBox2.TabIndex = 0
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Origin Pixel"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(17, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Y:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(17, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "X:"
        '
        'calibrationOriginPixelY
        '
        Me.calibrationOriginPixelY.Location = New System.Drawing.Point(32, 42)
        Me.calibrationOriginPixelY.Name = "calibrationOriginPixelY"
        Me.calibrationOriginPixelY.ReadOnly = True
        Me.calibrationOriginPixelY.Size = New System.Drawing.Size(38, 20)
        Me.calibrationOriginPixelY.TabIndex = 0
        '
        'calibrationOriginPixelX
        '
        Me.calibrationOriginPixelX.Location = New System.Drawing.Point(32, 19)
        Me.calibrationOriginPixelX.Name = "calibrationOriginPixelX"
        Me.calibrationOriginPixelX.ReadOnly = True
        Me.calibrationOriginPixelX.Size = New System.Drawing.Size(38, 20)
        Me.calibrationOriginPixelX.TabIndex = 0
        '
        'calibrationAxisReference
        '
        Me.calibrationAxisReference.Location = New System.Drawing.Point(254, 61)
        Me.calibrationAxisReference.Name = "calibrationAxisReference"
        Me.calibrationAxisReference.ReadOnly = True
        Me.calibrationAxisReference.Size = New System.Drawing.Size(51, 20)
        Me.calibrationAxisReference.TabIndex = 0
        '
        'calibrationAngle
        '
        Me.calibrationAngle.Location = New System.Drawing.Point(254, 38)
        Me.calibrationAngle.Name = "calibrationAngle"
        Me.calibrationAngle.ReadOnly = True
        Me.calibrationAngle.Size = New System.Drawing.Size(51, 20)
        Me.calibrationAngle.TabIndex = 0
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.label10)
        Me.groupBox3.Controls.Add(Me.label9)
        Me.groupBox3.Controls.Add(Me.groupBox5)
        Me.groupBox3.Controls.Add(Me.groupBox4)
        Me.groupBox3.Location = New System.Drawing.Point(504, 119)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(310, 168)
        Me.groupBox3.TabIndex = 2
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Measurements"
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(158, 113)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(146, 31)
        Me.label10.TabIndex = 1
        Me.label10.Text = "Location of the fiducial in the local coordinate system"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(158, 39)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(146, 27)
        Me.label9.TabIndex = 1
        Me.label9.Text = "Location of the fiducial in the image coordinate system"
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.label7)
        Me.groupBox5.Controls.Add(Me.measurementsCalibratedY)
        Me.groupBox5.Controls.Add(Me.label8)
        Me.groupBox5.Controls.Add(Me.measurementsCalibratedX)
        Me.groupBox5.Location = New System.Drawing.Point(6, 93)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(134, 68)
        Me.groupBox5.TabIndex = 0
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = "Calibrated Coordinates"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(9, 43)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(17, 13)
        Me.label7.TabIndex = 1
        Me.label7.Text = "Y:"
        '
        'measurementsCalibratedY
        '
        Me.measurementsCalibratedY.Location = New System.Drawing.Point(32, 40)
        Me.measurementsCalibratedY.Name = "measurementsCalibratedY"
        Me.measurementsCalibratedY.ReadOnly = True
        Me.measurementsCalibratedY.Size = New System.Drawing.Size(38, 20)
        Me.measurementsCalibratedY.TabIndex = 0
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(9, 20)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(17, 13)
        Me.label8.TabIndex = 1
        Me.label8.Text = "X:"
        '
        'measurementsCalibratedX
        '
        Me.measurementsCalibratedX.Location = New System.Drawing.Point(32, 17)
        Me.measurementsCalibratedX.Name = "measurementsCalibratedX"
        Me.measurementsCalibratedX.ReadOnly = True
        Me.measurementsCalibratedX.Size = New System.Drawing.Size(38, 20)
        Me.measurementsCalibratedX.TabIndex = 0
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.label6)
        Me.groupBox4.Controls.Add(Me.measurementsPixelY)
        Me.groupBox4.Controls.Add(Me.label5)
        Me.groupBox4.Controls.Add(Me.measurementsPixelX)
        Me.groupBox4.Location = New System.Drawing.Point(6, 19)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(134, 68)
        Me.groupBox4.TabIndex = 0
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Pixel Coordinates"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(9, 43)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(17, 13)
        Me.label6.TabIndex = 1
        Me.label6.Text = "Y:"
        '
        'measurementsPixelY
        '
        Me.measurementsPixelY.Location = New System.Drawing.Point(32, 40)
        Me.measurementsPixelY.Name = "measurementsPixelY"
        Me.measurementsPixelY.ReadOnly = True
        Me.measurementsPixelY.Size = New System.Drawing.Size(38, 20)
        Me.measurementsPixelY.TabIndex = 0
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(9, 20)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(17, 13)
        Me.label5.TabIndex = 1
        Me.label5.Text = "X:"
        '
        'measurementsPixelX
        '
        Me.measurementsPixelX.Location = New System.Drawing.Point(32, 17)
        Me.measurementsPixelX.Name = "measurementsPixelX"
        Me.measurementsPixelX.ReadOnly = True
        Me.measurementsPixelX.Size = New System.Drawing.Size(38, 20)
        Me.measurementsPixelX.TabIndex = 0
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(759, 389)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(56, 33)
        Me.quitButton.TabIndex = 4
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'DelaySlide
        '
        Me.DelaySlide.AutoSize = True
        Me.DelaySlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlide.Location = New System.Drawing.Point(504, 293)
        Me.DelaySlide.Maximum = 1500
        Me.DelaySlide.Name = "DelaySlide"
        Me.DelaySlide.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlide.TabIndex = 5
        Me.DelaySlide.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 434)
        Me.Controls.Add(Me.DelaySlide)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Simple Calibration Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private calibrationOriginPixelY As System.Windows.Forms.TextBox
    Private calibrationOriginPixelX As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private calibrationAxisReference As System.Windows.Forms.TextBox
    Private calibrationAngle As System.Windows.Forms.TextBox
    Private groupBox3 As System.Windows.Forms.GroupBox
    Private groupBox5 As System.Windows.Forms.GroupBox
    Private label7 As System.Windows.Forms.Label
    Private measurementsCalibratedY As System.Windows.Forms.TextBox
    Private label8 As System.Windows.Forms.Label
    Private measurementsCalibratedX As System.Windows.Forms.TextBox
    Private groupBox4 As System.Windows.Forms.GroupBox
    Private label6 As System.Windows.Forms.Label
    Private measurementsPixelY As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private measurementsPixelX As System.Windows.Forms.TextBox
    Private label10 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents DelaySlide As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class