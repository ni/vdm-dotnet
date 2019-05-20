using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Image to Array Example

// This example demonstrates how to convert an image into a two-dimensional array.  By
// converting an image to an array, you can apply .NET functions to the image data.

namespace ImageToArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp");
            imageViewer1.Roi.MaximumContours = 1;
        }

        private void DoImageToArray()
        {
            // Get the point from the viewer.
            PointContour point = imageViewer1.Roi[0].Shape as PointContour;
            if (point != null) {
                // Get the pixel data in a 7x7 region surrounding the point on the viewer.
                RectangleContour rectangle = new RectangleContour(point.X - 3, point.Y - 3, 7, 7);
                byte[,] pixelValues = imageViewer1.Image.ImageToArray(rectangle).U8;

                // Display the data
                textBox1.Text = String.Format("{0:0}", pixelValues[0, 0]);
                textBox2.Text = String.Format("{0:0}", pixelValues[0, 1]);
                textBox3.Text = String.Format("{0:0}", pixelValues[0, 2]);
                textBox4.Text = String.Format("{0:0}", pixelValues[0, 3]);
                textBox5.Text = String.Format("{0:0}", pixelValues[0, 4]);
                textBox6.Text = String.Format("{0:0}", pixelValues[0, 5]);
                textBox7.Text = String.Format("{0:0}", pixelValues[0, 6]);
                textBox8.Text = String.Format("{0:0}", pixelValues[1, 0]);
                textBox9.Text = String.Format("{0:0}", pixelValues[1, 1]);
                textBox10.Text = String.Format("{0:0}", pixelValues[1, 2]);
                textBox11.Text = String.Format("{0:0}", pixelValues[1, 3]);
                textBox12.Text = String.Format("{0:0}", pixelValues[1, 4]);
                textBox13.Text = String.Format("{0:0}", pixelValues[1, 5]);
                textBox14.Text = String.Format("{0:0}", pixelValues[1, 6]);
                textBox15.Text = String.Format("{0:0}", pixelValues[2, 0]);
                textBox16.Text = String.Format("{0:0}", pixelValues[2, 1]);
                textBox17.Text = String.Format("{0:0}", pixelValues[2, 2]);
                textBox18.Text = String.Format("{0:0}", pixelValues[2, 3]);
                textBox19.Text = String.Format("{0:0}", pixelValues[2, 4]);
                textBox20.Text = String.Format("{0:0}", pixelValues[2, 5]);
                textBox21.Text = String.Format("{0:0}", pixelValues[2, 6]);
                textBox22.Text = String.Format("{0:0}", pixelValues[3, 0]);
                textBox23.Text = String.Format("{0:0}", pixelValues[3, 1]);
                textBox24.Text = String.Format("{0:0}", pixelValues[3, 2]);
                textBox25.Text = String.Format("{0:0}", pixelValues[3, 3]);
                textBox26.Text = String.Format("{0:0}", pixelValues[3, 4]);
                textBox27.Text = String.Format("{0:0}", pixelValues[3, 5]);
                textBox28.Text = String.Format("{0:0}", pixelValues[3, 6]);
                textBox29.Text = String.Format("{0:0}", pixelValues[4, 0]);
                textBox30.Text = String.Format("{0:0}", pixelValues[4, 1]);
                textBox31.Text = String.Format("{0:0}", pixelValues[4, 2]);
                textBox32.Text = String.Format("{0:0}", pixelValues[4, 3]);
                textBox33.Text = String.Format("{0:0}", pixelValues[4, 4]);
                textBox34.Text = String.Format("{0:0}", pixelValues[4, 5]);
                textBox35.Text = String.Format("{0:0}", pixelValues[4, 6]);
                textBox36.Text = String.Format("{0:0}", pixelValues[5, 0]);
                textBox37.Text = String.Format("{0:0}", pixelValues[5, 1]);
                textBox38.Text = String.Format("{0:0}", pixelValues[5, 2]);
                textBox39.Text = String.Format("{0:0}", pixelValues[5, 3]);
                textBox40.Text = String.Format("{0:0}", pixelValues[5, 4]);
                textBox41.Text = String.Format("{0:0}", pixelValues[5, 5]);
                textBox42.Text = String.Format("{0:0}", pixelValues[5, 6]);
                textBox43.Text = String.Format("{0:0}", pixelValues[6, 0]);
                textBox44.Text = String.Format("{0:0}", pixelValues[6, 1]);
                textBox45.Text = String.Format("{0:0}", pixelValues[6, 2]);
                textBox46.Text = String.Format("{0:0}", pixelValues[6, 3]);
                textBox47.Text = String.Format("{0:0}", pixelValues[6, 4]);
                textBox48.Text = String.Format("{0:0}", pixelValues[6, 5]);
                textBox49.Text = String.Format("{0:0}", pixelValues[6, 6]);
            }
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

        private void LoadSelectedImage()
        {
            imageViewer1.Image.ReadFile(imagePath.Text);

            // If regions are on the viewer, update the array data
            if (imageViewer1.Roi.Count > 0)
            {
                DoImageToArray();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSelectedImage();
        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imageViewer1_RoiChanged(object sender, NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs e)
        {
            if (imageViewer1.Roi.Count > 0)
            {
                DoImageToArray();
            }
        }
    }

}