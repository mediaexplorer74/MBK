namespace MobileBandSync.Data
{
    using System;
    using System.Runtime.CompilerServices;

    public class TrackItem
    {
        public TrackItem();
        public TrackItem(string uniqueId, string title, string subtitle, string imagePath, string description, string content);
        public override string ToString();

        public string UniqueId { get; }

        public string Title { get; private set; }

        public string Subtitle { get; private set; }

        public string Description { get; private set; }

        public string ImagePath { get; private set; }

        public string Content { get; private set; }

        public int TrackId { get; set; }

        public int WorkoutId { get; set; }

        public int SecFromStart { get; set; }

        public int LongDelta { get; set; }

        public int LatDelta { get; set; }

        public int Elevation { get; set; }

        public byte Heartrate { get; set; }

        public int Barometer { get; set; }

        public uint Cadence { get; set; }

        public double SkinTemp { get; set; }

        public int GSR { get; set; }

        public int UV { get; set; }

        public double DistMeter { get; set; }

        public double SpeedMeterPerSecond { get; set; }

        public double TotalMeters { get; internal set; }

        public ushort SleepType { get; }

        public ushort SegmentType { get; }
    }
}

