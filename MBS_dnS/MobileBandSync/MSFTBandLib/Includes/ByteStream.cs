using System;
using System.IO;

namespace MobileBandSync.MSFTBandLib.Includes
{
	// Token: 0x0200006B RID: 107
	public class ByteStream : IDisposable
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x0000B939 File Offset: 0x00009B39
		// (set) Token: 0x060003B4 RID: 948 RVA: 0x0000B941 File Offset: 0x00009B41
		public bool Disposed { get; protected set; }

		// Token: 0x060003B5 RID: 949 RVA: 0x0000B94A File Offset: 0x00009B4A
		public ByteStream()
		{
			this.MemoryStream = new MemoryStream();
			this.BinaryReader = new BinaryReader(this.MemoryStream);
			this.BinaryWriter = new BinaryWriter(this.MemoryStream);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000B97F File Offset: 0x00009B7F
		public ByteStream(byte[] bytes) : this()
		{
			this.Write(bytes);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000B98E File Offset: 0x00009B8E
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000B99D File Offset: 0x00009B9D
		protected virtual void Dispose(bool disposing)
		{
			if (!this.Disposed)
			{
				this.BinaryReader.Dispose();
				this.BinaryWriter.Dispose();
				this.MemoryStream.Dispose();
				this.Disposed = true;
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000B9CF File Offset: 0x00009BCF
		public void Write(byte[] bytes)
		{
			this.BinaryWriter.Write(bytes);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000B9DD File Offset: 0x00009BDD
		public byte[] GetBytes()
		{
			return this.MemoryStream.ToArray();
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000B9EA File Offset: 0x00009BEA
		public uint GetUint32(int position = 0)
		{
			this.BinaryReader.BaseStream.Position = (long)position;
			return this.BinaryReader.ReadUInt32();
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000BA09 File Offset: 0x00009C09
		public ulong GetUint64(int position = 0)
		{
			this.BinaryReader.BaseStream.Position = (long)position;
			return this.BinaryReader.ReadUInt64();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000BA28 File Offset: 0x00009C28
		public string GetString(int position = 0, long chars = 0L)
		{
			if (chars == 0L)
			{
				chars = this.BinaryReader.BaseStream.Length;
			}
			this.BinaryReader.BaseStream.Position = (long)position;
			return new string(this.BinaryReader.ReadChars((int)chars));
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000BA63 File Offset: 0x00009C63
		public byte GetByte(int position = 0)
		{
			this.BinaryReader.BaseStream.Position = (long)position;
			return this.BinaryReader.ReadByte();
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000BA82 File Offset: 0x00009C82
		public ushort GetUshort(int position = 0)
		{
			this.BinaryReader.BaseStream.Position = (long)position;
			return this.BinaryReader.ReadUInt16();
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0000BAA4 File Offset: 0x00009CA4
		public ushort[] GetUshorts(int count, int pos = 0)
		{
			ushort[] array = new ushort[count];
			for (int i = 0; i < count; i++)
			{
				pos = ((i == 0) ? pos : (pos + 2));
				array[i] = this.GetUshort(pos);
			}
			return array;
		}

		// Token: 0x04000227 RID: 551
		public MemoryStream MemoryStream;

		// Token: 0x04000228 RID: 552
		public BinaryReader BinaryReader;

		// Token: 0x04000229 RID: 553
		public BinaryWriter BinaryWriter;
	}
}
