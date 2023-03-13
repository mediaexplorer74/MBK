namespace MobileBandSync.MSFTBandLib.Command
{
    using System;
    using System.Runtime.CompilerServices;

    public class CommandDataSize : Attribute
    {
        public CommandDataSize(int DataSize);

        public int DataSize { get; protected set; }
    }
}

