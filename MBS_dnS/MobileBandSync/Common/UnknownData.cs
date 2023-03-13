using System;

namespace MobileBandSync.Common
{
	// Token: 0x0200009A RID: 154
	public class UnknownData
	{
		// Token: 0x060005BA RID: 1466 RVA: 0x0000E7D4 File Offset: 0x0000C9D4
		public UnknownData(int iID, byte[] buffer, int iLength)
		{
			this.ID = iID;
			this.Content = new byte[iLength];
			buffer.CopyTo(this.Content, 0);
			this.ValueInt16 = new int[100];
			this.ValueInt32 = new int[100];
			int num = 0;
			for (int i = 0; i < iLength; i += 2)
			{
				if (i + 1 >= iLength)
				{
					this.ValueInt16[num] = (int)buffer[i];
				}
				else
				{
					this.ValueInt16[num] = (int)BitConverter.ToInt16(buffer, i);
				}
				if (i + 3 < iLength)
				{
					this.ValueInt32[num] = BitConverter.ToInt32(buffer, i);
				}
				num++;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0000E86A File Offset: 0x0000CA6A
		public byte[] Content { get; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000E872 File Offset: 0x0000CA72
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x0000E87A File Offset: 0x0000CA7A
		public int ID { get; set; }

		// Token: 0x040003CD RID: 973
		public int[] ValueInt16;

		// Token: 0x040003CE RID: 974
		public int[] ValueInt32;
	}
}
