namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class WorkoutMarker
    {
        public DistanceAnnotationType Action { get; set; }

        public EventType WorkoutType { get; set; }

        public int Value2 { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

