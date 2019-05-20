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
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog
        Me.label1 = New System.Windows.Forms.Label
        Me.overlaidTextBox = New System.Windows.Forms.TextBox
        Me.quitButton = New System.Windows.Forms.Button
        Me.textColorButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(451, 354)
        Me.imageViewer1.TabIndex = 0
        '
        'colorDialog1
        '
        Me.colorDialog1.Color = System.Drawing.Color.Lime
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 380)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(70, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Overlaid Text"
        '
        'overlaidTextBox
        '
        Me.overlaidTextBox.ForeColor = System.Drawing.Color.Lime
        Me.overlaidTextBox.Location = New System.Drawing.Point(12, 396)
        Me.overlaidTextBox.Multiline = True
        Me.overlaidTextBox.Name = "overlaidTextBox"
        Me.overlaidTextBox.Size = New System.Drawing.Size(148, 42)
        Me.overlaidTextBox.TabIndex = 2
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(376, 396)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(87, 31)
        Me.quitButton.TabIndex = 3
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'textColorButton
        '
        Me.textColorButton.Location = New System.Drawing.Point(273, 396)
        Me.textColorButton.Name = "textColorButton"
        Me.textColorButton.Size = New System.Drawing.Size(97, 31)
        Me.textColorButton.TabIndex = 3
        Me.textColorButton.Text = "Select Text Color"
        Me.textColorButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Interval = 200
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 465)
        Me.Controls.Add(Me.textColorButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.overlaidTextBox)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Nondestructive Overlay Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private colorDialog1 As System.Windows.Forms.ColorDialog
    Private label1 As System.Windows.Forms.Label
    Private overlaidTextBox As System.Windows.Forms.TextBox
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents textColorButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
End Class