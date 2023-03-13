using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000058 RID: 88
	public interface BandConnectionInterface : IDisposable
	{
		// Token: 0x0600033F RID: 831
		Task Connect(BandInterface Band);

		// Token: 0x06000340 RID: 832
		Task Disconnect();

		// Token: 0x06000341 RID: 833
		Task<CommandResponse> Command(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192U, Action<ulong, ulong> Progress = null);

		// Token: 0x06000342 RID: 834
		Task CommandStore(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192U, Action<ulong, ulong> Progress = null);
	}
}
