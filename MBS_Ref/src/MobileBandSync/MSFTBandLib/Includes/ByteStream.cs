namespace MobileBandSync.MSFTBandLib.Includes
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class ByteStream : IDisposable
    {
        public System.IO.MemoryStream MemoryStream;
        public System.IO.BinaryReader BinaryReader;
        public System.IO.BinaryWriter BinaryWriter;

        public ByteStream();
        public ByteStream(byte[] bytes);
        public void Dispose();
        protected virtual void Dispose(bool disposing);
        public byte GetByte(int position = 0);
        public byte[] GetBytes();
        public string GetString(int position = 0, long chars = 0L);
        public uint GetUint32(int position = 0);
        public ulong GetUint64(int position = 0);
        public ushort GetUshort(int position = 0);
        public ushort[] GetUshorts(int count, int pos = 0);
        public void Write(byte[] bytes);

        public bool Disposed { get; protected set; }
    }
}

