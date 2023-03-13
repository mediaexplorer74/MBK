using System;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Command;

public class CommandPacket
{
	protected CommandEnum Command;

	protected byte[] args;

	protected Func<uint> CmdBufferSize;

	public CommandPacket(CommandEnum command, Func<uint> BufferSize, byte[] args = null)
	{
		Command = command;
		CmdBufferSize = BufferSize;
		if (args != null)
		{
			this.args = args;
		}
		else
		{
			this.args = GetCommandDefaultArgumentsBytes();
		}
	}

	public int GetCommandDataSize()
	{
		if (CmdBufferSize != null)
		{
			return CommandHelper.GetCommandDataSize(CmdBufferSize);
		}
		return CommandHelper.GetCommandDataSize(Command);
	}

	public byte[] GetArgsSizeBytes()
	{
		return new byte[1] { (byte)(8 + args.Length) };
	}

	public byte[] GetCommandDefaultArgumentsBytes()
	{
		if (CmdBufferSize != null)
		{
			return CommandHelper.GetCommandDefaultArgumentsBytes(CmdBufferSize);
		}
		return CommandHelper.GetCommandDefaultArgumentsBytes(Command);
	}

	public byte[] GetBytes()
	{
		ByteStream byteStream = new ByteStream();
		byteStream.BinaryWriter.Write(GetArgsSizeBytes());
		byteStream.BinaryWriter.Write((ushort)12025);
		byteStream.BinaryWriter.Write((ushort)Command);
		byteStream.BinaryWriter.Write(GetCommandDataSize());
		byteStream.BinaryWriter.Write(args);
		return byteStream.GetBytes();
	}
}
