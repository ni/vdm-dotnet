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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using NationalInstruments.Vision.Internal;
using System.Diagnostics;

namespace NationalInstruments.Vision
{
    //==============================================================================================
    /// <summary>
    /// Defines an object used to read Audio Video Interleave (AVI) files.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class AviInputSession : IDisposable
    {
        internal IntPtr _session = IntPtr.Zero;
        internal AviInfo _info = null;
        private object _disposeLock = new object();
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AviInputSession" crefType="Unqualified"/> class with the specified filename. 
        /// </summary>
        /// <param name="fileName">
        /// The name of the AVI file.
        /// </param>

        public AviInputSession(string fileName)
        {
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            _session = VisionDllCommon.imaqOpenAVI(fileName);
            Utilities.ThrowError(_session);
        }

        
        internal class AviInfo
        {
            private UInt32 _width;
            private UInt32 _height;
            private ImageType _imageType;
            private UInt32 _numFrames;
            private UInt32 _framesPerSecond;
            private string _filterName;
            private bool _hasData;
            private UInt32 _maxDataSize;

public UInt32 Width
            {
                get { return _width; }
                set { _width = value; }
            }

public UInt32 Height
            {
                get { return _height; }
                set { _height = value; }
            }

public ImageType ImageType
            {
                get { return _imageType; }
                set { _imageType = value; }
            }

public UInt32 NumFrames
            {
                get { return _numFrames; }
                set { _numFrames = value; }
            }

public UInt32 FramesPerSecond
            {
                get { return _framesPerSecond; }
                set { _framesPerSecond = value; }
            }

public string FilterName
            {
                get { return _filterName; }
                set { _filterName = value; }
            }

public bool HasData
            {
                get { return _hasData; }
                set { _hasData = value; }
            }

public UInt32 MaxDataSize
            {
                get { return _maxDataSize; }
                set { _maxDataSize = value; }
            }
        }

        
        private AviInfo GetAviInfo()
        {
            ThrowIfDisposed();
            if (_info == null)
            {
                CVI_AVIInfo _cviInfo = new CVI_AVIInfo();
                Utilities.ThrowError(VisionDllCommon.imaqGetAVIInfo(_session, out _cviInfo));
                _info = _cviInfo.ConvertToExternal();
            }
            return _info;
        }
        //==========================================================================================
        /// <summary>
        /// Gets the width of the images in the Audio Video Interleave (AVI) file.
        /// </summary>
        /// <value>
        /// Width of the images in the AVI.
        /// </value>

        [CLSCompliant(false)]
        public UInt32 Width
        {
            get { ThrowIfDisposed(); return GetAviInfo().Width; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the height of the images in the Audio Video Interleave (AVI) file. 
        /// </summary>
        /// <value>
        ///  Height of the images in the Audio Video Interleave (AVI) file. 
        /// </value>

        [CLSCompliant(false)]
        public UInt32 Height
        {
            get { ThrowIfDisposed(); return GetAviInfo().Height; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the type of the images of the Audio Video Interleave (AVI) file.
        /// </summary>
        /// <value>
        /// Type of the images of the AVI file.
        /// </value>

        public ImageType ImageType
        {
            get { ThrowIfDisposed(); return GetAviInfo().ImageType; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the number of frames in the Audio Video Interleave (AVI) file. 
        /// </summary>
        /// <value>
        /// Number of frames in the Audio Video Interleave (AVI) file. 
        /// </value>

        [CLSCompliant(false)]
        public UInt32 Frames
        {
            get { ThrowIfDisposed(); return GetAviInfo().NumFrames; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the number of frames per second this Audio Video Interleave (AVI) file should be shown at. 
        /// </summary>
        /// <value>
        /// Number of frames per second this Audio Video Interleave (AVI) file should be shown at. 
        /// </value>
        /// <remarks>
        /// The AVI may play at a slower rate, depending on the performance of the system on which it plays. 
        /// </remarks>

        [CLSCompliant(false)]
        public UInt32 FramesPerSecond
        {
            get { ThrowIfDisposed(); return GetAviInfo().FramesPerSecond; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the name of the decompression filter used to read this Audio Video Interleave (AVI) file.
        /// </summary>
        /// <value>
        /// Name of the decompression filter used to read this Audio Video Interleave (AVI) file.
        /// </value>

        public string FilterName
        {
            get { ThrowIfDisposed(); return GetAviInfo().FilterName; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets whether this Audio Video Interleave (AVI) file has data attached to its frames.
        /// </summary>
        /// <value>
        /// If this property is <see langword="true"/>, you can read the data by calling <see cref="NationalInstruments.Vision.AviInputSession.ReadFrame" crefType="PartiallyQualified"/> and passing <see langword="true"/> to <format type="italics">readData</format>.
        /// </value>

        public bool HasData
        {
            get { ThrowIfDisposed(); return GetAviInfo().HasData; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the maximum size of the data attached to the frames of this Audio Video Interleave (AVI) file.
        /// </summary>
        /// <value>
        ///  Maximum size of the data attached to the frames of this AVI file.
        /// </value>

        [CLSCompliant(false)]
        public UInt32 MaximumDataSize
        {
            get { ThrowIfDisposed(); return GetAviInfo().MaxDataSize; }
        }

        //==========================================================================================
        /// <summary>
        /// Reads a frame from the currently open Audio Video Interleave (AVI).
        /// </summary>
        /// <param name="image">
        /// The image into which the method stores the frame of the AVI.
        /// </param>
        /// <param name="frame">
        /// Frame number to read. The frame number is zero-based.
        /// </param>

        [CLSCompliant(false)]
        public void ReadFrame(VisionImage image, UInt32 frame)
        {
            ReadFrame(image, frame, false);
        }
        //==========================================================================================
        /// <summary>
        /// Reads a frame from the currently open Audio Video Interleave (AVI).
        /// </summary>
        /// <param name="image">
        /// The image into which the method stores the frame of the AVI.
        /// </param>
        /// <param name="frame">
        /// Frame number to read. The frame number is zero-based.
        /// </param>
        /// <param name="readData">
        /// Whether to read the data attached to this frame, if any.
        /// </param>
        /// <returns>
        /// If <paramref name="readData"/> is <see langword="true"/>, the data attached to this frame, if any.  If <paramref name="readData"/> is <see langword="false"/>, the method returns <see langword="null"/>.
        /// </returns>

        [CLSCompliant(false)]
        public byte[] ReadFrame(VisionImage image, UInt32 frame, bool readData)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (readData)
            {
                UInt32 dataSize = MaximumDataSize;
                byte[] tempData = new byte[dataSize];
                Utilities.ThrowError(VisionDllCommon.imaqReadAVIFrame(image._image, _session, frame, tempData, ref dataSize));
                byte[] data = tempData;
                if (dataSize != MaximumDataSize)
                {
                    data = new byte[dataSize];
                    Array.Copy(tempData, data, dataSize);
                }
                return data;
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqReadAVIFrame(image._image, _session, frame, IntPtr.Zero, IntPtr.Zero));
                return null;
            }
        }

internal void ThrowIfDisposed()
		{
			if (_session == IntPtr.Zero)
			{
				throw new ObjectDisposedException("NationalInstruments.Vision.AviInputSession");
			}
		}
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An AviInputSession instance to compare to this instance.</param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(AviInputSession other)
        {
            return other != null && _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            AviInputSession other = (AviInputSession)obj;
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
            return _session.GetHashCode();
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
            return "AviInputSession";
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.AviInputSession" crefType="Unqualified"/>.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // _session is safe to use since it's unmanaged.
                if (_session != IntPtr.Zero)
                {
                    VisionDllCommon.imaqCloseAVI(_session);
                    _session = IntPtr.Zero;
                }
            }
        }

        
        ~AviInputSession()
        {
            Dispose(false);
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines an object used to write Audio Video Interleave (AVI) files.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class AviOutputSession : IDisposable
    {
        internal IntPtr _session = IntPtr.Zero;
        private object _disposeLock = new object();
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AviOutputSession" crefType="Unqualified"/> class with the specified filename. 
        /// </summary>
        /// <param name="fileName">
        /// The name of the Audio Video Interleave (AVI) file to write.
        /// </param>

        public AviOutputSession(string fileName) : 
            this(fileName, 30)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AviOutputSession" crefType="Unqualified"/> class with the specified file name and <see cref="NationalInstruments.Vision.AviInputSession.FramesPerSecond" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="fileName">
        /// The name of the Audio Video Interleave (AVI) file to write.
        /// </param>
        /// <param name="framesPerSecond">
        /// The number of frames per second of this AVI. <paramref name="framesPerSecond"/> indicates the playback rate you want to use for the AVI you create. The AVI may play at a slower rate depending on the performance of the system it plays on. 
        /// The default value is 30.
        /// </param>

        [CLSCompliant(false)]
        public AviOutputSession(string fileName, UInt32 framesPerSecond) : 
            this(fileName, framesPerSecond, null)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AviOutputSession" crefType="Unqualified"/> class with the specified file name, compression filter, and <see cref="NationalInstruments.Vision.AviInputSession.FramesPerSecond" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="fileName">
        /// The name of the Audio Video Interleave (AVI) file to write.
        /// </param>
        /// <param name="framesPerSecond">
        /// The number of frames per second of this AVI. <paramref name="framesPerSecond"/> indicates the playback rate you want to use for the AVI you create. The AVI may play at a slower rate depending on the performance of the system it plays on. 
        /// The default value is 30.
        /// </param>
        /// <param name="compressionFilter">
        /// The name of the compression filter to use. To get a list of valid compression filters on your system, call <see cref="NationalInstruments.Vision.AviOutputSession.GetCompressionFilters" crefType="Unqualified"/>. By default, this parameter indicates that the method uses no compression.
        /// </param>

        [CLSCompliant(false)]
        public AviOutputSession(string fileName, UInt32 framesPerSecond, string compressionFilter) : 
            this(fileName, framesPerSecond, compressionFilter, -1)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AviOutputSession" crefType="Unqualified"/> class with the specified file name, compression filter, quality, and <see cref="NationalInstruments.Vision.AviInputSession.FramesPerSecond" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="fileName">
        /// The name of the Audio Video Interleave (AVI) file to write.
        /// </param>
        /// <param name="framesPerSecond">
        /// The number of frames per second of this AVI. <paramref name="framesPerSecond"/> indicates the playback rate you want to use for the AVI you create. The AVI may play at a slower rate depending on the performance of the system it plays on. 
        /// The default value is 30.
        /// </param>
        /// <param name="compressionFilter">
        /// The name of the compression filter to use. To get a list of valid compression filters on your system, call <see cref="NationalInstruments.Vision.AviOutputSession.GetCompressionFilters" crefType="Unqualified"/>. By default, this parameter indicates that the method uses no compression.
        /// </param>
        /// <param name="quality">
        /// The quality to use for the compression filter, from 0 to 1000. The default value is 1000.
        /// </param>

        [CLSCompliant(false)]
        public AviOutputSession(string fileName, UInt32 framesPerSecond, string compressionFilter, Int32 quality) : 
            this(fileName, framesPerSecond, compressionFilter, quality, false, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.AviOutputSession" crefType="Unqualified"/> class with the specified file name, compression filter, quality, <see cref="NationalInstruments.Vision.AviInputSession.FramesPerSecond" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.AviInputSession.HasData" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.AviInputSession.MaximumDataSize" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="fileName">
        /// The name of the Audio Video Interleave (AVI) file to write.
        /// </param>
        /// <param name="framesPerSecond">
        /// The number of frames per second of this AVI. <paramref name="framesPerSecond"/> indicates the playback rate you want to use for the AVI you create. The AVI may play at a slower rate depending on the performance of the system it plays on. 
        /// The default value is 30.
        /// </param>
        /// <param name="compressionFilter">
        /// The name of the compression filter to use. To get a list of valid compression filters on your system, call <see cref="NationalInstruments.Vision.AviOutputSession.GetCompressionFilters" crefType="Unqualified"/>. By default, this parameter indicates that the method uses no compression.
        /// </param>
        /// <param name="quality">
        /// The quality to use for the compression filter, from 0 to 1000. The default value is 1000.
        /// </param>
        /// <param name="hasData">
        /// Whether this AVI has data associated with each frame.  The default value is <see langword="false"/>.
        /// </param>
        /// <param name="maxDataSize">
        /// The maximum size of data that can be attached to each frame. If you do not want to attach data to this AVI, set this to 0.
        /// The default value is 10000.
        /// </param>

        [CLSCompliant(false)]
        public AviOutputSession(string fileName, UInt32 framesPerSecond, string compressionFilter, Int32 quality, bool hasData, UInt32 maxDataSize)
        {
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            // If compressionFilter is null, that's OK, since imaqCreateAVI() will accept it as NULL.
            _session = VisionDllCommon.imaqCreateAVI(fileName, compressionFilter, quality, framesPerSecond, hasData ? maxDataSize: 0 );
            Utilities.ThrowError(_session);
        }
        //==========================================================================================
        /// <summary>
        /// Returns an array of the compression filters on this system available to be used to create Audio Video Interleave (AVI) files. 
        /// </summary>
        /// <returns>
        /// On success, this method returns a collection of names of compression filters that are available to compress AVI files on this system. 
        /// </returns>

        public static Collection<string> GetCompressionFilters()
        {
            int numFilters;
            IntPtr filtersPtr = VisionDllCommon.imaqGetFilterNames(out numFilters);
            Utilities.ThrowError(filtersPtr);
            return Utilities.ConvertIntPtrToStringCollection(filtersPtr, numFilters, true);
        }
        //==========================================================================================
        /// <summary>
        /// Writes a frame to the currently open Audio Video Interleave (AVI) file with the specified image.
        /// </summary>
        /// <param name="image">
        /// The image to write to the frame of the AVI.
        /// </param>

        public void WriteFrame(VisionImage image)
        {
            WriteFrame(image, null);
        }
        //==========================================================================================
        /// <summary>
        /// Writes a frame to the currently open Audio Video Interleave (AVI) file with the specified image and data.
        /// </summary>
        /// <param name="image">
        /// The image to write to the frame of the AVI.
        /// </param>
        /// <param name="data">
        /// The data to attach to this frame, if any.
        /// </param>

        public void WriteFrame(VisionImage image, byte[] data)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (data == null)
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteAVIFrame(image._image, _session, IntPtr.Zero, 0));
            }
            else
            {
                Utilities.ThrowError(VisionDllCommon.imaqWriteAVIFrame(image._image, _session, data, (UInt32)data.Length));
            }
        }

        
		internal void ThrowIfDisposed()
		{
			if (_session == IntPtr.Zero)
			{
				throw new ObjectDisposedException("NationalInstruments.Vision.AviOutputSession");
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
            return "AviOutputSession";
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An AviOutputSession instance to compare to this instance.</param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(AviOutputSession other)
        {
            return other != null && _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            AviOutputSession other = (AviOutputSession)obj;
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
            return _session.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.AviOutputSession" crefType="Unqualified"/>.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // _session is safe to use since it's unmanaged.
                if (_session != IntPtr.Zero)
                {
                    VisionDllCommon.imaqCloseAVI(_session);
                    _session = IntPtr.Zero;
                }
            }
        }

        
        ~AviOutputSession()
        {
            Dispose(false);
        }
    }

}