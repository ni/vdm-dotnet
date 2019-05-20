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
        Me.quitButton = New System.Windows.Forms.Button
        Me.compareImagesButton = New System.Windows.Forms.Button
        Me.loadImagesButton = New System.Windows.Forms.Button
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.browseButton2 = New System.Windows.Forms.Button
        Me.browseButton1 = New System.Windows.Forms.Button
        Me.imagePath2 = New System.Windows.Forms.TextBox
        Me.imagePath1 = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer3 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label8 = New System.Windows.Forms.Label
        Me.comparisonBox = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(398, 431)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(98, 26)
        Me.quitButton.TabIndex = 23
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'compareImagesButton
        '
        Me.compareImagesButton.Enabled = False
        Me.compareImagesButton.Location = New System.Drawing.Point(398, 399)
        Me.compareImagesButton.Name = "compareImagesButton"
        Me.compareImagesButton.Size = New System.Drawing.Size(98, 26)
        Me.compareImagesButton.TabIndex = 25
        Me.compareImagesButton.Text = "Compare Images"
        Me.compareImagesButton.UseVisualStyleBackColor = True
        '
        'loadImagesButton
        '
        Me.loadImagesButton.Location = New System.Drawing.Point(398, 369)
        Me.loadImagesButton.Name = "loadImagesButton"
        Me.loadImagesButton.Size = New System.Drawing.Size(98, 26)
        Me.loadImagesButton.TabIndex = 24
        Me.loadImagesButton.Text = "Load Images"
        Me.loadImagesButton.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(263, 406)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(129, 45)
        Me.label7.TabIndex = 19
        Me.label7.Text = "2. Compare the two images.  Try different comparison operators."
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(263, 383)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(100, 13)
        Me.label6.TabIndex = 20
        Me.label6.Text = "1. Load the images."
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(263, 360)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 13)
        Me.label5.TabIndex = 21
        Me.label5.Text = "Instructions:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(9, 331)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(69, 13)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Result Image"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(263, 322)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(213, 13)
        Me.label3.TabIndex = 17
        Me.label3.Text = "(Image 2 must be the same size as Image 1)"
        '
        'browseButton2
        '
        Me.browseButton2.Location = New System.Drawing.Point(485, 275)
        Me.browseButton2.Name = "browseButton2"
        Me.browseButton2.Size = New System.Drawing.Size(25, 20)
        Me.browseButton2.TabIndex = 15
        Me.browseButton2.Text = "..."
        Me.browseButton2.UseVisualStyleBackColor = True
        '
        'browseButton1
        '
        Me.browseButton1.Location = New System.Drawing.Point(231, 275)
        Me.browseButton1.Name = "browseButton1"
        Me.browseButton1.Size = New System.Drawing.Size(25, 20)
        Me.browseButton1.TabIndex = 16
        Me.browseButton1.Text = "..."
        Me.browseButton1.UseVisualStyleBackColor = True
        '
        'imagePath2
        '
        Me.imagePath2.Location = New System.Drawing.Point(266, 274)
        Me.imagePath2.Multiline = True
        Me.imagePath2.Name = "imagePath2"
        Me.imagePath2.Size = New System.Drawing.Size(213, 45)
        Me.imagePath2.TabIndex = 13
        '
        'imagePath1
        '
        Me.imagePath1.Location = New System.Drawing.Point(12, 274)
        Me.imagePath1.Multiline = True
        Me.imagePath1.Name = "imagePath1"
        Me.imagePath1.Size = New System.Drawing.Size(213, 45)
        Me.imagePath1.TabIndex = 14
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(263, 6)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 13)
        Me.label2.TabIndex = 11
        Me.label2.Text = "Source Image 2"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(82, 13)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Source Image 1"
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(266, 22)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(231, 242)
        Me.imageViewer2.TabIndex = 8
        '
        'imageViewer3
        '
        Me.imageViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer3.Location = New System.Drawing.Point(12, 347)
        Me.imageViewer3.Name = "imageViewer3"
        Me.imageViewer3.Size = New System.Drawing.Size(231, 242)
        Me.imageViewer3.TabIndex = 9
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 22)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(231, 242)
        Me.imageViewer1.TabIndex = 10
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(265, 506)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(106, 13)
        Me.label8.TabIndex = 26
        Me.label8.Text = "Comparison Operator"
        '
        'comparisonBox
        '
        Me.comparisonBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comparisonBox.FormattingEnabled = True
        Me.comparisonBox.Items.AddRange(New Object() {"Clear if <", "Clear if <=", "Clear if =", "Clear if >=", "Clear if >"})
        Me.comparisonBox.Location = New System.Drawing.Point(266, 530)
        Me.comparisonBox.Name = "comparisonBox"
        Me.comparisonBox.Size = New System.Drawing.Size(104, 21)
        Me.comparisonBox.TabIndex = 27
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 604)
        Me.Controls.Add(Me.comparisonBox)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.compareImagesButton)
        Me.Controls.Add(Me.loadImagesButton)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.browseButton2)
        Me.Controls.Add(Me.browseButton1)
        Me.Controls.Add(Me.imagePath2)
        Me.Controls.Add(Me.imagePath1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer3)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Compare Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents compareImagesButton As System.Windows.Forms.Button
    Private WithEvents loadImagesButton As System.Windows.Forms.Button
    Private label7 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private WithEvents browseButton2 As System.Windows.Forms.Button
    Private WithEvents browseButton1 As System.Windows.Forms.Button
    Private imagePath2 As System.Windows.Forms.TextBox
    Private imagePath1 As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer3 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label8 As System.Windows.Forms.Label
    Private comparisonBox As System.Windows.Forms.ComboBox
End Class