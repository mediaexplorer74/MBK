namespace MobileBandSync.MSFTBandLib
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.Devices.Bluetooth;
    using Windows.Storage.Streams;

    public interface BandInterface
    {
        Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, Action<ulong, ulong> Progress = null);
        Task CommandStore(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs, uint uiBufferSize = 0x2000, Action<ulong, ulong> Progress = null);
        Task Connect(Action<ulong, ulong> Progress = null);
        Task<bool> DeleteChunkRange(BandMetadataRange metaData);
        Task Disconnect();
        DataReader GetDataReader();
        DataWriter GetDataWriter();
        BluetoothDevice GetDevice();
        Task<DateTime> GetDeviceTime();
        Task<Sleep> GetLastSleep();
        string GetMac();
        string GetName();
        Task<byte[]> GetSensorLog(Action<string> Report, Action<ulong, ulong> Progress, bool bCleanupSensorLog, bool bStoreSensorLog);
        Task<string> GetSerialNumber();
        Task<BandVersion> GetVersion();
    }
}

