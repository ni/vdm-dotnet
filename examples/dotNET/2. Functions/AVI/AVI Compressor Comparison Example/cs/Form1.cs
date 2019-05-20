using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// AVI Compression Comparison Example

// This example creates a new AVI using each compressor installed on
// your machine and compares the size of the file, the average write
// times, and the quality of each compressor.  The uncompressed version
// is also included to provide a benchmark data point.

// This example will take a few seconds to create all the AVIs required
// for analysis.  These AVIs are saved to a folder named AVI Compressor
// Comparison Example under the same folder as this example.

namespace AVI_Compressor_Comparison_Example
{
    public partial class Form1 : Form
    {
        Collection<string> filters;
        AviInputSession inputSession;
        int curFilter = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void SetupTableHeaders()
        {
            results.Columns.Add("Compressor", 150);
            results.Columns.Add("File Size (KB)", 80);
            results.Columns.Add("Avg Write Time (ms)", 120);
            results.Columns.Add("Quality (0 to 1000)", 110);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Clear existing results.
            results.Clear();
            results.View = View.Details;
            SetupTableHeaders();
            progressBar1.Value = 0;

            // Start running conversion tests.
            curFilter = -1;
            timer1.Enabled = true;
        }

        private void AddItem(string filterName, double fileSize, double averageFrameTime, double quality)
        {
            ListViewItem item = new ListViewItem(filterName);
            item.SubItems.Add(Math.Round(fileSize, 2).ToString());
            item.SubItems.Add(Math.Round(averageFrameTime, 2).ToString());
            item.SubItems.Add(Math.Round(quality, 2).ToString());
            results.Items.Add(item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAviFilters();
            LoadAvi();
            DisplayAviInfo();

            SetupTableHeaders();
            // Initialize progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = filters.Count + 1;
            progressBar1.Value = 0;
        }
        private void LoadAviFilters()
        {
            filters = AviOutputSession.GetCompressionFilters();
        }

        private void LoadAvi()
        {
            openFileDialog1.InitialDirectory = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"AVIs");
            openFileDialog1.FileName = "CompressorComparison.avi";
            openFileDialog1.Filter = "AVI files (*.avi)|*.avi||";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                inputSession = new AviInputSession(openFileDialog1.FileName);
            }

            // Create the temp directory.
            try {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AVI Compressor Comparison Example"));
            } catch (Exception) {
            }
        }

        private void DisplayAviInfo()
        {
            width.Text = inputSession.Width.ToString();
            height.Text = inputSession.Height.ToString();
            numFrames.Text = inputSession.Frames.ToString();
            compressionFilter.Text = inputSession.FilterName;
        }

        private void GetFilterName(int index, out string filterName, out string commonName, out string outputPath)
        {
            if (index < 0 || index > filters.Count)
            {
                filterName = "";
                commonName = "Uncompressed";
            }
            else
            {
                filterName = filters[index];
                commonName = filterName;
            }
            outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"AVI Compressor Comparison Example\" + commonName + ".avi");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Quit running conversions if no more filters
            if (curFilter >= filters.Count)
            {
                timer1.Enabled = false;
                return;
            }

            string filterName, commonName, outputPath;
            GetFilterName(curFilter, out filterName, out commonName, out outputPath);

            double averageFrameTime;
            // Create compressed AVI file.
            using (AviOutputSession outputSession = new AviOutputSession(outputPath, 30, filterName))
            {
                // Copy the frames from original AVI file to the compressed file.
                CopyAvi(inputSession, outputSession, out averageFrameTime);
            }

            // Calculate results of compression and write them to the table
            long fileSize = new System.IO.FileInfo(outputPath).Length;
            double quality;
            using (AviInputSession writtenSession = new AviInputSession(outputPath)) {
                quality = CompareAvi(inputSession, writtenSession);
            }

            AddItem(commonName, (double)fileSize/1024, averageFrameTime, quality);
            progressBar1.Value = progressBar1.Value + 1;
            curFilter++;
            Refresh();
        }

        private void CopyAvi(AviInputSession source, AviOutputSession dest, out double averageFrameTime)
        {
            int totalTime = 0;

            // Grab each frame.
            VisionImage[] frames = new VisionImage[source.Frames];
            for (uint i = 0; i < source.Frames; ++i)
            {
                frames[i] = new VisionImage(ImageType.Rgb32);
                source.ReadFrame(frames[i], i);
            }

            // Convert each frame.
            int startTime = System.Environment.TickCount;
            for (int i = 0; i < source.Frames; ++i)
            {
                // Write the frame.
                dest.WriteFrame(frames[i]);
            }
            totalTime = System.Environment.TickCount - startTime;
            averageFrameTime = ((double)totalTime) / source.Frames;
        }

        // CompareAvi compares each frame of two images to calculate the average
        // difference.  This is used to compare quality.
        private double CompareAvi(AviInputSession original, AviInputSession other)
        {
            double totalDiff = 0;
            using (VisionImage firstImage = new VisionImage(), secondImage = new VisionImage())
            {
                // Setup the images to store the frames.
                firstImage.Type = ImageType.Rgb32;
                secondImage.Type = ImageType.Rgb32;

                // Calculate the difference between frames.
                for (uint curFrame = 0; curFrame < original.Frames; ++curFrame)
                {
                    // Read the frames.
                    original.ReadFrame(firstImage, curFrame);
                    other.ReadFrame(secondImage, curFrame);

                    // Resize first image to be same as second if needed.
                    if (firstImage.Width != secondImage.Width || firstImage.Height != secondImage.Height)
                    {
                        Algorithms.Resample(firstImage, firstImage, secondImage.Width, secondImage.Height, InterpolationMethod.Bilinear);
                    }

                    // Calculate the difference between the frames.
                    Algorithms.AbsoluteDifference(firstImage, secondImage, firstImage);
                    ColorHistogramReport colorReport = Algorithms.ColorHistogram(firstImage, 256, ColorMode.Hsl);
                    totalDiff += colorReport.Plane3.Mean;
                }
            }
            // Calculate quality from difference
            totalDiff = totalDiff / (double)original.Frames;
            double quality = 1000 - (totalDiff * 10);
            if (quality < 0)
            {
                quality = 0;
            }
            return quality;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}