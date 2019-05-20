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

// Nonlinear Calibration Example
//
// This example illustrates how to use a calibration grid to calibrate an image for nonlinear
// distortion.  The example corrects the image, making it possible to perform accurate measurements
// in real-world units on the resulting image.
//
// The example loads a template image of a grid used to calibrate a system.  It uses the loaded
// image to learn the grid calibration, uses the learned calibration information to correct
// the distorted image, and measures distances in the corrected image.

namespace NonlinearCalibration
{
    public partial class Form1 : Form
    {
        private VisionImage calibrationTemplate = new VisionImage();
        private VisionImage partImage = new VisionImage();
        private VisionImage processedPartImage = new VisionImage();
        private VisionImage uncorrectedImage = new VisionImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void loadCalibrationButton_Click(object sender, EventArgs e)
        {
            // Load Calibration Grid image.
            calibrationTemplate.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Nonlinear grid.png"));
            imageViewer1.Attach(calibrationTemplate);

            // Update command buttons.
            learnCalibrationButton.Enabled = true;
            loadTargetButton.Enabled = false;
            measurePartsButton.Enabled = false;
        }

        private void learnCalibrationButton_Click(object sender, EventArgs e)
        {
            string learnCalibrationText = learnCalibrationButton.Text;
            learnCalibrationButton.Text = "Learning...";
            Update();

            // Set up the calibration grid options.
            // Dots in the grid image are horizontally and vertically 6.35 mm apart.
            // The dots have a pixel intensity in the range [0, 128].
            CalibrationGridOptions calibrationGridOptions = new CalibrationGridOptions(new GridDescriptor(.635, .635, CalibrationUnit.Centimeter), new Range(0, 128));

            // Set up the calibration options.
            LearnCalibrationOptions learnCalibrationOptions = new LearnCalibrationOptions(new CoordinateSystem(), CalibrationMethod.Nonlinear, ScalingMethod.ScaleToPreserveArea, CalibrationCorrectionMode.FullImage);
            learnCalibrationOptions.LearnCorrectionTable = true;
            learnCalibrationOptions.LearnErrorMap = true;

            // Learn the Grid Image calibration.
            Algorithms.LearnCalibrationGrid(calibrationTemplate, calibrationGridOptions, learnCalibrationOptions);

            // Restore the original description.
            learnCalibrationButton.Text = learnCalibrationText;

            // Update the command buttons.
            learnCalibrationButton.Enabled = false;
            loadTargetButton.Enabled = true;
        }

        private void loadTargetButton_Click(object sender, EventArgs e)
        {
            // Load Calibration Grid image.
            uncorrectedImage.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Distorted coins.png"));
            imageViewer1.Attach(uncorrectedImage);

            measurePartsButton.Enabled = true;
        }

        private void measurePartsButton_Click(object sender, EventArgs e)
        {
            // Start timing.
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            
            // Apply the calibration to the parts image and correct it.
            Algorithms.CopyCalibrationInformation(calibrationTemplate, uncorrectedImage);
            Algorithms.CorrectCalibratedImage(uncorrectedImage, partImage, new PixelValue(0), InterpolationMethod.Bilinear);

            // Process the image to segment the parts from the background.
            Algorithms.Threshold(partImage, processedPartImage, new Range(0, 150));
            Algorithms.RejectBorder(processedPartImage, processedPartImage);
            Algorithms.FillHoles(processedPartImage, processedPartImage);
            Algorithms.ConvexHull(processedPartImage, processedPartImage);

            // Perform particle analysis.
            Collection<ParticleReport> particleReports = Algorithms.ParticleReport(processedPartImage, Connectivity.Connectivity8, false);
            double[,] areas = Algorithms.ParticleMeasurements(processedPartImage, new Collection<MeasurementType>(new MeasurementType[] { MeasurementType.Area }), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Calibrated).CalibratedMeasurements;
            // Stop timing and overlay results.
            stopwatch.Stop();

            OverlayTextOptions overlayOptions = new OverlayTextOptions("Arial", 18, HorizontalTextAlignment.Center);
            overlayOptions.TextDecoration.Bold = true;
            overlayOptions.VerticalAlignment = VerticalTextAlignment.Baseline;
            for (int i = 0; i < particleReports.Count; ++i)
            {
                partImage.Overlays.Default.AddText(String.Format("{0:0.00} cm^2", areas[i,0]), particleReports[i].CenterOfMass, Rgb32Value.GreenColor, overlayOptions);
            }
            wholeImageTime.Text = String.Format("{0:0}", stopwatch.ElapsedMilliseconds);
            imageViewer1.Attach(partImage);
            imageViewer2.Attach(uncorrectedImage);

            stopwatch.Reset();
            // Start timing.
            stopwatch.Start();

            // Apply the calibration to the parts image.
            Algorithms.CopyCalibrationInformation(calibrationTemplate, uncorrectedImage);

            // Process the image to segment the parts from the background.
            Algorithms.Threshold(uncorrectedImage, processedPartImage, new Range(0, 150));
            Algorithms.RejectBorder(processedPartImage, processedPartImage);
            Algorithms.FillHoles(processedPartImage, processedPartImage);
            Algorithms.ConvexHull(processedPartImage, processedPartImage);

            // Perform particle analysis.
            particleReports = Algorithms.ParticleReport(processedPartImage, Connectivity.Connectivity8, false);
            areas = Algorithms.ParticleMeasurements(processedPartImage, new Collection<MeasurementType>(new MeasurementType[]{MeasurementType.Area}), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Calibrated).CalibratedMeasurements;

            // Stop timing and overlay results.
            stopwatch.Stop();

            for (int i = 0; i < particleReports.Count; ++i)
            {
                uncorrectedImage.Overlays.Default.AddText(String.Format("{0:0.00} cm^2", areas[i,0]), particleReports[i].CenterOfMass, Rgb32Value.GreenColor, overlayOptions);
            }
            coinsImageTime.Text = String.Format("{0:0}", stopwatch.ElapsedMilliseconds);

            // Update command buttons.
            measurePartsButton.Enabled = false;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}