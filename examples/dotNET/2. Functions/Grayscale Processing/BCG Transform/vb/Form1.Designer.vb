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
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.brightnessUpDown = New System.Windows.Forms.NumericUpDown
        Me.contrastUpDown = New System.Windows.Forms.NumericUpDown
        Me.gammaUpDown = New System.Windows.Forms.NumericUpDown
        Me.resetButton = New System.Windows.Forms.Button
        Me.browseButton = New System.Windows.Forms.Button
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.brightnessSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.contrastSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.gammaSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.brightnessUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.contrastUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gammaUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 32)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(516, 269)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(12, 338)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(516, 269)
        Me.imageViewer2.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(9, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(125, 20)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Original Image"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(8, 315)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(165, 20)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Transformed Image"
        '
        'brightnessUpDown
        '
        Me.brightnessUpDown.Location = New System.Drawing.Point(752, 60)
        Me.brightnessUpDown.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.brightnessUpDown.Name = "brightnessUpDown"
        Me.brightnessUpDown.Size = New System.Drawing.Size(54, 20)
        Me.brightnessUpDown.TabIndex = 3
        Me.brightnessUpDown.Value = New Decimal(New Integer() {171, 0, 0, 0})
        '
        'contrastUpDown
        '
        Me.contrastUpDown.Location = New System.Drawing.Point(752, 137)
        Me.contrastUpDown.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.contrastUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.contrastUpDown.Name = "contrastUpDown"
        Me.contrastUpDown.Size = New System.Drawing.Size(54, 20)
        Me.contrastUpDown.TabIndex = 3
        Me.contrastUpDown.Value = New Decimal(New Integer() {56, 0, 0, 0})
        '
        'gammaUpDown
        '
        Me.gammaUpDown.DecimalPlaces = 1
        Me.gammaUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.gammaUpDown.Location = New System.Drawing.Point(752, 214)
        Me.gammaUpDown.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.gammaUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.gammaUpDown.Name = "gammaUpDown"
        Me.gammaUpDown.Size = New System.Drawing.Size(54, 20)
        Me.gammaUpDown.TabIndex = 3
        Me.gammaUpDown.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'resetButton
        '
        Me.resetButton.Location = New System.Drawing.Point(724, 261)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(82, 23)
        Me.resetButton.TabIndex = 4
        Me.resetButton.Text = "Reset Values"
        Me.resetButton.UseVisualStyleBackColor = True
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(781, 328)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(25, 20)
        Me.browseButton.TabIndex = 6
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(537, 328)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(234, 20)
        Me.imagePath.TabIndex = 7
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(534, 312)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(61, 13)
        Me.label4.TabIndex = 8
        Me.label4.Text = "Image Path"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(534, 375)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 13)
        Me.label5.TabIndex = 9
        Me.label5.Text = "Instructions:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(534, 390)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(108, 13)
        Me.label6.TabIndex = 9
        Me.label6.Text = "1. Load an image file."
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(534, 405)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(261, 13)
        Me.label7.TabIndex = 9
        Me.label7.Text = "2. Modify the brightness, contrast, and gamma values."
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(649, 425)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(76, 29)
        Me.loadImageButton.TabIndex = 10
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(731, 425)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(76, 29)
        Me.quitButton.TabIndex = 10
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'brightnessSlide
        '
        Me.brightnessSlide.AutoSize = True
        Me.brightnessSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.brightnessSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.brightnessSlide.Location = New System.Drawing.Point(543, 46)
        Me.brightnessSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.brightnessSlide.Name = "brightnessSlide"
        Me.brightnessSlide.Size = New System.Drawing.Size(203, 53)
        Me.brightnessSlide.TabIndex = 11
        Me.brightnessSlide.Value = 171
        '
        'contrastSlide
        '
        Me.contrastSlide.AutoSize = True
        Me.contrastSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.contrastSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.contrastSlide.Location = New System.Drawing.Point(543, 122)
        Me.contrastSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.OneTo90
        Me.contrastSlide.Name = "contrastSlide"
        Me.contrastSlide.Size = New System.Drawing.Size(203, 53)
        Me.contrastSlide.TabIndex = 11
        Me.contrastSlide.Value = 56
        '
        'gammaSlide
        '
        Me.gammaSlide.AutoSize = True
        Me.gammaSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gammaSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.gammaSlide.Location = New System.Drawing.Point(543, 193)
        Me.gammaSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.OneTo10Log
        Me.gammaSlide.Name = "gammaSlide"
        Me.gammaSlide.Size = New System.Drawing.Size(203, 53)
        Me.gammaSlide.TabIndex = 11
        Me.gammaSlide.Value = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(559, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Brightness"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(556, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Contrast"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(556, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Gamma"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 619)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gammaSlide)
        Me.Controls.Add(Me.contrastSlide)
        Me.Controls.Add(Me.brightnessSlide)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.gammaUpDown)
        Me.Controls.Add(Me.contrastUpDown)
        Me.Controls.Add(Me.brightnessUpDown)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "BCG Transform Example"
        CType(Me.brightnessUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.contrastUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gammaUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private WithEvents brightnessUpDown As System.Windows.Forms.NumericUpDown
    Private WithEvents contrastUpDown As System.Windows.Forms.NumericUpDown
    Private WithEvents gammaUpDown As System.Windows.Forms.NumericUpDown
    Private WithEvents resetButton As System.Windows.Forms.Button
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private imagePath As System.Windows.Forms.TextBox
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents brightnessSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents contrastSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents gammaSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class