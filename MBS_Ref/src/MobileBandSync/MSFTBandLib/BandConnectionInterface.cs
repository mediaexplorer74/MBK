namespace MobileBandSync.MSFTBandLib
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public interface BandConnectionInterface : IDisposable
    {
        Task<CommandResponse> Command(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 0x2000, Action<ulong, ulong> Progress = null);
        Task CommandStore(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 0x2000, Action<ulong, ulong> Progress = null);
        Task Connect(BandInterface Band);
        Task Disconnect();
    }
}

