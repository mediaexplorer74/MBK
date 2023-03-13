using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using Windows.Storage.Streams;

namespace MobileBandSync.MSFTBandLib;

public interface BandSocketInterface : IDisposable
{
	Task Connect(string mac, Guid uuid, Action<ulong, ulong> Progress = null);

	Task Disconnect();

	Task Send(CommandPacket packet);

	Task Send(CommandPacket packet, byte[] bytesToSend);

	Task<int> SendStatus(CommandPacket packet, byte[] bytesToSend);

	Task<CommandResponse> Receive(uint buffer, Action<ulong, ulong> Progress = null);

	Task<CommandResponse> Request(CommandPacket packet, uint buffer, Action<ulong, ulong> Progress = null);

	DataReader GetDataReader();

	DataWriter GetDataWriter();
}
