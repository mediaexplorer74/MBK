using System;

namespace MobileBandSync.MSFTBandLib.Command
{
	// Token: 0x02000074 RID: 116
	public class CommandDataSize : Attribute
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x0000BB67 File Offset: 0x00009D67
		// (set) Token: 0x060003CA RID: 970 RVA: 0x0000BB6F File Offset: 0x00009D6F
		public int DataSize { get; protected set; }

		// Token: 0x060003CB RID: 971 RVA: 0x0000BB78 File Offset: 0x00009D78
		public CommandDataSize(int DataSize)
		{
			this.DataSize = DataSize;
		}
	}
}
