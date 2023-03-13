namespace MobileBandSync.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Workout
    {
        public WorkoutSummary Summary;
        public MobileBandSync.Common.SleepSummary SleepSummary;

        public Workout();

        public DateTime StartTime { get; set; }

        public DateTime LastSplitTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<WorkoutPoint> TrackPoints { get; }

        public int LastHR { get; set; }

        public string Notes { get; set; }

        public EventType Type { get; set; }

        public string TCXBuffer { get; set; }

        public string Filename { get; set; }

        public ulong Filesize { get; set; }
    }
}

