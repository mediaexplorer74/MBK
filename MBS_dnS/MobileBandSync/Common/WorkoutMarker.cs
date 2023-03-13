using System;

namespace MobileBandSync.Common
{
	// Token: 0x0200008E RID: 142
	public class WorkoutMarker
	{
		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x0000E34E File Offset: 0x0000C54E
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x0000E356 File Offset: 0x0000C556
		public DistanceAnnotationType Action { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x0000E35F File Offset: 0x0000C55F
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x0000E367 File Offset: 0x0000C567
		public EventType WorkoutType { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x0000E370 File Offset: 0x0000C570
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x0000E378 File Offset: 0x0000C578
		public int Value2 { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x0000E381 File Offset: 0x0000C581
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x0000E389 File Offset: 0x0000C589
		public DateTime TimeStamp { get; set; }
	}
}
