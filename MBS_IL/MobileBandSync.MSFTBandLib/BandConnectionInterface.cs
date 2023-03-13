using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;

namespace MobileBandSync.MSFTBandLib;

public interface BandConnectionInterface : IDisposable
{
	Task Connect(BandInterface Band);

	Task Disconnect();

	Task<CommandResponse> Command(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192u, Action<ulong, ulong> Progress = null);

	Task CommandStore(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192u, Action<ulong, ulong> Progress = null);
}
