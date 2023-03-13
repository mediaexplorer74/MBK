namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class Sensor
    {
        public uint GalvanicSkinResponse { get; set; }

        public uint Value1 { get; set; }

        public uint Value2 { get; set; }

        public uint Value3 { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

