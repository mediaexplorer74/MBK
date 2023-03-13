namespace MobileBandSync.Data
{
    using System;
    using System.Runtime.CompilerServices;

    public class SleepItem
    {
        public SleepItem();
        public SleepItem(string uniqueId, string title, string subtitle, string imagePath, string description, string content);
        public override string ToString();

        public string UniqueId { get; }

        public string Title { get; private set; }

        public string Subtitle { get; private set; }

        public string Description { get; private set; }

        public string ImagePath { get; private set; }

        public string Content { get; private set; }

        public int SleepId { get; set; }

        public int SleepActivityId { get; set; }

        public int SecFromStart { get; set; }

        public byte SegmentType { get; set; }

        public byte SleepType { get; set; }

        public byte Heartrate { get; set; }
    }
}

