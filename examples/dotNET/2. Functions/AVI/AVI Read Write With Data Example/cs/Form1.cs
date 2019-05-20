using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

// AVI Read Write With Data Example
//
// 1. Select the path to save the AVI. The AVI that is created will
//    have sample data associated with each image.
//
// 2. The sample Images, waveforms and time stamps will be acquired
//    and saved to the AVI during the Writing phase.
//
// 3. After the AVI is done being written, the AVI is read along with
//    the data associated with each image. Use the Frame and Data to
//    Examine slider to examine the various images in the AVI during
//    the reading phase.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace AVI_Read_Write_With_Data_Example
{
    public enum RunMode
    {
        NotRunning = 0,
        WritingFrames = 1,
        ReadingFrames = 2
    }
    public partial class Form1 : Form
    {
        private RunMode mode = RunMode.NotRunning;
        private Form2 form2 = null;
        private AviInputSession sourceSession = null;
        private AviOutputSession destSession = null;
        private uint numFrames = 0;
        private uint curFrame = 0;
        private VisionImage frame = new VisionImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2(this);
            form2.Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (mode == RunMode.ReadingFrames)
            {
                if (sourceSession != null)
                {
                    sourceSession.Dispose();
                }
            }
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Close AVI if it is open
            if (mode != RunMode.NotRunning)
            {
                form2.Graph.ClearGraph();
                form2.FrameNum.Enabled = false;
                form2.FrameSlider.Enabled = false;
                if (sourceSession != null) {
                    sourceSession.Dispose();
                    sourceSession = null;
                }
            }

            // Load base AVI
            sourceSession = new AviInputSession(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"AVIs\Flame.avi"));
            numFrames = sourceSession.Frames;

            // Create output AVI
            if (Path.Text == "")
            {
                Browse();
            }
            destSession = new AviOutputSession(Path.Text, sourceSession.FramesPerSecond, null, -1, true, 10000);

            // Start writing
            statusLabel.Text = "Writing AVI File and Data";
            curFrame = 0;
            mode = RunMode.WritingFrames;
            frame.Type = ImageType.Rgb32;
            imageViewer1.Attach(frame);
            timer1.Enabled = true;
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        static double sinPhase;
        static double cosPhase;
        // Sample Data creates a time stamp, waveform and image. The time stamp
        // and waveform data are bundled together and flattened to a string.
        // This data is saved with the image in an AVI so when the AVI image is
        // read out later, the same data it was written with can also be
        // retrieved.
        private void SampleData(AviInputSession sourceSession, AviOutputSession destSession, VisionImage frame, uint frameIndex)
        {
            // Get and display  time
            string timestamp = DateTime.Now.ToString();
            form2.CurTime.Text = timestamp;

            // Read the frame
            sourceSession.ReadFrame(frame, frameIndex);

            // Get and display sample waveforms
            double[] waves = new double[3];
            waves[0] = 5 * Math.Sin(sinPhase);
            waves[1] = 4 * Math.Cos(cosPhase);
            waves[2] = (new Random()).NextDouble() * 6 - 3;
            sinPhase += .1;
            cosPhase += .15;

            form2.Graph.AppendData(waves[0], waves[1], waves[2]);

            AviData data = new AviData(timestamp, waves[0], waves[1], waves[2]);
            // Flatten data to buffer
            byte[] bytes = FlattenData(data);
            destSession.WriteFrame(frame, bytes);
        }

        // WriteFrame copies an AVI frame to a new location and adds timestamp
        // and waveform data to the frame.  The frame is then displayed in the viewer
        // and its data plotted on the graph.
        private void WriteFrame(uint frameIndex)
        {
            SampleData(sourceSession, destSession, frame, frameIndex);
            this.Refresh();
        }


        // UnflattenData breaks a data object containing a timestamp and three waveform numbers
        // into its respective data.
        private AviData UnflattenData(byte[] data)
        {
            MemoryStream memoryStream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return (AviData)formatter.Deserialize(memoryStream);
        }
        // FlattenData combines a timestamp and three waveform numbers into a
        // byte[]. This allows the cluster of information to be written
        // out together.
        private byte[] FlattenData(AviData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, data);
            return memoryStream.GetBuffer();
        }

        // ReadAllData reads in each frame's data and plots the resulting graph
        private void ReadAllData()
        {
            for (uint frameIndex = 0; frameIndex < sourceSession.Frames; ++frameIndex)
            {
                byte[] data = sourceSession.ReadFrame(imageViewer1.Image, frameIndex, true);

                // Read the data
                AviData aviData = UnflattenData(data);

                // Display results
                form2.CurTime.Text = aviData.TimeStamp;
                form2.Graph.AppendData(aviData.SinWave, aviData.SquareWave, aviData.Noise);
                form2.Refresh();
            }
        }

        // ReadFrame reads and displays the specified frame and its data
        public void ReadFrame(uint frameIndex)
        {
            // Read the frame
            byte[] data = sourceSession.ReadFrame(imageViewer1.Image, frameIndex, true);

            // Read the data
            AviData aviData = UnflattenData(data);

            // Display results
            form2.CurTime.Text = aviData.TimeStamp;
            form2.Graph.CursorValue = (int)frameIndex;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Done writing?
            if (curFrame >= numFrames || mode != RunMode.WritingFrames)
            {
                // Close AVIs
                sourceSession.Dispose();
                sourceSession = null;
                destSession.Dispose();
                destSession = null;

                // Setup for reading AVI frames
                mode = RunMode.ReadingFrames;
                startButton.Enabled = true;
                stopButton.Enabled = false;
                sourceSession = new AviInputSession(Path.Text);

                form2.Graph.SetupForReading((int)sourceSession.Frames);
                form2.FrameSlider.Enabled = true;
                form2.FrameSlider.SetRangeFromAvi(sourceSession);
                form2.FrameNum.Enabled = true;
                form2.FrameNum.Maximum = (int)sourceSession.Frames - 1;

                // Update display to reflect change in state
                statusLabel.Text = "Reading AVI File and Data";
                this.Refresh();
                form2.Graph.ClearGraph();

                ReadAllData();
                ReadFrame(0);
                form2.Graph.DoneReading();
                timer1.Enabled = false;
                return;
            }

            // Write the frame
            WriteFrame(curFrame);
            curFrame++;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            mode = RunMode.NotRunning;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            Browse();
        }
        private void Browse() {
            saveFileDialog1.FileName = Path.Text;
            saveFileDialog1.Title = "Name of AVI file to create";
            saveFileDialog1.Filter = "AVI files (*.avi)|*.avi||";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                Path.Text = saveFileDialog1.FileName;
            }
        }
    }
    // This class holds the data that is stored in the AVI.
    [Serializable]
    public class AviData
    {
        private string _timeStamp;
        private double _sinWave;
        private double _squareWave;
        private double _noise;

        public double Noise
        {
            get { return _noise; }
            set { _noise = value; }
        }

        public double SquareWave
        {
            get { return _squareWave; }
            set { _squareWave = value; }
        }

        public double SinWave
        {
            get { return _sinWave; }
            set { _sinWave = value; }
        }

        public string TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
        public AviData(string timeStamp, double sinWave, double squareWave, double noise)
        {
            _timeStamp = timeStamp;
            _sinWave = sinWave;
            _squareWave = squareWave;
            _noise = noise;
        }
    }
}
