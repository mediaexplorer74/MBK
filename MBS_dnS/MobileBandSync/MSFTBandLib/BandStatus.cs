using System;
using System.IO;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000054 RID: 84
	public class BandStatus
	{
		// Token: 0x06000307 RID: 775 RVA: 0x00008E70 File Offset: 0x00007070
		private BandStatus()
		{
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00009AF6 File Offset: 0x00007CF6
		// (set) Token: 0x06000309 RID: 777 RVA: 0x00009AFE File Offset: 0x00007CFE
		public ushort PacketType { get; private set; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00009B07 File Offset: 0x00007D07
		// (set) Token: 0x0600030B RID: 779 RVA: 0x00009B0F File Offset: 0x00007D0F
		public uint Status { get; private set; }

		// Token: 0x0600030C RID: 780 RVA: 0x00009A2D File Offset: 0x00007C2D
		public static int GetSerializedByteCount()
		{
			return 12;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00009B18 File Offset: 0x00007D18
		public static BandStatus DeserializeFromBytes(byte[] data)
		{
			return new BandStatus
			{
				PacketType = BitConverter.ToUInt16(data, 0),
				Status = BitConverter.ToUInt32(data, 2)
			};
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00009B3C File Offset: 0x00007D3C
		internal void SerializeToBytes(ref byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream(BandStatus.GetSerializedByteCount());
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.PacketType);
			binaryWriter.Write(this.Status);
			data = memoryStream.ToArray();
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00009B7C File Offset: 0x00007D7C
		internal byte[] SerializeToByteArray()
		{
			int num = 0;
			byte[] array = new byte[BandMetadataRange.GetSerializedByteCount()];
			BandBitConverter.GetBytes(this.PacketType, array, num);
			num += 2;
			BandBitConverter.GetBytes(this.Status, array, num);
			return array;
		}

		// Token: 0x04000151 RID: 337
		private const int serializedByteCount = 6;
	}
}
