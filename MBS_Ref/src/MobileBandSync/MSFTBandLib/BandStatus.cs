namespace MobileBandSync.MSFTBandLib
{
    using System;
    using System.Runtime.CompilerServices;

    public class BandStatus
    {
        private const int serializedByteCount = 6;

        private BandStatus();
        public static BandStatus DeserializeFromBytes(byte[] data);
        public static int GetSerializedByteCount();
        internal byte[] SerializeToByteArray();
        internal void SerializeToBytes(ref byte[] data);

        public ushort PacketType { get; private set; }

        public uint Status { get; private set; }
    }
}

