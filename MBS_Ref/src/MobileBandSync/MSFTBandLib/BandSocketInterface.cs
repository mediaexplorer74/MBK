namespace MobileBandSync.MSFTBandLib
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.Storage.Streams;

    public interface BandSocketInterface : IDisposable
    {
        Task Connect(string mac, Guid uuid, Action<ulong, ulong> Progress = null);
        Task Disconnect();
        DataReader GetDataReader();
        DataWriter GetDataWriter();
        Task<CommandResponse> Receive(uint buffer, Action<ulong, ulong> Progress = null);
        Task<CommandResponse> Request(CommandPacket packet, uint buffer, Action<ulong, ulong> Progress = null);
        Task Send(CommandPacket packet);
        Task Send(CommandPacket packet, byte[] bytesToSend);
        Task<int> SendStatus(CommandPacket packet, byte[] bytesToSend);
    }
}

