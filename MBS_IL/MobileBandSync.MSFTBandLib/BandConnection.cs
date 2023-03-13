using System;
using System.Threading.Tasks;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Exceptions;

namespace MobileBandSync.MSFTBandLib;

public class BandConnection<T> : BandConnectionInterface, IDisposable where T : class, BandSocketInterface
{
	protected BandInterface Band;

	public readonly BandSocketInterface Cargo;

	public readonly BandSocketInterface Push;

	public bool Connected { get; protected set; }

	public bool Disposed { get; protected set; }

	public BandConnection()
	{
		Cargo = Activator.CreateInstance(typeof(T), new object[0]) as T;
		Push = Activator.CreateInstance(typeof(T), new object[0]) as T;
	}

	public BandConnection(BandInterface Band)
		: this()
	{
		this.Band = Band;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!Disposed)
		{
			Cargo.Dispose();
			Push.Dispose();
			Disposed = true;
		}
	}

	public async Task Connect(Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			Connected = true;
			string mac = Band.GetMac();
			await Cargo.Connect(mac, Guid.Parse("a502ca97-2ba5-413c-a4e0-13804e47b38f"), Progress);
			return;
		}
		throw new BandConnectionConnected();
	}

	public async Task Connect(BandInterface Band)
	{
		if (!Connected)
		{
			this.Band = Band;
			await Connect();
			return;
		}
		throw new BandConnectionConnected();
	}

	public async Task Disconnect()
	{
		if (Connected)
		{
			await Cargo.Disconnect();
			await Push.Disconnect();
			Connected = false;
			return;
		}
		throw new BandConnectionConnectedNot();
	}

	public async Task<CommandResponse> Command(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192u, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectionConnectedNot();
		}
		CommandPacket packet = new CommandPacket(command, BufferSize, args);
		return await Cargo.Request(packet, buffer, Progress);
	}

	public async Task CommandStore(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192u, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectionConnectedNot();
		}
		CommandPacket packet = new CommandPacket(command, BufferSize);
		await Cargo.Send(packet, args);
	}

	public async Task<CommandResponse> CommandStoreStatus(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 8192u, Action<ulong, ulong> Progress = null)
	{
		if (!Connected)
		{
			throw new BandConnectionConnectedNot();
		}
		CommandPacket packet = new CommandPacket(command, BufferSize);
		return await Cargo.Request(packet, buffer, Progress);
	}
}
