using System;

namespace MobileBandSync.Common
{
	// Token: 0x0200008D RID: 141
	public class Steps
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000E30A File Offset: 0x0000C50A
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x0000E312 File Offset: 0x0000C512
		public ushort SleepType { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000E31B File Offset: 0x0000C51B
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x0000E323 File Offset: 0x0000C523
		public ushort SegmentType { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000E32C File Offset: 0x0000C52C
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x0000E334 File Offset: 0x0000C534
		public uint Counter { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x0000E33D File Offset: 0x0000C53D
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x0000E345 File Offset: 0x0000C545
		public DateTime TimeStamp { get; set; }
	}
}
