namespace MobileBandSync.MSFTBandLib.Command
{
    using System;
    using System.Runtime.InteropServices;

    public class CommandPacket
    {
        protected CommandEnum Command;
        protected byte[] args;
        protected Func<uint> CmdBufferSize;

        public CommandPacket(CommandEnum command, Func<uint> BufferSize, byte[] args = null);
        public byte[] GetArgsSizeBytes();
        public byte[] GetBytes();
        public int GetCommandDataSize();
        public byte[] GetCommandDefaultArgumentsBytes();
    }
}

