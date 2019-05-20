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
using System.Runtime.Serialization;
using NationalInstruments.Vision.Internal;
using System.Security;
using System.Security.Permissions;

namespace NationalInstruments.Vision
{
	/// <summary>
	/// Summary description for VisionException.
	/// </summary>
    [Serializable]
	public sealed class VisionException : System.Exception
	{
        private ErrorCode _visionErrorCode;
        private string _visionErrorText;
        //==========================================================================================
        /// <summary>
        /// Gets or sets the error message returned from NI Vision.
        /// </summary>
        /// <value>
        /// The default value is <see langword="null"/>.
        /// </value>

        public string VisionErrorText
        {
            get { return _visionErrorText; }
            set { _visionErrorText = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the error code returned from NI Vision.
        /// </summary>
        /// <value>
        /// The default value is Success.
        /// </value>

        public ErrorCode VisionErrorCode
        {
            get { return _visionErrorCode; }
            set { _visionErrorCode = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.VisionException" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The Vision error code that this VisionException represents.
        /// </param>

		public VisionException(ErrorCode errorCode)
		{
			VisionErrorCode = errorCode;
            VisionErrorText = VisionDllCommon.imaqGetErrorText((int)VisionErrorCode);
		}
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.VisionException" crefType="Unqualified"/> class.</summary>

        public VisionException() : base()
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.VisionException" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception. </param>

        public VisionException(string message) : base(message)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.VisionException" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>

        public VisionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        
        private VisionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            _visionErrorCode = (ErrorCode)info.GetValue("errorCode", typeof(ErrorCode));
            _visionErrorText = (string)info.GetString("errorText");
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// A VisionException instance to compare to this instance.</param>
        /// <returns>
        /// </returns>

        public bool Equals(VisionException other)
        {
            return other != null && _visionErrorCode == other._visionErrorCode && _visionErrorText == other._visionErrorText && Message == other.Message;
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
            VisionException other = (VisionException)obj;
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
            return _visionErrorCode.GetHashCode() ^ (_visionErrorText == null ? 0 : _visionErrorText.GetHashCode());
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
            return "VisionException: VisionErrorCode=" + _visionErrorCode.ToString() + ", VisionErrorText=" + _visionErrorText;
        }

        //==========================================================================================
        /// <summary>
        /// Sets the SerializationInfo with information about the exception. 
        /// </summary>
        /// <param name="info">
        /// The SerializationInfo that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">
        /// The StreamingContext that contains contextual information about the source or destination. </param>

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("errorCode", _visionErrorCode);
            info.AddValue("errorText", _visionErrorText);
        }
	}
}
