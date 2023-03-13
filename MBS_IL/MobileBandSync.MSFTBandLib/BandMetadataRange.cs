using System;
using System.IO;

namespace MobileBandSync.MSFTBandLib;

public class BandMetadataRange
{
	private const int serializedByteCount = 12;

	public uint StartingSeqNumber { get; set; }

	public uint EndingSeqNumber { get; set; }

	public uint ByteCount { get; set; }

	private BandMetadataRange()
	{
	}

	public static int GetSerializedByteCount()
	{
		return 12;
	}

	public static BandMetadataRange DeserializeFromBytes(byte[] data)
	{
		return new BandMetadataRange
		{
			StartingSeqNumber = BitConverter.ToUInt32(data, 0),
			EndingSeqNumber = BitConverter.ToUInt32(data, 4),
			ByteCount = BitConverter.ToUInt32(data, 8)
		};
	}

	internal void SerializeToBytes(ref byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream(GetSerializedByteCount());
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(StartingSeqNumber);
		binaryWriter.Write(EndingSeqNumber);
		binaryWriter.Write(ByteCount);
		data = memoryStream.ToArray();
	}

	internal byte[] SerializeToByteArray()
	{
		int num = 0;
		byte[] array = new byte[GetSerializedByteCount()];
		BandBitConverter.GetBytes(StartingSeqNumber, array, num);
		num += 4;
		BandBitConverter.GetBytes(EndingSeqNumber, array, num);
		num += 4;
		BandBitConverter.GetBytes(ByteCount, array, num);
		return array;
	}
}
