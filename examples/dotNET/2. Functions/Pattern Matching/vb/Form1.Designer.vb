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
        Me.imageViewerMain = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.subpixelAccuracy = New System.Windows.Forms.CheckBox
        Me.label4 = New System.Windows.Forms.Label
        Me.matchesRequested = New System.Windows.Forms.NumericUpDown
        Me.label3 = New System.Windows.Forms.Label
        Me.minimumContrast = New System.Windows.Forms.NumericUpDown
        Me.label2 = New System.Windows.Forms.Label
        Me.minimumScore = New System.Windows.Forms.NumericUpDown
        Me.label1 = New System.Windows.Forms.Label
        Me.matchMode = New System.Windows.Forms.ComboBox
        Me.resultsBox = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.matchesFound = New System.Windows.Forms.TextBox
        Me.imageViewerPattern = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label6 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.learnPatternButton = New System.Windows.Forms.Button
        Me.matchPatternButton = New System.Windows.Forms.Button
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.browseButton = New System.Windows.Forms.Button
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.groupBox1.SuspendLayout()
        CType(Me.matchesRequested, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimumContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimumScore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.resultsBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewerMain
        '
        Me.imageViewerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewerMain.Location = New System.Drawing.Point(18, 14)
        Me.imageViewerMain.Name = "imageViewerMain"
        Me.imageViewerMain.Size = New System.Drawing.Size(358, 318)
        Me.imageViewerMain.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.subpixelAccuracy)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.matchesRequested)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.minimumContrast)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.minimumScore)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.matchMode)
        Me.groupBox1.Location = New System.Drawing.Point(391, 17)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(236, 153)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Search Parameters"
        '
        'subpixelAccuracy
        '
        Me.subpixelAccuracy.AutoSize = True
        Me.subpixelAccuracy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.subpixelAccuracy.Location = New System.Drawing.Point(10, 124)
        Me.subpixelAccuracy.Name = "subpixelAccuracy"
        Me.subpixelAccuracy.Size = New System.Drawing.Size(117, 17)
        Me.subpixelAccuracy.TabIndex = 4
        Me.subpixelAccuracy.Text = "Subpixel Accuracy:"
        Me.subpixelAccuracy.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 100)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Matches Requested:"
        '
        'matchesRequested
        '
        Me.matchesRequested.Location = New System.Drawing.Point(113, 98)
        Me.matchesRequested.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.matchesRequested.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.matchesRequested.Name = "matchesRequested"
        Me.matchesRequested.Size = New System.Drawing.Size(46, 20)
        Me.matchesRequested.TabIndex = 2
        Me.matchesRequested.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 75)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(93, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Minimum Contrast:"
        '
        'minimumContrast
        '
        Me.minimumContrast.Location = New System.Drawing.Point(113, 73)
        Me.minimumContrast.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.minimumContrast.Name = "minimumContrast"
        Me.minimumContrast.Size = New System.Drawing.Size(46, 20)
        Me.minimumContrast.TabIndex = 2
        Me.minimumContrast.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 50)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Minimum Score:"
        '
        'minimumScore
        '
        Me.minimumScore.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.minimumScore.Location = New System.Drawing.Point(113, 48)
        Me.minimumScore.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.minimumScore.Name = "minimumScore"
        Me.minimumScore.Size = New System.Drawing.Size(57, 20)
        Me.minimumScore.TabIndex = 2
        Me.minimumScore.Value = New Decimal(New Integer() {800, 0, 0, 0})
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(70, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Match Mode:"
        '
        'matchMode
        '
        Me.matchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.matchMode.FormattingEnabled = True
        Me.matchMode.Items.AddRange(New Object() {"Shift Invariant", "Rotation Invariant"})
        Me.matchMode.Location = New System.Drawing.Point(113, 19)
        Me.matchMode.Name = "matchMode"
        Me.matchMode.Size = New System.Drawing.Size(116, 21)
        Me.matchMode.TabIndex = 0
        '
        'resultsBox
        '
        Me.resultsBox.Controls.Add(Me.label5)
        Me.resultsBox.Controls.Add(Me.matchesFound)
        Me.resultsBox.Location = New System.Drawing.Point(382, 334)
        Me.resultsBox.Name = "resultsBox"
        Me.resultsBox.Size = New System.Drawing.Size(144, 47)
        Me.resultsBox.TabIndex = 2
        Me.resultsBox.TabStop = False
        Me.resultsBox.Text = "Results"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(4, 22)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(84, 13)
        Me.label5.TabIndex = 1
        Me.label5.Text = "Matches Found:"
        '
        'matchesFound
        '
        Me.matchesFound.Location = New System.Drawing.Point(99, 19)
        Me.matchesFound.Name = "matchesFound"
        Me.matchesFound.ReadOnly = True
        Me.matchesFound.Size = New System.Drawing.Size(30, 20)
        Me.matchesFound.TabIndex = 0
        '
        'imageViewerPattern
        '
        Me.imageViewerPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewerPattern.Location = New System.Drawing.Point(532, 340)
        Me.imageViewerPattern.Name = "imageViewerPattern"
        Me.imageViewerPattern.Size = New System.Drawing.Size(95, 77)
        Me.imageViewerPattern.TabIndex = 3
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(529, 324)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(73, 13)
        Me.label6.TabIndex = 4
        Me.label6.Text = "Pattern Image"
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(17, 345)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(75, 36)
        Me.loadImageButton.TabIndex = 5
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(87, 395)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(288, 20)
        Me.imagePath.TabIndex = 6
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(19, 397)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(61, 13)
        Me.label7.TabIndex = 7
        Me.label7.Text = "Image Path"
        '
        'learnPatternButton
        '
        Me.learnPatternButton.Enabled = False
        Me.learnPatternButton.Location = New System.Drawing.Point(99, 345)
        Me.learnPatternButton.Name = "learnPatternButton"
        Me.learnPatternButton.Size = New System.Drawing.Size(80, 36)
        Me.learnPatternButton.TabIndex = 8
        Me.learnPatternButton.Text = "Learn Pattern"
        Me.learnPatternButton.UseVisualStyleBackColor = True
        '
        'matchPatternButton
        '
        Me.matchPatternButton.Enabled = False
        Me.matchPatternButton.Location = New System.Drawing.Point(187, 345)
        Me.matchPatternButton.Name = "matchPatternButton"
        Me.matchPatternButton.Size = New System.Drawing.Size(82, 36)
        Me.matchPatternButton.TabIndex = 9
        Me.matchPatternButton.Text = "Match Pattern"
        Me.matchPatternButton.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(388, 173)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(64, 13)
        Me.label8.TabIndex = 10
        Me.label8.Text = "Instructions:"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(388, 189)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(108, 13)
        Me.label9.TabIndex = 11
        Me.label9.Text = "1. Load an image file."
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(388, 206)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(239, 33)
        Me.label10.TabIndex = 11
        Me.label10.Text = "2. Draw a rectangle around the pattern you want to match.  Click Learn Pattern."
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(388, 239)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(239, 62)
        Me.label11.TabIndex = 12
        Me.label11.Text = "3. Load a new image and click Match Pattern to search for pattern matches.  If ne" & _
            "cessary, draw a rectangle to restrict the search to a part of the image."
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(275, 345)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(49, 36)
        Me.exitButton.TabIndex = 13
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(384, 397)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(24, 19)
        Me.browseButton.TabIndex = 15
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 420)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.matchPatternButton)
        Me.Controls.Add(Me.learnPatternButton)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.imageViewerPattern)
        Me.Controls.Add(Me.resultsBox)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageViewerMain)
        Me.Name = "Form1"
        Me.Text = "Pattern Matching Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.matchesRequested, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimumContrast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimumScore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.resultsBox.ResumeLayout(False)
        Me.resultsBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewerMain As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label3 As System.Windows.Forms.Label
    Private minimumContrast As System.Windows.Forms.NumericUpDown
    Private label2 As System.Windows.Forms.Label
    Private minimumScore As System.Windows.Forms.NumericUpDown
    Private label1 As System.Windows.Forms.Label
    Private matchMode As System.Windows.Forms.ComboBox
    Private subpixelAccuracy As System.Windows.Forms.CheckBox
    Private label4 As System.Windows.Forms.Label
    Private matchesRequested As System.Windows.Forms.NumericUpDown
    Private resultsBox As System.Windows.Forms.GroupBox
    Private label5 As System.Windows.Forms.Label
    Private matchesFound As System.Windows.Forms.TextBox
    Private imageViewerPattern As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label6 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private imagePath As System.Windows.Forms.TextBox
    Private label7 As System.Windows.Forms.Label
    Private WithEvents learnPatternButton As System.Windows.Forms.Button
    Private WithEvents matchPatternButton As System.Windows.Forms.Button
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
