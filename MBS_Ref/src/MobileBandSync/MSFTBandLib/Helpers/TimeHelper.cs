namespace MobileBandSync.MSFTBandLib.Helpers
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Runtime.InteropServices;

    public static class TimeHelper
    {
        public static DateTime DateTimeResponse(CommandResponse response, int position = 0);
        public static DateTime DateTimeUshorts(ushort[] t);
    }
}

