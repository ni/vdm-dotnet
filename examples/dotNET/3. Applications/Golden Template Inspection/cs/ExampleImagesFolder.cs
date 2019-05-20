using System;
using Microsoft.Win32;

namespace NationalInstruments.Vision
{
    /// <summary>
    /// Class to get the NI Vision example images folder
    /// </summary>
    public static class ExampleImagesFolder
    {
        public static string GetExampleImagesFolder()
        {
            RegistryKey key = Registry.LocalMachine;
            key = key.OpenSubKey(@"SOFTWARE\National Instruments\IMAQ Vision\CurrentVersion");
            string imagesPath = "C:\\Users\\Public\\Documents\\National Instruments\\Vision\\Examples\\Images";
            key.Close();
            return imagesPath;
        }
    }
}
