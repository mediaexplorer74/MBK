namespace MobileBandSync.MSFTBandLib
{
    using System;
    using System.Runtime.CompilerServices;

    public class BandMetadataRange
    {
        private const int serializedByteCount = 12;

        private BandMetadataRange();
        public static BandMetadataRange DeserializeFromBytes(byte[] data);
        public static int GetSerializedByteCount();
        internal byte[] SerializeToByteArray();
        internal void SerializeToBytes(ref byte[] data);

        public uint StartingSeqNumber { get; set; }

        public uint EndingSeqNumber { get; set; }

        public uint ByteCount { get; set; }
    }
}

