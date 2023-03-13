using System;

namespace MobileBandSync.Common
{
	// Token: 0x02000090 RID: 144
	public class SleepSummary
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0000E3C5 File Offset: 0x0000C5C5
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x0000E3CD File Offset: 0x0000C5CD
		public DateTime StartDate { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0000E3D6 File Offset: 0x0000C5D6
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x0000E3DE File Offset: 0x0000C5DE
		public TimeSpan Duration { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000E3E7 File Offset: 0x0000C5E7
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x0000E3EF File Offset: 0x0000C5EF
		public double TimesAwoke { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000E3F8 File Offset: 0x0000C5F8
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x0000E400 File Offset: 0x0000C600
		public TimeSpan TotalRestlessSleepDuration { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0000E409 File Offset: 0x0000C609
		// (set) Token: 0x0600053F RID: 1343 RVA: 0x0000E411 File Offset: 0x0000C611
		public int CaloriesBurned { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x0000E41A File Offset: 0x0000C61A
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x0000E422 File Offset: 0x0000C622
		public int HFAverage { get; set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0000E42B File Offset: 0x0000C62B
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0000E433 File Offset: 0x0000C633
		public int HFMax { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x0000E43C File Offset: 0x0000C63C
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x0000E444 File Offset: 0x0000C644
		public DateTime IntermediateDate { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0000E44D File Offset: 0x0000C64D
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x0000E455 File Offset: 0x0000C655
		public TimeSpan FallAsleepTime { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x0000E45E File Offset: 0x0000C65E
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x0000E466 File Offset: 0x0000C666
		public uint Feeling { get; set; }

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x0000E46F File Offset: 0x0000C66F
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x0000E477 File Offset: 0x0000C677
		public double Version { get; internal set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0000E480 File Offset: 0x0000C680
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x0000E488 File Offset: 0x0000C688
		public TimeSpan TotalRestfulSleepDuration { get; internal set; }
	}
}
