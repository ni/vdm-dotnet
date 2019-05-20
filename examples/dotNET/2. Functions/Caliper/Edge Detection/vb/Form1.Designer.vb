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
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.process = New System.Windows.Forms.ComboBox
        Me.label9 = New System.Windows.Forms.Label
        Me.smoothing = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.interpolationMethod = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.polarity = New System.Windows.Forms.ComboBox
        Me.label6 = New System.Windows.Forms.Label
        Me.minimumThreshold = New System.Windows.Forms.NumericUpDown
        Me.kernelSize = New System.Windows.Forms.NumericUpDown
        Me.width = New System.Windows.Forms.NumericUpDown
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label12 = New System.Windows.Forms.Label
        Me.EdgeDetectionGraph1 = New NationalInstruments.Vision.MeasurementStudioDemo.EdgeDetectionGraph
        Me.groupBox1.SuspendLayout()
        CType(Me.minimumThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kernelSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.width, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Line
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(394, 329)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 355)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(78, 355)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(295, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(380, 355)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(26, 20)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.process)
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.smoothing)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.interpolationMethod)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.polarity)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.minimumThreshold)
        Me.groupBox1.Controls.Add(Me.kernelSize)
        Me.groupBox1.Controls.Add(Me.width)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Location = New System.Drawing.Point(417, 170)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(286, 171)
        Me.groupBox1.TabIndex = 6
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Edge Options"
        '
        'process
        '
        Me.process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.process.FormattingEnabled = True
        Me.process.Items.AddRange(New Object() {"First", "FirstAndLast", "All", "Best"})
        Me.process.Location = New System.Drawing.Point(151, 144)
        Me.process.Name = "process"
        Me.process.Size = New System.Drawing.Size(122, 21)
        Me.process.TabIndex = 9
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(148, 129)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(45, 13)
        Me.label9.TabIndex = 8
        Me.label9.Text = "Process"
        '
        'smoothing
        '
        Me.smoothing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.smoothing.FormattingEnabled = True
        Me.smoothing.Items.AddRange(New Object() {"Average", "Median"})
        Me.smoothing.Location = New System.Drawing.Point(151, 104)
        Me.smoothing.Name = "smoothing"
        Me.smoothing.Size = New System.Drawing.Size(122, 21)
        Me.smoothing.TabIndex = 7
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(148, 89)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(57, 13)
        Me.label8.TabIndex = 6
        Me.label8.Text = "Smoothing"
        '
        'interpolationMethod
        '
        Me.interpolationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.interpolationMethod.FormattingEnabled = True
        Me.interpolationMethod.Items.AddRange(New Object() {"ZeroOrder", "Bilinear", "BilinearFixed"})
        Me.interpolationMethod.Location = New System.Drawing.Point(151, 66)
        Me.interpolationMethod.Name = "interpolationMethod"
        Me.interpolationMethod.Size = New System.Drawing.Size(122, 21)
        Me.interpolationMethod.TabIndex = 5
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(148, 51)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(104, 13)
        Me.label7.TabIndex = 4
        Me.label7.Text = "Interpolation Method"
        '
        'polarity
        '
        Me.polarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.polarity.FormattingEnabled = True
        Me.polarity.Items.AddRange(New Object() {"All", "Rising ", "Falling"})
        Me.polarity.Location = New System.Drawing.Point(151, 27)
        Me.polarity.Name = "polarity"
        Me.polarity.Size = New System.Drawing.Size(122, 21)
        Me.polarity.TabIndex = 3
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(148, 12)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(41, 13)
        Me.label6.TabIndex = 2
        Me.label6.Text = "Polarity"
        '
        'minimumThreshold
        '
        Me.minimumThreshold.Location = New System.Drawing.Point(89, 65)
        Me.minimumThreshold.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.minimumThreshold.Name = "minimumThreshold"
        Me.minimumThreshold.Size = New System.Drawing.Size(41, 20)
        Me.minimumThreshold.TabIndex = 1
        Me.minimumThreshold.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'kernelSize
        '
        Me.kernelSize.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.kernelSize.Location = New System.Drawing.Point(89, 42)
        Me.kernelSize.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.kernelSize.Name = "kernelSize"
        Me.kernelSize.Size = New System.Drawing.Size(41, 20)
        Me.kernelSize.TabIndex = 1
        Me.kernelSize.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'width
        '
        Me.width.Location = New System.Drawing.Point(89, 19)
        Me.width.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.width.Name = "width"
        Me.width.Size = New System.Drawing.Size(41, 20)
        Me.width.TabIndex = 1
        Me.width.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(1, 65)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(81, 19)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Min Threshold:"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(1, 41)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(81, 19)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Kernel Size:"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(1, 18)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(81, 19)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Width:"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(555, 416)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(71, 37)
        Me.loadImageButton.TabIndex = 7
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(632, 416)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(71, 37)
        Me.quitButton.TabIndex = 7
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(414, 344)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(64, 13)
        Me.label10.TabIndex = 8
        Me.label10.Text = "Instructions:"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(414, 362)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(156, 13)
        Me.label11.TabIndex = 8
        Me.label11.Text = "1. Load an image and display it."
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(414, 377)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(289, 36)
        Me.label12.TabIndex = 8
        Me.label12.Text = "2. Draw a line in the image. The example overlays the detected edge on the image." & _
            ""
        '
        'EdgeDetectionGraph1
        '
        Me.EdgeDetectionGraph1.AutoSize = True
        Me.EdgeDetectionGraph1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.EdgeDetectionGraph1.Location = New System.Drawing.Point(417, 12)
        Me.EdgeDetectionGraph1.Name = "EdgeDetectionGraph1"
        Me.EdgeDetectionGraph1.Size = New System.Drawing.Size(290, 144)
        Me.EdgeDetectionGraph1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 465)
        Me.Controls.Add(Me.EdgeDetectionGraph1)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Edge Detection Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.minimumThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.kernelSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.width, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private kernelSize As System.Windows.Forms.NumericUpDown
    Private Shadows width As System.Windows.Forms.NumericUpDown
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private minimumThreshold As System.Windows.Forms.NumericUpDown
    Private interpolationMethod As System.Windows.Forms.ComboBox
    Private label7 As System.Windows.Forms.Label
    Private polarity As System.Windows.Forms.ComboBox
    Private label6 As System.Windows.Forms.Label
    Private process As System.Windows.Forms.ComboBox
    Private label9 As System.Windows.Forms.Label
    Private smoothing As System.Windows.Forms.ComboBox
    Private label8 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label10 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private label12 As System.Windows.Forms.Label
    Friend WithEvents EdgeDetectionGraph1 As NationalInstruments.Vision.MeasurementStudioDemo.EdgeDetectionGraph
End Class