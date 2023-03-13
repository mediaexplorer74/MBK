namespace MobileBandSync.OpenTcx
{
    using System;

    public class OpenTcxException : Exception
    {
        public OpenTcxException(string message);
        public OpenTcxException(string message, Exception inner);
    }
}

