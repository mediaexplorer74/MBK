using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Metrics;
using Windows.Devices.Bluetooth;
using Windows.Storage.Streams;

namespace MobileBandSync.MSFTBandLib;

public interface BandInterface
{
	string GetMac();

	string GetName();

	BluetoothDevice GetDevice();

	Task Connect(Action<ulong, ulong> Progress = null);

	Task Disconnect();

	Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, Action<ulong, ulong> Progress = null);

	Task CommandStore(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs, uint uiBufferSize = 8192u, Action<ulong, ulong> Progress = null);

	Task<DateTime> GetDeviceTime();

	Task<Sleep> GetLastSleep();

	Task<string> GetSerialNumber();

	Task<BandVersion> GetVersion();

	Task<byte[]> GetSensorLog(Action<string> Report, Action<ulong, ulong> Progress, bool bCleanupSensorLog, bool bStoreSensorLog);

	Task<bool> DeleteChunkRange(BandMetadataRange metaData);

	DataReader GetDataReader();

	DataWriter GetDataWriter();
}
