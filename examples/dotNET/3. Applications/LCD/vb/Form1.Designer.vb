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
        Me.number = New System.Windows.Forms.TextBox
        Me.quitButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Segments1 = New NationalInstruments.Vision.MeasurementStudioDemo.Segments
        Me.Segments2 = New NationalInstruments.Vision.MeasurementStudioDemo.Segments
        Me.Segments3 = New NationalInstruments.Vision.MeasurementStudioDemo.Segments
        Me.Segments4 = New NationalInstruments.Vision.MeasurementStudioDemo.Segments
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(262, 226)
        Me.imageViewer1.TabIndex = 0
        '
        'number
        '
        Me.number.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.number.Location = New System.Drawing.Point(292, 139)
        Me.number.Name = "number"
        Me.number.ReadOnly = True
        Me.number.Size = New System.Drawing.Size(170, 31)
        Me.number.TabIndex = 2
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(209, 261)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(64, 30)
        Me.quitButton.TabIndex = 4
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'Segments1
        '
        Me.Segments1.AutoSize = True
        Me.Segments1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Segments1.Location = New System.Drawing.Point(292, 12)
        Me.Segments1.Name = "Segments1"
        Me.Segments1.Size = New System.Drawing.Size(63, 121)
        Me.Segments1.TabIndex = 5
        '
        'Segments2
        '
        Me.Segments2.AutoSize = True
        Me.Segments2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Segments2.Location = New System.Drawing.Point(361, 12)
        Me.Segments2.Name = "Segments2"
        Me.Segments2.Size = New System.Drawing.Size(63, 121)
        Me.Segments2.TabIndex = 5
        '
        'Segments3
        '
        Me.Segments3.AutoSize = True
        Me.Segments3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Segments3.Location = New System.Drawing.Point(430, 12)
        Me.Segments3.Name = "Segments3"
        Me.Segments3.Size = New System.Drawing.Size(63, 121)
        Me.Segments3.TabIndex = 5
        '
        'Segments4
        '
        Me.Segments4.AutoSize = True
        Me.Segments4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Segments4.Location = New System.Drawing.Point(499, 12)
        Me.Segments4.Name = "Segments4"
        Me.Segments4.Size = New System.Drawing.Size(63, 121)
        Me.Segments4.TabIndex = 5
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(292, 176)
        Me.DelaySlider1.Maximum = 1500
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 6
        Me.DelaySlider1.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 319)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.Segments4)
        Me.Controls.Add(Me.Segments3)
        Me.Controls.Add(Me.Segments2)
        Me.Controls.Add(Me.Segments1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.number)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "LCD Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private number As System.Windows.Forms.TextBox
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents Segments1 As NationalInstruments.Vision.MeasurementStudioDemo.Segments
    Friend WithEvents Segments2 As NationalInstruments.Vision.MeasurementStudioDemo.Segments
    Friend WithEvents Segments3 As NationalInstruments.Vision.MeasurementStudioDemo.Segments
    Friend WithEvents Segments4 As NationalInstruments.Vision.MeasurementStudioDemo.Segments
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class