using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Color Distance Example
//
// This example calculates the distance between two colors in the CIE
// colorspace.  The user selects two points in one image by using the
// point tool.  These two color values are then used to calculate and
// plot the distance.

namespace ColorDistance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Color cubes.jpg");
            
            // Set up image buffers
            imageViewer1.Image.Type = ImageType.Rgb32;
            imageViewer2.Image.Type = ImageType.Rgb32;

            // Load in and display the default image.
            imageViewer1.Image.ReadFile(imagePath.Text);
            imageViewer1.ZoomInfo.Initialize(.5, .5);
            imageViewer1.Roi.MaximumContours = 2;

            imageViewer2.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "CIE Color Space.png"));
            imageViewer2.RefreshImage();
            imageViewer2.Center.Initialize(85, 102);
        }

        // Click the browse button to open the file dialog.
        private void browseButton_Click(object sender, EventArgs e)
        {
            ImagePreviewFileDialog dialog = new ImagePreviewFileDialog();
            dialog.FileName = imagePath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath.Text = dialog.FileName;
                // Load the image.
                LoadSelectedImage();
            }
        }

        private void LoadSelectedImage()
        {
            // Load an image using ReadFile.
            imageViewer1.Image.ReadFile(imagePath.Text);
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            DisplayColorDistance();
        }

        // DisplayColorDistance plots two points in the CIE colorspace and draws
        // a line between these two points.
        private void DisplayColorDistance()
        {
            // Only handle two points.
            if (imageViewer1.Roi.Count != 2)
            {
                return;
            }

            // Get pixel values.
            Rgb32Value rgb32Value1 = imageViewer1.Image.GetPixel(imageViewer1.Roi[0].Shape as PointContour).Rgb32;
            Rgb32Value rgb32Value2 = imageViewer1.Image.GetPixel(imageViewer1.Roi[1].Shape as PointContour).Rgb32;

            // Remove any previous overlays.
            imageViewer2.Image.Overlays.Default.Clear();

            // Transform to the correct colorspace.
            CieXyzValue cieXyzValue1 = Algorithms.ConvertColorValue(new ColorValue(rgb32Value1), ColorMode.CieXyz).CieXyz;
            CieXyzValue cieXyzValue2 = Algorithms.ConvertColorValue(new ColorValue(rgb32Value2), ColorMode.CieXyz).CieXyz;
            
            // Calculate points.
            double sum1 = cieXyzValue1.X + cieXyzValue1.Y + cieXyzValue1.Z;
            if (sum1 == 0.0)
            {
                sum1 = 1;
            }
            PointContour point1 = new PointContour(cieXyzValue1.Y / sum1 * 255, cieXyzValue1.X / sum1 * 255);
            double sum2 = cieXyzValue2.X + cieXyzValue2.Y + cieXyzValue2.Z;
            if (sum2 == 0.0)
            {
                sum2 = 1;
            }
            PointContour point2 = new PointContour(cieXyzValue2.Y / sum2 * 255, cieXyzValue2.X / sum2 * 255);

            // Display ovals around the points to make them more visible.
            imageViewer2.Image.Overlays.Default.AddOval(new OvalContour(point1.X - 5, point1.Y - 5, 10, 10), Rgb32Value.BlackColor);
            imageViewer2.Image.Overlays.Default.AddOval(new OvalContour(point2.X - 5, point2.Y - 5, 10, 10), Rgb32Value.BlackColor);

            // Draw a line between the points.
            imageViewer2.Image.Overlays.Default.AddLine(new LineContour(point1, point2), Rgb32Value.BlackColor);

            // Calculate distance in CIE
            CalculateColorDistance(rgb32Value1, rgb32Value2);
        }

        // Calculates the distance between the two color values in the CIE colorspace.
        private void CalculateColorDistance(Rgb32Value rgb32Value1, Rgb32Value rgb32Value2)
        {
            // Transform to the correct colorspace.
            CieLabValue cieLabValue1 = Algorithms.ConvertColorValue(new ColorValue(rgb32Value1), ColorMode.CieLab).CieLab;
            CieLabValue cieLabValue2 = Algorithms.ConvertColorValue(new ColorValue(rgb32Value2), ColorMode.CieLab).CieLab;

            // Calculate distance in CIE.
            double distance = Math.Pow(cieLabValue1.L - cieLabValue2.L, 2) + Math.Pow(cieLabValue1.A - cieLabValue2.A, 2) + Math.Pow(cieLabValue1.B - cieLabValue2.B, 2);
            distance = Math.Sqrt(distance);
            distanceTextBox.Text = String.Format("{0:0.00}", distance);
        }


        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }
    }
}