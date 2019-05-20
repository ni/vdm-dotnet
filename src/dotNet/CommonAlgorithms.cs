//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2019, National Instruments Corp.

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:

// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Runtime.InteropServices;
using NationalInstruments.Vision.Internal;
using NationalInstruments.Vision.WindowsForms;

namespace NationalInstruments.Vision
{
    //==============================================================================================
    /// <summary>
    /// Defines commonly used algorithms to manipulate an image.
    /// </summary>

    public static class CommonAlgorithms
    {
        #region Image Manipulation functions
        //==========================================================================================
        /// <summary>
        /// Changes the type of an image with the specified source, destination, and type.
        /// </summary>
        /// <param name="source">
        /// The source image.
        /// </param>
        /// <param name="destination">
        /// The destination image. Set this parameter equal to source or <see langword="null"/> to perform the change directly on the source image. 
        /// </param>
        /// <param name="type">
        /// The new type for the image. <paramref name="type"/> is the new type for the <paramref name="destination"/> image if it is being used, otherwise it is the new type for <paramref name="source"/>. 
        /// </param>

        public static void Cast(VisionImage source, VisionImage destination, ImageType type)
        {
            Cast(source, destination, type, 0);
        }
        //==========================================================================================
        /// <summary>
        /// Changes the type of an image with the specified source, destination, type, and lookup table.
        /// </summary>
        /// <param name="source">
        /// The source image.
        /// </param>
        /// <param name="destination">
        /// The destination image. Set this parameter equal to source or <see langword="null"/> to perform the change directly on the source image. 
        /// </param>
        /// <param name="type">
        /// The new type for the image. <paramref name="type"/> is the new type for the <paramref name="destination"/> image if it is being used, otherwise it is the new type for <paramref name="source"/>. 
        /// </param>
        /// <param name="lookupTable">
        /// An optional lookup table. If you do not want  to use a lookup table, this parameter may be <see keyword="" keywordType="mstudio"/>.  
        /// </param>

        public static void Cast(VisionImage source, VisionImage destination, ImageType type, Collection<float> lookupTable)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            source.ThrowIfDisposed();
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            int tableSize = 256;
            if (source.Type == ImageType.I16 || source.Type == ImageType.U16) { tableSize = 65536; }
            // If the table is the correct size, just do the conversion; otherwise, pad it first.
            float[] cviTable;
            if (lookupTable == null)
            {
                cviTable = null;
            }
            else
            {
                if (lookupTable.Count >= tableSize)
                {
                    cviTable = Utilities.ConvertCollectionToArray<float>(lookupTable);
                }
                else
                {
                    cviTable = new float[tableSize];
                    for (int i = 0; i < lookupTable.Count; ++i)
                    {
                        cviTable[i] = lookupTable[i];
                    }
                    for (int i = lookupTable.Count; i < tableSize; ++i)
                    {
                        if (source.Type == ImageType.I16)
                        {
                            cviTable[i] = (i <= 32768) ? (float)i : (float)(i - 65536);
                        }
                        else
                        {
                            cviTable[i] = i;
                        }
                    }
                }
            }
            Utilities.ThrowError(VisionDllCommon.imaqCast(destination._image, source._image, type, cviTable, 0));
        }
        //==========================================================================================
        /// <summary>
        /// Changes the type of an image with the specified source, destination, type, and shifts.
        /// </summary>
        /// <param name="source">
        /// The source image.
        /// </param>
        /// <param name="destination">
        /// The destination image. Set this parameter equal to source or <see langword="null"/> to perform the change directly on the source image. 
        /// </param>
        /// <param name="type">
        /// The new type for the image. <paramref name="type"/> is the new type for the <paramref name="destination"/> image if it is being used, otherwise it is the new type for <paramref name="source"/>. 
        /// </param>
        /// <param name="numberOfShifts">
        /// The shift value for converting 16-bit images to 8-bit images. The method executes this conversion by shifting the 16-bit pixel values to the right by the specified number of shift operations, up to a maximum of 8 shift operations, and then truncating to get an 8-bit value. Enter a value of –1 to ignore the bit depth and shift 0. Enter a value of 0 to use the bit depth to cast the image.
        /// </param>

        public static void Cast(VisionImage source, VisionImage destination, ImageType type, Int32 numberOfShifts)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            source.ThrowIfDisposed();
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqCast(destination._image, source._image, type, null, numberOfShifts));
        }
        //==========================================================================================
        /// <summary>
        /// Copies the source image to the destination image, including the border size and calibration information. 
        /// </summary>
        /// <param name="source">
        /// The source image to copy.
        /// </param>
        /// <param name="destination">
        /// The resulting image.
        /// </param>
        /// <remarks>
        /// Use this method with all image types.
        /// <para>
        /// To copy an area of one image to an area of another image, use the Extract2 method with xSubsample and ySubsample set to 1.
        /// </para>
        /// 	<para>
        /// The <paramref name="source"/> and <paramref name="destination"/> images must be the same type of image. The method copies the complete definition of the source image and its pixel data to the destination image. The method also modifies the border of the destination image so that it becomes the same size as the border of the source image.
        /// </para>
        /// </remarks>

        public static void Copy(VisionImage source, VisionImage destination)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            source.ThrowIfDisposed();
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqDuplicate(destination._image, source._image));
        }
        #endregion
        #region File I/O functions
        //==========================================================================================
        /// <summary>
        /// Returns information regarding the contents of an image file. You can retrieve information from the following image file formats only: AIPD, BMP, JPEG, JPEG2000, PNG, and TIFF.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file from which the method gets information.
        /// </param>

        public static FileInformation GetFileInformation(string fileName)
        {
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            Int32 calibrationUnit;
            float calibrationX;
            float calibrationY;
            Int32 width;
            Int32 height;
            Int32 imageType;
            Utilities.ThrowError(VisionDllCommon.imaqGetFileInfo(fileName, out calibrationUnit, out calibrationX, out calibrationY, out width, out height, out imageType));
            FileInformation toReturn = new FileInformation();
            toReturn.CalibrationGrid.Unit = (CalibrationUnit)calibrationUnit;
            toReturn.CalibrationGrid.XStep = calibrationX;
            toReturn.CalibrationGrid.YStep = calibrationY;
            toReturn.Height = height;
            toReturn.Width = width;
            toReturn.ImageType = (ImageType)imageType;
            return toReturn;
        }
        #endregion
    }
}
