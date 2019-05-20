using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// ReadImage example
// This example shows how to open, read, and display images in NI Vision.

namespace ReadImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the combo box
            imageType.SelectedIndex = 0;
            
            // Initialize the common dialog's default directory
            openFileDialog1.InitialDirectory = ExampleImagesFolder.GetExampleImagesFolder();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            ReadImage();
        }

        private void ReadImage()
        {
            if (openFileDialog1.FileName != "")
            {
                // Read the file into the image attached to the viewer
                imageViewer1.Image.ReadFile(openFileDialog1.FileName);
            }
        }

        private void imageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the image type is changed, change the viewer's image type, and
            // reload the image from the disk.
            imageViewer1.Image.Type = (ImageType)imageType.SelectedIndex;
            ReadImage();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}