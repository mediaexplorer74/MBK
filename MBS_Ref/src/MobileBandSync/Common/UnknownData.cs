namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class UnknownData
    {
        public int[] ValueInt16;
        public int[] ValueInt32;

        public UnknownData(int iID, byte[] buffer, int iLength);

        public byte[] Content { get; }

        public int ID { get; set; }
    }
}

