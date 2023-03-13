using System;
using System.Collections.Generic;

namespace MobileBandSync.Common
{
	// Token: 0x0200009F RID: 159
	public class Workout
	{
		// Token: 0x060005ED RID: 1517 RVA: 0x0000EAD2 File Offset: 0x0000CCD2
		public Workout()
		{
			this.Type = EventType.Workout;
			this.TrackPoints = new List<WorkoutPoint>();
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0000EAED File Offset: 0x0000CCED
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0000EAF5 File Offset: 0x0000CCF5
		public DateTime StartTime { get; set; }

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0000EAFE File Offset: 0x0000CCFE
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x0000EB06 File Offset: 0x0000CD06
		public DateTime LastSplitTime { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x0000EB0F File Offset: 0x0000CD0F
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x0000EB17 File Offset: 0x0000CD17
		public DateTime EndTime { get; set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0000EB20 File Offset: 0x0000CD20
		public List<WorkoutPoint> TrackPoints { get; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000EB28 File Offset: 0x0000CD28
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0000EB30 File Offset: 0x0000CD30
		public int LastHR { get; set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0000EB39 File Offset: 0x0000CD39
		// (set) Token: 0x060005F8 RID: 1528 RVA: 0x0000EB41 File Offset: 0x0000CD41
		public string Notes { get; set; }

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0000EB4A File Offset: 0x0000CD4A
		// (set) Token: 0x060005FA RID: 1530 RVA: 0x0000EB52 File Offset: 0x0000CD52
		public EventType Type { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0000EB5B File Offset: 0x0000CD5B
		// (set) Token: 0x060005FC RID: 1532 RVA: 0x0000EB63 File Offset: 0x0000CD63
		public string TCXBuffer { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x0000EB6C File Offset: 0x0000CD6C
		// (set) Token: 0x060005FE RID: 1534 RVA: 0x0000EB74 File Offset: 0x0000CD74
		public string Filename { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x0000EB7D File Offset: 0x0000CD7D
		// (set) Token: 0x06000600 RID: 1536 RVA: 0x0000EB85 File Offset: 0x0000CD85
		public ulong Filesize { get; set; }

		// Token: 0x040003F1 RID: 1009
		public WorkoutSummary Summary;

		// Token: 0x040003F2 RID: 1010
		public SleepSummary SleepSummary;
	}
}
