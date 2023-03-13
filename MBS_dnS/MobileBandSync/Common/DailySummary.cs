using System;

namespace MobileBandSync.Common
{
	// Token: 0x02000098 RID: 152
	public class DailySummary
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000E78E File Offset: 0x0000C98E
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0000E796 File Offset: 0x0000C996
		public uint Flag { get; set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x0000E79F File Offset: 0x0000C99F
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x0000E7A7 File Offset: 0x0000C9A7
		public DateTime Date { get; set; }
	}
}
