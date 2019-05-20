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
        Me.label12 = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.actualEdges3 = New System.Windows.Forms.TextBox
        Me.actualEdges2 = New System.Windows.Forms.TextBox
        Me.expectedEdges3 = New System.Windows.Forms.TextBox
        Me.actualEdges1 = New System.Windows.Forms.TextBox
        Me.expectedEdges2 = New System.Windows.Forms.TextBox
        Me.expectedEdges1 = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label11 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.resetButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.testPartsButton = New System.Windows.Forms.Button
        Me.actualEdges5 = New System.Windows.Forms.TextBox
        Me.expectedEdges5 = New System.Windows.Forms.TextBox
        Me.actualEdges4 = New System.Windows.Forms.TextBox
        Me.expectedEdges4 = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.PassFailLed1 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed2 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed3 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed4 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed5 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.globalPassFailLed = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.SuspendLayout()
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(9, 377)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(306, 18)
        Me.label12.TabIndex = 42
        Me.label12.Text = "2. Click Test Parts."
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(156, 286)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(66, 33)
        Me.quitButton.TabIndex = 38
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(570, 15)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(37, 13)
        Me.label8.TabIndex = 29
        Me.label8.Text = "Status"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(504, 2)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(60, 35)
        Me.label7.TabIndex = 28
        Me.label7.Text = "Actual # of Edges"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(437, 2)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(60, 35)
        Me.label6.TabIndex = 27
        Me.label6.Text = "Expected # of Edges"
        '
        'actualEdges3
        '
        Me.actualEdges3.Enabled = False
        Me.actualEdges3.Location = New System.Drawing.Point(507, 84)
        Me.actualEdges3.Name = "actualEdges3"
        Me.actualEdges3.ReadOnly = True
        Me.actualEdges3.Size = New System.Drawing.Size(52, 20)
        Me.actualEdges3.TabIndex = 22
        Me.actualEdges3.Text = "0"
        '
        'actualEdges2
        '
        Me.actualEdges2.Enabled = False
        Me.actualEdges2.Location = New System.Drawing.Point(507, 62)
        Me.actualEdges2.Name = "actualEdges2"
        Me.actualEdges2.ReadOnly = True
        Me.actualEdges2.Size = New System.Drawing.Size(52, 20)
        Me.actualEdges2.TabIndex = 24
        Me.actualEdges2.Text = "0"
        '
        'expectedEdges3
        '
        Me.expectedEdges3.Enabled = False
        Me.expectedEdges3.Location = New System.Drawing.Point(440, 84)
        Me.expectedEdges3.Name = "expectedEdges3"
        Me.expectedEdges3.ReadOnly = True
        Me.expectedEdges3.Size = New System.Drawing.Size(52, 20)
        Me.expectedEdges3.TabIndex = 26
        Me.expectedEdges3.Text = "0"
        '
        'actualEdges1
        '
        Me.actualEdges1.Enabled = False
        Me.actualEdges1.Location = New System.Drawing.Point(507, 40)
        Me.actualEdges1.Name = "actualEdges1"
        Me.actualEdges1.ReadOnly = True
        Me.actualEdges1.Size = New System.Drawing.Size(52, 20)
        Me.actualEdges1.TabIndex = 25
        Me.actualEdges1.Text = "0"
        '
        'expectedEdges2
        '
        Me.expectedEdges2.Enabled = False
        Me.expectedEdges2.Location = New System.Drawing.Point(440, 62)
        Me.expectedEdges2.Name = "expectedEdges2"
        Me.expectedEdges2.ReadOnly = True
        Me.expectedEdges2.Size = New System.Drawing.Size(52, 20)
        Me.expectedEdges2.TabIndex = 18
        Me.expectedEdges2.Text = "0"
        '
        'expectedEdges1
        '
        Me.expectedEdges1.Enabled = False
        Me.expectedEdges1.Location = New System.Drawing.Point(440, 40)
        Me.expectedEdges1.Name = "expectedEdges1"
        Me.expectedEdges1.ReadOnly = True
        Me.expectedEdges1.Size = New System.Drawing.Size(52, 20)
        Me.expectedEdges1.TabIndex = 17
        Me.expectedEdges1.Text = "0"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(387, 87)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(47, 13)
        Me.label3.TabIndex = 13
        Me.label3.Text = "Target 3"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(387, 65)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(47, 13)
        Me.label2.TabIndex = 12
        Me.label2.Text = "Target 2"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(387, 43)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(47, 13)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Target 1"
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Line
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 14)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowToolbar = True
        Me.imageViewer1.Size = New System.Drawing.Size(349, 260)
        Me.imageViewer1.TabIndex = 11
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(9, 346)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(306, 31)
        Me.label11.TabIndex = 43
        Me.label11.Text = "1. Draw an inspection line for each feature you want to detect.  To delete a line" & _
            ", select it and press the Delete key."
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(9, 326)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(64, 13)
        Me.label10.TabIndex = 44
        Me.label10.Text = "Instructions:"
        '
        'resetButton
        '
        Me.resetButton.Enabled = False
        Me.resetButton.Location = New System.Drawing.Point(84, 286)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(66, 33)
        Me.resetButton.TabIndex = 40
        Me.resetButton.Text = "Reset"
        Me.resetButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'testPartsButton
        '
        Me.testPartsButton.Enabled = False
        Me.testPartsButton.Location = New System.Drawing.Point(12, 286)
        Me.testPartsButton.Name = "testPartsButton"
        Me.testPartsButton.Size = New System.Drawing.Size(66, 33)
        Me.testPartsButton.TabIndex = 41
        Me.testPartsButton.Text = "Test Parts"
        Me.testPartsButton.UseVisualStyleBackColor = True
        '
        'actualEdges5
        '
        Me.actualEdges5.Enabled = False
        Me.actualEdges5.Location = New System.Drawing.Point(507, 128)
        Me.actualEdges5.Name = "actualEdges5"
        Me.actualEdges5.ReadOnly = True
        Me.actualEdges5.Size = New System.Drawing.Size(52, 20)
        Me.actualEdges5.TabIndex = 20
        Me.actualEdges5.Text = "0"
        '
        'expectedEdges5
        '
        Me.expectedEdges5.Enabled = False
        Me.expectedEdges5.Location = New System.Drawing.Point(440, 128)
        Me.expectedEdges5.Name = "expectedEdges5"
        Me.expectedEdges5.ReadOnly = True
        Me.expectedEdges5.Size = New System.Drawing.Size(52, 20)
        Me.expectedEdges5.TabIndex = 23
        Me.expectedEdges5.Text = "0"
        '
        'actualEdges4
        '
        Me.actualEdges4.Enabled = False
        Me.actualEdges4.Location = New System.Drawing.Point(507, 106)
        Me.actualEdges4.Name = "actualEdges4"
        Me.actualEdges4.ReadOnly = True
        Me.actualEdges4.Size = New System.Drawing.Size(52, 20)
        Me.actualEdges4.TabIndex = 19
        Me.actualEdges4.Text = "0"
        '
        'expectedEdges4
        '
        Me.expectedEdges4.Enabled = False
        Me.expectedEdges4.Location = New System.Drawing.Point(440, 106)
        Me.expectedEdges4.Name = "expectedEdges4"
        Me.expectedEdges4.ReadOnly = True
        Me.expectedEdges4.Size = New System.Drawing.Size(52, 20)
        Me.expectedEdges4.TabIndex = 21
        Me.expectedEdges4.Text = "0"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(387, 131)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(47, 13)
        Me.label5.TabIndex = 15
        Me.label5.Text = "Target 5"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(387, 109)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(47, 13)
        Me.label4.TabIndex = 16
        Me.label4.Text = "Target 4"
        '
        'PassFailLed1
        '
        Me.PassFailLed1.Caption = ""
        Me.PassFailLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray
        Me.PassFailLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed1.Location = New System.Drawing.Point(573, 40)
        Me.PassFailLed1.Name = "PassFailLed1"
        Me.PassFailLed1.Size = New System.Drawing.Size(32, 24)
        Me.PassFailLed1.TabIndex = 45
        Me.PassFailLed1.Value = True
        '
        'PassFailLed2
        '
        Me.PassFailLed2.Caption = ""
        Me.PassFailLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray
        Me.PassFailLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed2.Location = New System.Drawing.Point(573, 62)
        Me.PassFailLed2.Name = "PassFailLed2"
        Me.PassFailLed2.Size = New System.Drawing.Size(32, 24)
        Me.PassFailLed2.TabIndex = 45
        Me.PassFailLed2.Value = True
        '
        'PassFailLed3
        '
        Me.PassFailLed3.Caption = ""
        Me.PassFailLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray
        Me.PassFailLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed3.Location = New System.Drawing.Point(573, 84)
        Me.PassFailLed3.Name = "PassFailLed3"
        Me.PassFailLed3.Size = New System.Drawing.Size(32, 24)
        Me.PassFailLed3.TabIndex = 45
        Me.PassFailLed3.Value = True
        '
        'PassFailLed4
        '
        Me.PassFailLed4.Caption = ""
        Me.PassFailLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray
        Me.PassFailLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed4.Location = New System.Drawing.Point(573, 106)
        Me.PassFailLed4.Name = "PassFailLed4"
        Me.PassFailLed4.Size = New System.Drawing.Size(32, 24)
        Me.PassFailLed4.TabIndex = 45
        Me.PassFailLed4.Value = True
        '
        'PassFailLed5
        '
        Me.PassFailLed5.Caption = ""
        Me.PassFailLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGray
        Me.PassFailLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed5.Location = New System.Drawing.Point(573, 128)
        Me.PassFailLed5.Name = "PassFailLed5"
        Me.PassFailLed5.Size = New System.Drawing.Size(32, 24)
        Me.PassFailLed5.TabIndex = 45
        Me.PassFailLed5.Value = True
        '
        'globalPassFailLed
        '
        Me.globalPassFailLed.Caption = "Global Pass/Fail"
        Me.globalPassFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen
        Me.globalPassFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.globalPassFailLed.Location = New System.Drawing.Point(391, 168)
        Me.globalPassFailLed.Name = "globalPassFailLed"
        Me.globalPassFailLed.Size = New System.Drawing.Size(213, 59)
        Me.globalPassFailLed.TabIndex = 46
        Me.globalPassFailLed.Value = True
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(388, 259)
        Me.DelaySlider1.Maximum = 1500
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 47
        Me.DelaySlider1.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 395)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.globalPassFailLed)
        Me.Controls.Add(Me.PassFailLed5)
        Me.Controls.Add(Me.PassFailLed4)
        Me.Controls.Add(Me.PassFailLed3)
        Me.Controls.Add(Me.PassFailLed2)
        Me.Controls.Add(Me.PassFailLed1)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.actualEdges3)
        Me.Controls.Add(Me.actualEdges2)
        Me.Controls.Add(Me.expectedEdges3)
        Me.Controls.Add(Me.actualEdges1)
        Me.Controls.Add(Me.expectedEdges2)
        Me.Controls.Add(Me.expectedEdges1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.testPartsButton)
        Me.Controls.Add(Me.actualEdges5)
        Me.Controls.Add(Me.expectedEdges5)
        Me.Controls.Add(Me.actualEdges4)
        Me.Controls.Add(Me.expectedEdges4)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label12 As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label8 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private actualEdges3 As System.Windows.Forms.TextBox
    Private actualEdges2 As System.Windows.Forms.TextBox
    Private expectedEdges3 As System.Windows.Forms.TextBox
    Private actualEdges1 As System.Windows.Forms.TextBox
    Private expectedEdges2 As System.Windows.Forms.TextBox
    Private expectedEdges1 As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label11 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private WithEvents resetButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents testPartsButton As System.Windows.Forms.Button
    Private actualEdges5 As System.Windows.Forms.TextBox
    Private expectedEdges5 As System.Windows.Forms.TextBox
    Private actualEdges4 As System.Windows.Forms.TextBox
    Private expectedEdges4 As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Friend WithEvents PassFailLed1 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed2 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed3 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed4 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed5 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents globalPassFailLed As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class