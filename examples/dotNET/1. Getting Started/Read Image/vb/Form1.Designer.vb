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
        Me.imageType = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(18, 8)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowImageInfo = True
        Me.imageViewer1.ShowScrollbars = True
        Me.imageViewer1.Size = New System.Drawing.Size(467, 336)
        Me.imageViewer1.TabIndex = 0
        '
        'imageType
        '
        Me.imageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.imageType.FormattingEnabled = True
        Me.imageType.Items.AddRange(New Object() {"8 bits", "16 bits (signed)", "Float", "Complex", "Rgb32", "Hsl32", "RgbU64", "16 bits (unsigned)"})
        Me.imageType.Location = New System.Drawing.Point(18, 377)
        Me.imageType.Name = "imageType"
        Me.imageType.Size = New System.Drawing.Size(131, 21)
        Me.imageType.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(15, 361)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Image Type"
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(319, 361)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(80, 35)
        Me.loadImageButton.TabIndex = 3
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(405, 361)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(80, 35)
        Me.exitButton.TabIndex = 3
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 431)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageType)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents imageType As System.Windows.Forms.ComboBox
    Private label1 As System.Windows.Forms.Label
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents exitButton As System.Windows.Forms.Button
End Class

