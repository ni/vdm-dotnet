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
        Me.startReadingButton = New System.Windows.Forms.Button
        Me.pauseReadingButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.delay = New System.Windows.Forms.NumericUpDown
        Me.label1 = New System.Windows.Forms.Label
        Me.readTextBox = New System.Windows.Forms.TextBox
        CType(Me.delay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(19, 7)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(298, 288)
        Me.imageViewer1.TabIndex = 0
        '
        'startReadingButton
        '
        Me.startReadingButton.Location = New System.Drawing.Point(19, 301)
        Me.startReadingButton.Name = "startReadingButton"
        Me.startReadingButton.Size = New System.Drawing.Size(92, 36)
        Me.startReadingButton.TabIndex = 1
        Me.startReadingButton.Text = "Start Reading"
        Me.startReadingButton.UseVisualStyleBackColor = True
        '
        'pauseReadingButton
        '
        Me.pauseReadingButton.Location = New System.Drawing.Point(19, 345)
        Me.pauseReadingButton.Name = "pauseReadingButton"
        Me.pauseReadingButton.Size = New System.Drawing.Size(92, 36)
        Me.pauseReadingButton.TabIndex = 2
        Me.pauseReadingButton.Text = "Pause Reading"
        Me.pauseReadingButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(21, 389)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(89, 32)
        Me.quitButton.TabIndex = 3
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        '
        'delay
        '
        Me.delay.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.delay.Location = New System.Drawing.Point(191, 317)
        Me.delay.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.delay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.delay.Name = "delay"
        Me.delay.Size = New System.Drawing.Size(54, 20)
        Me.delay.TabIndex = 4
        Me.delay.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(191, 300)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(56, 13)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Delay (ms)"
        '
        'readTextBox
        '
        Me.readTextBox.Location = New System.Drawing.Point(122, 306)
        Me.readTextBox.Name = "readTextBox"
        Me.readTextBox.Size = New System.Drawing.Size(59, 20)
        Me.readTextBox.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 424)
        Me.Controls.Add(Me.readTextBox)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.delay)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.pauseReadingButton)
        Me.Controls.Add(Me.startReadingButton)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "OCR"
        CType(Me.delay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents startReadingButton As System.Windows.Forms.Button
    Private WithEvents pauseReadingButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents delay As System.Windows.Forms.NumericUpDown
    Private label1 As System.Windows.Forms.Label
    Private readTextBox As System.Windows.Forms.TextBox
End Class