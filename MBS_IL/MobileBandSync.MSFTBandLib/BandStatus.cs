using System;
using System.IO;

namespace MobileBandSync.MSFTBandLib;

public class BandStatus
{
	private const int serializedByteCount = 6;

	public ushort PacketType { get; private set; }

	public uint Status { get; private set; }

	private BandStatus()
	{
	}

	public static int GetSerializedByteCount()
	{
		return 12;
	}

	public static BandStatus DeserializeFromBytes(byte[] data)
	{
		return new BandStatus
		{
			PacketType = BitConverter.ToUInt16(data, 0),
			Status = BitConverter.ToUInt32(data, 2)
		};
	}

	internal void SerializeToBytes(ref byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream(GetSerializedByteCount());
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(PacketType);
		binaryWriter.Write(Status);
		data = memoryStream.ToArray();
	}

	internal byte[] SerializeToByteArray()
	{
		int num = 0;
		byte[] array = new byte[BandMetadataRange.GetSerializedByteCount()];
		BandBitConverter.GetBytes(PacketType, array, num);
		num += 2;
		BandBitConverter.GetBytes(Status, array, num);
		return array;
	}
}
