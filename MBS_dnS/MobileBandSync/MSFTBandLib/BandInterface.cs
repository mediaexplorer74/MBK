using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Metrics;
using Windows.Devices.Bluetooth;
using Windows.Storage.Streams;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x0200005D RID: 93
	public interface BandInterface
	{
		// Token: 0x06000354 RID: 852
		string GetMac();

		// Token: 0x06000355 RID: 853
		string GetName();

		// Token: 0x06000356 RID: 854
		BluetoothDevice GetDevice();

		// Token: 0x06000357 RID: 855
		Task Connect(Action<ulong, ulong> Progress = null);

		// Token: 0x06000358 RID: 856
		Task Disconnect();

		// Token: 0x06000359 RID: 857
		Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, Action<ulong, ulong> Progress = null);

		// Token: 0x0600035A RID: 858
		Task CommandStore(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs, uint uiBufferSize = 8192U, Action<ulong, ulong> Progress = null);

		// Token: 0x0600035B RID: 859
		Task<DateTime> GetDeviceTime();

		// Token: 0x0600035C RID: 860
		Task<Sleep> GetLastSleep();

		// Token: 0x0600035D RID: 861
		Task<string> GetSerialNumber();

		// Token: 0x0600035E RID: 862
		Task<BandVersion> GetVersion();

		// Token: 0x0600035F RID: 863
		Task<byte[]> GetSensorLog(Action<string> Report, Action<ulong, ulong> Progress, bool bCleanupSensorLog, bool bStoreSensorLog);

		// Token: 0x06000360 RID: 864
		Task<bool> DeleteChunkRange(BandMetadataRange metaData);

		// Token: 0x06000361 RID: 865
		DataReader GetDataReader();

		// Token: 0x06000362 RID: 866
		DataWriter GetDataWriter();
	}
}
