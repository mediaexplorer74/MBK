using System;
using System.Reflection;
using MobileBandSync.MSFTBandLib.Facility;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Command;

public static class CommandHelper
{
	public static ushort Create(FacilityEnum facility, bool tx, int index)
	{
		return (ushort)(((int)facility << 8) | ((tx ? 1 : 0) << 7) | index);
	}

	public static int GetCommandDataSize(CommandEnum command)
	{
		Attribute customAttribute = typeof(CommandEnum).GetRuntimeField(command.ToString()).GetCustomAttribute(typeof(CommandDataSize));
		if (customAttribute == null)
		{
			return 8192;
		}
		return ((CommandDataSize)customAttribute).DataSize;
	}

	public static int GetCommandDataSize(Func<uint> BufferSize)
	{
		return (int)(BufferSize?.Invoke() ?? 8192);
	}

	public static byte[] GetCommandDefaultArgumentsBytes(CommandEnum command)
	{
		ByteStream byteStream = new ByteStream();
		byteStream.BinaryWriter.Write(GetCommandDataSize(command));
		return byteStream.GetBytes();
	}

	public static byte[] GetCommandDefaultArgumentsBytes(Func<uint> BufferSize)
	{
		byte[] result = null;
		if (BufferSize != null)
		{
			ByteStream byteStream = new ByteStream();
			byteStream.BinaryWriter.Write(BufferSize());
			result = byteStream.GetBytes();
		}
		return result;
	}
}
