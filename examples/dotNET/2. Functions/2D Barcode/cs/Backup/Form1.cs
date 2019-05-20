using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// 2D Barcode Example

// This example program demonstrates how to read 2D Barcodes. There are
// two supported types of barcodes: DataMatrix and PDF417. To read
// DataMatrix barcodes call ReadDataMatrixBarcode. You can setup the
// DataMatrixDescriptionOptions, DataMatrixSearchOptions, and DataMatrixSizeOptions
// objects to specify search options and  barcode subtype. To read
// a PDF417 barcode call ReadPdf417Barcode.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace _D_Barcode
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Collection<string>> barcodeTypesInfo;
        private Collection<string> curImages = new Collection<string>();
        private int imageIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            barcodeTypesInfo = GetTypesAndFileNames();
            foreach (string type in barcodeTypesInfo.Keys)
            {
                barcodeType.Items.Add(type);
            }
            // Make "Data Matrix" the default.
            barcodeType.SelectedIndex = barcodeType.Items.IndexOf("Data Matrix");

            // Make using Data Matrix options the default.
            useOptionsBox.Checked = true;

            // Make not grading the default.
            gradeDMBox.Checked = false;

            // Set up timer
            timer1.Interval = (int)delaySlider1.Value;

            // Start reading barcodes.
            startButton_Click(startButton, EventArgs.Empty);
        }

        private Dictionary<string, Collection<string>> GetTypesAndFileNames()
        {
            Dictionary<string, Collection<string>> typesAndFileNames = new Dictionary<string, Collection<string>>();
            string basePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "2D Barcodes");
            foreach (string type in System.IO.Directory.GetDirectories(basePath))
            {
                typesAndFileNames[System.IO.Path.GetFileName(type)] = new Collection<string>();
                //string dir = System.IO.Path.Combine(basePath, type);
                foreach (string fileName in System.IO.Directory.GetFiles(type))
                {
                    if (fileName.EndsWith(".png"))
                    {
                        typesAndFileNames[System.IO.Path.GetFileName(type)].Add(fileName);
                    }
                }
            }
            return typesAndFileNames;
        }

        private void barcodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            curImages = barcodeTypesInfo[(string)barcodeType.SelectedItem];
            imageIndex = 0;
        }

        // Start reading barcodes.
        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            barcodeType.Enabled = false;
            timer1.Enabled = true;
        }

        private void delaySlider1_AfterChangeValue(object sender, EventArgs e)
        {
            // Set timer interval (cannot be 0)
            timer1.Interval = (int)delaySlider1.Value != 0 ? (int)delaySlider1.Value : 1;
        }

        // timer1_Tick is called when the timer interval has passed.  The next image
        // is read in, barcode settings are initialized based on the type,
        // and the barcode is read and processed.
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer so that we don't count the time spent reading the barcode
            timer1.Enabled = false;
            using (VisionImage tempImage = new VisionImage()) {
                // Load the barcode image.
                tempImage.ReadVisionFile(curImages[imageIndex]);

                Collection<Pdf417Report> pdf417Report = new Collection<Pdf417Report>();
                DataMatrixReport dmReport = new DataMatrixReport();
                QRReport qrReport = new QRReport();
                // Read barcode and time how long it takes.
                int startTime = System.Environment.TickCount;
                if (barcodeType.Text == "PDF417")
                {
                    // Decode a PDF417 code.
                    pdf417Report = Algorithms.ReadPdf417Barcode(tempImage);
                }
                else if (barcodeType.Text == "Data Matrix")
                {
                    // Decode a Data Matrix
                    DataMatrixDescriptionOptions descOptions = new DataMatrixDescriptionOptions();
                    DataMatrixSizeOptions sizeOptions = new DataMatrixSizeOptions();
                    DataMatrixSearchOptions searchOptions = new DataMatrixSearchOptions();
                    if (useOptionsBox.Checked)
                    {
                        // Read the options from the image.
                        GetDataMatrixCodeSettings(tempImage, ref descOptions, ref sizeOptions, ref searchOptions);
                    }
                    DataMatrixGradingMode gradingMode = DataMatrixGradingMode.None;
                    if (gradeDMBox.Checked)
                    {
                        gradingMode = DataMatrixGradingMode.PrepareForAim;
                    }
                    dmReport = Algorithms.ReadDataMatrixBarcode(tempImage, null, gradingMode, descOptions, sizeOptions, searchOptions);
                }
                else
                {
                    // Decode a QR Code
                    QRDescriptionOptions descOptions = new QRDescriptionOptions();
                    QRSizeOptions sizeOptions = new QRSizeOptions();
                    QRSearchOptions searchOptions = new QRSearchOptions();
                    if (useOptionsBox.Checked)
                    {
                        // Read the options from the image.
                    }
                    qrReport = Algorithms.ReadQRCode(tempImage, null, descOptions, sizeOptions, searchOptions);
                }
                int elapsedTime = System.Environment.TickCount - startTime;
                bool found;
                if (barcodeType.Text == "PDF417")
                {
                    found = pdf417Report.Count > 0;
                }
                else if (barcodeType.Text == "Data Matrix")
                {
                    found = dmReport.Found;
                }
                else
                {
                    found = qrReport.Found;
                }
                // Process info
                if (found)
                {
                    PointContour centerPoint = new PointContour();
                    if (barcodeType.Text == "PDF417")
                    {
                        dataFound.Text = pdf417Report[0].StringData;
                        typeFound.Text = "Pdf417";
                        tempImage.Overlays.Default.AddPolygon(new PolygonContour(pdf417Report[0].Corners), Rgb32Value.GreenColor, DrawingMode.DrawValue);
                        // Center the viewer on the barcode.
                        centerPoint.Initialize((pdf417Report[0].Corners[0].X + pdf417Report[0].Corners[2].X) / 2, (pdf417Report[0].Corners[0].Y + pdf417Report[0].Corners[2].Y) / 2);
                    }
                    else if (barcodeType.Text == "Data Matrix")
                    {
                        if (dmReport.Binary)
                        {
                            dataFound.Text = System.Text.Encoding.Default.GetString(dmReport.GetBinaryData());
                        }
                        else
                        {
                            dataFound.Text = dmReport.StringData;
                        }
                        DisplayDataMatrixType(dmReport);
                        tempImage.Overlays.Default.AddPolygon(new PolygonContour(dmReport.Corners), Rgb32Value.GreenColor, DrawingMode.DrawValue);
                        // Center the viewer on the barcode.
                        centerPoint.Initialize((dmReport.Corners[0].X + dmReport.Corners[2].X) / 2, (dmReport.Corners[0].Y + dmReport.Corners[2].Y) / 2);
                        // Grade the barcode if requested.
                        if (gradeDMBox.Checked)
                        {
                            AimGradeReport gradeReport = Algorithms.GradeDataMatrixBarcodeAim(tempImage);
                            gradeOverall.Text = gradeReport.OverallGrade.ToString();
                            gradeDecoding.Text = gradeReport.DecodingGrade.ToString();
                            gradeSymbolContrast.Text = gradeReport.SymbolContrastGrade.ToString();
                            gradePrintGrowth.Text = gradeReport.PrintGrowthGrade.ToString();
                            gradeAxialNonuniformity.Text = gradeReport.AxialNonuniformityGrade.ToString();
                            gradeUnusedErrorCorrection.Text = gradeReport.UnusedErrorCorrectionGrade.ToString();
                        }
                        else
                        {
                            gradeOverall.Text = "";
                            gradeDecoding.Text = "";
                            gradeSymbolContrast.Text = "";
                            gradePrintGrowth.Text = "";
                            gradeAxialNonuniformity.Text = "";
                            gradeUnusedErrorCorrection.Text = "";
                        }
                    }
                    else
                    {
                        dataFound.Text = System.Text.Encoding.Default.GetString(qrReport.GetData());
                        DisplayQRType(qrReport);
                        tempImage.Overlays.Default.AddPolygon(new PolygonContour(qrReport.Corners), Rgb32Value.GreenColor, DrawingMode.DrawValue);
                        // Center the viewer on the barcode.
                        centerPoint.Initialize((qrReport.Corners[0].X + qrReport.Corners[2].X) / 2, (qrReport.Corners[0].Y + qrReport.Corners[2].Y) / 2);
                    }
                    readTime.Text = elapsedTime.ToString();
                    Algorithms.Copy(tempImage, imageViewer1.Image);
                    imageViewer1.RefreshImage();
                    imageViewer1.Center.Initialize(centerPoint.X, centerPoint.Y);
                }
            }
            // Set up for next image
            imageIndex = (imageIndex + 1) % curImages.Count;
            timer1.Enabled = true;
        }

        // GetDataMatrixCodeSettings initializes the settings for the given barcode.
        // The settings are stored in the custom data of each image.
        // Since these settings are stored in Visual Basic 6 format, we use the VBCustomData class.
        private void GetDataMatrixCodeSettings(VisionImage barcode, ref DataMatrixDescriptionOptions descOptions, ref DataMatrixSizeOptions sizeOptions, ref DataMatrixSearchOptions searchOptions)
        {
            descOptions.AspectRatio = new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionAspectRatio")).Numeric[0];
            VBCustomData sizeData = new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionRowsColumns"));
            descOptions.Rows = (uint)sizeData.Numeric[0];
            descOptions.Columns = (uint)sizeData.Numeric[1];
            descOptions.Rectangle = new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionRectangle")).Numeric[0] != 0.0;
            descOptions.Ecc = (DataMatrixEcc)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionECC")).Numeric[0]);
            descOptions.Polarity = (DataMatrixPolarity)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionPolarity")).Numeric[0]);
            descOptions.CellFill = (DataMatrixCellFillMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionCellFill")).Numeric[0]);
            descOptions.MinimumBorderIntegrity = new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionMinimumBorderIntegrity")).Numeric[0];
            descOptions.MirrorMode = (DataMatrixMirrorMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMDescriptionMirror")).Numeric[0]);

            sizeData = new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSizeBarcode"));
            sizeOptions.MinimumSize = (uint)sizeData.Numeric[0];
            sizeOptions.MaximumSize = (uint)sizeData.Numeric[1];
            sizeOptions.QuietZoneWidth = (uint)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSizeQuietZoneWidth"))).Numeric[0];

            searchOptions.RotationMode = (DataMatrixRotationMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchRotation"))).Numeric[0];
            searchOptions.SkipLocation = (new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchSkipLocation"))).Numeric[0] != 0.0;
            searchOptions.EdgeThreshold = (uint)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchEdgeThreshold"))).Numeric[0];
            searchOptions.DemodulationMode = (DataMatrixDemodulationMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchDemodulation"))).Numeric[0];
            searchOptions.CellSampleSize = (DataMatrixCellSampleSize)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchCellSampleSize"))).Numeric[0];
            searchOptions.CellFilterMode = (DataMatrixCellFilterMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchCellFilter"))).Numeric[0];
            searchOptions.SkewDegreesAllowed = (uint)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchSkewDegrees"))).Numeric[0];
            searchOptions.MaximumIterations = (uint)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchMaxIterations"))).Numeric[0];
            searchOptions.InitialSearchVectorWidth = (uint)(new VBCustomData(barcode.CustomData.GetDataRawBytes("DMSearchInitialSearchVectorWidth"))).Numeric[0];
        }

        // GetQRCodeSettings initializes the settings for the given barcode.
        // The settings are stored in the custom data of each image.
        // Since these settings are stored in Visual Basic 6 format, we use the VBCustomData class.
        private void GetQRCodeSettings(VisionImage barcode, ref QRDescriptionOptions descOptions, ref QRSizeOptions sizeOptions, ref QRSearchOptions searchOptions)
        {
            descOptions.Dimensions = (QRDimension)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRCellDimensions"))).Numeric[0];
            descOptions.Polarity = (QRPolarity)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRCodePolarity"))).Numeric[0];
            descOptions.MirrorMode = (QRMirrorMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRCodeMirrorMode"))).Numeric[0];
            descOptions.ModelType = (QRModelType)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRModelType"))).Numeric[0];

            searchOptions.DemodulationMode = (QRDemodulationMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRDemodulationMode"))).Numeric[0];
            searchOptions.CellSampleSize = (QRCellSampleSize)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRSampleSize"))).Numeric[0];
            searchOptions.CellFilterMode = (QRCellFilterMode)(new VBCustomData(barcode.CustomData.GetDataRawBytes("QRFilterMode"))).Numeric[0];

            VBCustomData sizeData = new VBCustomData(barcode.CustomData.GetDataRawBytes("QRMatrixSize"));
            sizeOptions.MinimumSize = (uint)sizeData.Numeric[0];
            sizeOptions.MaximumSize = (uint)sizeData.Numeric[1];
        }

        private void DisplayDataMatrixType(DataMatrixReport report)
        {
            switch (report.Ecc)
            {
                case DataMatrixEcc.Ecc000:
                    typeFound.Text = "Data Matrix ECC 000";
                    break;
                case DataMatrixEcc.Ecc050:
                    typeFound.Text = "Data Matrix ECC 050";
                    break;
                case DataMatrixEcc.Ecc080:
                    typeFound.Text = "Data Matrix ECC 080";
                    break;
                case DataMatrixEcc.Ecc100:
                    typeFound.Text = "Data Matrix ECC 100";
                    break;
                case DataMatrixEcc.Ecc140:
                    typeFound.Text = "Data Matrix ECC 140";
                    break;
                case DataMatrixEcc.Ecc200:
                    typeFound.Text = "Data Matrix ECC 200";
                    break;
            }
        }

        private void DisplayQRType(QRReport report)
        {
            switch (report.ModelType)
            {
                case QRModelType.Micro:
                    typeFound.Text = "QR Micro Code";
                    break;
                case QRModelType.Model1:
                    typeFound.Text = "QR Model 1 Code";
                    break;
                case QRModelType.Model2:
                    typeFound.Text = "QR Model 2 Code";
                    break;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            barcodeType.Enabled = true;
            stopButton.Enabled = false;
            startButton.Enabled = true;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}