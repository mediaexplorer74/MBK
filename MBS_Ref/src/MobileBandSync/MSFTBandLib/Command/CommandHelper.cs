namespace MobileBandSync.MSFTBandLib.Command
{
    using MobileBandSync.MSFTBandLib.Facility;
    using System;

    public static class CommandHelper
    {
        public static ushort Create(FacilityEnum facility, bool tx, int index);
        public static int GetCommandDataSize(CommandEnum command);
        public static int GetCommandDataSize(Func<uint> BufferSize);
        public static byte[] GetCommandDefaultArgumentsBytes(CommandEnum command);
        public static byte[] GetCommandDefaultArgumentsBytes(Func<uint> BufferSize);
    }
}

