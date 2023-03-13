using System;
using System.IO;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000053 RID: 83
	public class BandMetadataRange
	{
		// Token: 0x060002FC RID: 764 RVA: 0x00008E70 File Offset: 0x00007070
		private BandMetadataRange()
		{
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060002FD RID: 765 RVA: 0x000099FA File Offset: 0x00007BFA
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00009A02 File Offset: 0x00007C02
		public uint StartingSeqNumber { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00009A0B File Offset: 0x00007C0B
		// (set) Token: 0x06000300 RID: 768 RVA: 0x00009A13 File Offset: 0x00007C13
		public uint EndingSeqNumber { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00009A1C File Offset: 0x00007C1C
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00009A24 File Offset: 0x00007C24
		public uint ByteCount { get; set; }

		// Token: 0x06000303 RID: 771 RVA: 0x00009A2D File Offset: 0x00007C2D
		public static int GetSerializedByteCount()
		{
			return 12;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00009A31 File Offset: 0x00007C31
		public static BandMetadataRange DeserializeFromBytes(byte[] data)
		{
			return new BandMetadataRange
			{
				StartingSeqNumber = BitConverter.ToUInt32(data, 0),
				EndingSeqNumber = BitConverter.ToUInt32(data, 4),
				ByteCount = BitConverter.ToUInt32(data, 8)
			};
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00009A60 File Offset: 0x00007C60
		internal void SerializeToBytes(ref byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream(BandMetadataRange.GetSerializedByteCount());
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.StartingSeqNumber);
			binaryWriter.Write(this.EndingSeqNumber);
			binaryWriter.Write(this.ByteCount);
			data = memoryStream.ToArray();
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00009AAC File Offset: 0x00007CAC
		internal byte[] SerializeToByteArray()
		{
			int num = 0;
			byte[] array = new byte[BandMetadataRange.GetSerializedByteCount()];
			BandBitConverter.GetBytes(this.StartingSeqNumber, array, num);
			num += 4;
			BandBitConverter.GetBytes(this.EndingSeqNumber, array, num);
			num += 4;
			BandBitConverter.GetBytes(this.ByteCount, array, num);
			return array;
		}

		// Token: 0x0400014E RID: 334
		private const int serializedByteCount = 12;
	}
}
