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

// Circle Distance Example
//
// The objective of this gauging example is to measure distances between the circular
// holes on a part that contains both circular and square holes.  The part is imaged using
// a back light so that the holes and the background appear as white regions,
// while the part itself appears black.  Blob analysis detects and isolates the
// circular holes in the part, and then computes the distances between the center
// of mass of each detected hole.  An automatic thresholding technique detects all white
// regions in the image (including the holes and the background), and the Heywood
// circularity factor determines if a particle is circular or not.  The Heywood
// circularity parameter has a value close to one for circular regions.

namespace CircleDistance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Holes.tif");
        }

        // The function that does the actual circle computation.
        private void ComputeCircles()
        {
            // Perform the operation only if an image has been loaded.
            if (imageViewer1.Image.Width > 0)
            {
                // Automatic threshold of the image
                using (VisionImage image = new VisionImage())
                {
                    Algorithms.AutoThreshold(imageViewer1.Image, image, 2, ThresholdMethod.Entropy);

                    // Extract the shape descriptors.
                    double[,] particleMeasurements = Algorithms.ParticleMeasurements(image, new Collection<MeasurementType>(new MeasurementType[] { MeasurementType.HeywoodCircularityFactor, MeasurementType.CenterOfMassX, MeasurementType.CenterOfMassY })).PixelMeasurements;

                    // Keep circular parts using the Heywood circularity factor.
                    Collection<PointContour> centers = new Collection<PointContour>();
                    double minimumHeywoodValue = (double)minimumHeywood.Value;
                    for (int i = 0; i < particleMeasurements.GetLength(0); ++i)
                    {
                        if (particleMeasurements[i, 0] < minimumHeywoodValue)
                        {
                            centers.Add(new PointContour(particleMeasurements[i, 1], particleMeasurements[i, 2]));
                        }
                    }

                    // Compute and draw distances between circular parts.
                    DisplayResults(centers);
                }
            }
        }

        // Displays the results by overlaying lines connecting the centers of the circles.
        private void DisplayResults(Collection<PointContour> centers)
        {
            // Clear any overlays.
            imageViewer1.Image.Overlays.Default.Clear();

            if (centers.Count > 0)
            {
                // Draw the polygon.
                imageViewer1.Image.Overlays.Default.AddPolygon(new PolygonContour(centers), Rgb32Value.RedColor, DrawingMode.DrawValue);

                // Copy the first point to the end.
                centers.Add(centers[0]);

                // Label the distance of each line.
                for (int i = 0; i < centers.Count - 1; ++i)
                {
                    DisplayDistance(centers[i], centers[i + 1]);
                }
            }

        }

        private void DisplayDistance(PointContour point1, PointContour point2)
        {
            Collection<PointContour> points = new Collection<PointContour>(new PointContour[]{point1, point2});
            double distance = Algorithms.FindPointDistances(points)[0];
            OverlayTextOptions textOptions = new OverlayTextOptions();
            textOptions.FontSize = 14;
            textOptions.BackgroundColor = Rgb32Value.WhiteColor;
            textOptions.HorizontalAlignment = HorizontalTextAlignment.Center;
            imageViewer1.Image.Overlays.Default.AddText(String.Format("{0:0.00}", distance), new PointContour((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2), Rgb32Value.BlackColor, textOptions);
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void LoadSelectedImage() {
            // Read the image
            imageViewer1.Image.ReadFile(imagePath.Text);

            // Enable the Process Image button
            processImageButton.Enabled = true;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                LoadSelectedImage();
            }
        }

        private void processImageButton_Click(object sender, EventArgs e)
        {
            ComputeCircles();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimumHeywood_ValueChanged(object sender, EventArgs e)
        {
            // Compute the circle information.
            ComputeCircles();
        }

    }
}