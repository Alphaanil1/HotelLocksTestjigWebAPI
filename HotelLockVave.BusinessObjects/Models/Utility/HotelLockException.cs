using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.BusinessObjects.Models.Utility
{
    [Serializable]
    public class HotelLockException : Exception, ISerializable
    {
        public HotelLockException() { }
        public HotelLockException(string Message) : base(Message)
        { }
        public HotelLockException(string Message, Exception InnerException) : base(Message, InnerException)
        { }
        protected HotelLockException(SerializationInfo Info, StreamingContext Context) : base(Info, Context)
        { }
    }

    [Serializable]
    public class PortNotAvailableException : Exception
    {
        public PortNotAvailableException() { }
        public PortNotAvailableException(string Message) : base(Message) { }
        public PortNotAvailableException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected PortNotAvailableException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class NoSystemPasswordSetException : Exception
    {
        public NoSystemPasswordSetException() { }
        public NoSystemPasswordSetException(string message) : base(message) { }
        public NoSystemPasswordSetException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected NoSystemPasswordSetException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class WrongCommandCodeException : Exception
    {
        public WrongCommandCodeException() { }
        public WrongCommandCodeException(string message) : base(message) { }
        public WrongCommandCodeException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected WrongCommandCodeException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }
    [Serializable]
    public class WrongCRCException : Exception
    {
        public WrongCRCException() { }
        public WrongCRCException(string message) : base(message) { }
        public WrongCRCException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected WrongCRCException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class ParameterNotConfiguredException : Exception
    {
        public ParameterNotConfiguredException() { }
        public ParameterNotConfiguredException(string message) : base(message) { }
        public ParameterNotConfiguredException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected ParameterNotConfiguredException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class SystemPasswordMismatchException : Exception
    {
        public SystemPasswordMismatchException() { }
        public SystemPasswordMismatchException(string message) : base(message) { }
        public SystemPasswordMismatchException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected SystemPasswordMismatchException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class WrongDataException : Exception
    {
        public WrongDataException() { }
        public WrongDataException(string message) : base(message) { }
        public WrongDataException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected WrongDataException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class WrongFrameTypeException : Exception
    {
        public WrongFrameTypeException() { }
        public WrongFrameTypeException(string message) : base(message) { }
        public WrongFrameTypeException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected WrongFrameTypeException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class CardNotPresentException : Exception
    {
        public CardNotPresentException() { }
        public CardNotPresentException(string Message) : base(Message) { }
        public CardNotPresentException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected CardNotPresentException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class USBCommunicatioErrorException : Exception
    {
        public USBCommunicatioErrorException() { }
        public USBCommunicatioErrorException(string message) : base(message) { }
        public USBCommunicatioErrorException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected USBCommunicatioErrorException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    //added by bhagyashri (14-11-19)
    [Serializable]
    public class DataPresentException : Exception
    {
        public DataPresentException() { }
        public DataPresentException(string message) : base(message) { }
        public DataPresentException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected DataPresentException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class DataTransferCompleteException : Exception
    {
        public DataTransferCompleteException() { }
        public DataTransferCompleteException(string message) : base(message) { }
        public DataTransferCompleteException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected DataTransferCompleteException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class MemoryFullException : Exception
    {
        public MemoryFullException() { }
        public MemoryFullException(string message) : base(message) { }
        public MemoryFullException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected MemoryFullException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class CardWriteFailException : Exception
    {
        public CardWriteFailException() { }
        public CardWriteFailException(string message) : base(message) { }
        public CardWriteFailException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected CardWriteFailException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    [Serializable]
    public class NoDataException : Exception
    {
        public NoDataException() { }
        public NoDataException(string message) : base(message) { }
        public NoDataException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected NoDataException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    //-------------------
    //---ERR14
    [Serializable]
    public class NoTimeSetException : Exception
    {
        public NoTimeSetException() { }
        public NoTimeSetException(string message) : base(message) { }
        public NoTimeSetException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected NoTimeSetException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }

    ////---ERR15
    //[Serializable]
    //public class MemoryReadWriteFailedException : Exception
    //{
    //    public MemoryReadWriteFailedException() { }
    //    public MemoryReadWriteFailedException(string message) : base(message) { }
    //    public MemoryReadWriteFailedException(string Message, Exception InnerException) : base(Message, InnerException) { }
    //    protected MemoryReadWriteFailedException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    //}

    ////---ERR16
    //[Serializable]
    //public class RTCReadWriteException : Exception
    //{
    //    public RTCReadWriteException() { }
    //    public RTCReadWriteException(string message) : base(message) { }
    //    public RTCReadWriteException(string Message, Exception InnerException) : base(Message, InnerException) { }
    //    protected RTCReadWriteException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    //}

    //---ERR17
    [Serializable]
    public class CardReadFailedException : Exception
    {
        public CardReadFailedException() { }
        public CardReadFailedException(string Message) : base(Message) { }
        public CardReadFailedException(string Message, Exception InnerException) : base(Message, InnerException) { }
        protected CardReadFailedException(SerializationInfo Info, StreamingContext Context) : base(Info, Context) { }
    }
}
