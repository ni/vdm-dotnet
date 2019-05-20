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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.loadButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.distanceTextBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(327, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(263, 71)
        Me.label1.TabIndex = 0
        Me.label1.Text = resources.GetString("label1.Text")
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 26)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(107, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Demonstration Image"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(10, 42)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(277, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(293, 42)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(26, 20)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(10, 96)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(292, 232)
        Me.imageViewer1.TabIndex = 4
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(308, 96)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(292, 232)
        Me.imageViewer2.TabIndex = 4
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(450, 334)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(72, 39)
        Me.loadButton.TabIndex = 5
        Me.loadButton.Text = "Load Image"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(531, 334)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(69, 39)
        Me.quitButton.TabIndex = 5
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 80)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(92, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Image to Measure"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(305, 80)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(89, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "2D Color Triangle"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(7, 336)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(333, 25)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Color Distance (in CIE L*a*b*):"
        '
        'distanceTextBox
        '
        Me.distanceTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.distanceTextBox.Location = New System.Drawing.Point(346, 335)
        Me.distanceTextBox.Name = "distanceTextBox"
        Me.distanceTextBox.ReadOnly = True
        Me.distanceTextBox.Size = New System.Drawing.Size(98, 31)
        Me.distanceTextBox.TabIndex = 8
        Me.distanceTextBox.Text = "0.00"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 383)
        Me.Controls.Add(Me.distanceTextBox)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Color Distance Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private distanceTextBox As System.Windows.Forms.TextBox
End Class