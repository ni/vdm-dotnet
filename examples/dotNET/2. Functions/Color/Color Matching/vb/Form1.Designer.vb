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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.blackSpectrumBox = New System.Windows.Forms.PictureBox
        Me.orangeSpectrumBox = New System.Windows.Forms.PictureBox
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.redSpectrumBox = New System.Windows.Forms.PictureBox
        Me.label3 = New System.Windows.Forms.Label
        Me.greenSpectrumBox = New System.Windows.Forms.PictureBox
        Me.label4 = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ExpectedLed1 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed2 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed3 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed4 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed5 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed6 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed7 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed8 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed10 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed11 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed12 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed13 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.ExpectedLed9 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed1 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed5 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed10 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed9 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed2 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed6 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed11 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed3 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed7 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed12 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed4 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed8 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed13 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.blackSpectrumBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.orangeSpectrumBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redSpectrumBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.greenSpectrumBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(391, 293)
        Me.imageViewer1.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.BackColor = System.Drawing.Color.Black
        Me.groupBox1.Controls.Add(Me.ExpectedLed13)
        Me.groupBox1.Controls.Add(Me.ExpectedLed8)
        Me.groupBox1.Controls.Add(Me.ExpectedLed4)
        Me.groupBox1.Controls.Add(Me.ExpectedLed12)
        Me.groupBox1.Controls.Add(Me.ExpectedLed7)
        Me.groupBox1.Controls.Add(Me.ExpectedLed3)
        Me.groupBox1.Controls.Add(Me.ExpectedLed11)
        Me.groupBox1.Controls.Add(Me.ExpectedLed6)
        Me.groupBox1.Controls.Add(Me.ExpectedLed2)
        Me.groupBox1.Controls.Add(Me.ExpectedLed9)
        Me.groupBox1.Controls.Add(Me.ExpectedLed10)
        Me.groupBox1.Controls.Add(Me.ExpectedLed5)
        Me.groupBox1.Controls.Add(Me.ExpectedLed1)
        Me.groupBox1.Location = New System.Drawing.Point(420, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(237, 131)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Expected Pattern"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.PassFailLed13)
        Me.groupBox2.Controls.Add(Me.PassFailLed10)
        Me.groupBox2.Controls.Add(Me.PassFailLed8)
        Me.groupBox2.Controls.Add(Me.PassFailLed1)
        Me.groupBox2.Controls.Add(Me.PassFailLed4)
        Me.groupBox2.Controls.Add(Me.PassFailLed5)
        Me.groupBox2.Controls.Add(Me.PassFailLed12)
        Me.groupBox2.Controls.Add(Me.PassFailLed9)
        Me.groupBox2.Controls.Add(Me.PassFailLed7)
        Me.groupBox2.Controls.Add(Me.PassFailLed2)
        Me.groupBox2.Controls.Add(Me.PassFailLed3)
        Me.groupBox2.Controls.Add(Me.PassFailLed6)
        Me.groupBox2.Controls.Add(Me.PassFailLed11)
        Me.groupBox2.Location = New System.Drawing.Point(421, 166)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(236, 138)
        Me.groupBox2.TabIndex = 4
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Pass/Fail"
        '
        'blackSpectrumBox
        '
        Me.blackSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.blackSpectrumBox.Location = New System.Drawing.Point(12, 328)
        Me.blackSpectrumBox.Name = "blackSpectrumBox"
        Me.blackSpectrumBox.Size = New System.Drawing.Size(192, 80)
        Me.blackSpectrumBox.TabIndex = 5
        Me.blackSpectrumBox.TabStop = False
        '
        'orangeSpectrumBox
        '
        Me.orangeSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.orangeSpectrumBox.Location = New System.Drawing.Point(211, 328)
        Me.orangeSpectrumBox.Name = "orangeSpectrumBox"
        Me.orangeSpectrumBox.Size = New System.Drawing.Size(192, 80)
        Me.orangeSpectrumBox.TabIndex = 5
        Me.orangeSpectrumBox.TabStop = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 312)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(109, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Black Color Spectrum"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(208, 312)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(117, 13)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Orange Color Spectrum"
        '
        'redSpectrumBox
        '
        Me.redSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.redSpectrumBox.Location = New System.Drawing.Point(12, 438)
        Me.redSpectrumBox.Name = "redSpectrumBox"
        Me.redSpectrumBox.Size = New System.Drawing.Size(192, 80)
        Me.redSpectrumBox.TabIndex = 5
        Me.redSpectrumBox.TabStop = False
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(9, 422)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(102, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Red Color Spectrum"
        '
        'greenSpectrumBox
        '
        Me.greenSpectrumBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.greenSpectrumBox.Location = New System.Drawing.Point(211, 438)
        Me.greenSpectrumBox.Name = "greenSpectrumBox"
        Me.greenSpectrumBox.Size = New System.Drawing.Size(192, 80)
        Me.greenSpectrumBox.TabIndex = 5
        Me.greenSpectrumBox.TabStop = False
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(208, 422)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(111, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Green Color Spectrum"
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(586, 533)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(66, 31)
        Me.quitButton.TabIndex = 10
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(424, 369)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(228, 69)
        Me.label6.TabIndex = 11
        Me.label6.Text = resources.GetString("label6.Text")
        '
        'timer1
        '
        Me.timer1.Interval = 500
        '
        'ExpectedLed1
        '
        Me.ExpectedLed1.Caption = ""
        Me.ExpectedLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.ExpectedLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed1.Location = New System.Drawing.Point(68, 10)
        Me.ExpectedLed1.Name = "ExpectedLed1"
        Me.ExpectedLed1.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed1.TabIndex = 0
        Me.ExpectedLed1.Value = True
        '
        'ExpectedLed2
        '
        Me.ExpectedLed2.Caption = ""
        Me.ExpectedLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.ExpectedLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed2.Location = New System.Drawing.Point(108, 10)
        Me.ExpectedLed2.Name = "ExpectedLed2"
        Me.ExpectedLed2.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed2.TabIndex = 0
        Me.ExpectedLed2.Value = True
        '
        'ExpectedLed3
        '
        Me.ExpectedLed3.Caption = ""
        Me.ExpectedLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.ExpectedLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed3.Location = New System.Drawing.Point(148, 10)
        Me.ExpectedLed3.Name = "ExpectedLed3"
        Me.ExpectedLed3.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed3.TabIndex = 0
        Me.ExpectedLed3.Value = True
        '
        'ExpectedLed4
        '
        Me.ExpectedLed4.Caption = ""
        Me.ExpectedLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.ExpectedLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed4.Location = New System.Drawing.Point(188, 10)
        Me.ExpectedLed4.Name = "ExpectedLed4"
        Me.ExpectedLed4.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed4.TabIndex = 0
        Me.ExpectedLed4.Value = True
        '
        'ExpectedLed5
        '
        Me.ExpectedLed5.Caption = ""
        Me.ExpectedLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.ExpectedLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed5.Location = New System.Drawing.Point(68, 45)
        Me.ExpectedLed5.Name = "ExpectedLed5"
        Me.ExpectedLed5.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed5.TabIndex = 0
        Me.ExpectedLed5.Value = True
        '
        'ExpectedLed6
        '
        Me.ExpectedLed6.Caption = ""
        Me.ExpectedLed6.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.ExpectedLed6.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed6.Location = New System.Drawing.Point(108, 45)
        Me.ExpectedLed6.Name = "ExpectedLed6"
        Me.ExpectedLed6.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed6.TabIndex = 0
        Me.ExpectedLed6.Value = True
        '
        'ExpectedLed7
        '
        Me.ExpectedLed7.Caption = ""
        Me.ExpectedLed7.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.ExpectedLed7.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed7.Location = New System.Drawing.Point(148, 45)
        Me.ExpectedLed7.Name = "ExpectedLed7"
        Me.ExpectedLed7.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed7.TabIndex = 0
        Me.ExpectedLed7.Value = True
        '
        'ExpectedLed8
        '
        Me.ExpectedLed8.Caption = ""
        Me.ExpectedLed8.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.ExpectedLed8.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed8.Location = New System.Drawing.Point(188, 45)
        Me.ExpectedLed8.Name = "ExpectedLed8"
        Me.ExpectedLed8.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed8.TabIndex = 0
        Me.ExpectedLed8.Value = True
        '
        'ExpectedLed10
        '
        Me.ExpectedLed10.Caption = ""
        Me.ExpectedLed10.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.ExpectedLed10.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed10.Location = New System.Drawing.Point(68, 80)
        Me.ExpectedLed10.Name = "ExpectedLed10"
        Me.ExpectedLed10.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed10.TabIndex = 0
        Me.ExpectedLed10.Value = True
        '
        'ExpectedLed11
        '
        Me.ExpectedLed11.Caption = ""
        Me.ExpectedLed11.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.ExpectedLed11.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed11.Location = New System.Drawing.Point(108, 80)
        Me.ExpectedLed11.Name = "ExpectedLed11"
        Me.ExpectedLed11.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed11.TabIndex = 0
        Me.ExpectedLed11.Value = True
        '
        'ExpectedLed12
        '
        Me.ExpectedLed12.Caption = ""
        Me.ExpectedLed12.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.ExpectedLed12.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed12.Location = New System.Drawing.Point(148, 80)
        Me.ExpectedLed12.Name = "ExpectedLed12"
        Me.ExpectedLed12.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed12.TabIndex = 0
        Me.ExpectedLed12.Value = True
        '
        'ExpectedLed13
        '
        Me.ExpectedLed13.Caption = ""
        Me.ExpectedLed13.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.ExpectedLed13.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed13.Location = New System.Drawing.Point(188, 80)
        Me.ExpectedLed13.Name = "ExpectedLed13"
        Me.ExpectedLed13.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed13.TabIndex = 0
        Me.ExpectedLed13.Value = True
        '
        'ExpectedLed9
        '
        Me.ExpectedLed9.Caption = ""
        Me.ExpectedLed9.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.ExpectedLed9.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.ExpectedLed9.Location = New System.Drawing.Point(28, 80)
        Me.ExpectedLed9.Name = "ExpectedLed9"
        Me.ExpectedLed9.Size = New System.Drawing.Size(40, 40)
        Me.ExpectedLed9.TabIndex = 0
        Me.ExpectedLed9.Value = True
        '
        'PassFailLed1
        '
        Me.PassFailLed1.Caption = ""
        Me.PassFailLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.PassFailLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed1.Location = New System.Drawing.Point(67, 11)
        Me.PassFailLed1.Name = "PassFailLed1"
        Me.PassFailLed1.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed1.TabIndex = 0
        Me.PassFailLed1.Value = True
        '
        'PassFailLed5
        '
        Me.PassFailLed5.Caption = ""
        Me.PassFailLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.PassFailLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed5.Location = New System.Drawing.Point(67, 46)
        Me.PassFailLed5.Name = "PassFailLed5"
        Me.PassFailLed5.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed5.TabIndex = 0
        Me.PassFailLed5.Value = True
        '
        'PassFailLed10
        '
        Me.PassFailLed10.Caption = ""
        Me.PassFailLed10.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.PassFailLed10.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed10.Location = New System.Drawing.Point(67, 81)
        Me.PassFailLed10.Name = "PassFailLed10"
        Me.PassFailLed10.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed10.TabIndex = 0
        Me.PassFailLed10.Value = True
        '
        'PassFailLed9
        '
        Me.PassFailLed9.Caption = ""
        Me.PassFailLed9.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.PassFailLed9.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed9.Location = New System.Drawing.Point(27, 81)
        Me.PassFailLed9.Name = "PassFailLed9"
        Me.PassFailLed9.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed9.TabIndex = 0
        Me.PassFailLed9.Value = True
        '
        'PassFailLed2
        '
        Me.PassFailLed2.Caption = ""
        Me.PassFailLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.PassFailLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed2.Location = New System.Drawing.Point(107, 11)
        Me.PassFailLed2.Name = "PassFailLed2"
        Me.PassFailLed2.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed2.TabIndex = 0
        Me.PassFailLed2.Value = True
        '
        'PassFailLed6
        '
        Me.PassFailLed6.Caption = ""
        Me.PassFailLed6.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.PassFailLed6.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed6.Location = New System.Drawing.Point(107, 46)
        Me.PassFailLed6.Name = "PassFailLed6"
        Me.PassFailLed6.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed6.TabIndex = 0
        Me.PassFailLed6.Value = True
        '
        'PassFailLed11
        '
        Me.PassFailLed11.Caption = ""
        Me.PassFailLed11.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.PassFailLed11.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed11.Location = New System.Drawing.Point(107, 81)
        Me.PassFailLed11.Name = "PassFailLed11"
        Me.PassFailLed11.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed11.TabIndex = 0
        Me.PassFailLed11.Value = True
        '
        'PassFailLed3
        '
        Me.PassFailLed3.Caption = ""
        Me.PassFailLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.PassFailLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed3.Location = New System.Drawing.Point(147, 11)
        Me.PassFailLed3.Name = "PassFailLed3"
        Me.PassFailLed3.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed3.TabIndex = 0
        Me.PassFailLed3.Value = True
        '
        'PassFailLed7
        '
        Me.PassFailLed7.Caption = ""
        Me.PassFailLed7.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.PassFailLed7.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed7.Location = New System.Drawing.Point(147, 46)
        Me.PassFailLed7.Name = "PassFailLed7"
        Me.PassFailLed7.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed7.TabIndex = 0
        Me.PassFailLed7.Value = True
        '
        'PassFailLed12
        '
        Me.PassFailLed12.Caption = ""
        Me.PassFailLed12.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.PassFailLed12.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed12.Location = New System.Drawing.Point(147, 81)
        Me.PassFailLed12.Name = "PassFailLed12"
        Me.PassFailLed12.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed12.TabIndex = 0
        Me.PassFailLed12.Value = True
        '
        'PassFailLed4
        '
        Me.PassFailLed4.Caption = ""
        Me.PassFailLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackRed
        Me.PassFailLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed4.Location = New System.Drawing.Point(187, 11)
        Me.PassFailLed4.Name = "PassFailLed4"
        Me.PassFailLed4.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed4.TabIndex = 0
        Me.PassFailLed4.Value = True
        '
        'PassFailLed8
        '
        Me.PassFailLed8.Caption = ""
        Me.PassFailLed8.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackOrange
        Me.PassFailLed8.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed8.Location = New System.Drawing.Point(187, 46)
        Me.PassFailLed8.Name = "PassFailLed8"
        Me.PassFailLed8.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed8.TabIndex = 0
        Me.PassFailLed8.Value = True
        '
        'PassFailLed13
        '
        Me.PassFailLed13.Caption = ""
        Me.PassFailLed13.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.BlackLimeGreen
        Me.PassFailLed13.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.PassFailLed13.Location = New System.Drawing.Point(187, 81)
        Me.PassFailLed13.Name = "PassFailLed13"
        Me.PassFailLed13.Size = New System.Drawing.Size(40, 40)
        Me.PassFailLed13.TabIndex = 0
        Me.PassFailLed13.Value = True
        '
        'PassFailLed
        '
        Me.PassFailLed.Caption = "Part OK?"
        Me.PassFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed.Location = New System.Drawing.Point(421, 302)
        Me.PassFailLed.Name = "PassFailLed"
        Me.PassFailLed.Size = New System.Drawing.Size(237, 64)
        Me.PassFailLed.TabIndex = 12
        Me.PassFailLed.Value = False
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(421, 441)
        Me.DelaySlider1.Maximum = 2000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 13
        Me.DelaySlider1.Value = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 569)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.PassFailLed)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.greenSpectrumBox)
        Me.Controls.Add(Me.orangeSpectrumBox)
        Me.Controls.Add(Me.redSpectrumBox)
        Me.Controls.Add(Me.blackSpectrumBox)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Color Matching Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        CType(Me.blackSpectrumBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.orangeSpectrumBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redSpectrumBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.greenSpectrumBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private blackSpectrumBox As System.Windows.Forms.PictureBox
    Private orangeSpectrumBox As System.Windows.Forms.PictureBox
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private redSpectrumBox As System.Windows.Forms.PictureBox
    Private label3 As System.Windows.Forms.Label
    Private greenSpectrumBox As System.Windows.Forms.PictureBox
    Private label4 As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label6 As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents ExpectedLed4 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed3 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed2 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed1 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed8 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed7 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed6 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed5 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed13 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed12 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed11 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed9 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents ExpectedLed10 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed13 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed10 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed8 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed1 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed4 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed5 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed12 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed9 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed7 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed2 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed3 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed6 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed11 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class