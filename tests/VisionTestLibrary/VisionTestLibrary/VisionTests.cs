using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using Xunit;

namespace VisionTestLibrary
{
    public class VisionTests
    {
        // The below test is a negative test that checks for the exception in case of null image.
        // Add you Tests in similar manner inside this class.
        [Fact]
        public void NegativeTestColorHistogram()
        {
            bool testResult = true;
            try
            {
                Algorithms.ColorHistogram(null);
                testResult = false;
            }
            catch(ArgumentNullException e)
            {
                testResult = true;
            }
            finally
            {
                Assert.True(testResult, "Failed: Expected error as image was null");
            }
        }

    }
}
