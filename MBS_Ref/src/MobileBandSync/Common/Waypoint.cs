namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class Waypoint
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double SpeedOverGround { get; set; }

        public double ElevationFromMeanSeaLevel { get; set; }

        public double EstimatedHorizontalError { get; set; }

        public double EstimatedVerticalError { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

