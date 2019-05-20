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
        Dim Palette7 As NationalInstruments.Vision.WindowsForms.Palette = New NationalInstruments.Vision.WindowsForms.Palette
        Me.label1 = New System.Windows.Forms.Label
        Me.stepNumber = New System.Windows.Forms.NumericUpDown
        Me.label2 = New System.Windows.Forms.Label
        Me.stepsTextBox = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.imageSelection2 = New System.Windows.Forms.RadioButton
        Me.imageSelection1 = New System.Windows.Forms.RadioButton
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.imageTypeHSL = New System.Windows.Forms.RadioButton
        Me.imageTypeRGB = New System.Windows.Forms.RadioButton
        Me.label3 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label12 = New System.Windows.Forms.Label
        Me.imageViewer2Label = New System.Windows.Forms.Label
        Me.RedMinimumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.RedMaximumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.GreenMinimumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.GreenMaximumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.BlueMinimumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.BlueMaximumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.quitButton = New System.Windows.Forms.Button
        CType(Me.stepNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(9, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(197, 43)
        Me.label1.TabIndex = 0
        Me.label1.Text = "This example illustrates how to use the HSL color space to perform inspection tas" & _
            "ks based on object colors."
        '
        'stepNumber
        '
        Me.stepNumber.Location = New System.Drawing.Point(44, 59)
        Me.stepNumber.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.stepNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.stepNumber.Name = "stepNumber"
        Me.stepNumber.Size = New System.Drawing.Size(38, 20)
        Me.stepNumber.TabIndex = 1
        Me.stepNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 61)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(29, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Step"
        '
        'stepsTextBox
        '
        Me.stepsTextBox.Location = New System.Drawing.Point(12, 85)
        Me.stepsTextBox.Multiline = True
        Me.stepsTextBox.Name = "stepsTextBox"
        Me.stepsTextBox.ReadOnly = True
        Me.stepsTextBox.Size = New System.Drawing.Size(296, 87)
        Me.stepsTextBox.TabIndex = 3
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.imageSelection2)
        Me.groupBox1.Controls.Add(Me.imageSelection1)
        Me.groupBox1.Location = New System.Drawing.Point(12, 190)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(84, 69)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Test Image"
        '
        'imageSelection2
        '
        Me.imageSelection2.AutoSize = True
        Me.imageSelection2.Location = New System.Drawing.Point(10, 43)
        Me.imageSelection2.Name = "imageSelection2"
        Me.imageSelection2.Size = New System.Drawing.Size(63, 17)
        Me.imageSelection2.TabIndex = 0
        Me.imageSelection2.Text = "Image 2"
        Me.imageSelection2.UseVisualStyleBackColor = True
        '
        'imageSelection1
        '
        Me.imageSelection1.AutoSize = True
        Me.imageSelection1.Checked = True
        Me.imageSelection1.Location = New System.Drawing.Point(10, 20)
        Me.imageSelection1.Name = "imageSelection1"
        Me.imageSelection1.Size = New System.Drawing.Size(63, 17)
        Me.imageSelection1.TabIndex = 0
        Me.imageSelection1.TabStop = True
        Me.imageSelection1.Text = "Image 1"
        Me.imageSelection1.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.imageTypeHSL)
        Me.groupBox2.Controls.Add(Me.imageTypeRGB)
        Me.groupBox2.Location = New System.Drawing.Point(102, 190)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(206, 69)
        Me.groupBox2.TabIndex = 5
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Threshold Color Mode"
        '
        'imageTypeHSL
        '
        Me.imageTypeHSL.AutoSize = True
        Me.imageTypeHSL.Location = New System.Drawing.Point(12, 43)
        Me.imageTypeHSL.Name = "imageTypeHSL"
        Me.imageTypeHSL.Size = New System.Drawing.Size(187, 17)
        Me.imageTypeHSL.TabIndex = 0
        Me.imageTypeHSL.Text = "HSL (Hue, Saturation, Luminance)"
        Me.imageTypeHSL.UseVisualStyleBackColor = True
        '
        'imageTypeRGB
        '
        Me.imageTypeRGB.AutoSize = True
        Me.imageTypeRGB.Checked = True
        Me.imageTypeRGB.Location = New System.Drawing.Point(12, 20)
        Me.imageTypeRGB.Name = "imageTypeRGB"
        Me.imageTypeRGB.Size = New System.Drawing.Size(139, 17)
        Me.imageTypeRGB.TabIndex = 0
        Me.imageTypeRGB.TabStop = True
        Me.imageTypeRGB.Text = "RGB (Red, Green, Blue)"
        Me.imageTypeRGB.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(25, 265)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(62, 13)
        Me.label3.TabIndex = 15
        Me.label3.Text = "Red or Hue"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(25, 372)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(99, 13)
        Me.label8.TabIndex = 15
        Me.label8.Text = "Green or Saturation"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(25, 481)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(95, 13)
        Me.label11.TabIndex = 15
        Me.label11.Text = "Blue or Luminance"
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(342, 18)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(312, 247)
        Me.imageViewer1.TabIndex = 16
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(342, 293)
        Me.imageViewer2.Name = "imageViewer2"
        Palette7.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
        Me.imageViewer2.Palette = Palette7
        Me.imageViewer2.Size = New System.Drawing.Size(312, 247)
        Me.imageViewer2.TabIndex = 16
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(339, 2)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(74, 13)
        Me.label12.TabIndex = 17
        Me.label12.Text = "Original Image"
        '
        'imageViewer2Label
        '
        Me.imageViewer2Label.AutoSize = True
        Me.imageViewer2Label.Location = New System.Drawing.Point(339, 277)
        Me.imageViewer2Label.Name = "imageViewer2Label"
        Me.imageViewer2Label.Size = New System.Drawing.Size(0, 13)
        Me.imageViewer2Label.TabIndex = 17
        '
        'RedMinimumSlide
        '
        Me.RedMinimumSlide.AutoSize = True
        Me.RedMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RedMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Red
        Me.RedMinimumSlide.Location = New System.Drawing.Point(22, 276)
        Me.RedMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.RedMinimumSlide.Name = "RedMinimumSlide"
        Me.RedMinimumSlide.Size = New System.Drawing.Size(203, 53)
        Me.RedMinimumSlide.TabIndex = 18
        Me.RedMinimumSlide.Value = 42
        '
        'RedMaximumSlide
        '
        Me.RedMaximumSlide.AutoSize = True
        Me.RedMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RedMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Red
        Me.RedMaximumSlide.Location = New System.Drawing.Point(22, 320)
        Me.RedMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.RedMaximumSlide.Name = "RedMaximumSlide"
        Me.RedMaximumSlide.Size = New System.Drawing.Size(203, 53)
        Me.RedMaximumSlide.TabIndex = 18
        Me.RedMaximumSlide.Value = 121
        '
        'GreenMinimumSlide
        '
        Me.GreenMinimumSlide.AutoSize = True
        Me.GreenMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GreenMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Green
        Me.GreenMinimumSlide.Location = New System.Drawing.Point(22, 385)
        Me.GreenMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.GreenMinimumSlide.Name = "GreenMinimumSlide"
        Me.GreenMinimumSlide.Size = New System.Drawing.Size(203, 53)
        Me.GreenMinimumSlide.TabIndex = 18
        Me.GreenMinimumSlide.Value = 15
        '
        'GreenMaximumSlide
        '
        Me.GreenMaximumSlide.AutoSize = True
        Me.GreenMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GreenMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Green
        Me.GreenMaximumSlide.Location = New System.Drawing.Point(22, 429)
        Me.GreenMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.GreenMaximumSlide.Name = "GreenMaximumSlide"
        Me.GreenMaximumSlide.Size = New System.Drawing.Size(203, 53)
        Me.GreenMaximumSlide.TabIndex = 18
        Me.GreenMaximumSlide.Value = 255
        '
        'BlueMinimumSlide
        '
        Me.BlueMinimumSlide.AutoSize = True
        Me.BlueMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BlueMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Blue
        Me.BlueMinimumSlide.Location = New System.Drawing.Point(22, 492)
        Me.BlueMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.BlueMinimumSlide.Name = "BlueMinimumSlide"
        Me.BlueMinimumSlide.Size = New System.Drawing.Size(203, 53)
        Me.BlueMinimumSlide.TabIndex = 18
        Me.BlueMinimumSlide.Value = 54
        '
        'BlueMaximumSlide
        '
        Me.BlueMaximumSlide.AutoSize = True
        Me.BlueMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BlueMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.Blue
        Me.BlueMaximumSlide.Location = New System.Drawing.Point(22, 536)
        Me.BlueMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.BlueMaximumSlide.Name = "BlueMaximumSlide"
        Me.BlueMaximumSlide.Size = New System.Drawing.Size(203, 53)
        Me.BlueMaximumSlide.TabIndex = 18
        Me.BlueMaximumSlide.Value = 255
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(242, 9)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(66, 37)
        Me.quitButton.TabIndex = 19
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 594)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.BlueMaximumSlide)
        Me.Controls.Add(Me.BlueMinimumSlide)
        Me.Controls.Add(Me.GreenMaximumSlide)
        Me.Controls.Add(Me.GreenMinimumSlide)
        Me.Controls.Add(Me.RedMaximumSlide)
        Me.Controls.Add(Me.RedMinimumSlide)
        Me.Controls.Add(Me.imageViewer2Label)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.stepsTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.stepNumber)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Color Threshold Example"
        CType(Me.stepNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label1 As System.Windows.Forms.Label
    Private WithEvents stepNumber As System.Windows.Forms.NumericUpDown
    Private label2 As System.Windows.Forms.Label
    Private stepsTextBox As System.Windows.Forms.TextBox
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents imageSelection2 As System.Windows.Forms.RadioButton
    Private WithEvents imageSelection1 As System.Windows.Forms.RadioButton
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents imageTypeHSL As System.Windows.Forms.RadioButton
    Private WithEvents imageTypeRGB As System.Windows.Forms.RadioButton
    Private label3 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label12 As System.Windows.Forms.Label
    Private imageViewer2Label As System.Windows.Forms.Label
    Friend WithEvents RedMinimumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents RedMaximumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents GreenMinimumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents GreenMaximumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents BlueMinimumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents BlueMaximumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents quitButton As System.Windows.Forms.Button
End Class