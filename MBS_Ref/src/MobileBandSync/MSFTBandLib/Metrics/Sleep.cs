namespace MobileBandSync.MSFTBandLib.Metrics
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Runtime.CompilerServices;

    public class Sleep
    {
        public Sleep();
        public Sleep(CommandResponse response);

        public uint Calories { get; protected set; }

        public uint Duration { get; protected set; }

        public uint Feeling { get; protected set; }

        public uint RestingHR { get; protected set; }

        public uint TimeAsleep { get; protected set; }

        public uint TimeAwake { get; protected set; }

        public uint TimeToSleep { get; protected set; }

        public uint TimesAwoke { get; protected set; }

        public DateTime Timestamp { get; protected set; }

        public DateTime WokeUp { get; protected set; }

        public ushort Version { get; protected set; }
    }
}

