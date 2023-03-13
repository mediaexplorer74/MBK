namespace MobileBandSync.MSFTBandLib
{
    using System;

    internal static class BandBitConverter
    {
        private static readonly char[] HexCharTable;

        static BandBitConverter();
        public static void GetBytes(Guid guid, byte[] buffer, int offset);
        public static void GetBytes(short i, byte[] buffer, int offset);
        public static void GetBytes(int i, byte[] buffer, int offset);
        public static void GetBytes(long i, byte[] buffer, int offset);
        public static void GetBytes(ushort i, byte[] buffer, int offset);
        public static void GetBytes(uint i, byte[] buffer, int offset);
        public static void GetBytes(ulong i, byte[] buffer, int offset);
        public static Guid ToGuid(byte[] buffer, int offset);
        public static string ToString(byte[] buffer);
        public static string ToString(byte[] buffer, int offset, int count);
        private static string ToStringInternal(byte[] buffer, int offset, int count);
    }
}

