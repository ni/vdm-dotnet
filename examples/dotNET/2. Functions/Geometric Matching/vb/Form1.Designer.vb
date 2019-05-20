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
        Me.imageViewer = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.templatePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.loadButton = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.searchButton = New System.Windows.Forms.Button
        Me.label5 = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.searchParameters = New System.Windows.Forms.GroupBox
        Me.occlusionInvariant = New System.Windows.Forms.CheckBox
        Me.scaleInvariant = New System.Windows.Forms.CheckBox
        Me.rotationInvariant = New System.Windows.Forms.CheckBox
        Me.label11 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.minScore = New System.Windows.Forms.NumericUpDown
        Me.numMatches = New System.Windows.Forms.NumericUpDown
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.label7 = New System.Windows.Forms.Label
        Me.templateImageViewer = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label8 = New System.Windows.Forms.Label
        Me.searchParameters.SuspendLayout()
        CType(Me.minScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMatches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer
        '
        Me.imageViewer.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer.Location = New System.Drawing.Point(390, 29)
        Me.imageViewer.Name = "imageViewer"
        Me.imageViewer.Size = New System.Drawing.Size(601, 472)
        Me.imageViewer.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(392, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(36, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image"
        '
        'templatePath
        '
        Me.templatePath.Location = New System.Drawing.Point(10, 27)
        Me.templatePath.Multiline = True
        Me.templatePath.Name = "templatePath"
        Me.templatePath.Size = New System.Drawing.Size(292, 40)
        Me.templatePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(308, 27)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(57, 29)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "Browse"
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 11)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(95, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Template File Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(10, 125)
        Me.imagePath.Multiline = True
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(292, 39)
        Me.imagePath.TabIndex = 5
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 108)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(80, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Image File Path"
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(10, 184)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(87, 40)
        Me.loadButton.TabIndex = 7
        Me.loadButton.Text = "Load File"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(104, 198)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(91, 13)
        Me.label4.TabIndex = 8
        Me.label4.Text = "1. Click Load File."
        '
        'searchButton
        '
        Me.searchButton.Enabled = False
        Me.searchButton.Location = New System.Drawing.Point(10, 230)
        Me.searchButton.Name = "searchButton"
        Me.searchButton.Size = New System.Drawing.Size(87, 40)
        Me.searchButton.TabIndex = 7
        Me.searchButton.Text = "Search"
        Me.searchButton.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(103, 230)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(239, 40)
        Me.label5.TabIndex = 8
        Me.label5.Text = "2. Search the ROI to look for the locations of the template.  If no ROI is specif" & _
            "ied, the entire image will be searched."
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(10, 511)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(87, 41)
        Me.exitButton.TabIndex = 7
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(103, 526)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(170, 27)
        Me.label6.TabIndex = 8
        Me.label6.Text = "3. Stop the example."
        '
        'searchParameters
        '
        Me.searchParameters.Controls.Add(Me.occlusionInvariant)
        Me.searchParameters.Controls.Add(Me.scaleInvariant)
        Me.searchParameters.Controls.Add(Me.rotationInvariant)
        Me.searchParameters.Controls.Add(Me.label11)
        Me.searchParameters.Controls.Add(Me.label10)
        Me.searchParameters.Controls.Add(Me.label9)
        Me.searchParameters.Controls.Add(Me.minScore)
        Me.searchParameters.Controls.Add(Me.numMatches)
        Me.searchParameters.Location = New System.Drawing.Point(13, 283)
        Me.searchParameters.Name = "searchParameters"
        Me.searchParameters.Size = New System.Drawing.Size(141, 218)
        Me.searchParameters.TabIndex = 9
        Me.searchParameters.TabStop = False
        Me.searchParameters.Text = "Search Parameters"
        '
        'occlusionInvariant
        '
        Me.occlusionInvariant.AutoSize = True
        Me.occlusionInvariant.Location = New System.Drawing.Point(27, 82)
        Me.occlusionInvariant.Name = "occlusionInvariant"
        Me.occlusionInvariant.Size = New System.Drawing.Size(73, 17)
        Me.occlusionInvariant.TabIndex = 14
        Me.occlusionInvariant.Text = "Occlusion"
        Me.occlusionInvariant.UseVisualStyleBackColor = True
        '
        'scaleInvariant
        '
        Me.scaleInvariant.AutoSize = True
        Me.scaleInvariant.Location = New System.Drawing.Point(27, 59)
        Me.scaleInvariant.Name = "scaleInvariant"
        Me.scaleInvariant.Size = New System.Drawing.Size(53, 17)
        Me.scaleInvariant.TabIndex = 13
        Me.scaleInvariant.Text = "Scale"
        Me.scaleInvariant.UseVisualStyleBackColor = True
        '
        'rotationInvariant
        '
        Me.rotationInvariant.AutoSize = True
        Me.rotationInvariant.Checked = True
        Me.rotationInvariant.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rotationInvariant.Location = New System.Drawing.Point(27, 36)
        Me.rotationInvariant.Name = "rotationInvariant"
        Me.rotationInvariant.Size = New System.Drawing.Size(66, 17)
        Me.rotationInvariant.TabIndex = 12
        Me.rotationInvariant.Text = "Rotation"
        Me.rotationInvariant.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(22, 166)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(79, 13)
        Me.label11.TabIndex = 11
        Me.label11.Text = "Minimum Score"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(23, 115)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(100, 13)
        Me.label10.TabIndex = 10
        Me.label10.Text = "Number of Matches"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(24, 20)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(67, 13)
        Me.label9.TabIndex = 9
        Me.label9.Text = "Match Mode"
        '
        'minScore
        '
        Me.minScore.Location = New System.Drawing.Point(26, 183)
        Me.minScore.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.minScore.Name = "minScore"
        Me.minScore.Size = New System.Drawing.Size(63, 20)
        Me.minScore.TabIndex = 1
        Me.minScore.Value = New Decimal(New Integer() {800, 0, 0, 0})
        '
        'numMatches
        '
        Me.numMatches.Location = New System.Drawing.Point(26, 133)
        Me.numMatches.Name = "numMatches"
        Me.numMatches.Size = New System.Drawing.Size(63, 20)
        Me.numMatches.TabIndex = 1
        Me.numMatches.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(8, 68)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(294, 40)
        Me.label7.TabIndex = 10
        Me.label7.Text = "The Template File was created using the Geometric Matching Training Interface.  "
        '
        'templateImageViewer
        '
        Me.templateImageViewer.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.templateImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.templateImageViewer.Location = New System.Drawing.Point(167, 299)
        Me.templateImageViewer.Name = "templateImageViewer"
        Me.templateImageViewer.Size = New System.Drawing.Size(211, 202)
        Me.templateImageViewer.TabIndex = 11
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(169, 282)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(51, 13)
        Me.label8.TabIndex = 12
        Me.label8.Text = "Template"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 563)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.templateImageViewer)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.searchParameters)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.searchButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.templatePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer)
        Me.Name = "Form1"
        Me.Text = "Geometric Matching"
        Me.searchParameters.ResumeLayout(False)
        Me.searchParameters.PerformLayout()
        CType(Me.minScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMatches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private templatePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private WithEvents searchButton As System.Windows.Forms.Button
    Private label5 As System.Windows.Forms.Label
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private label6 As System.Windows.Forms.Label
    Private searchParameters As System.Windows.Forms.GroupBox
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private label7 As System.Windows.Forms.Label
    Private templateImageViewer As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private WithEvents minScore As System.Windows.Forms.NumericUpDown
    Private WithEvents numMatches As System.Windows.Forms.NumericUpDown
    Private label10 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private WithEvents occlusionInvariant As System.Windows.Forms.CheckBox
    Private WithEvents scaleInvariant As System.Windows.Forms.CheckBox
    Private WithEvents rotationInvariant As System.Windows.Forms.CheckBox
End Class

