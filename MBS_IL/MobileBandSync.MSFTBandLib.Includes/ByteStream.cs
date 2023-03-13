using System;
using System.IO;

namespace MobileBandSync.MSFTBandLib.Includes;

public class ByteStream : IDisposable
{
	public MemoryStream MemoryStream;

	public BinaryReader BinaryReader;

	public BinaryWriter BinaryWriter;

	public bool Disposed { get; protected set; }

	public ByteStream()
	{
		MemoryStream = new MemoryStream();
		BinaryReader = new BinaryReader(MemoryStream);
		BinaryWriter = new BinaryWriter(MemoryStream);
	}

	public ByteStream(byte[] bytes)
		: this()
	{
		Write(bytes);
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
			BinaryReader.Dispose();
			BinaryWriter.Dispose();
			MemoryStream.Dispose();
			Disposed = true;
		}
	}

	public void Write(byte[] bytes)
	{
		BinaryWriter.Write(bytes);
	}

	public byte[] GetBytes()
	{
		return MemoryStream.ToArray();
	}

	public uint GetUint32(int position = 0)
	{
		BinaryReader.BaseStream.Position = position;
		return BinaryReader.ReadUInt32();
	}

	public ulong GetUint64(int position = 0)
	{
		BinaryReader.BaseStream.Position = position;
		return BinaryReader.ReadUInt64();
	}

	public string GetString(int position = 0, long chars = 0L)
	{
		if (chars == 0L)
		{
			chars = BinaryReader.BaseStream.Length;
		}
		BinaryReader.BaseStream.Position = position;
		return new string(BinaryReader.ReadChars((int)chars));
	}

	public byte GetByte(int position = 0)
	{
		BinaryReader.BaseStream.Position = position;
		return BinaryReader.ReadByte();
	}

	public ushort GetUshort(int position = 0)
	{
		BinaryReader.BaseStream.Position = position;
		return BinaryReader.ReadUInt16();
	}

	public ushort[] GetUshorts(int count, int pos = 0)
	{
		ushort[] array = new ushort[count];
		for (int i = 0; i < count; i++)
		{
			pos = ((i == 0) ? pos : (pos + 2));
			array[i] = GetUshort(pos);
		}
		return array;
	}
}
