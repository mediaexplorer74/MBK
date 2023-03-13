using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using Windows.Storage.Streams;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x0200005F RID: 95
	public interface BandSocketInterface : IDisposable
	{
		// Token: 0x0600036A RID: 874
		Task Connect(string mac, Guid uuid, Action<ulong, ulong> Progress = null);

		// Token: 0x0600036B RID: 875
		Task Disconnect();

		// Token: 0x0600036C RID: 876
		Task Send(CommandPacket packet);

		// Token: 0x0600036D RID: 877
		Task Send(CommandPacket packet, byte[] bytesToSend);

		// Token: 0x0600036E RID: 878
		Task<int> SendStatus(CommandPacket packet, byte[] bytesToSend);

		// Token: 0x0600036F RID: 879
		Task<CommandResponse> Receive(uint buffer, Action<ulong, ulong> Progress = null);

		// Token: 0x06000370 RID: 880
		Task<CommandResponse> Request(CommandPacket packet, uint buffer, Action<ulong, ulong> Progress = null);

		// Token: 0x06000371 RID: 881
		DataReader GetDataReader();

		// Token: 0x06000372 RID: 882
		DataWriter GetDataWriter();
	}
}
