using System;

namespace MobileBandSync.Common
{
	// Token: 0x0200009D RID: 157
	public class WorkoutPoint
	{
		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0000EA42 File Offset: 0x0000CC42
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x0000EA4A File Offset: 0x0000CC4A
		public DateTime Time { get; set; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x0000EA53 File Offset: 0x0000CC53
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x0000EA5B File Offset: 0x0000CC5B
		public int HeartRateBpm { get; set; }

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0000EA64 File Offset: 0x0000CC64
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0000EA6C File Offset: 0x0000CC6C
		public GpsPosition Position { get; set; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0000EA75 File Offset: 0x0000CC75
		// (set) Token: 0x060005E2 RID: 1506 RVA: 0x0000EA7D File Offset: 0x0000CC7D
		public double Elevation { get; set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x0000EA86 File Offset: 0x0000CC86
		// (set) Token: 0x060005E4 RID: 1508 RVA: 0x0000EA8E File Offset: 0x0000CC8E
		public uint GalvanicSkinResponse { get; set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0000EA97 File Offset: 0x0000CC97
		// (set) Token: 0x060005E6 RID: 1510 RVA: 0x0000EA9F File Offset: 0x0000CC9F
		public double SkinTemperature { get; set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000EAA8 File Offset: 0x0000CCA8
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000EAB0 File Offset: 0x0000CCB0
		public uint Cadence { get; set; }
	}
}
