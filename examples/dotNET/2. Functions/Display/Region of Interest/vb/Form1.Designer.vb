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
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.loadButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 8)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowToolbar = True
        Me.imageViewer1.Size = New System.Drawing.Size(534, 330)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 349)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(76, 349)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(436, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(518, 349)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 19)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(497, 439)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(47, 31)
        Me.quitButton.TabIndex = 4
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(417, 439)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(74, 31)
        Me.loadButton.TabIndex = 4
        Me.loadButton.Text = "Load Image"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(12, 381)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(531, 55)
        Me.label2.TabIndex = 5
        Me.label2.Text = resources.GetString("label2.Text")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 473)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Region of Interest Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
End Class