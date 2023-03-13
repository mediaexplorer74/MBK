namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class Steps
    {
        public ushort SleepType { get; set; }

        public ushort SegmentType { get; set; }

        public uint Counter { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

