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
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.processButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.numberOfParticles = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.orientation = New System.Windows.Forms.TextBox
        Me.label20 = New System.Windows.Forms.Label
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.heightBox = New System.Windows.Forms.TextBox
        Me.label21 = New System.Windows.Forms.Label
        Me.widthBox = New System.Windows.Forms.TextBox
        Me.label22 = New System.Windows.Forms.Label
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.centerOfMassY = New System.Windows.Forms.TextBox
        Me.label19 = New System.Windows.Forms.Label
        Me.centerOfMassX = New System.Windows.Forms.TextBox
        Me.label18 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label17 = New System.Windows.Forms.Label
        Me.label16 = New System.Windows.Forms.Label
        Me.label15 = New System.Windows.Forms.Label
        Me.label14 = New System.Windows.Forms.Label
        Me.boundingRectBottom = New System.Windows.Forms.TextBox
        Me.boundingRectRight = New System.Windows.Forms.TextBox
        Me.boundingRectTop = New System.Windows.Forms.TextBox
        Me.boundingRectLeft = New System.Windows.Forms.TextBox
        Me.numberOfHoles = New System.Windows.Forms.TextBox
        Me.label13 = New System.Windows.Forms.Label
        Me.area = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.minimumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.maximumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.connectivitySwitch = New NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch
        Me.reportIndex = New System.Windows.Forms.NumericUpDown
        Me.groupBox1.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.reportIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(8, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(132, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Demonstration Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(11, 22)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(175, 20)
        Me.imagePath.TabIndex = 1
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(192, 22)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(51, 20)
        Me.browseButton.TabIndex = 2
        Me.browseButton.Text = "Browse"
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(11, 51)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(93, 31)
        Me.loadImageButton.TabIndex = 3
        Me.loadImageButton.Text = "Load Image File"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'processButton
        '
        Me.processButton.Enabled = False
        Me.processButton.Location = New System.Drawing.Point(11, 88)
        Me.processButton.Name = "processButton"
        Me.processButton.Size = New System.Drawing.Size(93, 31)
        Me.processButton.TabIndex = 3
        Me.processButton.Text = "Process"
        Me.processButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(11, 125)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(93, 31)
        Me.exitButton.TabIndex = 3
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(119, 51)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(123, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "1. Click Load Image File."
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(119, 69)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(123, 30)
        Me.label3.TabIndex = 4
        Me.label3.Text = "2. Threshold the image, and get the particles."
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(256, 4)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(89, 13)
        Me.label4.TabIndex = 5
        Me.label4.Text = "Threshold Values"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(275, 24)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(78, 13)
        Me.label5.TabIndex = 8
        Me.label5.Text = "Minimum Value"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(275, 109)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(81, 13)
        Me.label6.TabIndex = 8
        Me.label6.Text = "Maximum Value"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(275, 186)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(65, 13)
        Me.label7.TabIndex = 10
        Me.label7.Text = "Connectivity"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(346, 220)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(74, 13)
        Me.label8.TabIndex = 10
        Me.label8.Text = "Connectivity-8"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(346, 249)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(74, 13)
        Me.label9.TabIndex = 10
        Me.label9.Text = "Connectivity-4"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(8, 214)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(102, 13)
        Me.label10.TabIndex = 11
        Me.label10.Text = "# of Particles Found"
        '
        'numberOfParticles
        '
        Me.numberOfParticles.Location = New System.Drawing.Point(116, 211)
        Me.numberOfParticles.Name = "numberOfParticles"
        Me.numberOfParticles.Size = New System.Drawing.Size(43, 20)
        Me.numberOfParticles.TabIndex = 12
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.orientation)
        Me.groupBox1.Controls.Add(Me.label20)
        Me.groupBox1.Controls.Add(Me.groupBox4)
        Me.groupBox1.Controls.Add(Me.groupBox3)
        Me.groupBox1.Controls.Add(Me.groupBox2)
        Me.groupBox1.Controls.Add(Me.numberOfHoles)
        Me.groupBox1.Controls.Add(Me.label13)
        Me.groupBox1.Controls.Add(Me.area)
        Me.groupBox1.Controls.Add(Me.label12)
        Me.groupBox1.Location = New System.Drawing.Point(61, 240)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(220, 250)
        Me.groupBox1.TabIndex = 14
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Particle Reports (pixels)"
        '
        'orientation
        '
        Me.orientation.Location = New System.Drawing.Point(118, 135)
        Me.orientation.Name = "orientation"
        Me.orientation.Size = New System.Drawing.Size(63, 20)
        Me.orientation.TabIndex = 5
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(113, 113)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(58, 13)
        Me.label20.TabIndex = 4
        Me.label20.Text = "Orientation"
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.heightBox)
        Me.groupBox4.Controls.Add(Me.label21)
        Me.groupBox4.Controls.Add(Me.widthBox)
        Me.groupBox4.Controls.Add(Me.label22)
        Me.groupBox4.Location = New System.Drawing.Point(110, 161)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(104, 76)
        Me.groupBox4.TabIndex = 3
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Dimensions"
        '
        'heightBox
        '
        Me.heightBox.Location = New System.Drawing.Point(6, 45)
        Me.heightBox.Name = "heightBox"
        Me.heightBox.Size = New System.Drawing.Size(55, 20)
        Me.heightBox.TabIndex = 0
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(67, 48)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(38, 13)
        Me.label21.TabIndex = 1
        Me.label21.Text = "Height"
        '
        'widthBox
        '
        Me.widthBox.Location = New System.Drawing.Point(6, 19)
        Me.widthBox.Name = "widthBox"
        Me.widthBox.Size = New System.Drawing.Size(55, 20)
        Me.widthBox.TabIndex = 0
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(67, 22)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(35, 13)
        Me.label22.TabIndex = 1
        Me.label22.Text = "Width"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.centerOfMassY)
        Me.groupBox3.Controls.Add(Me.label19)
        Me.groupBox3.Controls.Add(Me.centerOfMassX)
        Me.groupBox3.Controls.Add(Me.label18)
        Me.groupBox3.Location = New System.Drawing.Point(110, 31)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(104, 76)
        Me.groupBox3.TabIndex = 3
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Center of Mass"
        '
        'centerOfMassY
        '
        Me.centerOfMassY.Location = New System.Drawing.Point(6, 45)
        Me.centerOfMassY.Name = "centerOfMassY"
        Me.centerOfMassY.Size = New System.Drawing.Size(65, 20)
        Me.centerOfMassY.TabIndex = 0
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Location = New System.Drawing.Point(75, 48)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(14, 13)
        Me.label19.TabIndex = 1
        Me.label19.Text = "Y"
        '
        'centerOfMassX
        '
        Me.centerOfMassX.Location = New System.Drawing.Point(6, 19)
        Me.centerOfMassX.Name = "centerOfMassX"
        Me.centerOfMassX.Size = New System.Drawing.Size(65, 20)
        Me.centerOfMassX.TabIndex = 0
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(75, 22)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(14, 13)
        Me.label18.TabIndex = 1
        Me.label18.Text = "X"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label17)
        Me.groupBox2.Controls.Add(Me.label16)
        Me.groupBox2.Controls.Add(Me.label15)
        Me.groupBox2.Controls.Add(Me.label14)
        Me.groupBox2.Controls.Add(Me.boundingRectBottom)
        Me.groupBox2.Controls.Add(Me.boundingRectRight)
        Me.groupBox2.Controls.Add(Me.boundingRectTop)
        Me.groupBox2.Controls.Add(Me.boundingRectLeft)
        Me.groupBox2.Location = New System.Drawing.Point(8, 108)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(98, 129)
        Me.groupBox2.TabIndex = 2
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Bounding Rect"
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(55, 100)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(40, 13)
        Me.label17.TabIndex = 1
        Me.label17.Text = "Bottom"
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(55, 74)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(32, 13)
        Me.label16.TabIndex = 1
        Me.label16.Text = "Right"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(55, 48)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(26, 13)
        Me.label15.TabIndex = 1
        Me.label15.Text = "Top"
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(55, 22)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(25, 13)
        Me.label14.TabIndex = 1
        Me.label14.Text = "Left"
        '
        'boundingRectBottom
        '
        Me.boundingRectBottom.Location = New System.Drawing.Point(6, 97)
        Me.boundingRectBottom.Name = "boundingRectBottom"
        Me.boundingRectBottom.Size = New System.Drawing.Size(46, 20)
        Me.boundingRectBottom.TabIndex = 0
        '
        'boundingRectRight
        '
        Me.boundingRectRight.Location = New System.Drawing.Point(6, 71)
        Me.boundingRectRight.Name = "boundingRectRight"
        Me.boundingRectRight.Size = New System.Drawing.Size(46, 20)
        Me.boundingRectRight.TabIndex = 0
        '
        'boundingRectTop
        '
        Me.boundingRectTop.Location = New System.Drawing.Point(6, 45)
        Me.boundingRectTop.Name = "boundingRectTop"
        Me.boundingRectTop.Size = New System.Drawing.Size(46, 20)
        Me.boundingRectTop.TabIndex = 0
        '
        'boundingRectLeft
        '
        Me.boundingRectLeft.Location = New System.Drawing.Point(6, 19)
        Me.boundingRectLeft.Name = "boundingRectLeft"
        Me.boundingRectLeft.Size = New System.Drawing.Size(46, 20)
        Me.boundingRectLeft.TabIndex = 0
        '
        'numberOfHoles
        '
        Me.numberOfHoles.Location = New System.Drawing.Point(6, 77)
        Me.numberOfHoles.Name = "numberOfHoles"
        Me.numberOfHoles.Size = New System.Drawing.Size(47, 20)
        Me.numberOfHoles.TabIndex = 1
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(3, 61)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(86, 13)
        Me.label13.TabIndex = 0
        Me.label13.Text = "Number of Holes"
        '
        'area
        '
        Me.area.Location = New System.Drawing.Point(6, 36)
        Me.area.Name = "area"
        Me.area.Size = New System.Drawing.Size(47, 20)
        Me.area.TabIndex = 1
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(3, 20)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(29, 13)
        Me.label12.TabIndex = 0
        Me.label12.Text = "Area"
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(460, 5)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(327, 229)
        Me.imageViewer1.TabIndex = 15
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(460, 240)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(327, 237)
        Me.imageViewer2.TabIndex = 15
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'minimumSlide
        '
        Me.minimumSlide.AutoSize = True
        Me.minimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.minimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.minimumSlide.Location = New System.Drawing.Point(251, 46)
        Me.minimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.minimumSlide.Name = "minimumSlide"
        Me.minimumSlide.Size = New System.Drawing.Size(203, 53)
        Me.minimumSlide.TabIndex = 16
        Me.minimumSlide.Value = 0
        '
        'maximumSlide
        '
        Me.maximumSlide.AutoSize = True
        Me.maximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.maximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.maximumSlide.Location = New System.Drawing.Point(251, 130)
        Me.maximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.maximumSlide.Name = "maximumSlide"
        Me.maximumSlide.Size = New System.Drawing.Size(203, 53)
        Me.maximumSlide.TabIndex = 16
        Me.maximumSlide.Value = 100
        '
        'connectivitySwitch
        '
        Me.connectivitySwitch.AutoSize = True
        Me.connectivitySwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.connectivitySwitch.Location = New System.Drawing.Point(281, 202)
        Me.connectivitySwitch.Name = "connectivitySwitch"
        Me.connectivitySwitch.Size = New System.Drawing.Size(68, 85)
        Me.connectivitySwitch.TabIndex = 17
        '
        'reportIndex
        '
        Me.reportIndex.Location = New System.Drawing.Point(20, 247)
        Me.reportIndex.Name = "reportIndex"
        Me.reportIndex.Size = New System.Drawing.Size(38, 20)
        Me.reportIndex.TabIndex = 18
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 484)
        Me.Controls.Add(Me.reportIndex)
        Me.Controls.Add(Me.connectivitySwitch)
        Me.Controls.Add(Me.maximumSlide)
        Me.Controls.Add(Me.minimumSlide)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.numberOfParticles)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.processButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Particle Analysis Report Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.reportIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents processButton As System.Windows.Forms.Button
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private numberOfParticles As System.Windows.Forms.TextBox
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label12 As System.Windows.Forms.Label
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private numberOfHoles As System.Windows.Forms.TextBox
    Private label13 As System.Windows.Forms.Label
    Private area As System.Windows.Forms.TextBox
    Private label17 As System.Windows.Forms.Label
    Private label16 As System.Windows.Forms.Label
    Private label15 As System.Windows.Forms.Label
    Private label14 As System.Windows.Forms.Label
    Private boundingRectBottom As System.Windows.Forms.TextBox
    Private boundingRectRight As System.Windows.Forms.TextBox
    Private boundingRectTop As System.Windows.Forms.TextBox
    Private boundingRectLeft As System.Windows.Forms.TextBox
    Private label20 As System.Windows.Forms.Label
    Private groupBox3 As System.Windows.Forms.GroupBox
    Private centerOfMassY As System.Windows.Forms.TextBox
    Private label19 As System.Windows.Forms.Label
    Private centerOfMassX As System.Windows.Forms.TextBox
    Private label18 As System.Windows.Forms.Label
    Private orientation As System.Windows.Forms.TextBox
    Private groupBox4 As System.Windows.Forms.GroupBox
    Private heightBox As System.Windows.Forms.TextBox
    Private label21 As System.Windows.Forms.Label
    Private widthBox As System.Windows.Forms.TextBox
    Private label22 As System.Windows.Forms.Label
    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents minimumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents maximumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents connectivitySwitch As NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch
    Friend WithEvents reportIndex As System.Windows.Forms.NumericUpDown
End Class
