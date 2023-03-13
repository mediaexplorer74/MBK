using System;
using System.Text;

namespace MobileBandSync.MSFTBandLib;

internal static class BandBitConverter
{
	private static readonly char[] HexCharTable = "0123456789ABCDEF".ToCharArray();

	public static void GetBytes(short i, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 2)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		for (int j = 0; j < 16; j += 8)
		{
			buffer[offset++] = (byte)((uint)(i >> j) & 0xFFu);
		}
	}

	public static void GetBytes(ushort i, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 2)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		for (int j = 0; j < 16; j += 8)
		{
			buffer[offset++] = (byte)((uint)(i >> j) & 0xFFu);
		}
	}

	public static void GetBytes(int i, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 4)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		for (int j = 0; j < 32; j += 8)
		{
			buffer[offset++] = (byte)((uint)(i >> j) & 0xFFu);
		}
	}

	public static void GetBytes(uint i, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 4)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		for (int j = 0; j < 32; j += 8)
		{
			buffer[offset++] = (byte)((i >> j) & 0xFFu);
		}
	}

	public static void GetBytes(long i, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 8)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		for (int j = 0; j < 64; j += 8)
		{
			buffer[offset++] = (byte)((i >> j) & 0xFF);
		}
	}

	public static void GetBytes(ulong i, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 8)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		for (int j = 0; j < 64; j += 8)
		{
			buffer[offset++] = (byte)((i >> j) & 0xFF);
		}
	}

	public static Guid ToGuid(byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 16)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (buffer.Length == 16)
		{
			return new Guid(buffer);
		}
		return new Guid(BitConverter.ToInt32(buffer, offset), BitConverter.ToInt16(buffer, offset + 4), BitConverter.ToInt16(buffer, offset + 6), buffer[offset + 8], buffer[offset + 9], buffer[offset + 10], buffer[offset + 11], buffer[offset + 12], buffer[offset + 13], buffer[offset + 14], buffer[offset + 15]);
	}

	public static void GetBytes(Guid guid, byte[] buffer, int offset)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || buffer.Length < offset + 16)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		guid.ToByteArray().CopyTo(buffer, offset);
	}

	public static string ToString(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		return ToStringInternal(buffer, 0, buffer.Length);
	}

	public static string ToString(byte[] buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0 || (buffer.Length != 0 && offset >= buffer.Length))
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (count < 0 || offset + count > buffer.Length)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return ToStringInternal(buffer, offset, count);
	}

	private static string ToStringInternal(byte[] buffer, int offset, int count)
	{
		StringBuilder stringBuilder = new StringBuilder(count * 2);
		while (count > 0)
		{
			byte b = buffer[offset];
			stringBuilder.Append(HexCharTable[(b >> 4) & 0xF]);
			stringBuilder.Append(HexCharTable[b & 0xF]);
			count--;
			offset++;
		}
		return stringBuilder.ToString();
	}
}
