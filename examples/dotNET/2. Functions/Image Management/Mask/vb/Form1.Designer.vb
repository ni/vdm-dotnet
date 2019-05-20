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
        Me.sourceImagePath = New System.Windows.Forms.TextBox
        Me.maskImagePath = New System.Windows.Forms.TextBox
        Me.sourceBrowseButton = New System.Windows.Forms.Button
        Me.maskImageButton = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.imageViewerMask = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.loadImagesButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(10, 8)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowToolbar = True
        Me.imageViewer1.Size = New System.Drawing.Size(249, 270)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(265, 8)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.ShowToolbar = True
        Me.imageViewer2.Size = New System.Drawing.Size(249, 270)
        Me.imageViewer2.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 292)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(98, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Source Image Path"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(14, 316)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(90, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Mask Image Path"
        '
        'sourceImagePath
        '
        Me.sourceImagePath.Location = New System.Drawing.Point(110, 289)
        Me.sourceImagePath.Name = "sourceImagePath"
        Me.sourceImagePath.Size = New System.Drawing.Size(368, 20)
        Me.sourceImagePath.TabIndex = 2
        '
        'maskImagePath
        '
        Me.maskImagePath.Location = New System.Drawing.Point(110, 313)
        Me.maskImagePath.Name = "maskImagePath"
        Me.maskImagePath.Size = New System.Drawing.Size(368, 20)
        Me.maskImagePath.TabIndex = 2
        '
        'sourceBrowseButton
        '
        Me.sourceBrowseButton.Location = New System.Drawing.Point(484, 290)
        Me.sourceBrowseButton.Name = "sourceBrowseButton"
        Me.sourceBrowseButton.Size = New System.Drawing.Size(30, 19)
        Me.sourceBrowseButton.TabIndex = 3
        Me.sourceBrowseButton.Text = "..."
        Me.sourceBrowseButton.UseVisualStyleBackColor = True
        '
        'maskImageButton
        '
        Me.maskImageButton.Location = New System.Drawing.Point(484, 313)
        Me.maskImageButton.Name = "maskImageButton"
        Me.maskImageButton.Size = New System.Drawing.Size(30, 19)
        Me.maskImageButton.TabIndex = 3
        Me.maskImageButton.Text = "..."
        Me.maskImageButton.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 360)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(65, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Mask Image"
        '
        'imageViewerMask
        '
        Me.imageViewerMask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewerMask.Location = New System.Drawing.Point(10, 376)
        Me.imageViewerMask.Name = "imageViewerMask"
        Me.imageViewerMask.Size = New System.Drawing.Size(93, 86)
        Me.imageViewerMask.TabIndex = 5
        '
        'loadImagesButton
        '
        Me.loadImagesButton.Location = New System.Drawing.Point(425, 390)
        Me.loadImagesButton.Name = "loadImagesButton"
        Me.loadImagesButton.Size = New System.Drawing.Size(88, 33)
        Me.loadImagesButton.TabIndex = 6
        Me.loadImagesButton.Text = "Load Images"
        Me.loadImagesButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(425, 429)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(88, 33)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(138, 356)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(64, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "Instructions:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(138, 376)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(116, 13)
        Me.label5.TabIndex = 7
        Me.label5.Text = "1. Load the image files."
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(138, 398)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(231, 27)
        Me.label6.TabIndex = 7
        Me.label6.Text = "2. Click a point in viewer 1 to view the masked image in viewer 2."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 474)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.loadImagesButton)
        Me.Controls.Add(Me.imageViewerMask)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.maskImageButton)
        Me.Controls.Add(Me.sourceBrowseButton)
        Me.Controls.Add(Me.maskImagePath)
        Me.Controls.Add(Me.sourceImagePath)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Mask Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private sourceImagePath As System.Windows.Forms.TextBox
    Private maskImagePath As System.Windows.Forms.TextBox
    Private WithEvents sourceBrowseButton As System.Windows.Forms.Button
    Private WithEvents maskImageButton As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private imageViewerMask As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents loadImagesButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
End Class