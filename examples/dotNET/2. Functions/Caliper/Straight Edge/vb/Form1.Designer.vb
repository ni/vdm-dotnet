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
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label15 = New System.Windows.Forms.Label
        Me.label16 = New System.Windows.Forms.Label
        Me.label17 = New System.Windows.Forms.Label
        Me.label18 = New System.Windows.Forms.Label
        Me.label19 = New System.Windows.Forms.Label
        Me.minimumCoverage = New System.Windows.Forms.NumericUpDown
        Me.minimumSignalToNoiseRatio = New System.Windows.Forms.NumericUpDown
        Me.orientation = New System.Windows.Forms.NumericUpDown
        Me.angleRange = New System.Windows.Forms.NumericUpDown
        Me.angleTolerance = New System.Windows.Forms.NumericUpDown
        Me.label14 = New System.Windows.Forms.Label
        Me.label13 = New System.Windows.Forms.Label
        Me.label12 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.houghIterations = New System.Windows.Forms.NumericUpDown
        Me.stepSize = New System.Windows.Forms.NumericUpDown
        Me.maximumScore = New System.Windows.Forms.NumericUpDown
        Me.minimumScore = New System.Windows.Forms.NumericUpDown
        Me.numberOfLines = New System.Windows.Forms.NumericUpDown
        Me.searchDirection = New System.Windows.Forms.ComboBox
        Me.searchMode = New System.Windows.Forms.ComboBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
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
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.label20 = New System.Windows.Forms.Label
        Me.label21 = New System.Windows.Forms.Label
        Me.label22 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.groupBox2.SuspendLayout()
        CType(Me.minimumCoverage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimumSignalToNoiseRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.orientation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.angleRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.angleTolerance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.houghIterations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stepSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maximumScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimumScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numberOfLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.minimumThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kernelSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.width, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowToolbar = True
        Me.imageViewer1.Size = New System.Drawing.Size(461, 374)
        Me.imageViewer1.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label15)
        Me.groupBox2.Controls.Add(Me.label16)
        Me.groupBox2.Controls.Add(Me.label17)
        Me.groupBox2.Controls.Add(Me.label18)
        Me.groupBox2.Controls.Add(Me.label19)
        Me.groupBox2.Controls.Add(Me.minimumCoverage)
        Me.groupBox2.Controls.Add(Me.minimumSignalToNoiseRatio)
        Me.groupBox2.Controls.Add(Me.orientation)
        Me.groupBox2.Controls.Add(Me.angleRange)
        Me.groupBox2.Controls.Add(Me.angleTolerance)
        Me.groupBox2.Controls.Add(Me.label14)
        Me.groupBox2.Controls.Add(Me.label13)
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.houghIterations)
        Me.groupBox2.Controls.Add(Me.stepSize)
        Me.groupBox2.Controls.Add(Me.maximumScore)
        Me.groupBox2.Controls.Add(Me.minimumScore)
        Me.groupBox2.Controls.Add(Me.numberOfLines)
        Me.groupBox2.Controls.Add(Me.searchDirection)
        Me.groupBox2.Controls.Add(Me.searchMode)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(495, 155)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(285, 211)
        Me.groupBox2.TabIndex = 10
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Straight Edge Options"
        '
        'label15
        '
        Me.label15.Location = New System.Drawing.Point(133, 174)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(80, 16)
        Me.label15.TabIndex = 18
        Me.label15.Text = "Min Cover"
        Me.label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label16
        '
        Me.label16.Location = New System.Drawing.Point(133, 148)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(80, 16)
        Me.label16.TabIndex = 17
        Me.label16.Text = "Min SNR"
        Me.label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label17
        '
        Me.label17.Location = New System.Drawing.Point(133, 122)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(80, 16)
        Me.label17.TabIndex = 16
        Me.label17.Text = "Orientation"
        Me.label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label18
        '
        Me.label18.Location = New System.Drawing.Point(133, 96)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(80, 16)
        Me.label18.TabIndex = 15
        Me.label18.Text = "Angle Range"
        Me.label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label19
        '
        Me.label19.Location = New System.Drawing.Point(133, 70)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(80, 16)
        Me.label19.TabIndex = 14
        Me.label19.Text = "Angle Inc"
        Me.label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'minimumCoverage
        '
        Me.minimumCoverage.Location = New System.Drawing.Point(219, 172)
        Me.minimumCoverage.Name = "minimumCoverage"
        Me.minimumCoverage.Size = New System.Drawing.Size(52, 20)
        Me.minimumCoverage.TabIndex = 10
        Me.minimumCoverage.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'minimumSignalToNoiseRatio
        '
        Me.minimumSignalToNoiseRatio.Location = New System.Drawing.Point(219, 146)
        Me.minimumSignalToNoiseRatio.Name = "minimumSignalToNoiseRatio"
        Me.minimumSignalToNoiseRatio.Size = New System.Drawing.Size(52, 20)
        Me.minimumSignalToNoiseRatio.TabIndex = 9
        '
        'orientation
        '
        Me.orientation.Location = New System.Drawing.Point(219, 120)
        Me.orientation.Name = "orientation"
        Me.orientation.Size = New System.Drawing.Size(52, 20)
        Me.orientation.TabIndex = 11
        '
        'angleRange
        '
        Me.angleRange.Location = New System.Drawing.Point(219, 94)
        Me.angleRange.Name = "angleRange"
        Me.angleRange.Size = New System.Drawing.Size(52, 20)
        Me.angleRange.TabIndex = 13
        Me.angleRange.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'angleTolerance
        '
        Me.angleTolerance.Location = New System.Drawing.Point(219, 68)
        Me.angleTolerance.Name = "angleTolerance"
        Me.angleTolerance.Size = New System.Drawing.Size(53, 20)
        Me.angleTolerance.TabIndex = 12
        Me.angleTolerance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label14
        '
        Me.label14.Location = New System.Drawing.Point(-10, 174)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(80, 16)
        Me.label14.TabIndex = 8
        Me.label14.Text = "Hough Iter."
        Me.label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(-10, 148)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(80, 16)
        Me.label13.TabIndex = 7
        Me.label13.Text = "Step Size"
        Me.label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(-10, 122)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(80, 16)
        Me.label12.TabIndex = 6
        Me.label12.Text = "Max Score"
        Me.label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(-10, 96)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(80, 16)
        Me.label11.TabIndex = 5
        Me.label11.Text = "Min Score"
        Me.label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(-10, 70)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(80, 16)
        Me.label10.TabIndex = 4
        Me.label10.Text = "Num. Lines"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'houghIterations
        '
        Me.houghIterations.Location = New System.Drawing.Point(76, 172)
        Me.houghIterations.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.houghIterations.Name = "houghIterations"
        Me.houghIterations.Size = New System.Drawing.Size(52, 20)
        Me.houghIterations.TabIndex = 3
        Me.houghIterations.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'stepSize
        '
        Me.stepSize.Location = New System.Drawing.Point(76, 146)
        Me.stepSize.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.stepSize.Name = "stepSize"
        Me.stepSize.Size = New System.Drawing.Size(52, 20)
        Me.stepSize.TabIndex = 3
        Me.stepSize.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'maximumScore
        '
        Me.maximumScore.Location = New System.Drawing.Point(76, 120)
        Me.maximumScore.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.maximumScore.Name = "maximumScore"
        Me.maximumScore.Size = New System.Drawing.Size(52, 20)
        Me.maximumScore.TabIndex = 3
        Me.maximumScore.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'minimumScore
        '
        Me.minimumScore.Location = New System.Drawing.Point(76, 94)
        Me.minimumScore.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.minimumScore.Name = "minimumScore"
        Me.minimumScore.Size = New System.Drawing.Size(52, 20)
        Me.minimumScore.TabIndex = 3
        Me.minimumScore.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'numberOfLines
        '
        Me.numberOfLines.Location = New System.Drawing.Point(76, 68)
        Me.numberOfLines.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numberOfLines.Name = "numberOfLines"
        Me.numberOfLines.Size = New System.Drawing.Size(53, 20)
        Me.numberOfLines.TabIndex = 3
        Me.numberOfLines.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'searchDirection
        '
        Me.searchDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.searchDirection.FormattingEnabled = True
        Me.searchDirection.Items.AddRange(New Object() {"LeftToRight", "RightToLeft", "BottomToTop", "TopToBottom"})
        Me.searchDirection.Location = New System.Drawing.Point(149, 34)
        Me.searchDirection.Name = "searchDirection"
        Me.searchDirection.Size = New System.Drawing.Size(122, 21)
        Me.searchDirection.TabIndex = 2
        '
        'searchMode
        '
        Me.searchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.searchMode.FormattingEnabled = True
        Me.searchMode.Items.AddRange(New Object() {"FirstRakeEdges", "BestRakeEdges", "BestHoughLine", "FirstProjectionEdge", "BestProjectionEdge"})
        Me.searchMode.Location = New System.Drawing.Point(8, 34)
        Me.searchMode.Name = "searchMode"
        Me.searchMode.Size = New System.Drawing.Size(121, 21)
        Me.searchMode.TabIndex = 1
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(148, 16)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(86, 13)
        Me.label9.TabIndex = 0
        Me.label9.Text = "Search Direction"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(10, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(71, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Search Mode"
        '
        'groupBox1
        '
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
        Me.groupBox1.Location = New System.Drawing.Point(495, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(286, 137)
        Me.groupBox1.TabIndex = 9
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Edge Options"
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
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 391)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 11
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(76, 388)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(365, 20)
        Me.imagePath.TabIndex = 12
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(447, 388)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(26, 19)
        Me.browseButton.TabIndex = 13
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(492, 377)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(64, 13)
        Me.label20.TabIndex = 14
        Me.label20.Text = "Instructions:"
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(492, 394)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(156, 13)
        Me.label21.TabIndex = 14
        Me.label21.Text = "1. Load an image and display it."
        '
        'label22
        '
        Me.label22.Location = New System.Drawing.Point(492, 411)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(284, 30)
        Me.label22.TabIndex = 14
        Me.label22.Text = "2. Draw an ROI on the image.  The example overlays detected straight edges on the" & _
            " image."
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(578, 444)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(77, 29)
        Me.loadImageButton.TabIndex = 15
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(661, 444)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(77, 29)
        Me.quitButton.TabIndex = 15
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 478)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label22)
        Me.Controls.Add(Me.label21)
        Me.Controls.Add(Me.label20)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Find Straight Edges Example"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.minimumCoverage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimumSignalToNoiseRatio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.orientation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.angleRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.angleTolerance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.houghIterations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stepSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maximumScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimumScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numberOfLines, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private label15 As System.Windows.Forms.Label
    Private label16 As System.Windows.Forms.Label
    Private label17 As System.Windows.Forms.Label
    Private label18 As System.Windows.Forms.Label
    Private label19 As System.Windows.Forms.Label
    Private minimumCoverage As System.Windows.Forms.NumericUpDown
    Private minimumSignalToNoiseRatio As System.Windows.Forms.NumericUpDown
    Private orientation As System.Windows.Forms.NumericUpDown
    Private angleRange As System.Windows.Forms.NumericUpDown
    Private angleTolerance As System.Windows.Forms.NumericUpDown
    Private label14 As System.Windows.Forms.Label
    Private label13 As System.Windows.Forms.Label
    Private label12 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private houghIterations As System.Windows.Forms.NumericUpDown
    Private stepSize As System.Windows.Forms.NumericUpDown
    Private maximumScore As System.Windows.Forms.NumericUpDown
    Private minimumScore As System.Windows.Forms.NumericUpDown
    Private numberOfLines As System.Windows.Forms.NumericUpDown
    Private searchDirection As System.Windows.Forms.ComboBox
    Private searchMode As System.Windows.Forms.ComboBox
    Private label9 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private smoothing As System.Windows.Forms.ComboBox
    Private label8 As System.Windows.Forms.Label
    Private interpolationMethod As System.Windows.Forms.ComboBox
    Private label7 As System.Windows.Forms.Label
    Private polarity As System.Windows.Forms.ComboBox
    Private label6 As System.Windows.Forms.Label
    Private minimumThreshold As System.Windows.Forms.NumericUpDown
    Private kernelSize As System.Windows.Forms.NumericUpDown
    Private Shadows width As System.Windows.Forms.NumericUpDown
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private label20 As System.Windows.Forms.Label
    Private label21 As System.Windows.Forms.Label
    Private label22 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
End Class