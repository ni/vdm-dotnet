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
        Me.loadButton = New System.Windows.Forms.Button
        Me.measureButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(15, 10)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(420, 305)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 328)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(78, 325)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(320, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(404, 325)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(31, 19)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(15, 360)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(71, 35)
        Me.loadButton.TabIndex = 4
        Me.loadButton.Text = "Load Image"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'measureButton
        '
        Me.measureButton.Location = New System.Drawing.Point(15, 401)
        Me.measureButton.Name = "measureButton"
        Me.measureButton.Size = New System.Drawing.Size(71, 35)
        Me.measureButton.TabIndex = 4
        Me.measureButton.Text = "Measure Orientation"
        Me.measureButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(364, 401)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(71, 35)
        Me.quitButton.TabIndex = 4
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(101, 363)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(254, 16)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Instructions:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(101, 379)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(254, 16)
        Me.label3.TabIndex = 5
        Me.label3.Text = "1. Load an image file."
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(101, 401)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(254, 16)
        Me.label4.TabIndex = 5
        Me.label4.Text = "2. Measure the particle orientation."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 444)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.measureButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Particle Orientation Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private WithEvents measureButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
End Class