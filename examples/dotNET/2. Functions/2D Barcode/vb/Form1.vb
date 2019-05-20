Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections.ObjectModel
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' 2D Barcode Example

' This example program demonstrates how to read 2D Barcodes. There are
' two supported types of barcodes: DataMatrix and PDF417. To read
' DataMatrix barcodes call ReadDataMatrixBarcode. You can setup the
' DataMatrixDescriptionOptions, DataMatrixSearchOptions, and DataMatrixSizeOptions
' objects to specify search options and  barcode subtype. To read
' a PDF417 barcode call ReadPdf417Barcode.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private barcodeTypesInfo As Dictionary(Of String, Collection(Of String))
    Private curImages As New Collection(Of String)()
    Private imageIndex As Integer = 0
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        barcodeTypesInfo = GetTypesAndFileNames()
        For Each type As String In barcodeTypesInfo.Keys
            barcodeType.Items.Add(type)
        Next
        ' Make "Data Matrix" the default.
        barcodeType.SelectedIndex = barcodeType.Items.IndexOf("Data Matrix")

        ' Make using Data Matrix options the default.
        useOptionsBox.Checked = True

        ' Make not grading the default.
        gradeDMBox.Checked = False

        ' Set up timer
        timer1.Interval = CInt(DelaySlider1.Value)

        ' Start reading barcodes.
        startButton_Click(startButton, EventArgs.Empty)
    End Sub

    Private Function GetTypesAndFileNames() As Dictionary(Of String, Collection(Of String))
        Dim typesAndFileNames As New Dictionary(Of String, Collection(Of String))()
        Dim basePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "2D Barcodes")
        For Each type As String In System.IO.Directory.GetDirectories(basePath)
            typesAndFileNames(System.IO.Path.GetFileName(type)) = New Collection(Of String)()
            'string dir = System.IO.Path.Combine(basePath, type);
            For Each fileName As String In System.IO.Directory.GetFiles(type)
                If fileName.EndsWith(".png") Then
                    typesAndFileNames(System.IO.Path.GetFileName(type)).Add(fileName)
                End If
            Next
        Next
        Return typesAndFileNames
    End Function

    Private Sub barcodeType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles barcodeType.SelectedIndexChanged
        curImages = barcodeTypesInfo(DirectCast(barcodeType.SelectedItem, String))
        imageIndex = 0
    End Sub

    ' Start reading barcodes.
    Private Sub startButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startButton.Click
        startButton.Enabled = False
        stopButton.Enabled = True
        barcodeType.Enabled = False
        timer1.Enabled = True
    End Sub

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        ' Set timer interval (cannot be 0)
        timer1.Interval = IIf(CInt(DelaySlider1.Value) <> 0, CInt(DelaySlider1.Value), 1)
    End Sub

    ' timer1_Tick is called when the timer interval has passed.  The next image
    ' is read in, barcode settings are initialized based on the type,
    ' and the barcode is read and processed.
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Stop the timer so that we don't count the time spent reading the barcode
        timer1.Enabled = False
        Using tempImage As New VisionImage()
            ' Load the barcode image.
            tempImage.ReadVisionFile(curImages(imageIndex))

            Dim pdf417Report As New Collection(Of Pdf417Report)()
            Dim dmReport As New DataMatrixReport()
            Dim qrReport As New QRReport()
            ' Read barcode and time how long it takes.
            Dim startTime As Integer = System.Environment.TickCount
            If barcodeType.Text = "PDF417" Then
                ' Decode a PDF417 code.
                pdf417Report = Algorithms.ReadPdf417Barcode(tempImage)
            ElseIf barcodeType.Text = "Data Matrix" Then
                ' Decode a Data Matrix
                Dim descOptions As New DataMatrixDescriptionOptions()
                Dim sizeOptions As New DataMatrixSizeOptions()
                Dim searchOptions As New DataMatrixSearchOptions()
                If useOptionsBox.Checked Then
                    ' Read the options from the image.
                    GetDataMatrixCodeSettings(tempImage, descOptions, sizeOptions, searchOptions)
                End If
                Dim gradingMode As DataMatrixGradingMode = DataMatrixGradingMode.None
                If gradeDMBox.Checked Then
                    gradingMode = DataMatrixGradingMode.PrepareForAim
                End If
                dmReport = Algorithms.ReadDataMatrixBarcode(tempImage, Nothing, gradingMode, descOptions, sizeOptions, searchOptions)
            Else
                ' Decode a QR Code
                Dim descOptions As New QRDescriptionOptions()
                Dim sizeOptions As New QRSizeOptions()
                Dim searchOptions As New QRSearchOptions()
                If useOptionsBox.Checked Then
                    ' Read the options from the image.
                End If
                qrReport = Algorithms.ReadQRCode(tempImage, Nothing, descOptions, sizeOptions, searchOptions)
            End If
            Dim elapsedTime As Integer = System.Environment.TickCount - startTime
            Dim found As Boolean
            If barcodeType.Text = "PDF417" Then
                found = pdf417Report.Count > 0
            ElseIf barcodeType.Text = "Data Matrix" Then
                found = dmReport.Found
            Else
                found = qrReport.Found
            End If
            ' Process info
            If found Then
                Dim centerPoint As New PointContour()
                If barcodeType.Text = "PDF417" Then
                    dataFound.Text = pdf417Report(0).StringData
                    typeFound.Text = "Pdf417"
                    tempImage.Overlays.[Default].AddPolygon(New PolygonContour(pdf417Report(0).Corners), Rgb32Value.GreenColor, DrawingMode.DrawValue)
                    ' Center the viewer on the barcode.
                    centerPoint.Initialize((pdf417Report(0).Corners(0).X + pdf417Report(0).Corners(2).X) / 2, (pdf417Report(0).Corners(0).Y + pdf417Report(0).Corners(2).Y) / 2)
                ElseIf barcodeType.Text = "Data Matrix" Then
                    If dmReport.Binary Then
                        dataFound.Text = System.Text.Encoding.Default.GetString(dmReport.GetBinaryData())
                    Else
                        dataFound.Text = dmReport.StringData
                    End If
                    DisplayDataMatrixType(dmReport)
                    tempImage.Overlays.[Default].AddPolygon(New PolygonContour(dmReport.Corners), Rgb32Value.GreenColor, DrawingMode.DrawValue)
                    ' Center the viewer on the barcode.
                    centerPoint.Initialize((dmReport.Corners(0).X + dmReport.Corners(2).X) / 2, (dmReport.Corners(0).Y + dmReport.Corners(2).Y) / 2)
                    ' Grade the barcode if requested.
                    If gradeDMBox.Checked Then
                        Dim gradeReport As AimGradeReport = Algorithms.GradeDataMatrixBarcodeAim(tempImage)
                        gradeOverall.Text = gradeReport.OverallGrade.ToString()
                        gradeDecoding.Text = gradeReport.DecodingGrade.ToString()
                        gradeSymbolContrast.Text = gradeReport.SymbolContrastGrade.ToString()
                        gradePrintGrowth.Text = gradeReport.PrintGrowthGrade.ToString()
                        gradeAxialNonuniformity.Text = gradeReport.AxialNonuniformityGrade.ToString()
                        gradeUnusedErrorCorrection.Text = gradeReport.UnusedErrorCorrectionGrade.ToString()
                    Else
                        gradeOverall.Text = ""
                        gradeDecoding.Text = ""
                        gradeSymbolContrast.Text = ""
                        gradePrintGrowth.Text = ""
                        gradeAxialNonuniformity.Text = ""
                        gradeUnusedErrorCorrection.Text = ""
                    End If
                    Else
                        dataFound.Text = System.Text.Encoding.[Default].GetString(qrReport.GetData())
                        DisplayQRType(qrReport)
                        tempImage.Overlays.[Default].AddPolygon(New PolygonContour(qrReport.Corners), Rgb32Value.GreenColor, DrawingMode.DrawValue)
                        ' Center the viewer on the barcode.
                        centerPoint.Initialize((qrReport.Corners(0).X + qrReport.Corners(2).X) / 2, (qrReport.Corners(0).Y + qrReport.Corners(2).Y) / 2)
                    End If
                    readTime.Text = elapsedTime.ToString()
                    Algorithms.Copy(tempImage, imageViewer1.Image)
                    imageViewer1.RefreshImage()
                    imageViewer1.Center.Initialize(centerPoint.X, centerPoint.Y)
            End If
        End Using
        ' Set up for next image
        imageIndex = (imageIndex + 1) Mod curImages.Count
        timer1.Enabled = True
    End Sub

    ' GetDataMatrixCodeSettings initializes the settings for the given barcode.
    ' The settings are stored in the custom data of each image.
    ' Since these settings are stored in Visual Basic 6 format, we use the VBCustomData class.
    Private Sub GetDataMatrixCodeSettings(ByVal barcode As VisionImage, ByRef descOptions As DataMatrixDescriptionOptions, ByRef sizeOptions As DataMatrixSizeOptions, ByRef searchOptions As DataMatrixSearchOptions)
        descOptions.AspectRatio = New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionAspectRatio")).Numeric(0)
        Dim sizeData As New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionRowsColumns"))
        descOptions.Rows = CUInt(sizeData.Numeric(0))
        descOptions.Columns = CUInt(sizeData.Numeric(1))
        descOptions.Rectangle = New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionRectangle")).Numeric(0) <> 0.0R
        descOptions.Ecc = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionECC")).Numeric(0)), DataMatrixEcc)
        descOptions.Polarity = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionPolarity")).Numeric(0)), DataMatrixPolarity)
        descOptions.CellFill = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionCellFill")).Numeric(0)), DataMatrixCellFillMode)
        descOptions.MinimumBorderIntegrity = New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionMinimumBorderIntegrity")).Numeric(0)
        descOptions.MirrorMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionMirror")).Numeric(0)), DataMatrixMirrorMode)

        sizeData = New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSizeBarcode"))
        sizeOptions.MinimumSize = CUInt(sizeData.Numeric(0))
        sizeOptions.MaximumSize = CUInt(sizeData.Numeric(1))
        sizeOptions.QuietZoneWidth = CUInt((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSizeQuietZoneWidth"))).Numeric(0))

        searchOptions.RotationMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchRotation"))).Numeric(0), DataMatrixRotationMode)
        searchOptions.SkipLocation = (New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchSkipLocation"))).Numeric(0) <> 0.0R
        searchOptions.EdgeThreshold = CUInt((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchEdgeThreshold"))).Numeric(0))
        searchOptions.DemodulationMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchDemodulation"))).Numeric(0), DataMatrixDemodulationMode)
        searchOptions.CellSampleSize = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchCellSampleSize"))).Numeric(0), DataMatrixCellSampleSize)
        searchOptions.CellFilterMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchCellFilter"))).Numeric(0), DataMatrixCellFilterMode)
        searchOptions.SkewDegreesAllowed = CUInt((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchSkewDegrees"))).Numeric(0))
        searchOptions.MaximumIterations = CUInt((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchMaxIterations"))).Numeric(0))
        searchOptions.InitialSearchVectorWidth = CUInt((New VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchInitialSearchVectorWidth"))).Numeric(0))
    End Sub

    ' GetQRCodeSettings initializes the settings for the given barcode.
    ' The settings are stored in the custom data of each image.
    ' Since these settings are stored in Visual Basic 6 format, we use the VBCustomData class.
    Private Sub GetQRCodeSettings(ByVal barcode As VisionImage, ByRef descOptions As QRDescriptionOptions, ByRef sizeOptions As QRSizeOptions, ByRef searchOptions As QRSearchOptions)
        descOptions.Dimensions = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRCellDimensions"))).Numeric(0), QRDimension)
        descOptions.Polarity = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRCodePolarity"))).Numeric(0), QRPolarity)
        descOptions.MirrorMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRCodeMirrorMode"))).Numeric(0), QRMirrorMode)
        descOptions.ModelType = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRModelType"))).Numeric(0), QRModelType)

        searchOptions.DemodulationMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRDemodulationMode"))).Numeric(0), QRDemodulationMode)
        searchOptions.CellSampleSize = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRSampleSize"))).Numeric(0), QRCellSampleSize)
        searchOptions.CellFilterMode = CType((New VBCustomData(barcode.CustomData.GetDataRawBytes("QRFilterMode"))).Numeric(0), QRCellFilterMode)

        Dim sizeData As New VBCustomData(barcode.CustomData.GetDataRawBytes("QRMatrixSize"))
        sizeOptions.MinimumSize = CUInt(sizeData.Numeric(0))
        sizeOptions.MaximumSize = CUInt(sizeData.Numeric(1))
    End Sub

    Private Sub DisplayDataMatrixType(ByVal report As DataMatrixReport)
        Select Case report.Ecc
            Case DataMatrixEcc.Ecc000
                typeFound.Text = "Data Matrix ECC 000"
                Exit Select
            Case DataMatrixEcc.Ecc050
                typeFound.Text = "Data Matrix ECC 050"
                Exit Select
            Case DataMatrixEcc.Ecc080
                typeFound.Text = "Data Matrix ECC 080"
                Exit Select
            Case DataMatrixEcc.Ecc100
                typeFound.Text = "Data Matrix ECC 100"
                Exit Select
            Case DataMatrixEcc.Ecc140
                typeFound.Text = "Data Matrix ECC 140"
                Exit Select
            Case DataMatrixEcc.Ecc200
                typeFound.Text = "Data Matrix ECC 200"
                Exit Select
        End Select
    End Sub

    Private Sub DisplayQRType(ByVal report As QRReport)
        Select Case report.ModelType
            Case QRModelType.Micro
                typeFound.Text = "QR Micro Code"
                Exit Select
            Case QRModelType.Model1
                typeFound.Text = "QR Model 1 Code"
                Exit Select
            Case QRModelType.Model2
                typeFound.Text = "QR Model 2 Code"
                Exit Select
        End Select
    End Sub

    Private Sub stopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles stopButton.Click
        timer1.Enabled = False
        barcodeType.Enabled = True
        stopButton.Enabled = False
        startButton.Enabled = True
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

End Class