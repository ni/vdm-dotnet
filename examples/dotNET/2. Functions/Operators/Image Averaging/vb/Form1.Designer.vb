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
        Me.components = New System.ComponentModel.Container
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.filenameLabel = New System.Windows.Forms.Label
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.averageButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(10, 21)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(443, 225)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(76, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Source Image:"
        '
        'filenameLabel
        '
        Me.filenameLabel.AutoSize = True
        Me.filenameLabel.Location = New System.Drawing.Point(82, 5)
        Me.filenameLabel.Name = "filenameLabel"
        Me.filenameLabel.Size = New System.Drawing.Size(68, 13)
        Me.filenameLabel.TabIndex = 2
        Me.filenameLabel.Text = "noise-00.png"
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(10, 278)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(443, 225)
        Me.imageViewer2.TabIndex = 0
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 262)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(88, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Averaged Image:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(459, 5)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Instructions:"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(459, 30)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(139, 45)
        Me.label4.TabIndex = 3
        Me.label4.Text = "1. Click the Load Next Image button several times to load the noisy images."
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(459, 84)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(139, 17)
        Me.label5.TabIndex = 3
        Me.label5.Text = "2. Average the images."
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(462, 115)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(124, 31)
        Me.loadImageButton.TabIndex = 4
        Me.loadImageButton.Text = "Load Next Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'averageButton
        '
        Me.averageButton.Location = New System.Drawing.Point(462, 152)
        Me.averageButton.Name = "averageButton"
        Me.averageButton.Size = New System.Drawing.Size(124, 31)
        Me.averageButton.TabIndex = 4
        Me.averageButton.Text = "Average Images"
        Me.averageButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(462, 189)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(124, 31)
        Me.quitButton.TabIndex = 4
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 511)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.averageButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.filenameLabel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Image Averaging Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private filenameLabel As System.Windows.Forms.Label
    Private WithEvents imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents averageButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
End Class