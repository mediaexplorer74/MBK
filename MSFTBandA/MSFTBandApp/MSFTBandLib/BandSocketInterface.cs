using System;
using System.Threading.Tasks;
using MSFTBandLib.Command;

namespace MSFTBandLib {

/// <summary>
/// Band socket interface
/// </summary>
public interface BandSocketInterface : IDisposable {

	/// <summary>Connect to a Band.</summary>
	/// <param name="mac">Band address</param>
	/// <param name="uuid">RFCOMM service UUID</param>
	/// <returns>Task</returns>
	Task Connect(string mac, Guid uuid);

	/// <summary>Close the connection.</summary>
	/// <returns>Task</returns>
	Task Disconnect();

	/// <summary>Send a command packet to the device.</summary>
	/// <param name="packet">Command packet</param>
	/// <returns>Task</returns>
	Task Send(CommandPacket packet);

	/// <summary>
	/// Receive bytes up to a specified buffer size.
	/// 
	/// Receives and adds bytes to a single `CommandResponse` 
	/// 	object until no more bytes are received or a 
	/// 	Band status has been received (indicating end of data).
	/// </summary>
	/// <param name="buffer">buffer</param>
	/// <returns>Task<CommandResponse></returns>
	Task<CommandResponse> Receive(uint buffer);

	/// <summary>
	/// Send command packet to device and get a response.
	/// 
	/// Refer to `Send(...)` and `Receive(...)`.
	/// </summary>
	/// <param name="packet">Command packet</param>
	/// <param name="buffer">Buffer size to receive from</param>
	/// <returns>Task<CommandResponse></returns>
	Task<CommandResponse> Request(CommandPacket packet, uint buffer);

}

}