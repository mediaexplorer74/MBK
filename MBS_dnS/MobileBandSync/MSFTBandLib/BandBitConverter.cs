using System;
using System.Text;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x0200005B RID: 91
	internal static class BandBitConverter
	{
		// Token: 0x06000345 RID: 837 RVA: 0x0000A57C File Offset: 0x0000877C
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
				buffer[offset++] = (byte)(i >> j & 255);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000A5D0 File Offset: 0x000087D0
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
				buffer[offset++] = (byte)(i >> j & 255);
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000A624 File Offset: 0x00008824
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
				buffer[offset++] = (byte)(i >> j & 255);
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000A678 File Offset: 0x00008878
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
				buffer[offset++] = (byte)(i >> j & 255U);
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000A6CC File Offset: 0x000088CC
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
				buffer[offset++] = (byte)(i >> j & 255L);
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000A724 File Offset: 0x00008924
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
				buffer[offset++] = (byte)(i >> j & 255UL);
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000A77C File Offset: 0x0000897C
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

		// Token: 0x0600034C RID: 844 RVA: 0x0000A80A File Offset: 0x00008A0A
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

		// Token: 0x0600034D RID: 845 RVA: 0x0000A840 File Offset: 0x00008A40
		public static string ToString(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			return BandBitConverter.ToStringInternal(buffer, 0, buffer.Length);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000A85C File Offset: 0x00008A5C
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
			return BandBitConverter.ToStringInternal(buffer, offset, count);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000A8B0 File Offset: 0x00008AB0
		private static string ToStringInternal(byte[] buffer, int offset, int count)
		{
			StringBuilder stringBuilder = new StringBuilder(count * 2);
			while (count > 0)
			{
				byte b = buffer[offset];
				stringBuilder.Append(BandBitConverter.HexCharTable[b >> 4 & 15]);
				stringBuilder.Append(BandBitConverter.HexCharTable[(int)(b & 15)]);
				count--;
				offset++;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400015E RID: 350
		private static readonly char[] HexCharTable = "0123456789ABCDEF".ToCharArray();
	}
}
