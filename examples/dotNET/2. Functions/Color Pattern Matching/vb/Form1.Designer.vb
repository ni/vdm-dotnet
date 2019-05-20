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
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.subpixelAccuracy = New System.Windows.Forms.CheckBox
        Me.colorScoreWeight = New System.Windows.Forms.NumericUpDown
        Me.label8 = New System.Windows.Forms.Label
        Me.matchesRequested = New System.Windows.Forms.NumericUpDown
        Me.label7 = New System.Windows.Forms.Label
        Me.minimumContrast = New System.Windows.Forms.NumericUpDown
        Me.label6 = New System.Windows.Forms.Label
        Me.minimumScore = New System.Windows.Forms.NumericUpDown
        Me.label5 = New System.Windows.Forms.Label
        Me.matchFeatureMode = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.searchStrategy = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.colorSensitivity = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.matchModeBox = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label12 = New System.Windows.Forms.Label
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.matchesFound = New System.Windows.Forms.TextBox
        Me.label13 = New System.Windows.Forms.Label
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label14 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.learnPatternButton = New System.Windows.Forms.Button
        Me.matchPatternButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label15 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.groupBox1.SuspendLayout()
        CType(Me.colorScoreWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.matchesRequested, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimumContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimumScore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(525, 427)
        Me.imageViewer1.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.subpixelAccuracy)
        Me.groupBox1.Controls.Add(Me.colorScoreWeight)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.matchesRequested)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.minimumContrast)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.minimumScore)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.matchFeatureMode)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.searchStrategy)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.colorSensitivity)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.matchModeBox)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(543, 7)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(282, 256)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Search Parameters"
        '
        'subpixelAccuracy
        '
        Me.subpixelAccuracy.AutoSize = True
        Me.subpixelAccuracy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.subpixelAccuracy.Location = New System.Drawing.Point(20, 229)
        Me.subpixelAccuracy.Name = "subpixelAccuracy"
        Me.subpixelAccuracy.Size = New System.Drawing.Size(117, 17)
        Me.subpixelAccuracy.TabIndex = 4
        Me.subpixelAccuracy.Text = "Subpixel Accuracy:"
        Me.subpixelAccuracy.UseVisualStyleBackColor = True
        '
        'colorScoreWeight
        '
        Me.colorScoreWeight.Location = New System.Drawing.Point(125, 203)
        Me.colorScoreWeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.colorScoreWeight.Name = "colorScoreWeight"
        Me.colorScoreWeight.Size = New System.Drawing.Size(45, 20)
        Me.colorScoreWeight.TabIndex = 3
        Me.colorScoreWeight.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(17, 205)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(102, 13)
        Me.label8.TabIndex = 2
        Me.label8.Text = "Color Score Weight:"
        '
        'matchesRequested
        '
        Me.matchesRequested.Location = New System.Drawing.Point(125, 177)
        Me.matchesRequested.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.matchesRequested.Name = "matchesRequested"
        Me.matchesRequested.Size = New System.Drawing.Size(45, 20)
        Me.matchesRequested.TabIndex = 3
        Me.matchesRequested.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(13, 179)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(106, 13)
        Me.label7.TabIndex = 2
        Me.label7.Text = "Matches Requested:"
        '
        'minimumContrast
        '
        Me.minimumContrast.Location = New System.Drawing.Point(125, 151)
        Me.minimumContrast.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.minimumContrast.Name = "minimumContrast"
        Me.minimumContrast.Size = New System.Drawing.Size(45, 20)
        Me.minimumContrast.TabIndex = 3
        Me.minimumContrast.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(26, 153)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(93, 13)
        Me.label6.TabIndex = 2
        Me.label6.Text = "Minimum Contrast:"
        '
        'minimumScore
        '
        Me.minimumScore.Location = New System.Drawing.Point(125, 125)
        Me.minimumScore.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.minimumScore.Name = "minimumScore"
        Me.minimumScore.Size = New System.Drawing.Size(45, 20)
        Me.minimumScore.TabIndex = 3
        Me.minimumScore.Value = New Decimal(New Integer() {700, 0, 0, 0})
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(37, 127)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(82, 13)
        Me.label5.TabIndex = 2
        Me.label5.Text = "Minimum Score:"
        '
        'matchFeatureMode
        '
        Me.matchFeatureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.matchFeatureMode.FormattingEnabled = True
        Me.matchFeatureMode.Items.AddRange(New Object() {"ColorAndShape", "Color", "Shape"})
        Me.matchFeatureMode.Location = New System.Drawing.Point(125, 98)
        Me.matchFeatureMode.Name = "matchFeatureMode"
        Me.matchFeatureMode.Size = New System.Drawing.Size(151, 21)
        Me.matchFeatureMode.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(10, 101)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(109, 13)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Match Feature Mode:"
        '
        'searchStrategy
        '
        Me.searchStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.searchStrategy.FormattingEnabled = True
        Me.searchStrategy.Items.AddRange(New Object() {"Conservative", "Balanced", "Aggressive", "VeryAggressive"})
        Me.searchStrategy.Location = New System.Drawing.Point(125, 71)
        Me.searchStrategy.Name = "searchStrategy"
        Me.searchStrategy.Size = New System.Drawing.Size(151, 21)
        Me.searchStrategy.TabIndex = 1
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(33, 74)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(86, 13)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Search Strategy:"
        '
        'colorSensitivity
        '
        Me.colorSensitivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.colorSensitivity.FormattingEnabled = True
        Me.colorSensitivity.Items.AddRange(New Object() {"Low", "Medium", "High"})
        Me.colorSensitivity.Location = New System.Drawing.Point(125, 44)
        Me.colorSensitivity.Name = "colorSensitivity"
        Me.colorSensitivity.Size = New System.Drawing.Size(151, 21)
        Me.colorSensitivity.TabIndex = 1
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(35, 47)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(84, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Color Sensitivity:"
        '
        'matchModeBox
        '
        Me.matchModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.matchModeBox.FormattingEnabled = True
        Me.matchModeBox.Items.AddRange(New Object() {"ShiftInvariant", "RotationInvariant"})
        Me.matchModeBox.Location = New System.Drawing.Point(125, 17)
        Me.matchModeBox.Name = "matchModeBox"
        Me.matchModeBox.Size = New System.Drawing.Size(151, 21)
        Me.matchModeBox.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(49, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(70, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Match Mode:"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(553, 279)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(64, 13)
        Me.label9.TabIndex = 2
        Me.label9.Text = "Instructions:"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(553, 294)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(108, 13)
        Me.label10.TabIndex = 2
        Me.label10.Text = "1. Load an image file."
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(553, 310)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(266, 28)
        Me.label11.TabIndex = 2
        Me.label11.Text = "2. Draw a rectangle around the search item.  Click Learn Pattern."
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(553, 339)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(266, 44)
        Me.label12.TabIndex = 2
        Me.label12.Text = "3. Load a new image.  Click Match Pattern to look for the new location of the tem" & _
            "plate.  Draw a rectangle to restrict the search area."
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.matchesFound)
        Me.groupBox2.Controls.Add(Me.label13)
        Me.groupBox2.Location = New System.Drawing.Point(554, 386)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(126, 52)
        Me.groupBox2.TabIndex = 3
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Results"
        '
        'matchesFound
        '
        Me.matchesFound.Location = New System.Drawing.Point(90, 21)
        Me.matchesFound.Name = "matchesFound"
        Me.matchesFound.ReadOnly = True
        Me.matchesFound.Size = New System.Drawing.Size(30, 20)
        Me.matchesFound.TabIndex = 1
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(8, 24)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(81, 13)
        Me.label13.TabIndex = 0
        Me.label13.Text = "Matches found:"
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(699, 405)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(120, 101)
        Me.imageViewer2.TabIndex = 4
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(696, 388)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(73, 13)
        Me.label14.TabIndex = 5
        Me.label14.Text = "Pattern Image"
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(12, 455)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(82, 33)
        Me.loadImageButton.TabIndex = 6
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'learnPatternButton
        '
        Me.learnPatternButton.Enabled = False
        Me.learnPatternButton.Location = New System.Drawing.Point(100, 455)
        Me.learnPatternButton.Name = "learnPatternButton"
        Me.learnPatternButton.Size = New System.Drawing.Size(82, 33)
        Me.learnPatternButton.TabIndex = 6
        Me.learnPatternButton.Text = "Learn Pattern"
        Me.learnPatternButton.UseVisualStyleBackColor = True
        '
        'matchPatternButton
        '
        Me.matchPatternButton.Enabled = False
        Me.matchPatternButton.Location = New System.Drawing.Point(188, 455)
        Me.matchPatternButton.Name = "matchPatternButton"
        Me.matchPatternButton.Size = New System.Drawing.Size(82, 33)
        Me.matchPatternButton.TabIndex = 6
        Me.matchPatternButton.Text = "Match Pattern"
        Me.matchPatternButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(276, 455)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(82, 33)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(9, 506)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(64, 13)
        Me.label15.TabIndex = 7
        Me.label15.Text = "Image Path:"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(79, 503)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(426, 20)
        Me.imagePath.TabIndex = 8
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(511, 503)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(25, 20)
        Me.browseButton.TabIndex = 9
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 537)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label15)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.matchPatternButton)
        Me.Controls.Add(Me.learnPatternButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Color Pattern Matching Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.colorScoreWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.matchesRequested, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimumContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimumScore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private matchModeBox As System.Windows.Forms.ComboBox
    Private label1 As System.Windows.Forms.Label
    Private colorSensitivity As System.Windows.Forms.ComboBox
    Private label2 As System.Windows.Forms.Label
    Private searchStrategy As System.Windows.Forms.ComboBox
    Private label3 As System.Windows.Forms.Label
    Private matchFeatureMode As System.Windows.Forms.ComboBox
    Private label4 As System.Windows.Forms.Label
    Private minimumScore As System.Windows.Forms.NumericUpDown
    Private label5 As System.Windows.Forms.Label
    Private minimumContrast As System.Windows.Forms.NumericUpDown
    Private label6 As System.Windows.Forms.Label
    Private matchesRequested As System.Windows.Forms.NumericUpDown
    Private label7 As System.Windows.Forms.Label
    Private colorScoreWeight As System.Windows.Forms.NumericUpDown
    Private label8 As System.Windows.Forms.Label
    Private subpixelAccuracy As System.Windows.Forms.CheckBox
    Private label9 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private label12 As System.Windows.Forms.Label
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private matchesFound As System.Windows.Forms.TextBox
    Private label13 As System.Windows.Forms.Label
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label14 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents learnPatternButton As System.Windows.Forms.Button
    Private WithEvents matchPatternButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label15 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
End Class