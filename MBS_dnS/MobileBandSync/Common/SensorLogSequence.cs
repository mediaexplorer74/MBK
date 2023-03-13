using System;
using System.Collections.Generic;

namespace MobileBandSync.Common
{
	// Token: 0x0200009B RID: 155
	public class SensorLogSequence
	{
		// Token: 0x060005BE RID: 1470 RVA: 0x0000E884 File Offset: 0x0000CA84
		public SensorLogSequence(long lFileTime)
		{
			if (lFileTime > 0L)
			{
				this.TimeStamp = new DateTime?(DateTime.FromFileTime(lFileTime));
			}
			else
			{
				this.TimeStamp = new DateTime?(DateTime.MinValue);
			}
			this.HeartRates = new List<HeartRate>();
			this.Waypoints = new List<Waypoint>();
			this.AdditionalData = new List<UnknownData>();
			this.Counters = new List<Counter>();
			this.Temperatures = new List<SkinTemperature>();
			this.WorkoutMarkers = new List<WorkoutMarker>();
			this.WorkoutMarkers2 = new List<WorkoutMarker2>();
			this.SensorValues1 = new List<SensorValueCollection1>();
			this.SensorValues2 = new List<SensorValueCollection2>();
			this.SensorValues3 = new List<SensorValueCollection3>();
			this.StepSnapshots = new List<Steps>();
			this.SleepSummaries = new List<SleepSummary>();
			this.WorkoutSummaries = new List<WorkoutSummary>();
			this.DailySummaries = new List<DailySummary>();
			this.SensorList = new List<Sensor>();
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0000E964 File Offset: 0x0000CB64
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000E96C File Offset: 0x0000CB6C
		public DateTime? TimeStamp { get; set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000E975 File Offset: 0x0000CB75
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0000E97D File Offset: 0x0000CB7D
		public TimeSpan? Duration { get; set; }

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0000E986 File Offset: 0x0000CB86
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x0000E98E File Offset: 0x0000CB8E
		public int ID { get; set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0000E997 File Offset: 0x0000CB97
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0000E99F File Offset: 0x0000CB9F
		public int UtcOffset { get; set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0000E9A8 File Offset: 0x0000CBA8
		public List<HeartRate> HeartRates { get; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0000E9B0 File Offset: 0x0000CBB0
		public List<Waypoint> Waypoints { get; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000E9B8 File Offset: 0x0000CBB8
		public List<Counter> Counters { get; }

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x0000E9C0 File Offset: 0x0000CBC0
		public List<SkinTemperature> Temperatures { get; }

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000E9C8 File Offset: 0x0000CBC8
		public List<Sensor> SensorList { get; }

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x0000E9D0 File Offset: 0x0000CBD0
		public List<Steps> StepSnapshots { get; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000E9D8 File Offset: 0x0000CBD8
		public List<SleepSummary> SleepSummaries { get; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		public List<WorkoutMarker> WorkoutMarkers { get; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000E9E8 File Offset: 0x0000CBE8
		public List<WorkoutMarker2> WorkoutMarkers2 { get; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0000E9F0 File Offset: 0x0000CBF0
		public List<SensorValueCollection1> SensorValues1 { get; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0000E9F8 File Offset: 0x0000CBF8
		public List<SensorValueCollection2> SensorValues2 { get; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x0000EA00 File Offset: 0x0000CC00
		public List<SensorValueCollection3> SensorValues3 { get; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000EA08 File Offset: 0x0000CC08
		public List<UnknownData> AdditionalData { get; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0000EA10 File Offset: 0x0000CC10
		public List<WorkoutSummary> WorkoutSummaries { get; }

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0000EA18 File Offset: 0x0000CC18
		public List<DailySummary> DailySummaries { get; }
	}
}
