namespace MobileBandSync.MSFTBandLib.Command
{
    using MobileBandSync.MSFTBandLib.Includes;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class CommandResponse
    {
        public byte[] Status;
        public List<byte[]> Data;
        public const int RESPONSE_STATUS_LENGTH = 6;

        public CommandResponse();
        public void AddResponse(byte[] bytes);
        protected void AddResponseData(byte[] bytes);
        public static byte[] Combine(byte[] first, byte[] second);
        public byte[] GetAllData();
        public ByteStream GetByteStream(int index = 0);
        public byte[] GetData(int index = 0);
        public static byte[] GetResponseDataBytesEnd(byte[] bytes);
        public static byte[] GetResponseDataBytesStart(byte[] bytes);
        public static byte[] GetResponseStatusBytesEnd(byte[] bytes);
        public static byte[] GetResponseStatusBytesStart(byte[] bytes);
        public static bool ResponseBytesAreStatus(byte[] bytes);
        public static bool ResponseBytesContainData(byte[] bytes);
        public static bool ResponseBytesEndWithStatus(byte[] bytes);
        public static bool ResponseBytesStartWithStatus(byte[] bytes);
        public bool StatusReceived();

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly CommandResponse.<>c <>9;
            public static Func<byte, bool> <>9__9_0;
            public static Func<byte, int> <>9__14_0;

            static <>c();
            internal int <ResponseBytesAreStatus>b__14_0(byte b);
            internal bool <StatusReceived>b__9_0(byte s);
        }
    }
}

