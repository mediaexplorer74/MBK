namespace MobileBandSync.MSFTBandLib.Metrics
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Runtime.CompilerServices;

    public class BandVersion
    {
        public BandVersion();
        public BandVersion(CommandResponse response);

        public string AppName { get; protected set; }

        public byte PCBId { get; protected set; }

        public ushort VersionMajor { get; protected set; }

        public ushort VersionMinor { get; protected set; }

        public uint Revision { get; protected set; }

        public uint BuildNumber { get; protected set; }

        public byte DebugBuild { get; protected set; }
    }
}

