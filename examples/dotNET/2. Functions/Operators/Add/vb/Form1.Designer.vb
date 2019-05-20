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
        Me.imagePath1 = New System.Windows.Forms.TextBox
        Me.browseButton1 = New System.Windows.Forms.Button
        Me.imagePath2 = New System.Windows.Forms.TextBox
        Me.browseButton2 = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.imageViewer3 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.loadImagesButton = New System.Windows.Forms.Button
        Me.addImagesButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(16, 20)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(231, 242)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(270, 20)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(231, 242)
        Me.imageViewer2.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(82, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Source Image 1"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(267, 4)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Source Image 2"
        '
        'imagePath1
        '
        Me.imagePath1.Location = New System.Drawing.Point(16, 272)
        Me.imagePath1.Multiline = True
        Me.imagePath1.Name = "imagePath1"
        Me.imagePath1.Size = New System.Drawing.Size(213, 45)
        Me.imagePath1.TabIndex = 2
        '
        'browseButton1
        '
        Me.browseButton1.Location = New System.Drawing.Point(235, 273)
        Me.browseButton1.Name = "browseButton1"
        Me.browseButton1.Size = New System.Drawing.Size(25, 20)
        Me.browseButton1.TabIndex = 3
        Me.browseButton1.Text = "..."
        Me.browseButton1.UseVisualStyleBackColor = True
        '
        'imagePath2
        '
        Me.imagePath2.Location = New System.Drawing.Point(270, 272)
        Me.imagePath2.Multiline = True
        Me.imagePath2.Name = "imagePath2"
        Me.imagePath2.Size = New System.Drawing.Size(213, 45)
        Me.imagePath2.TabIndex = 2
        '
        'browseButton2
        '
        Me.browseButton2.Location = New System.Drawing.Point(489, 273)
        Me.browseButton2.Name = "browseButton2"
        Me.browseButton2.Size = New System.Drawing.Size(25, 20)
        Me.browseButton2.TabIndex = 3
        Me.browseButton2.Text = "..."
        Me.browseButton2.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(267, 320)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(213, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "(Image 2 must be the same size as Image 1)"
        '
        'imageViewer3
        '
        Me.imageViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer3.Location = New System.Drawing.Point(16, 345)
        Me.imageViewer3.Name = "imageViewer3"
        Me.imageViewer3.Size = New System.Drawing.Size(231, 242)
        Me.imageViewer3.TabIndex = 0
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(13, 329)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(69, 13)
        Me.label4.TabIndex = 5
        Me.label4.Text = "Result Image"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(267, 358)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 13)
        Me.label5.TabIndex = 6
        Me.label5.Text = "Instructions:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(267, 381)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(100, 13)
        Me.label6.TabIndex = 6
        Me.label6.Text = "1. Load the images."
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(267, 404)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(95, 13)
        Me.label7.TabIndex = 6
        Me.label7.Text = "2. Add the images."
        '
        'loadImagesButton
        '
        Me.loadImagesButton.Location = New System.Drawing.Point(421, 367)
        Me.loadImagesButton.Name = "loadImagesButton"
        Me.loadImagesButton.Size = New System.Drawing.Size(79, 26)
        Me.loadImagesButton.TabIndex = 7
        Me.loadImagesButton.Text = "Load Images"
        Me.loadImagesButton.UseVisualStyleBackColor = True
        '
        'addImagesButton
        '
        Me.addImagesButton.Enabled = False
        Me.addImagesButton.Location = New System.Drawing.Point(421, 397)
        Me.addImagesButton.Name = "addImagesButton"
        Me.addImagesButton.Size = New System.Drawing.Size(79, 26)
        Me.addImagesButton.TabIndex = 7
        Me.addImagesButton.Text = "Add Images"
        Me.addImagesButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(421, 429)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(79, 26)
        Me.quitButton.TabIndex = 7
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 596)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.addImagesButton)
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
        Me.Text = "Add Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private imagePath1 As System.Windows.Forms.TextBox
    Private WithEvents browseButton1 As System.Windows.Forms.Button
    Private imagePath2 As System.Windows.Forms.TextBox
    Private WithEvents browseButton2 As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private imageViewer3 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private WithEvents loadImagesButton As System.Windows.Forms.Button
    Private WithEvents addImagesButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
End Class