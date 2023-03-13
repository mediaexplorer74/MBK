using System;

namespace MobileBandSync.Common
{
	// Token: 0x02000097 RID: 151
	public class WorkoutSummary
	{
		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000E65C File Offset: 0x0000C85C
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x0000E664 File Offset: 0x0000C864
		public DateTime StartDate { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0000E66D File Offset: 0x0000C86D
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x0000E675 File Offset: 0x0000C875
		public int UnknownValue1 { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0000E67E File Offset: 0x0000C87E
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x0000E686 File Offset: 0x0000C886
		public double Duration { get; set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x0000E68F File Offset: 0x0000C88F
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x0000E697 File Offset: 0x0000C897
		public double Distance { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000E6A0 File Offset: 0x0000C8A0
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x0000E6A8 File Offset: 0x0000C8A8
		public double AverageSpeed { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000E6B1 File Offset: 0x0000C8B1
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0000E6B9 File Offset: 0x0000C8B9
		public double MaximumSpeed { get; set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0000E6C2 File Offset: 0x0000C8C2
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x0000E6CA File Offset: 0x0000C8CA
		public int CaloriesBurned { get; set; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000E6D3 File Offset: 0x0000C8D3
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x0000E6DB File Offset: 0x0000C8DB
		public int HFAverage { get; set; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0000E6E4 File Offset: 0x0000C8E4
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x0000E6EC File Offset: 0x0000C8EC
		public int HFMax { get; set; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0000E6F5 File Offset: 0x0000C8F5
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x0000E6FD File Offset: 0x0000C8FD
		public DateTime IntermediateDate { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0000E706 File Offset: 0x0000C906
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0000E70E File Offset: 0x0000C90E
		public int UtcDiffHrs { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000E717 File Offset: 0x0000C917
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0000E71F File Offset: 0x0000C91F
		public double TotalElevation { get; set; }

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0000E728 File Offset: 0x0000C928
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0000E730 File Offset: 0x0000C930
		public int UnknownValue2 { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0000E739 File Offset: 0x0000C939
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0000E741 File Offset: 0x0000C941
		public int UnknownValue3 { get; set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0000E74A File Offset: 0x0000C94A
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0000E752 File Offset: 0x0000C952
		public int UnknownValue4 { get; set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0000E75B File Offset: 0x0000C95B
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x0000E763 File Offset: 0x0000C963
		public int UnknownValue5 { get; set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0000E76C File Offset: 0x0000C96C
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x0000E774 File Offset: 0x0000C974
		public int UnknownValue6 { get; set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0000E77D File Offset: 0x0000C97D
		// (set) Token: 0x060005AE RID: 1454 RVA: 0x0000E785 File Offset: 0x0000C985
		public int UnknownValue7 { get; set; }
	}
}
