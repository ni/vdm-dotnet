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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security;
using System.Security.Permissions;
using NationalInstruments.Vision.Internal;
using NationalInstruments.Vision.WindowsForms;
using NationalInstruments.Vision.WindowsForms.Internal;
using System.Globalization;

namespace NationalInstruments.Vision 
{
    //==============================================================================================
    /// <summary>
    /// Specifies the type of image data the <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/> holds.
    /// </summary>

    public enum ImageType 
    {
        /// <summary>
        /// Unsigned 8-bit
        /// </summary>
        U8 = 0,
        /// <summary>
        /// Signed 16-bit
        /// </summary>
        I16 = 1,
        /// <summary>
        /// Single precision
        /// </summary>
        Single = 2,
        /// <summary>
        /// Complex
        /// </summary>
        Complex = 3,
        /// <summary>
        /// 32-bit RGB
        /// </summary>
        Rgb32 = 4,
        /// <summary>
        /// 32-bit HSL
        /// </summary>
        Hsl32 = 5,
        /// <summary>
        /// 64-bit unsigned RGB
        /// </summary>
        RgbU64 = 6,
        /// <summary>
        /// Unsigned 16-bit
        /// </summary>
        U16 = 7
    }

    //==============================================================================================
    /// <summary>
    /// Represents image data and properties that you can configure on a per image basis.
    /// </summary>

    [Serializable]
    public sealed class VisionImage : IDisposable, ISerializable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr _image = IntPtr.Zero;
        internal Collection<ImageViewer> _viewers = new Collection<ImageViewer>();
        internal static Dictionary<IntPtr, VisionImage> rawImageToImage = new Dictionary<IntPtr, VisionImage>();
        internal static VisionDllCommon.ExternalCanvasCallbackDelegate staticCallback = new VisionDllCommon.ExternalCanvasCallbackDelegate(imageChangedCallback);
        private CustomDataDictionary _customData = null;
        private Overlays _overlays = null;
        private PointContour _maskOffset = null;
        private object _disposeLock = new object();
        // We have to do this so the GC won't move or dispose our callback as long as we're loaded.
        internal static GCHandle _gch = GCHandle.Alloc(staticCallback);

internal void ThrowIfDisposed()
        {
            if (_image == IntPtr.Zero)
            {
                throw new ObjectDisposedException("NationalInstruments.Vision.VisionImage");
            }
        }

internal static void ThrowIfNonNullAndDisposed(VisionImage image)
        {
            if (image != null)
            {
                image.ThrowIfDisposed();
            }
        }

internal static IntPtr GetIntPtr(VisionImage image)
        {
            if (image == null) { return IntPtr.Zero; }
            return image._image;
        }

internal void AddViewer(ImageViewer viewer)
        {
            if (!_viewers.Contains(viewer))
            {
                _viewers.Add(viewer);
            }
        }

internal void RemoveViewer(ImageViewer viewer)
        {
            if (_viewers.Contains(viewer))
            {
                _viewers.Remove(viewer);
            }
        }

        //==========================================================================================
        /// <summary>
        /// A helper method to throw an "Incompatible image type" exception if we're not
        /// of this type.  We should only need to do this for cases where CVI can't tell
        /// we're the wrong type. (e.g. trying to call imaqArrayToImage() with the wrong
        /// kind of array)
        /// </summary>
        /// <param name="allowedType"></param>
        //==========================================================================================
        internal void ThrowIfWrongType(ImageType allowedType)
        {
            if (Type != allowedType)
            {
                throw new VisionException(ErrorCode.IncompType);
            }
        }

internal void ThrowIfWrongType(PixelValue value)
        {
            switch (Type)
            {
                case ImageType.U8:
                case ImageType.I16:
                case ImageType.U16:
                case ImageType.Single:
                    if (value.PixelType != PixelValue.Type.Grayscale)
                    {
                        throw new VisionException(ErrorCode.IncompType);
                    }
                    break;
                case ImageType.Rgb32:
                    if (value.PixelType != PixelValue.Type.Rgb32)
                    {
                        throw new VisionException(ErrorCode.IncompType);
                    }
                    break;
                case ImageType.RgbU64:
                    if (value.PixelType != PixelValue.Type.RgbU64)
                    {
                        throw new VisionException(ErrorCode.IncompType);
                    }
                    break;
                case ImageType.Hsl32:
                    if (value.PixelType != PixelValue.Type.Hsl32)
                    {
                        throw new VisionException(ErrorCode.IncompType);
                    }
                    break;
                case ImageType.Complex:
                    if (value.PixelType != PixelValue.Type.Complex)
                    {
                        throw new VisionException(ErrorCode.IncompType);
                    }
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    break;
            }
        }

internal void OnImageUpdated()
        {
            // Make sure we haven't been disposed.
            if (_image != IntPtr.Zero)
            {
                foreach (ImageViewer viewer in _viewers)
                {
                    viewer.OnImageUpdated(ImmediateUpdateMode.Normal);
                }
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the bit depth of the image.
        /// </summary>
        /// <value>
        /// This property applies only to U16, I16 and RGBU64 images. The value must be from 8 to 16 for U16 images, from 8 to 15 for I16 images, and from 8 to 16 for RGBU64 images, or 0. A value of 0 indicates that NI Vision should use the entire range of the image datatype.
        /// </value>

        [CLSCompliant(false)]
        public UInt32 BitDepth
        {
            get 
            {
                ThrowIfDisposed();
                UInt32 bitDepth;
                Utilities.ThrowError(VisionDllCommon.imaqGetBitDepth(_image, out bitDepth));
                return bitDepth;
            }
            set
            {
                ThrowIfDisposed();
                Utilities.ThrowError(VisionDllCommon.imaqSetBitDepth(_image, value));
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the pixel type of the image.</summary>
        /// <value>
        /// The pixel type of the image.
        /// </value>
        /// <remarks>
        /// You can set this property to change the image type and convert the image data to the specified format.  For more options when converting the image, use <see cref="NationalInstruments.Vision.CommonAlgorithms.Cast" crefType="Unqualified"/>.
        /// </remarks>

        public ImageType Type 
        {
            get 
            {
                ThrowIfDisposed();
                Int32 type;
                Utilities.ThrowError(VisionDllCommon.imaqGetImageType(_image, out type));
                return (ImageType) type;
            }
            set
            {
                ThrowIfDisposed();
                if (!Enum.IsDefined(typeof(ImageType), value))
                {
                    throw new System.ComponentModel.InvalidEnumArgumentException("value", (int)value, typeof(ImageType));
                }
                Utilities.ThrowError(VisionDllCommon.imaqCast(_image, _image, value, IntPtr.Zero, 0));
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the width of the image in pixels.</summary>
        /// <value>
        /// The width of the image in pixels.
        /// </value>

        public Int32 Width
        {
            get
            {
                ThrowIfDisposed();
                Int32 width, height;
                Utilities.ThrowError(VisionDllCommon.imaqGetImageSize(_image, out width, out height));
                return width;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the height of the image in pixels.</summary>
        /// <value>
        /// The height of the image in pixels.
        /// </value>

        public Int32 Height
        {
            get
            {
                ThrowIfDisposed();
                Int32 width, height;
                Utilities.ThrowError(VisionDllCommon.imaqGetImageSize(_image, out width, out height));
                return height;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the width, in pixels, of the border created around an image.
        /// </summary>
        /// <value>
        /// The default value is 3. Only specific NI Vision methods related to morphology or filtering use border information. With a border width of 3, you can use 7x7 kernels with no change.  If you plan to use kernels larger than 7x7 in your process, specify a larger border width.</value>

        public Int32 BorderWidth
        {
            get
            {
                ThrowIfDisposed();
                Int32 width;
                Utilities.ThrowError(VisionDllCommon.imaqGetBorderSize(_image, out width));
                return width;
            }
            set
            {
                ThrowIfDisposed();
                Utilities.ThrowError(VisionDllCommon.imaqSetBorderSize(_image, value));
            }

        }

[EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr StartPtr
        {
            get
            {
                ThrowIfDisposed();
                CVI_Point start = new CVI_Point(0, 0);
                return VisionDllCommon.imaqGetPixelAddress(_image, start);
            }
        }

        
#if (Bit64) 
        [CLSCompliant(false)]
#endif
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UInt64 LineWidthInBytes
        {
            get
            {
                ThrowIfDisposed();
                CVI_Point start = new CVI_Point(0, 0);
                CVI_Point nextLineStart = new CVI_Point(0, 1);
                IntPtr startPtr = VisionDllCommon.imaqGetPixelAddress(_image, start);
                IntPtr nextLinePtr = VisionDllCommon.imaqGetPixelAddress(_image, nextLineStart);
                return (UInt64)nextLinePtr - (UInt64)startPtr;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the offset of the mask image if this image is a mask.</summary>
        /// <value>
        /// The offset of the mask image if this image is a mask.
        /// </value>

        public PointContour MaskOffset
        {
            get
            {
                GetMaskOffset();
                return _maskOffset;
            }
            set
            {
                if (value == null) { throw new ArgumentNullException("value"); }
                ThrowIfDisposed();
                _maskOffset.PropertyChanged -= _maskOffset_PropertyChanged;
                _maskOffset = value;
                _maskOffset.PropertyChanged += _maskOffset_PropertyChanged;
                SetMaskOffset();
            }
        }

        
        private void GetMaskOffset()
        {
            ThrowIfDisposed();
            CVI_Point cviOffset = new CVI_Point();
            Utilities.ThrowError(VisionDllCommon.imaqGetMaskOffset(_image, out cviOffset));
            _maskOffset.PropertyChanged -= _maskOffset_PropertyChanged;
            _maskOffset = cviOffset.ConvertToExternal();
            _maskOffset.PropertyChanged += _maskOffset_PropertyChanged;
        }
        //==========================================================================================
        /// <summary>
        /// </summary>

        private void SetMaskOffset()
        {
            ThrowIfDisposed();
            CVI_Point cviOffset = new CVI_Point();
            cviOffset.ConvertFromExternal(_maskOffset);
            // Set the new value - if that doesn't work, reset to the old value
            try
            {
                VisionDllCommon.imaqSetMaskOffset(_image, cviOffset);
            }
            catch (VisionException)
            {
                GetMaskOffset();
                throw;
            }
        }

        
        void _maskOffset_PropertyChanged(object sender, EventArgs e)
        {
            SetMaskOffset();
        }

        /// <summary>
        /// Creates a new image.
        /// </summary>
        public VisionImage() : this(ImageType.U8)
        {
        }

        /// <summary>
        /// Creates a new image.
        /// </summary>
        /// <param name="type">The <see cref="NationalInstruments.Vision.ImageType"/> of the image.</param>
        public VisionImage(ImageType type) : this(type, 3)
        {
        }

        /// <summary>
        /// Creates a new image.
        /// </summary>
        /// <param name="type">The <see cref="NationalInstruments.Vision.ImageType"/> of the image.</param>
        /// <param name="borderSize">The size of the border.</param>
        public VisionImage(ImageType type, Int32 borderSize)
        {
            _image = VisionDllCommon.imaqCreateImage((Int32) type, borderSize);
            Utilities.ThrowError(_image);
            // protect the static table while we insert it
            lock(rawImageToImage) 
            {
            rawImageToImage[_image] = this;
            }
            _customData = new CustomDataDictionary(this);
            _overlays = new Overlays(this, true);
            _maskOffset = new PointContour();
            _maskOffset.PropertyChanged += _maskOffset_PropertyChanged;
            VisionDllCommon.SetExternalCanvasCallback(_image, staticCallback);
        }

private VisionImage(SerializationInfo info, StreamingContext context) : this()
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            // If creation fails somehow, we could be disposed, so give up.
            ThrowIfDisposed();
            byte[] flattenData = (byte[])info.GetValue("flattenedData", typeof(byte[]));
            Unflatten(flattenData);
        }

        
        internal static VisionImage getFromRawImage(IntPtr _image)
        {
            VisionImage toReturn = null;
            // It's possible we won't know what this image is.  If we don't,
            // just return null.
            lock(rawImageToImage) 
            {
            rawImageToImage.TryGetValue(_image, out toReturn);
            }
            return toReturn;
        }

internal static void imageChangedCallback(IntPtr _image)
        {
            // _image has been updated, so find its owner and tell it
            // that it has been changed.
            VisionImage image = getFromRawImage(_image);
            // If the image is null, we don't know what this image is, so we do nothing
            // rather than crash.
            // It would be nice to Debug.Fail() if the image is null, but this happens
            // every time we dispose an image so it's a bit impractical.
            if (image != null) {
                image.OnImageUpdated();
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the types of extra vision information associated with the image.
        /// </summary>
        /// <value>
        /// The types of extra vision information associated with the image.
        /// </value>

        public InfoTypes InfoTypes
        {
            get
            {
                ThrowIfDisposed();
                int present;
                Utilities.ThrowError(VisionDllCommon.imaqGetVisionInfoTypes(_image, out present));
                return (InfoTypes)present;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets whether the image is empty.
        /// </summary>
        /// <value>
        ///     <see langword="true"/> if all image pixels are 0; otherwise, <see langword="false"/>.
        /// </value>

        public bool IsEmpty
        {
            get
            {
                ThrowIfDisposed();
                int isEmpty;
                Utilities.ThrowError(VisionDllCommon.imaqIsImageEmpty(_image, out isEmpty));
                return isEmpty != 0;
            }
        }

internal void OnReadFile()
        {
            _overlays = new Overlays(this, false);
        }

        //==========================================================================================
        /// <summary>
        /// Removes the specified vision information types from an image.
        /// </summary>
        /// <param name="infoTypes">
        /// The vision information types to remove from this image.
        /// </param>

        public void RemoveVisionInfo(InfoTypes infoTypes)
        {
            ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqRemoveVisionInfo2(_image, (int)infoTypes));
        }

        /// <summary>
        /// Sets the size of the image.
        /// </summary>
        /// <param name="width">The new width of the image.</param>
        /// <param name="height">The new height of the image.</param>
        public void SetSize(Int32 width, Int32 height)
        {
            ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqSetImageSize(_image, width, height));
        }

        //==========================================================================================
        /// <summary>
        /// Sets the pixels of an image to the values in a given array.  This function resizes the
        /// image to the size of the array.
        /// </summary>
        /// <param name="array">The new pixels of the image in row-major order. These pixels must be
        /// of the same type as the image.
        /// </param>

        public void ArrayToImage(PixelValue2D array)
        {
            ThrowIfDisposed();
            if (array == null) { throw new ArgumentNullException("array"); }
            array.CheckType(Type);
            Array realArray = array.GetArray();
            if (realArray == null) { throw new ArgumentNullException("array"); }
            // We include the endpoints of the array so we need to add 1.
            int numRows = realArray.GetUpperBound(0) - realArray.GetLowerBound(0) + 1;
            int numCols = realArray.GetUpperBound(1) - realArray.GetLowerBound(1) + 1;
            // It would be super awesome if we could get a pointer to the array here, but we can't,
            // and generics don't seem to help.  So, overload!
            switch (Type)
            {
                case ImageType.U8:
                    ArrayToImageInternal(array.U8, numCols, numRows);
                    break;
                case ImageType.I16:
                    ArrayToImageInternal(array.I16, numCols, numRows);
                    break;
                case ImageType.Single:
                    ArrayToImageInternal(array.Single, numCols, numRows);
                    break;
                case ImageType.Complex:
                    ArrayToImageInternal(array.Complex, numCols, numRows);
                    break;
                case ImageType.Rgb32:
                    ArrayToImageInternal(array.Rgb32, numCols, numRows);
                    break;
                case ImageType.Hsl32:
                    ArrayToImageInternal(array.Hsl32, numCols, numRows);
                    break;
                case ImageType.RgbU64:
                    ArrayToImageInternal(array.RgbU64, numCols, numRows);
                    break;
                case ImageType.U16:
                    ArrayToImageInternal(array.U16, numCols, numRows);
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    break;
            }
        }

        
        internal void ArrayToImageInternal(byte[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(Int16[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(Single[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(Complex[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(Rgb32Value[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(Hsl32Value[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(RgbU64Value[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        
        internal void ArrayToImageInternal(UInt16[,] array, int numCols, int numRows)
        {
            Utilities.ThrowError(VisionDllCommon.imaqArrayToImage(_image, array, numCols, numRows));
        }

        //==========================================================================================
        /// <summary>
        /// Changes the intensity values in a line of pixels of an image.</summary>
        /// <param name="line">
        /// The coordinates of the line to change.  Any pixels designated by <format type="italics">line</format> found outside the actual image are not replaced. This Roi must contain exactly one <see cref="NationalInstruments.Vision.LineContour" crefType="Unqualified"/>.</param>
        /// <param name="pixels">
        /// The pixel values that the method uses to replace the values in the line.
        /// </param>

        public void SetLinePixels(Roi line, PixelValue1D pixels)
        {
            if (line == null) { throw new ArgumentNullException("line"); }
            line.ThrowIfDisposed();
            Utilities.ThrowIfNotSingleLine(line);
            SetLinePixels((LineContour)line[0].Shape, pixels);
        }
        //==========================================================================================
        /// <summary>
        /// Changes the intensity values in a line of pixels of an image.
        /// </summary>
        /// <param name="line">
        /// The coordinates of the line to change.  Any pixels designated by <format type="italics">line </format>found outside the actual image are not replaced.</param>
        /// <param name="pixels">
        /// The pixel values that the method uses to replace the values in the line.</param>

        public void SetLinePixels(LineContour line, PixelValue1D pixels)
        {
            ThrowIfDisposed();
            if (line == null) { throw new ArgumentNullException("line"); }
            if (pixels == null) { throw new ArgumentNullException("pixels"); }
            pixels.CheckType(Type);
            Array realArray = pixels.GetArray();
            if (realArray == null) { throw new ArgumentNullException("pixels"); }
            int numPixels = realArray.GetLength(0);
            CVI_Point cviStart = new CVI_Point();
            cviStart.ConvertFromExternal(line.Start);
            CVI_Point cviEnd = new CVI_Point();
            cviEnd.ConvertFromExternal(line.End);
            // It would be super awesome if we could get a pointer to the array here, but we can't,
            // and generics don't seem to help.  So, switch on the image type instead.
            switch (Type)
            {
                case ImageType.U8:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.U8, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.I16:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.I16, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.Single:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.Single, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.Complex:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.Complex, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.Rgb32:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.Rgb32, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.Hsl32:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.Hsl32, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.RgbU64:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.RgbU64, numPixels, cviStart, cviEnd));
                    break;
                case ImageType.U16:
                    Utilities.ThrowError(VisionDllCommon.imaqSetLine(_image, pixels.U16, numPixels, cviStart, cviEnd));
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    break;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Returns an array representation of the pixels in the image.
        /// </summary>
        /// <returns>
        /// The array representation of the pixels in the image in row-major order.
        /// </returns>
        //==========================================================================================
        public PixelValue2D ImageToArray()
        {
            return ImageToArray(RectangleContour.None);
        }

        //==========================================================================================
        /// <summary>
        /// Returns an array representation of the pixels in the region of interest.
        /// </summary>
        /// <param name="rectangle">
        /// The part of the image to extract. This Roi must either be empty or contain exactly one <see cref="NationalInstruments.Vision.RectangleContour" crefType="Unqualified"/>.
        /// </param>
        /// <returns>
        /// The array representation of the pixels in the region of interest in row-major order.
        /// </returns>

        public PixelValue2D ImageToArray(Roi rectangle)
        {
            Roi.ThrowIfNonNullAndDisposed(rectangle);
            return ImageToArray(Utilities.ConvertRoiToRectangle(rectangle));
        }

        //==========================================================================================
        /// <summary>
        /// Returns an array representation of the pixels in the rectangle.
        /// </summary>
        /// <param name="rectangle">
        /// The part of the image to extract.
        /// </param>
        /// <returns>
        /// The array representation of the pixels in the rectangle in row-major order.
        /// </returns>

        public PixelValue2D ImageToArray(RectangleContour rectangle) 
        {
            ThrowIfDisposed();
            if (rectangle == null) { throw new ArgumentNullException("rectangle"); }
            ImageType type = this.Type;
            Int32 numCols, numRows;
            CVI_Rectangle cviRect = new CVI_Rectangle();
            cviRect.ConvertFromExternal(rectangle);
            IntPtr array = VisionDllCommon.imaqImageToArray(_image, cviRect, out numCols, out numRows);
            Utilities.ThrowError(array);
            PixelValue2D toReturn;
            switch (type) {
                case ImageType.U8:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrFlatTo2DArrayByte(array, numRows, numCols, false));
                    break;
                case ImageType.I16:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrFlatTo2DArrayInt16(array, numRows, numCols, false));
                    break;
                case ImageType.Single:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrFlatTo2DArraySingle(array, numRows, numCols, false));
                    break;
                case ImageType.Complex:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrTo2DStructureArray<Complex>(array, numRows, numCols, false));
                    break;
                case ImageType.Rgb32:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrTo2DStructureArray<Rgb32Value>(array, numRows, numCols, false));
                    break;
                case ImageType.Hsl32:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrTo2DStructureArray<Hsl32Value>(array, numRows, numCols, false));
                    break;
                case ImageType.RgbU64:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrTo2DStructureArray<RgbU64Value>(array, numRows, numCols, false));
                    break;
                case ImageType.U16:
                    toReturn = new PixelValue2D(Utilities.ConvertIntPtrFlatTo2DArrayUInt16(array, numRows, numCols, false));
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    toReturn = new PixelValue2D(new byte[0, 0]);
                    break;
            }
            VisionDllCommon.imaqDispose(array);
            return toReturn;
        }
        //==========================================================================================
        /// <summary>
        /// Returns the pixel values along a given line in an image.</summary>
        /// <param name="line">
        /// The line of pixels to extract.  This Roi must be either empty or contain one LineContour.
        /// </param>
        /// <returns>
        /// The pixel values extracted from the image.</returns>
        /// <remarks>
        ///  If the starting or ending point of the line is outside the image, the line clips at the last visible pixel.
        /// </remarks>

        public PixelValue1D GetLinePixels(Roi line)
        {
            if (line == null) { throw new ArgumentNullException("line"); }
            line.ThrowIfDisposed();
            Utilities.ThrowIfNotSingleLine(line);
            return GetLinePixels((LineContour)line[0].Shape);
        }

        //==========================================================================================
        /// <summary>
        /// Returns the pixel values along a given line in an image.</summary>
        /// <param name="line">
        /// The line of pixels to extract.</param>
        /// <returns>
        /// The pixel values extracted from the image.
        /// </returns>
        /// <remarks>
        /// If the starting or ending point of the line is outside the image, the line clips at the last visible pixel.
        /// </remarks>

        public PixelValue1D GetLinePixels(LineContour line)
        {
            ThrowIfDisposed();
            if (line == null) { throw new ArgumentNullException("line"); }
            ImageType type = this.Type;
            Int32 numPoints;
            CVI_Point cviStart = new CVI_Point();
            cviStart.ConvertFromExternal(line.Start);
            CVI_Point cviEnd = new CVI_Point();
            cviEnd.ConvertFromExternal(line.End);
            IntPtr array = VisionDllCommon.imaqGetLine(_image, cviStart, cviEnd, out numPoints);
            Utilities.ThrowError(array);
            PixelValue1D toReturn;
            switch (type) {
                case ImageType.U8:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DArrayByte(array, numPoints, true));
                    break;
                case ImageType.I16:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DArrayInt16(array, numPoints, true));
                    break;
                case ImageType.Single:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DArraySingle(array, numPoints, true));
                    break;
                case ImageType.Complex:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DStructureArray<Complex>(array, numPoints, true));
                    break;
                case ImageType.Rgb32:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DStructureArray<Rgb32Value>(array, numPoints, true));
                    break;
                case ImageType.Hsl32:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DStructureArray<Hsl32Value>(array, numPoints, true));
                    break;
                case ImageType.RgbU64:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DStructureArray<RgbU64Value>(array, numPoints, true));
                    break;
                case ImageType.U16:
                    toReturn = new PixelValue1D(Utilities.ConvertIntPtrTo1DStructureArray<UInt16>(array, numPoints, true));
                    break;
                default:
                    Debug.Fail("Unknown image type!");
                    toReturn = new PixelValue1D(new byte[0]);
                    VisionDllCommon.imaqDispose(array);
                    break;
            }
            return toReturn;
        }

        //==========================================================================================
        /// <summary>
        /// Extracts a complex plane from an image to a 2D array.</summary>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// The <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/> must be of type Complex.
        /// </remarks>

        public float[,] ComplexPlaneToArray()
        {
            return ComplexPlaneToArray(ComplexPlane.Real, RectangleContour.None);
        }
        //==========================================================================================
        /// <summary>
        /// Extracts a complex plane from an image to a 2D array.
        /// </summary>
        /// <param name="plane">
        /// The plane to extract.  The default is Real.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// The <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/> must be of type Complex.
        /// </remarks>

        public float[,] ComplexPlaneToArray(ComplexPlane plane)
        {
            return ComplexPlaneToArray(plane, RectangleContour.None);
        }
        //==========================================================================================
        /// <summary>
        /// Extracts a complex plane from an image to a 2D array.
        /// </summary>
        /// <param name="plane">
        /// The plane to extract.  The default is Real.</param>
        /// <param name="rectangle">
        /// The part of the image to extract.
        /// </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// The <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/> must be of type Complex.
        /// </remarks>

        public float[,] ComplexPlaneToArray(ComplexPlane plane, Roi rectangle)
        {
            Roi.ThrowIfNonNullAndDisposed(rectangle);
            return ComplexPlaneToArray(plane, Utilities.ConvertRoiToRectangle(rectangle));
        }
        //==========================================================================================
        /// <summary>
        /// Extracts a complex plane from an image to a 2D array.
        /// </summary>
        /// <param name="plane">
        /// The plane to extract.  The default is Real.</param>
        /// <param name="rectangle">
        /// The part of the image to extract.
        /// </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// The <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/> must be of type Complex.
        /// </remarks>

        public float[,] ComplexPlaneToArray(ComplexPlane plane, RectangleContour rectangle)
        {
            ThrowIfDisposed();
            if (rectangle == null) { throw new ArgumentNullException("rectangle"); }
            Int32 numCols, numRows;
            CVI_Rectangle cviRect = new CVI_Rectangle();
            cviRect.ConvertFromExternal(rectangle);
            IntPtr array = VisionDllCommon.imaqComplexPlaneToArray(_image, plane, cviRect, out numRows, out numCols);
            Utilities.ThrowError(array);
            float[,] toReturn = Utilities.ConvertIntPtrFlatTo2DArraySingle(array, numRows, numCols, true);
            return toReturn;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A VisionImage instance to compare to this instance.
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(VisionImage other)
        {
            if (other == null) return false;
            if ((_image == IntPtr.Zero) != (other._image == IntPtr.Zero)) return false;
            if (_image == IntPtr.Zero && other._image == IntPtr.Zero) return true;
            if (Type != other.Type) return false;
            // Convert the images to arrays and compare them.
            PixelValue2D pixels1 = ImageToArray();
            PixelValue2D pixels2 = other.ImageToArray();
            return pixels1.Equals(pixels2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            VisionImage other = (VisionImage)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            // We can't use _image.GetHashCode() since you could have two separate images with
            // equal pixels (so they have to return the same hashcode)
            // At least hash the (0,0) value if the image is nonempty.
            int baseHashValue = 0;
            if (Width > 0 && Height > 0)
            {
                baseHashValue ^= GetPixel(new PointContour(0, 0)).GetHashCode();
            }
            return baseHashValue ^ Type.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }
        /// <summary>
        /// Reads an image file.
        /// </summary>
        /// <param name="fileName">The path of the file to read.</param>
        public void ReadFile(string fileName)
        {
            ReadFile(fileName, false);
        }

        //==========================================================================================
        /// <summary>
        /// Reads an image file.
        /// </summary>
        /// <param name="fileName">The path of the file to read.</param>
        /// <param name="readPalette">If <paramref name="readPalette"/> is <see langword="true"/>, the RGB palette used in the image; otherwise, <see langword="null"/>.</param>

        public unsafe Palette ReadFile(string fileName, bool readPalette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (readPalette)
            {
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                Int32 numColors;
                Utilities.ThrowError(VisionDllCommon.imaqReadFile(_image, fileName, colorTableArray, out numColors));
                OnReadFile();
                return new Palette(Utilities.ConvertArrayToCollection<Rgb32Value>(colorTableArray, numColors));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqReadFile(_image, fileName, IntPtr.Zero, IntPtr.Zero));
                OnReadFile();
                return null;
            }

        }

        /// <summary>
        /// Reads an image file and any attached vision information.
        /// </summary>
        /// <param name="fileName">The path of the file to read.</param>
        public void ReadVisionFile(string fileName)
        {
            ReadVisionFile(fileName, false);
        }

        /// <summary>
        /// Reads an image file and any attached vision information.
        /// </summary>
        /// <param name="fileName">The path of the file to read.</param>
        /// <param name="readPalette">Whether to read the RGB palette used in the image.</param>
        public unsafe Palette ReadVisionFile(string fileName, bool readPalette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (readPalette)
            {
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                Int32 numColors;
                Utilities.ThrowError(VisionDllCommon.imaqReadVisionFile(_image, fileName, colorTableArray, out numColors));
                OnReadFile();
                return new Palette(Utilities.ConvertArrayToCollection<Rgb32Value>(colorTableArray, numColors));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqReadVisionFile(_image, fileName, IntPtr.Zero, IntPtr.Zero));
                OnReadFile();
                return null;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Writes this image to a file.</summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>

        public void WriteFile(string fileName)
        {
            WriteFile(fileName, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="palette">
        /// The palette to associate with 8-bit images. The default is a grayscale palette.
        /// </param>
        /// <remarks>
        /// This method does not write overlay information, calibration information, pattern matching template information, or custom data to the file. To write this data, use WriteVisionFile. (link to WriteVisionFile)
        /// </remarks>

        public unsafe void WriteFile(string fileName, Palette palette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (palette != null)
            {
                // We need this to be exactly 256 entries long.
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                int i;
                for (i = 0; i < palette.Entries.Count && i < 256; ++i)
                {
                    colorTableArray[i] = palette.Entries[i].Rgb32Value;
                }
                for (int j = i; j < 256; ++j)
                {
                    colorTableArray[j] = new Rgb32Value((byte)j, (byte)j, (byte)j);
                }
                Utilities.ThrowError(VisionDllCommon.imaqWriteFile(_image, fileName, colorTableArray));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteFile(_image, fileName, IntPtr.Zero));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to file in BMP format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <remarks>
        /// Use this method with U8 and Rgb32 images.
        /// </remarks>

        public void WriteBmpFile(string fileName)
        {
            WriteBmpFile(fileName, false, null);
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// &gt;
        /// <param name="compress">
        ///     <see langword="true"/> to write a compressed BMP file; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </param>
        /// <remarks>
        /// Use this method with U8 and Rgb32 images.
        /// </remarks>

        public void WriteBmpFile(string fileName, bool compress)
        {
            WriteBmpFile(fileName, compress, null);
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="compress">
        ///     <see langword="true"/> to write a compressed BMP file; otherwise, <see langword="false"/>. The default value is <see langword="false"/>. 
        /// </param>
        /// <param name="palette">
        /// The palette to associate with U8 images.  The default is a grayscale image.
        /// </param>
        /// <remarks>
        /// Use this method with U8 and Rgb32 images.
        /// </remarks>

        public void WriteBmpFile(string fileName, bool compress, Palette palette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (palette != null)
            {
                // We need this to be exactly 256 entries long.
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                int i;
                for (i = 0; i < palette.Entries.Count && i < 256; ++i)
                {
                    colorTableArray[i] = palette.Entries[i].Rgb32Value;
                }
                for (int j = i; j < 256; ++j)
                {
                    colorTableArray[j] = new Rgb32Value((byte)j, (byte)j, (byte)j);
                }
                Utilities.ThrowError(VisionDllCommon.imaqWriteBMPFile(_image, fileName, compress ? 1 : 0, colorTableArray));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteBMPFile(_image, fileName, compress ? 1 : 0, IntPtr.Zero));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Writes an image to a file in JPEG format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <remarks>
        /// Use this method with U8 and Rgb32 images. This method uses lossy compression even if you set the quality to 1,000.
        /// </remarks>

        public void WriteJpegFile(string fileName)
        {
            WriteJpegFile(fileName, 750);
        }
        //==========================================================================================
        /// <summary>
        /// Writes an image to a file in JPEG format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="quality">
        /// The quality of the image to write. As quality increases, the method uses less lossy compression. Acceptable values range from 0 to 1,000. The default value is 750.</param>
        /// <remarks>
        /// Use this method with U8 and Rgb32 images. This method uses lossy compression even if you set the quality to 1,000.</remarks>

        [CLSCompliant(false)]
        public void WriteJpegFile(string fileName, UInt32 quality)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            Utilities.ThrowError(VisionDllCommon.imaqWriteJPEGFile(_image, fileName, quality, IntPtr.Zero));
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in JPEG2000 format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <remarks>
        /// Use this method with U8, I16, U16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteJpeg2000File(string fileName)
        {
            WriteJpeg2000File(fileName, true, 50, new Jpeg2000AdvancedOptions(), null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in JPEG2000 format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="lossless">
        ///     <see langword="true"/> to write the JPEG2000 file without loss of information; otherwise, <see langword="false"/>. The default value is <see langword="true"/>.
        /// </param>
        /// <remarks>
        /// Use this method with U8, I16, U16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteJpeg2000File(string fileName, bool lossless)
        {
            WriteJpeg2000File(fileName, lossless, 50, new Jpeg2000AdvancedOptions(), null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in JPEG2000 format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="lossless">
        ///     <see langword="true"/> to write the JPEG2000 file without loss of information; otherwise, <see langword="false"/>. The default value is <see langword="true"/>.
        /// </param>
        /// <param name="compressionRatio">
        /// The degree to which to compress the JPEG2000 file. For example, a <paramref name="compressionRatio"/> of 50 means that the resulting JPEG2000 file will be 50 times smaller than the size of the image in memory. This parameter is ignored if <paramref name="lossless"/> is <see langword="true"/>. This parameter has a default value of 50.
        /// </param>
        /// <remarks>
        /// Use this method with U8, I16, U16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteJpeg2000File(string fileName, bool lossless, double compressionRatio)
        {
            WriteJpeg2000File(fileName, lossless, compressionRatio, new Jpeg2000AdvancedOptions(), null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in JPEG2000 format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="lossless">
        ///     <see langword="true"/> to write the JPEG2000 file without loss of information; otherwise, <see langword="false"/>. The default value is <see langword="true"/>.
        /// </param>
        /// <param name="compressionRatio">
        /// The degree to which to compress the JPEG2000 file. For example, a <paramref name="compressionRatio"/> of 50 means that the resulting JPEG2000 file will be 50 times smaller than the size of the image in memory. This parameter is ignored if <paramref name="lossless"/> is <see langword="true"/>. This parameter has a default value of 50.
        /// </param>
        /// <param name="advancedOptions">
        /// Advanced options to use when writing this file.
        /// </param>
        /// <remarks>
        /// Use this method with U8, I16, U16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteJpeg2000File(string fileName, bool lossless, double compressionRatio, Jpeg2000AdvancedOptions advancedOptions)
        {
            WriteJpeg2000File(fileName, lossless, compressionRatio, advancedOptions, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in JPEG2000 format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="lossless">
        ///     <see langword="true"/> to write the JPEG2000 file without loss of information; otherwise, <see langword="false"/>. The default value is <see langword="true"/>.
        /// </param>
        /// <param name="compressionRatio">
        /// The degree to which to compress the JPEG2000 file. For example, a <paramref name="compressionRatio"/> of 50 means that the resulting JPEG2000 file will be 50 times smaller than the size of the image in memory. This parameter is ignored if <paramref name="lossless"/> is <see langword="true"/>. This parameter has a default value of 50.
        /// </param>
        /// <param name="advancedOptions">
        /// Advanced options to use when writing this file.
        /// </param>
        /// <param name="palette">
        /// The palette to associate with U8 images. The default is a grayscale palette.
        /// </param>
        /// <remarks>
        /// Use this method with U8, I16, U16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteJpeg2000File(string fileName, bool lossless, double compressionRatio, Jpeg2000AdvancedOptions advancedOptions, Palette palette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (advancedOptions == null) { throw new ArgumentNullException("advancedOptions"); }
            CVI_JPEG2000FileAdvancedOptions cviAdvancedOptions = new CVI_JPEG2000FileAdvancedOptions();
            cviAdvancedOptions.ConvertFromExternal(advancedOptions);
            if (palette != null)
            {
                // We need this to be exactly 256 entries long.
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                int i;
                for (i = 0; i < palette.Entries.Count && i < 256; ++i)
                {
                    colorTableArray[i] = palette.Entries[i].Rgb32Value;
                }
                for (int j = i; j < 256; ++j)
                {
                    colorTableArray[j] = new Rgb32Value((byte)j, (byte)j, (byte)j);
                }
                Utilities.ThrowError(VisionDllCommon.imaqWriteJPEG2000File(_image, fileName, lossless ? 1 : 0, (float)compressionRatio, ref cviAdvancedOptions, colorTableArray));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteJPEG2000File(_image, fileName, lossless ? 1 : 0, (float)compressionRatio, ref cviAdvancedOptions, IntPtr.Zero));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in PNG format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images. PNG format always stores images in a lossless manner.
        /// </remarks>

        public void WritePngFile(string fileName)
        {
            WritePngFile(fileName, 750, false, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in PNG format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="compressionSpeed">
        /// The compression speed to use. Acceptable values range from 0 to 1,000. The default value is 750.
        /// </param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images. PNG format always stores images in a lossless manner.
        /// </remarks>

        [CLSCompliant(false)]
        public void WritePngFile(string fileName, UInt32 compressionSpeed)
        {
            WritePngFile(fileName, compressionSpeed, false, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in PNG format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="compressionSpeed">
        /// The compression speed to use. Acceptable values range from 0 to 1,000. The default value is 750.
        /// </param>
        /// <param name="useBitDepth">
        ///     <see langword="true"/> if the bit depth is written with the image; otherwise, <see langword="false"/>. This parameter has an effect only when writing U16, I16, or RgbU64 images. The default is <see langword="false"/>.
        /// </param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images. PNG format always stores images in a lossless manner.
        /// </remarks>

        [CLSCompliant(false)]
        public void WritePngFile(string fileName, UInt32 compressionSpeed, bool useBitDepth)
        {
            WritePngFile(fileName, compressionSpeed, useBitDepth, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image to a file in PNG format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="compressionSpeed">
        /// The compression speed to use. Acceptable values range from 0 to 1,000. The default value is 750.
        /// </param>
        /// <param name="useBitDepth">
        ///     <see langword="true"/> if the bit depth is written with the image; otherwise, <see langword="false"/>. This parameter has an effect only when writing U16, I16, or RgbU64 images. The default is <see langword="false"/>.
        /// </param>
        /// <param name="palette">
        /// The palette to associate with U8 images. The default is a grayscale palette.</param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images. PNG format always stores images in a lossless manner.
        /// </remarks>

        [CLSCompliant(false)]
        public void WritePngFile(string fileName, UInt32 compressionSpeed, bool useBitDepth, Palette palette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (palette != null)
            {
                // We need this to be exactly 256 entries long.
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                int i;
                for (i = 0; i < palette.Entries.Count && i < 256; ++i)
                {
                    colorTableArray[i] = palette.Entries[i].Rgb32Value;
                }
                for (int j = i; j < 256; ++j)
                {
                    colorTableArray[j] = new Rgb32Value((byte)j, (byte)j, (byte)j);
                }
                Utilities.ThrowError(VisionDllCommon.imaqWritePNGFile2(_image, fileName, compressionSpeed, colorTableArray, useBitDepth ? 1 : 0));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWritePNGFile2(_image, fileName, compressionSpeed, IntPtr.Zero, useBitDepth ? 1 : 0));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Writes an image to file in TIFF format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteTiffFile(string fileName)
        {
            WriteTiffFile(fileName, new TiffOptions(), null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes an image to file in TIFF format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="options">
        /// The options to use when writing the file.</param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteTiffFile(string fileName, TiffOptions options)
        {
            WriteTiffFile(fileName, options, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes an image to file in TIFF format.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="options">
        /// The options to use when writing the file.</param>
        /// <param name="palette">
        /// The palette to associate with U8 images. The default is a grayscale palette.
        /// </param>
        /// <remarks>
        /// Use this method with U8, U16, I16, Rgb32, and RgbU64 images.
        /// </remarks>

        public void WriteTiffFile(string fileName, TiffOptions options, Palette palette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (options == null) { throw new ArgumentNullException("options"); }
            CVI_TIFFFileOptions cviOptions = new CVI_TIFFFileOptions();
            cviOptions.ConvertFromExternal(options);
            if (palette != null)
            {
                // We need this to be exactly 256 entries long.
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                int i;
                for (i = 0; i < palette.Entries.Count && i < 256; ++i)
                {
                    colorTableArray[i] = palette.Entries[i].Rgb32Value;
                }
                for (int j = i; j < 256; ++j)
                {
                    colorTableArray[j] = new Rgb32Value((byte)j, (byte)j, (byte)j);
                }
                Utilities.ThrowError(VisionDllCommon.imaqWriteTIFFFile(_image, fileName, ref cviOptions, colorTableArray));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteTIFFFile(_image, fileName, ref cviOptions, IntPtr.Zero));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image, along with extra vision information associated with the image, to a PNG file. This extra vision information includes overlay, pattern matching template, calibration information, and custom data.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>

        public void WriteVisionFile(string fileName)
        {
            WriteVisionFile(fileName, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes this image, along with extra vision information associated with the image, to a PNG file. This extra vision information includes overlay, pattern matching template, calibration information, and custom data.
        /// </summary>
        /// <param name="fileName">
        /// The path of the file to write.</param>
        /// <param name="palette">
        /// The palette to associate with U8 images. The default is a grayscale palette.
        /// </param>

        public unsafe void WriteVisionFile(string fileName, Palette palette)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (palette != null)
            {
                // We need this to be exactly 256 entries long.
                Rgb32Value[] colorTableArray = new Rgb32Value[256];
                int i;
                for (i = 0; i < palette.Entries.Count && i < 256; ++i)
                {
                    colorTableArray[i] = palette.Entries[i].Rgb32Value;
                }
                for (int j = i; j < 256; ++j)
                {
                    colorTableArray[j] = new Rgb32Value((byte)j, (byte)j, (byte)j);
                }
                Utilities.ThrowError(VisionDllCommon.imaqWriteVisionFile(_image, fileName, colorTableArray));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteVisionFile(_image, fileName, IntPtr.Zero));
            }
        }

        //==========================================================================================
        /// <summary>
        /// Sets each pixel in the image to a specified value.</summary>
        /// <param name="value">
        /// The value the method uses to fill the image pixels.  This <paramref name="value"/> must be of the same type as this <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/>.
        /// </param>

        public void FillImage(PixelValue value)
        {
            FillImage(value, null);
        }
        //==========================================================================================
        /// <summary>
        /// Sets each pixel in the image to a specified value.</summary>
        /// <param name="value">
        /// The value the method uses to fill the image pixels.  This <paramref name="value"/> must be of the same type as this <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/>.
        /// </param>
        /// <param name="mask">
        /// The method processes only those pixels in the image whose corresponding pixels in the mask are non-zero.  Set this parameter to <see langword="null"/> if you want to fill the entire image with pixel values.</param>

        public void FillImage(PixelValue value, VisionImage mask)
        {
            ThrowIfDisposed();
            ThrowIfNonNullAndDisposed(mask);
            ThrowIfWrongType(value);
            CVI_PixValue cviVal = value.CVI_PixValue;
            Utilities.ThrowError(VisionDllCommon.imaqFillImage(_image, cviVal, GetIntPtr(mask)));
        }

        //==========================================================================================
        /// <summary>
        /// Reads a pixel value from an image.</summary>
        /// <param name="point">
        /// The coordinate of the pixel to read.</param>
        /// <returns>
        /// The pixel value.</returns>

        public PixelValue GetPixel(PointContour point)
        {
            ThrowIfDisposed();
            if (point == null) { throw new ArgumentNullException("point"); }
            CVI_Point cviPoint = new CVI_Point();
            cviPoint.ConvertFromExternal(point);
            CVI_PixValue value = new CVI_PixValue();
            Utilities.ThrowError(VisionDllCommon.imaqGetPixel(_image, cviPoint, ref value));
            return new PixelValue(value, Type);
        }

        //==========================================================================================
        /// <summary>
        /// Reads a pixel value from an image.
        /// </summary>
        /// <param name="roi">
        /// The coordinate of the pixel to read. This Roi must contain exactly one <see cref="NationalInstruments.Vision.PointContour" crefType="Unqualified"/>.
        /// </param>
        /// <returns>
        /// The pixel value.
        /// </returns>

        public PixelValue GetPixel(Roi roi)
        {
            if (roi == null) { throw new ArgumentNullException("roi"); }
            Utilities.ThrowIfNotSinglePoint(roi);
            return GetPixel((PointContour)roi[0].Shape);
        }

        //==========================================================================================
        /// <summary>
        /// Changes a pixel value in an image.
        /// </summary>
        /// <param name="point">
        /// The coordinate of the pixel to set.</param>
        /// <param name="value">
        /// The pixel replacement value.
        /// </param>

        public void SetPixel(PointContour point, PixelValue value)
        {
            ThrowIfDisposed();
            if (point == null) { throw new ArgumentNullException("point"); }
            CVI_Point cviPoint = new CVI_Point();
            cviPoint.ConvertFromExternal(point);
            ThrowIfWrongType(value);
            Utilities.ThrowError(VisionDllCommon.imaqSetPixel(_image, cviPoint, value.CVI_PixValue));
        }

        //==========================================================================================
        /// <summary>
        /// Changes a pixel value in an image.
        /// </summary>
        /// <param name="roi">
        /// The coordinate of the pixel to set. This Roi must contain exactly one <see cref="NationalInstruments.Vision.PointContour" crefType="Unqualified"/>.</param>
        /// <param name="value">
        /// The pixel replacement value.
        /// </param>

        public void SetPixel(Roi roi, PixelValue value)
        {
            if (roi == null) { throw new ArgumentNullException("roi"); }
            Utilities.ThrowIfNotSinglePoint(roi);
            SetPixel((PointContour)roi[0].Shape, value);
        }

        //==========================================================================================
        /// <summary>
        /// Returns calibration information associated with the image.
        /// </summary>
        /// <returns>
        /// The calibration information associated with the image.
        /// </returns>

        public CalibrationInfo GetCalibrationInfo()
        {
            return GetCalibrationInfo(true);
        }
        //==========================================================================================
        /// <summary>
        /// Returns calibration information associated with the image.
        /// </summary>
        /// <param name="isGetErrorMap">Set it to true if the Error map is also required in
        /// the result.
        /// <returns>
        /// The calibration information associated with the image.
        /// </returns>

        public CalibrationInfo GetCalibrationInfo(bool isGetErrorMap)
        {
            ThrowIfDisposed();
            UInt32 _isGetErrorMap = (UInt32)(isGetErrorMap ? 1 : 0);
            IntPtr infoPtr = VisionDllCommon.imaqGetCalibrationInfo3(_image, _isGetErrorMap);
            Utilities.ThrowError(infoPtr);
            return Utilities.ConvertIntPtrToStructure<CalibrationInfo, CVI_CalibrationInfo>(infoPtr, true);
        }
        //==========================================================================================
        /// <summary>
        /// Gets the custom user data associated with this image.
        /// </summary>
        /// <value>
        /// The custom user data associated with this image.
        /// </value>
        /// <remarks>
        /// Use the <see cref="NationalInstruments.Vision.VisionImage.SetSize" crefType="Unqualified"/> method to change the size of the image.
        /// </remarks>

        public CustomDataDictionary CustomData
        {
            get
            {
                return _customData;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the overlay groups associated with this image.</summary>
        /// <value>
        /// The overlay groups associated with this image.
        /// </value>
        /// <remarks>
        ///  Use <see cref="NationalInstruments.Vision.Overlays.Default" crefType="Unqualified"/> to access the default overlay group.
        /// </remarks>

        public Overlays Overlays
        {
            get
            {
                return _overlays;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Populates a SerializationInfo with the data needed to serialize the target object. </summary>
        /// <param name="info">
        /// The SerializationInfo to populate with data. </param>
        /// <param name="context">
        /// The destination (see StreamingContext) for this serialization. 
        /// </param>

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            ThrowIfDisposed();
            byte[] flattenData = Flatten();
            info.AddValue("flattenedData", flattenData);
        }

        //==========================================================================================
        /// <summary>
        /// Flattens an image and stores its data.
        /// </summary>
        /// <returns>
        /// The flattened representation of the image.
        /// </returns>

        public byte[] Flatten()
        {
            return Flatten(FlattenType.ImageAndVisionInfo, CompressionType.None, 750);
        }
        //==========================================================================================
        /// <summary>
        /// Flattens an image and stores its data.
        /// </summary>
        /// <param name="type">
        /// </param>
        /// <returns>
        /// The flattened representation of the image.
        /// </returns>

        public byte[] Flatten(FlattenType type)
        {
            return Flatten(type, CompressionType.None, 750);
        }
        //==========================================================================================
        /// <summary>
        /// Flattens an image and stores its data.
        /// </summary>
        /// <param name="type">
        /// The parts of the image to flatten.  The default is <see cref="NationalInstruments.Vision.FlattenType.ImageAndVisionInfo" crefType="Unqualified"/>.
        /// </param>
        /// <param name="compression">
        /// The type of compression to use on the image pixel data.  The default is <see cref="NationalInstruments.Vision.CompressionType.None" crefType="Unqualified"/>.
        /// </param>
        /// <returns>
        /// The flattened representation of the image.
        /// </returns>

        public byte[] Flatten(FlattenType type, CompressionType compression)
        {
            return Flatten(type, compression, 750);
        }
        //==========================================================================================
        /// <summary>
        /// Flattens an image and stores its data.
        /// </summary>
        /// <param name="type">
        /// The parts of the image to flatten.  The default is <see cref="NationalInstruments.Vision.FlattenType.ImageAndVisionInfo" crefType="Unqualified"/>.
        /// </param>
        /// <param name="compression">
        /// The type of compression to use on the image pixel data.  The default is <see cref="NationalInstruments.Vision.CompressionType.None" crefType="Unqualified"/>.
        /// </param>
        /// <param name="quality">
        /// The quality of the compressed image pixel data.  Values range from 0 to 1000.  The default is 750.
        /// </param>
        /// <returns>
        /// The flattened representation of the image.
        /// </returns>

        public byte[] Flatten(FlattenType type, CompressionType compression, Int32 quality)
        {
            ThrowIfDisposed();
            UInt32 size;
            IntPtr resultPtr = VisionDllCommon.imaqFlatten(_image, (Int32)type, (Int32)compression, quality, out size);
            Utilities.ThrowError(resultPtr);
            byte[] result = new byte[size];
            Marshal.Copy(resultPtr, result, 0, (Int32)size);
            VisionDllCommon.imaqDispose(resultPtr);
            return result;
        }
        //==========================================================================================
        /// <summary>
        /// Takes the data returned from <see cref="NationalInstruments.Vision.VisionImage.Flatten" crefType="Unqualified"/> and stores it in an image.
        /// </summary>
        /// <param name="data">
        /// The data returned from <see cref="NationalInstruments.Vision.VisionImage.Flatten" crefType="Unqualified"/>.
        /// </param>
        /// <remarks>
        /// This method changes the type of this image to match the type in <paramref name="data"/>.
        /// </remarks>

        public void Unflatten(byte[] data)
        {
            ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqUnflatten(_image, data, (UInt32)data.Length));
        }

        //==========================================================================================
        /// <summary>
        /// Modifies the border of an image.</summary>
        /// <param name="method">
        /// The method used to fill the border of the image.</param>

        public void BorderOperation(BorderMethod method)
        {
            ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqFillBorder(_image, method));
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "VisionImage: Type=" + Type.ToString() + ", Width=" + Width.ToString(CultureInfo.CurrentCulture) + ", Height=" + Height.ToString(CultureInfo.CurrentCulture);
        }
        #region IDisposable Members

        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/>.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

private void Dispose(bool disposing) {
            // Since _image is unmanaged, it's OK to access it here (even though we may be
            // called during finalization if disposing == false)
            // Remove it from our map.
            lock (_disposeLock)
            {
                lock(rawImageToImage) 
                {
                if (rawImageToImage.ContainsKey(_image))
                {
                    rawImageToImage.Remove(_image);
                    }
                }
                if (_image != IntPtr.Zero)
                {
                    Utilities.ThrowError(VisionDllCommon.imaqDispose(_image));
                    _image = IntPtr.Zero;
                }
                if (disposing)
                {
                    // Notify the viewers that we've been disposed.
                    // We do this after our image has been disposed so the
                    // viewers will update correctly.
                    foreach (ImageViewer viewer in _viewers)
                    {
                        viewer.OnImageChange();
                    }
                    _viewers.Clear();
                }
            }
        }

~VisionImage()
        {
            Dispose(false);
        }
        #endregion
    }

    //==============================================================================================
    /// <summary>
    /// Represents the set of all overlay groups on a <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/>.</summary>
    /// <remarks>
    /// </remarks>

    public sealed class Overlays
    {
        private VisionImage _image = null;
        private Dictionary<string, Overlay> _overlays = new Dictionary<string, Overlay>();
        private Overlay _defaultOverlay;

        
        internal Overlays(VisionImage image, bool calledFromConstructor)
        {
            _image = image;
            _defaultOverlay = new Overlay(_image, null, calledFromConstructor);
        }
        //==========================================================================================
        /// <summary>
        /// Gets the default overlay group.
        /// </summary>
        /// <value>
        /// </value>

        public Overlay Default
        {
            get { return _defaultOverlay; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the overlay group specified by the given name.</summary>
        /// <value>
        /// </value>

        public Overlay this[string name]
        {
            get
            {
                if (!_overlays.ContainsKey(name))
                {
                    // Create a new overlay of that name.
                    _overlays[name] = new Overlay(_image, name, false);
                }
                return _overlays[name];
            }
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Overlays";
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides methods that draw shapes onto the overlay. These shapes are displayed on top of a <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/>.
    /// </summary>
    /// <remarks>
    /// Overlays do not modify the actual image pixels and are deleted when the image is resized. To save overlay information along with an image, use <see cref="NationalInstruments.Vision.VisionImage.WriteVisionFile" crefType="Unqualified"/>.
    /// </remarks>

    public sealed class Overlay
    {
        private string _name = null;
        private Rgb32Value _defaultColor = Rgb32Value.GreenColor;
        private VisionImage _image = null;
        private TransformBehaviors _transformBehaviors = null;

        
        internal Overlay(VisionImage image, string name, bool calledFromConstructor)
        {
            _image = image;
            _name = name;
            _transformBehaviors = new TransformBehaviors();
            _transformBehaviors.PropertyChanged += _transformBehaviors_PropertyChanged;
            // If we were called from the constructor, our transform behaviors must be the defaults,
            // so don't try to update them.
            if (!calledFromConstructor)
            {
                UpdateTransformBehaviors();
            }
        }
        //==========================================================================================
        /// <summary>Gets the name of the overlay group.
        /// </summary>
        /// <value>
        /// </value>

        public string Name
        {
            get { return _name; }
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Overlay: Name=" + _name + ", DefaultColor=" + _defaultColor.ToString();
        }

private void _transformBehaviors_PropertyChanged(object sender, EventArgs e)
        {
            _image.ThrowIfDisposed();
            CVI_TransformBehaviors cviBehaviors = new CVI_TransformBehaviors();
            cviBehaviors.ConvertFromExternal(_transformBehaviors);
            Utilities.ThrowError(VisionDllCommon.imaqSetOverlayProperties(_image._image, _name, ref cviBehaviors));
        }

        
        private void UpdateTransformBehaviors()
        {
            // Update from the DLL
            _image.ThrowIfDisposed();
            CVI_TransformBehaviors cviBehaviors = new CVI_TransformBehaviors();
            try
            {
                Utilities.ThrowError(VisionDllCommon.imaqGetOverlayProperties(_image._image, _name, out cviBehaviors));
            }
            catch (VisionException ex)
            {
                // If no such overlay group exists, then we can just create a new _transformBehaviors.
                // Otherwise, propagate the error.
                if (ex.VisionErrorCode != ErrorCode.OverlayGroupNotFound)
                {
                    throw;
                }
                // Remove the handler from the existing transform behaviors and add to the new one
                _transformBehaviors.PropertyChanged -= _transformBehaviors_PropertyChanged;
                _transformBehaviors = new TransformBehaviors();
                _transformBehaviors.PropertyChanged += _transformBehaviors_PropertyChanged;
                return;
            }
            // Remove the handler from the existing transform behaviors and add to the new one
            _transformBehaviors.PropertyChanged -= _transformBehaviors_PropertyChanged;
            _transformBehaviors = cviBehaviors.ConvertToExternal();
            _transformBehaviors.PropertyChanged += _transformBehaviors_PropertyChanged;
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the transformation behavior information for this overlay group.
        /// </summary>
        /// <value>
        /// </value>

        public TransformBehaviors TransformBehaviors
        {
            get
            {
                return _transformBehaviors;
            }
            set
            {
                _image.ThrowIfDisposed();
                // Remove the handler from the existing transform behaviors and add to the new one
                _transformBehaviors.PropertyChanged -= _transformBehaviors_PropertyChanged;
                _transformBehaviors = value;
                _transformBehaviors.PropertyChanged += _transformBehaviors_PropertyChanged;
                // Update the transform behaviors in the DLL.
                _transformBehaviors_PropertyChanged(this, EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the default color for the overlay object.
        /// </summary>
        /// <value>
        /// The default value is <see cref="NationalInstruments.Vision.Rgb32Value.GreenColor" crefType="PartiallyQualified"/>.
        /// </value>

        public Rgb32Value DefaultColor
        {
            get
            {
                return _defaultColor;
            }
            set
            {
                _defaultColor = value;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a line onto an image. 
        /// </summary>
        /// <param name="line">
        /// The location of the line.
        /// </param>

        public void AddLine(LineContour line)
        {
            AddLine(line, _defaultColor);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a line onto an image with the specified line and color. 
        /// </summary>
        /// <param name="line">
        /// The location of the line.
        /// </param>
        /// <param name="color">
        /// The color of the line. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>

        public void AddLine(LineContour line, Rgb32Value color)
        {
            _image.ThrowIfDisposed();
            if (line == null) { throw new ArgumentNullException("line"); }
            CVI_Point cviStart = new CVI_Point();
            CVI_Point cviEnd = new CVI_Point();
            cviStart.ConvertFromExternal(line.Start);
            cviEnd.ConvertFromExternal(line.End);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayLine(_image._image, cviStart, cviEnd, ref color, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Overlays an arc onto an image with the specified arc. 
        /// </summary>
        /// <param name="arc">
        /// The location and size of the arc. 
        /// </param>

        public void AddArc(Arc arc)
        {
            AddArc(arc, _defaultColor, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays an arc onto an image with the specified arc and color. 
        /// </summary>
        /// <param name="arc">
        /// The location and size of the arc. 
        /// </param>
        /// <param name="color">
        /// The color of the arc. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>

        public void AddArc(Arc arc, Rgb32Value color)
        {
            AddArc(arc, color, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays an arc onto an image with the specified arc, color, and <see cref="NationalInstruments.Vision.DrawingMode" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="arc">
        /// The location and size of the arc. 
        /// </param>
        /// <param name="color">
        /// The color of the arc. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>
        /// <param name="drawMode">
        /// The mode by which to draw the overlay. Valid options are <see cref="NationalInstruments.Vision.DrawingMode.DrawValue" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.DrawingMode.PaintValue" crefType="Unqualified"/>. 
        /// </param>

        public void AddArc(Arc arc, Rgb32Value color, DrawingMode drawMode)
        {
            _image.ThrowIfDisposed();
            if (arc == null) { throw new ArgumentNullException("arc"); }
            CVI_ArcInfo cviArc = new CVI_ArcInfo();
            cviArc.ConvertFromExternal(arc);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayArc(_image._image, ref cviArc, ref color, (Int32)drawMode, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a rectangle onto an image with the specified coordinate location. 
        /// </summary>
        /// <param name="rect">
        /// The coordinate location of the rectangle. 
        /// </param>

        public void AddRectangle(RectangleContour rect)
        {
            AddRectangle(rect, _defaultColor, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a rectangle onto an image with the specified coordinate location and color.  
        /// </summary>
        /// <param name="rect">
        /// The coordinate location of the rectangle. 
        /// </param>
        /// <param name="color">
        /// The color of the rectangle. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>

        public void AddRectangle(RectangleContour rect, Rgb32Value color)
        {
            AddRectangle(rect, color, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a rectangle onto an image with the specified coordinate location, color, and drawing mode.  
        /// </summary>
        /// <param name="rect">
        /// The coordinate location of the rectangle. 
        /// </param>
        /// <param name="color">
        /// The color of the rectangle. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>
        /// <param name="drawMode">
        /// The mode by which to draw the overlay. Valid modes are <see cref="NationalInstruments.Vision.DrawingMode.DrawValue" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.DrawingMode.PaintValue" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.DrawingMode.HighlightValue" crefType="Unqualified"/>.
        /// </param>

        public void AddRectangle(RectangleContour rect, Rgb32Value color, DrawingMode drawMode)
        {
            _image.ThrowIfDisposed();
            if (rect == null) { throw new ArgumentNullException("rect"); }
            CVI_Rectangle cviRect = new CVI_Rectangle();
            cviRect.ConvertFromExternal(rect);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayRect(_image._image, cviRect, ref color, (Int32)drawMode, _name));
        }
        //==========================================================================================
        /// <summary>Overlays an oval onto an image. 
        /// </summary>
        /// <param name="oval">
        /// The location of the oval.
        /// </param>

        public void AddOval(OvalContour oval)
        {
            AddOval(oval, _defaultColor, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays an oval onto an image with the specified oval and color. 
        /// </summary>
        /// <param name="oval">
        /// The location of the oval.
        /// </param>
        /// <param name="color">
        /// The color of the oval. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>

        public void AddOval(OvalContour oval, Rgb32Value color)
        {
            AddOval(oval, color, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays an oval onto an image with the specified oval and color. 
        /// </summary>
        /// <param name="oval">
        /// The location of the oval.
        /// </param>
        /// <param name="color">
        /// The color of the oval. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>
        /// <param name="drawMode">
        /// The mode by which to draw the overlay. Valid options are <see cref="NationalInstruments.Vision.DrawingMode.DrawValue" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.DrawingMode.PaintValue" crefType="Unqualified"/>.  
        /// </param>

        public void AddOval(OvalContour oval, Rgb32Value color, DrawingMode drawMode)
        {
            _image.ThrowIfDisposed();
            if (oval == null) { throw new ArgumentNullException("oval"); }
            CVI_Rectangle cviRect = new CVI_Rectangle();
            cviRect.ConvertFromExternal(oval);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayOval(_image._image, cviRect, ref color, (Int32)drawMode, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a bitmap onto an image with the specified bitmap and origin. 
        /// </summary>
        /// <param name="bitmap">
        /// The two-dimensional array of bitmap values to overlay on the image.
        /// </param>
        /// <param name="origin">
        /// The top-left corner of where the bitmap will be drawn.</param>

        public void AddBitmap(System.Drawing.Bitmap bitmap, PointContour origin)
        {
            if (bitmap == null) { throw new ArgumentNullException("bitmap"); }
            AddBitmap(bitmap, origin, bitmap.Width, bitmap.Height);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a bitmap onto an image with the specified bitmap, origin, width, and height. 
        /// </summary>
        /// <param name="bitmap">
        /// The two-dimensional array of bitmap values to overlay on the image.
        /// </param>
        /// <param name="origin">
        /// The top-left corner of where the bitmap will be drawn.
        /// </param>
        /// <param name="width">
        /// The width of the bitmap.
        /// </param>
        /// <param name="height">
        /// The height of the bitmap.
        /// </param>

        public void AddBitmap(System.Drawing.Bitmap bitmap, PointContour origin, Int32 width, Int32 height)
        {
            if (bitmap == null) { throw new ArgumentNullException("bitmap"); }
            if (origin == null) { throw new ArgumentNullException("origin"); }
            _image.ThrowIfDisposed();
            System.Drawing.Imaging.BitmapData bd = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try {
                int rowSizeBytes = bd.Width * 4;
                byte[] rgbBytes = new byte[bd.Height * rowSizeBytes];
                byte[] rowBuffer = new byte[rowSizeBytes];
                int rgbOffset = 0;
                IntPtr scanLinePtr = bd.Scan0;
                for (int i = 0; i < bd.Height; ++i)
                {
                    // Copy the row into the buffer, and copy that into the rgbBytes.
                    Marshal.Copy(scanLinePtr, rowBuffer, 0, rowSizeBytes);
                    // We'd like to block copy here, but we need to set the alpha to 0.
                    for (int j = 0; j < bd.Width; ++j)
                    {
                        rgbBytes[rgbOffset + j * 4] = rowBuffer[j * 4];
                        rgbBytes[rgbOffset + j * 4 + 1] = rowBuffer[j * 4 + 1];
                        rgbBytes[rgbOffset + j * 4 + 2] = rowBuffer[j * 4 + 2];
                        // Microsoft's version of alpha is 0 means transparent, 0xFF means opaque
                        // Our version of alpha is the opposite - 0 is opaque and 0xFF is transparent.
                        rgbBytes[rgbOffset + j * 4 + 3] = (byte)((byte)255 - rowBuffer[j * 4 + 3]);
                    }
                    rgbOffset += rowSizeBytes;
                    scanLinePtr = Utilities.AdvanceIntPtr(scanLinePtr, bd.Stride);
                }
                CVI_Point cviPoint = new CVI_Point();
                cviPoint.ConvertFromExternal(origin);
                Utilities.ThrowError(VisionDllCommon.imaqOverlayBitmap(_image._image, cviPoint, rgbBytes, (UInt32)bd.Width, (UInt32)bd.Height, _name));
            } finally {
                bitmap.UnlockBits(bd);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a metafile onto an image. 
        /// </summary>
        /// <param name="metafile">
        /// The Windows handle to the metafile that you want to convert into an overlay. 
        /// </param>

        public void AddMetafile(System.Drawing.Imaging.Metafile metafile)
        {
            AddMetafile(metafile, RectangleContour.None);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a metafile onto an image with the specified metafile and rectangle. 
        /// </summary>
        /// <param name="metafile">
        /// The Windows handle to the metafile that you want to convert into an overlay. 
        /// </param>
        /// <param name="rect">
        /// The location of rectangular region within the image that the function overlays the metafile. To use the bounding rectangle information stored in the metafile, set this parameter to <see cref="NationalInstruments.Vision.RectangleContour.None" crefType="Unqualified"/>.  
        /// </param>

        public void AddMetafile(System.Drawing.Imaging.Metafile metafile, RectangleContour rect)
        {
            _image.ThrowIfDisposed();
            if (metafile == null) { throw new ArgumentNullException("metafile"); }
            if (rect == null) { throw new ArgumentNullException("rect"); }
            CVI_Rectangle cviRect = new CVI_Rectangle();
            cviRect.ConvertFromExternal(rect);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayMetafile(_image._image, metafile.GetHenhmetafile(), cviRect, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a string of text onto an image with the specified text and coordinate location. 
        /// </summary>
        /// <param name="text">
        /// The text that the method overlays. 
        /// </param>
        /// <param name="origin">
        /// The coordinate location of the text reference point. 
        /// </param>

        public void AddText(string text, PointContour origin)
        {
            AddText(text, origin, _defaultColor, new OverlayTextOptions());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a string of text onto an image  with the specified text, coordinate location, and color.  
        /// </summary>
        /// <param name="text">
        /// The text that the method overlays. 
        /// </param>
        /// <param name="origin">
        /// The coordinate location of the text reference point. 
        /// </param>
        /// <param name="color">
        /// The color of the text. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>

        public void AddText(string text, PointContour origin, Rgb32Value color)
        {
            AddText(text, origin, color, new OverlayTextOptions());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a string of text onto an image with the specified text, coordinate location, color, and text style. 
        /// </summary>
        /// <param name="text">
        /// The text that the method overlays. 
        /// </param>
        /// <param name="origin">
        /// The coordinate location of the text reference point. 
        /// </param>
        /// <param name="color">
        /// The color of the text. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black. 
        /// </param>
        /// <param name="options">
        /// The <see cref="NationalInstruments.Vision.OverlayTextOptions" crefType="Unqualified"/> that the method uses to overlay text. 
        /// </param>

        public void AddText(string text, PointContour origin, Rgb32Value color, OverlayTextOptions options)
        {
            _image.ThrowIfDisposed();
            if (text == null) { throw new ArgumentNullException("text"); }
            if (origin == null) { throw new ArgumentNullException("origin"); }
            if (options == null) { throw new ArgumentNullException("options"); }
            CVI_Point cviOrigin = new CVI_Point();
            cviOrigin.ConvertFromExternal(origin);
            CVI_OverlayTextOptions cviOptions = new CVI_OverlayTextOptions();
            cviOptions.ConvertFromExternal(options);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayText(_image._image, cviOrigin, text, ref color, ref cviOptions, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a point onto an image. 
        /// </summary>
        /// <param name="point">
        /// The coordinate location of the point to overlay.
        /// </param>

        public void AddPoint(PointContour point)
        {
            AddPoint(point, _defaultColor, new PointSymbol());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a point onto an image. 
        /// </summary>
        /// <param name="point">
        /// The coordinate location of the point to overlay.
        /// </param>
        /// <param name="color">
        /// The color of the point. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>

        public void AddPoint(PointContour point, Rgb32Value color)
        {
            AddPoint(point, color, new PointSymbol());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a point onto an image. 
        /// </summary>
        /// <param name="point">
        /// The coordinate location of the point to overlay.
        /// </param>
        /// <param name="color">
        /// The color of the point. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>
        /// <param name="symbol">
        /// The symbol the method uses to represent the point. 
        /// </param>

        public void AddPoint(PointContour point, Rgb32Value color, PointSymbol symbol)
        {
            AddPoints(new Collection<PointContour>(new PointContour[] { point }), color, symbol);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a series of points onto an image. 
        /// </summary>
        /// <param name="points">
        /// A collection describing the coordinate location of each point to overlay. 
        /// </param>

        public void AddPoints(Collection<PointContour> points)
        {
            AddPoints(points, _defaultColor, new PointSymbol());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a series of points onto an image. 
        /// </summary>
        /// <param name="points">
        /// A collection  describing the coordinate location of each point to overlay. 
        /// </param>
        /// <param name="color">
        /// "The color of the points to overlay. The alpha color channel is not supported. Setting the color to transparent has
        /// the same effect as selecting black.</param>

        public void AddPoints(Collection<PointContour> points, Rgb32Value color)
        {
            AddPoints(points, color, new PointSymbol());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a series of points onto an image. 
        /// </summary>
        /// <param name="points">
        /// A collection describing the coordinate location of each point to overlay. 
        /// </param>
        /// <param name="color">
        /// "The color of the points to overlay. The alpha color channel is not supported. Setting the color to transparent has
        /// the same effect as selecting black.</param>
        /// <param name="symbol">
        /// The symbol the method uses to represent each point. 
        /// </param>

        public void AddPoints(Collection<PointContour> points, Rgb32Value color, PointSymbol symbol)
        {
            _image.ThrowIfDisposed();
            if (points == null) { throw new ArgumentNullException("points"); }
            if (symbol == null) { throw new ArgumentNullException("symbol"); }
            CVI_Point[] cviPoints = Utilities.ConvertCollectionToArray<PointContour, CVI_Point>(points);
            Rgb32Value[] colors = {color};
            if (symbol.Type == PointSymbolType.UserDefined)
            {
                CVI_UserPointSymbol cviUserPointSymbol = new CVI_UserPointSymbol();
                cviUserPointSymbol.ConvertFromExternal(symbol);
                try
                {
                    Utilities.ThrowError(VisionDllCommon.imaqOverlayPoints(_image._image, cviPoints, cviPoints.Length, colors, colors.Length, symbol.Type, ref cviUserPointSymbol, _name));
                }
                finally
                {
                    cviUserPointSymbol.Dispose();
                }
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqOverlayPoints(_image._image, cviPoints, cviPoints.Length, colors, colors.Length, symbol.Type, IntPtr.Zero, _name));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a region of interest onto an image with the specified region. 
        /// </summary>
        /// <param name="roi">
        /// The region of interest to overlay on to the image. 
        /// </param>

        public void AddRoi(Roi roi)
        {
            AddRoi(roi, new PointSymbol());
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a region of interest onto an image with the specified region and symbol. 
        /// </summary>
        /// <param name="roi">
        /// The region of interest to overlay on to the image. 
        /// </param>
        /// <param name="symbol">
        /// The symbol to represent a point contour in the overlay. 
        /// </param>

        public void AddRoi(Roi roi, PointSymbol symbol)
        {
            _image.ThrowIfDisposed();
            if (roi == null) { throw new ArgumentNullException("roi"); }
            if (symbol == null) { throw new ArgumentNullException("symbol"); }
            if (symbol.Type == PointSymbolType.UserDefined)
            {
                CVI_UserPointSymbol cviUserPointSymbol = new CVI_UserPointSymbol();
                    cviUserPointSymbol.ConvertFromExternal(symbol);
                try
                {
                    Utilities.ThrowError(VisionDllCommon.imaqOverlayROI(_image._image, roi._roi, symbol.Type, ref cviUserPointSymbol, _name));
                }
                finally
                {
                    cviUserPointSymbol.Dispose();
                }

            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqOverlayROI(_image._image, roi._roi, symbol.Type, IntPtr.Zero, _name));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a polyline onto an image with the specified coordinate location.
        /// </summary>
        /// <param name="polyline">
        /// The coordinate location of the polyline.
        /// </param>

        public void AddPolyline(PolylineContour polyline)
        {
            AddPolyline(polyline, _defaultColor);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a polyline onto an image with the specified coordinate location and color.
        /// </summary>
        /// <param name="polyline">
        /// The coordinate location of the polyline.
        /// </param>
        /// <param name="color">
        /// The color of the polyline. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>

        public void AddPolyline(PolylineContour polyline, Rgb32Value color)
        {
            _image.ThrowIfDisposed();
            if (polyline == null) { throw new ArgumentNullException("polyline"); }
            CVI_Point[] cviPoints = Utilities.ConvertCollectionToArray<PointContour, CVI_Point>(polyline._points);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayOpenContour(_image._image, cviPoints, cviPoints.Length, ref color, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a polygon onto an image with the specified coordinate location.
        /// </summary>
        /// <param name="polygon">
        /// The coordinate location of the polygon.
        /// </param>

        public void AddPolygon(PolygonContour polygon)
        {
            AddPolygon(polygon, _defaultColor, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a polygon onto an image with the specified coordinate location and color.
        /// </summary>
        /// <param name="polygon">
        /// The coordinate location of the polygon.
        /// </param>
        /// <param name="color">
        /// The color of the polygon. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>

        public void AddPolygon(PolygonContour polygon, Rgb32Value color)
        {
            AddPolygon(polygon, color, DrawingMode.DrawValue);
        }
        //==========================================================================================
        /// <summary>
        /// Overlays a polygon onto an image with the specified coordinate location, color, and drawing mode.
        /// </summary>
        /// <param name="polygon">
        /// The coordinate location of the polygon.
        /// </param>
        /// <param name="color">
        /// The color of the polygon. The alpha color channel is not supported. Setting the <paramref name="color"/> to transparent has the same effect as selecting black.
        /// </param>
        /// <param name="drawMode">
        /// The mode by which to draw the overlay. Valid modes are <see cref="NationalInstruments.Vision.DrawingMode.DrawValue" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.DrawingMode.PaintValue" crefType="Unqualified"/>.
        /// </param>

        public void AddPolygon(PolygonContour polygon, Rgb32Value color, DrawingMode drawMode)
        {
            _image.ThrowIfDisposed();
            if (polygon == null) { throw new ArgumentNullException("polygon"); }
            CVI_Point[] cviPoints = Utilities.ConvertCollectionToArray<PointContour, CVI_Point>(polygon._points);
            Utilities.ThrowError(VisionDllCommon.imaqOverlayClosedContour(_image._image, cviPoints, cviPoints.Length, ref color, drawMode, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Removes all the shapes from this overlay group.
        /// </summary>

        public void Clear()
        {
            _image.ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqClearOverlay(_image._image, _name));
        }
        //==========================================================================================
        /// <summary>
        /// Makes this overlay part of the image to which it is attached, and removes the Overlay object.
        /// </summary>

        public void Merge()
        {
            Merge(new Palette());
        }
        //==========================================================================================
        /// <summary>
        /// Makes this overlay part of the image to which it is attached, and removes the Overlay object.
        /// </summary>
        /// <param name="palette">
        /// A palette to associate with 8-bit images.
        /// </param>

        public void Merge(Palette palette)
        {
            _image.ThrowIfDisposed();
            // The palette is only supported if the image is U8.
            if (_image.Type == ImageType.U8)
            {
                Rgb32Value[] colors = new Rgb32Value[palette.Entries.Count];
                for (int i = 0; i < palette.Entries.Count; ++i)
                {
                    colors[i] = palette.Entries[i].Rgb32Value;
                }
                Utilities.ThrowError(VisionDllCommon.imaqMergeOverlay(_image._image, _image._image, colors, (UInt32)colors.Length, _name));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqMergeOverlay(_image._image, _image._image, IntPtr.Zero, 0, _name));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Copies the shapes in this overlay group to another <see cref="NationalInstruments.Vision.VisionImage" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="destination">
        /// The image to copy the shapes to.</param>

        public void CopyTo(VisionImage destination)
        {
            _image.ThrowIfDisposed();
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            Utilities.ThrowError(VisionDllCommon.imaqCopyOverlay(destination._image, _image._image, _name));
        }
    }

    //==============================================================================================
    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class CustomDataDictionary : IDictionary<string, object>, IDictionary
    {
        private readonly VisionImage _image = null;
        private readonly object _syncRoot = new object();

        
        internal CustomDataDictionary(VisionImage image)
        {
            _image = image;
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "CustomDataDictionary";
        }

private static byte[] SerializeObject(object o)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, o);
            return stream.GetBuffer();
        }

        
        private static object DeserializeObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(data);
            return formatter.Deserialize(stream);
        }
        //==========================================================================================
        /// <summary>
        /// Adds the string key and associated custom data object to the <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/>.</summary>
        /// <param name="key">
        /// </param>
        /// <param name="value">
        /// </param>

        public void Add(string key, object value)
        {
            _image.ThrowIfDisposed();
            if (key == null) { throw new ArgumentNullException("key"); }
            if (value == null) { throw new ArgumentNullException("value"); }
            byte[] valueBytes = SerializeObject(value);
            Utilities.ThrowError(VisionDllCommon.imaqWriteCustomData(_image._image, key, valueBytes, (UInt32)valueBytes.Length));
        }

        
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> pair)
        {
            Add(pair.Key, pair.Value);
        }
        //==========================================================================================
        /// <summary>
        /// Adds the string key and associated custom data object to the <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="value">
        /// </param>

        void IDictionary.Add(object key, object value)
        {
            Add((string)key, value);
        }

        //==========================================================================================
        /// <summary>
        /// Returns whether this <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/> contains data associated with this key.
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>

        public bool ContainsKey(string key)
        {
            _image.ThrowIfDisposed();
            if (key == null) { throw new ArgumentNullException("key"); }
            Int32 keyPresent;
            Utilities.ThrowError(VisionDllCommon.dotNET_ImageHasCustomKey(_image._image, key, out keyPresent));
            return (keyPresent != 0);
        }

        
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> pair)
        {
            if (!ContainsKey(pair.Key))
            {
                return false;
            }
            object value = this[pair.Key];
            return (value.Equals(pair.Value));
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether this <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/> contains the key and associated data.
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>

        bool IDictionary.Contains(object key)
        {
            return ContainsKey((string)key);
        }
        //==========================================================================================
        /// <summary>
        /// Removes all keys and custom data from the <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/>.
        /// </summary>

        public void Clear()
        {
            foreach (string key in Keys)
            {
                Remove(key);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Removes the key and associated data from the <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>

        public bool Remove(string key)
        {
            _image.ThrowIfDisposed();
            if (key == null) { throw new ArgumentNullException("key"); }
            Int32 success = VisionDllCommon.imaqRemoveCustomData(_image._image, key);
            // If the key isn't in the image, we want to just return false.  Otherwise, throw the error.
            if (success == 0 && VisionDllCommon.imaqGetLastError() == ErrorCode.CustomdataKeyNotFound)
            {
                return false;
            }
            Utilities.ThrowError(success);
            return true;
        }
        //==========================================================================================
        /// <summary>
        /// Removes the key and associated data from the <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="key">
        /// </param>

        void IDictionary.Remove(object key) {
            Remove((string)key);
        }

        
        bool ICollection<KeyValuePair<string,object>>.Remove(KeyValuePair<string, object> pair)
        {
            return Remove(pair.Key);
        }
        //==========================================================================================
        /// <summary>
        /// Gets the number of custom keys.
        /// </summary>
        /// <value>
        /// </value>

        public Int32 Count
        {
            get
            {
                return Keys.Count;
            }
        }

        
        bool ICollection<KeyValuePair<string, object> >.IsReadOnly
        {
            get
            {
                return false;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets whether this <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/> is not read only.
        /// </summary>
        /// <value>
        /// </value>

        bool IDictionary.IsReadOnly
        {
            get
            {
                return false;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets whether this <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/> is not of a fixed size.
        /// </summary>
        /// <value>
        /// </value>

        bool IDictionary.IsFixedSize
        {
            get
            {
                return false;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the synchronizing object.
        /// </summary>
        /// <value>
        /// </value>

        object ICollection.SyncRoot
        {
            get
            {
                return _syncRoot;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Indicates if the <see cref="NationalInstruments.Vision.CustomDataDictionary" crefType="Unqualified"/> is not synchronized.
        /// </summary>
        /// <value>
        /// </value>

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int index)
        {
            _image.ThrowIfDisposed();
            if (array == null) { throw new ArgumentNullException("array"); }
            if (index < 0) {
                throw new ArgumentOutOfRangeException("index");
            }
            ICollection<string> keys = Keys;
            if (index > keys.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            int numToCopy = keys.Count - index;
            if (numToCopy > array.Length)
            {
                throw new ArgumentOutOfRangeException("array");
            }
            int i = 0;
            foreach (string key in keys)
            {
                if (i >= index)
                {
                    array[i - index] = new KeyValuePair<string, object>(key, this[key]);
                }
                ++i;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Copies the keys and associated data into an array.
        /// </summary>
        /// <param name="array">
        /// </param>
        /// <param name="index">
        /// </param>

        void ICollection.CopyTo(System.Array array, int index)
        {
            ((ICollection<KeyValuePair<string, object>>)this).CopyTo((KeyValuePair<string, object>[])array, index);
        }

        //==========================================================================================
        /// <summary>
        /// Gets the raw data associated with this key.
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// You can use this method to get custom data that can be seen in other Application Development Environments (ADEs).
        /// </remarks>

        public byte[] GetDataRawBytes(string key)
        {
            _image.ThrowIfDisposed();
            if (key == null) { throw new ArgumentNullException("key"); }
            UInt32 size;
            IntPtr dataPtr = VisionDllCommon.imaqReadCustomData(_image._image, key, out size);
            byte[] data;
            try
            {
                // Throw the right exception if we didn't find it.
                if (dataPtr == IntPtr.Zero && VisionDllCommon.imaqGetLastError() == ErrorCode.CustomdataKeyNotFound)
                {
                    throw new KeyNotFoundException();
                }
                Utilities.ThrowError(dataPtr);
                data = new byte[size];
                Marshal.Copy(dataPtr, data, 0, (Int32)size);
            }
            finally
            {
                VisionDllCommon.imaqDispose(dataPtr);
            }
            return data;
        }

        //==========================================================================================
        /// <summary>
        /// Sets the raw data associated with this key.
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <remarks>
        /// You can use this method to set custom data that can be seen in other Application Development Environments (ADEs).
        /// </remarks>

        public void SetDataRawBytes(string key, byte[] value)
        {
            _image.ThrowIfDisposed();
            if (key == null) { throw new ArgumentNullException("key"); }
            if (value == null) { throw new ArgumentNullException("value"); }
            Utilities.ThrowError(VisionDllCommon.imaqWriteCustomData(_image._image, key, value, (UInt32)value.Length));
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>

        public object this[string key]
        {
            get
            {
                _image.ThrowIfDisposed();
                if (key == null) { throw new ArgumentNullException("key"); }
                byte[] dataBytes = GetDataRawBytes(key);
                return DeserializeObject(dataBytes);
            }
            set
            {
                _image.ThrowIfDisposed();
                if (key == null) { throw new ArgumentNullException("key"); }
                SetDataRawBytes(key, SerializeObject(value));
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the custom data associated with a key, which must be a string. 
        /// </summary>
        /// <value>
        /// </value>
        /// <remarks>
        /// Note that you can only get and set objects that are serializable, which includes most classes provided with NI Vision.
        /// </remarks>

        object IDictionary.this[object key]
        {
            get
            {
                return this[(string)key];
            }
            set
            {
                this[(string)key] = value;
            }
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="key">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <returns>
        /// </returns>

        public bool TryGetValue(string key, out object value)
        {
            _image.ThrowIfDisposed();
            if (key == null) { throw new ArgumentNullException("key"); }
            UInt32 size;
            IntPtr dataPtr = VisionDllCommon.imaqReadCustomData(_image._image, key, out size);
            byte[] dataBytes;
            try
            {
                // Don't throw an error if it's not found - just return false.
                if (dataPtr == IntPtr.Zero && VisionDllCommon.imaqGetLastError() == ErrorCode.CustomdataKeyNotFound)
                {
                    value = new object();
                    return false;
                }
                Utilities.ThrowError(dataPtr);
                dataBytes = new byte[size];
                Marshal.Copy(dataPtr, dataBytes, 0, (Int32)size);
                value = DeserializeObject(dataBytes);
            }
            finally
            {
                VisionDllCommon.imaqDispose(dataPtr);
            }
            return true;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the set of valid string keys that have custom data associated with them.
        /// </summary>
        /// <value>
        /// </value>

        public ICollection<string> Keys
        {
            get
            {
                _image.ThrowIfDisposed();
                UInt32 size;
                IntPtr stringsPtr = VisionDllCommon.imaqEnumerateCustomKeys(_image._image, out size);
                Utilities.ThrowError(stringsPtr);
                return Utilities.ConvertIntPtrToStringCollection(stringsPtr, (Int32)size, true);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets he set of valid string keys that have custom data associated with them.
        /// </summary>
        /// <value>
        /// </value>

        ICollection IDictionary.Keys
        {
            get
            {
                return (ICollection)Keys;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the collection of objects that are custom data values.
        /// </summary>
        /// <value>
        /// </value>

        public ICollection<object> Values
        {
            get
            {
                _image.ThrowIfDisposed();
                ICollection<string> keys = Keys;
                Collection<object> toReturn = new Collection<object>();
                foreach (string key in keys)
                {
                    toReturn.Add(this[key]);
                }
                return toReturn;
            }
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>

        ICollection IDictionary.Values
        {
            get
            {
                return (ICollection)Values;
            }
        }

IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            Collection<KeyValuePair<string, object>> toReturn = new Collection<KeyValuePair<string, object>>();
            foreach (string key in Keys)
            {
                toReturn.Add(new KeyValuePair<string, object>(key, this[key]));
            }
            return toReturn.GetEnumerator();
        }

private sealed class DictionaryEnumerator : IDictionaryEnumerator
        {
            private IEnumerator<KeyValuePair<string, object>> _enumerator;

            
            internal DictionaryEnumerator(IEnumerator<KeyValuePair<string, object>> enumerator)
            {
                _enumerator = enumerator;
            }

            
            public void Reset()
            {
                _enumerator.Reset();
            }

            
            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            
            public object Current
            {
                get
                {
                    return _enumerator.Current;
                }
            }

            
            public DictionaryEntry Entry
            {
                get
                {
                    return new DictionaryEntry(_enumerator.Current.Key, _enumerator.Current.Value);
                }
            }

            
            public object Key
            {
                get
                {
                    return _enumerator.Current.Key;
                }
            }

            
            public object Value
            {
                get
                {
                    return _enumerator.Current.Value;
                }
            }
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return new DictionaryEnumerator(((IEnumerable<KeyValuePair<string, object>>)this).GetEnumerator());
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, object>>)this).GetEnumerator();
        }
    }
}
