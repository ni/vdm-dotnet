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
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.exitButton = New System.Windows.Forms.Button
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.ClassificationGraph1 = New NationalInstruments.Vision.MeasurementStudioDemo.ClassificationGraph
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.SuspendLayout()
        '
        'timer1
        '
        Me.timer1.Interval = 1250
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(835, 439)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(62, 39)
        Me.exitButton.TabIndex = 3
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(21, 13)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(521, 465)
        Me.imageViewer1.TabIndex = 4
        '
        'ClassificationGraph1
        '
        Me.ClassificationGraph1.AutoSize = True
        Me.ClassificationGraph1.Location = New System.Drawing.Point(548, 13)
        Me.ClassificationGraph1.Name = "ClassificationGraph1"
        Me.ClassificationGraph1.Size = New System.Drawing.Size(352, 201)
        Me.ClassificationGraph1.TabIndex = 5
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(548, 220)
        Me.DelaySlider1.Maximum = 2500
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 6
        Me.DelaySlider1.Value = 1250
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 490)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.ClassificationGraph1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.exitButton)
        Me.Name = "Form1"
        Me.Text = "Classification"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Friend WithEvents ClassificationGraph1 As NationalInstruments.Vision.MeasurementStudioDemo.ClassificationGraph
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class