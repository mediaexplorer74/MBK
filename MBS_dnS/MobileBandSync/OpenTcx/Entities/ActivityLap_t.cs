using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000042 RID: 66
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class ActivityLap_t
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00009664 File Offset: 0x00007864
		// (set) Token: 0x06000282 RID: 642 RVA: 0x0000966C File Offset: 0x0000786C
		public double TotalTimeSeconds
		{
			get
			{
				return this.totalTimeSecondsField;
			}
			set
			{
				this.totalTimeSecondsField = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00009675 File Offset: 0x00007875
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0000967D File Offset: 0x0000787D
		public double DistanceMeters
		{
			get
			{
				return this.distanceMetersField;
			}
			set
			{
				this.distanceMetersField = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00009686 File Offset: 0x00007886
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0000968E File Offset: 0x0000788E
		public double MaximumSpeed
		{
			get
			{
				return this.maximumSpeedField;
			}
			set
			{
				this.maximumSpeedField = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000287 RID: 647 RVA: 0x00009697 File Offset: 0x00007897
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0000969F File Offset: 0x0000789F
		[XmlIgnore]
		public bool MaximumSpeedSpecified
		{
			get
			{
				return this.maximumSpeedFieldSpecified;
			}
			set
			{
				this.maximumSpeedFieldSpecified = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000289 RID: 649 RVA: 0x000096A8 File Offset: 0x000078A8
		// (set) Token: 0x0600028A RID: 650 RVA: 0x000096B0 File Offset: 0x000078B0
		public ushort Calories
		{
			get
			{
				return this.caloriesField;
			}
			set
			{
				this.caloriesField = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000096B9 File Offset: 0x000078B9
		// (set) Token: 0x0600028C RID: 652 RVA: 0x000096C1 File Offset: 0x000078C1
		public HeartRateInBeatsPerMinute_t AverageHeartRateBpm
		{
			get
			{
				return this.averageHeartRateBpmField;
			}
			set
			{
				this.averageHeartRateBpmField = value;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000096CA File Offset: 0x000078CA
		// (set) Token: 0x0600028E RID: 654 RVA: 0x000096D2 File Offset: 0x000078D2
		public HeartRateInBeatsPerMinute_t MaximumHeartRateBpm
		{
			get
			{
				return this.maximumHeartRateBpmField;
			}
			set
			{
				this.maximumHeartRateBpmField = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600028F RID: 655 RVA: 0x000096DB File Offset: 0x000078DB
		// (set) Token: 0x06000290 RID: 656 RVA: 0x000096E3 File Offset: 0x000078E3
		public Intensity_t Intensity
		{
			get
			{
				return this.intensityField;
			}
			set
			{
				this.intensityField = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000291 RID: 657 RVA: 0x000096EC File Offset: 0x000078EC
		// (set) Token: 0x06000292 RID: 658 RVA: 0x000096F4 File Offset: 0x000078F4
		public byte Cadence
		{
			get
			{
				return this.cadenceField;
			}
			set
			{
				this.cadenceField = value;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000293 RID: 659 RVA: 0x000096FD File Offset: 0x000078FD
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00009705 File Offset: 0x00007905
		[XmlIgnore]
		public bool CadenceSpecified
		{
			get
			{
				return this.cadenceFieldSpecified;
			}
			set
			{
				this.cadenceFieldSpecified = value;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000970E File Offset: 0x0000790E
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00009716 File Offset: 0x00007916
		public TriggerMethod_t TriggerMethod
		{
			get
			{
				return this.triggerMethodField;
			}
			set
			{
				this.triggerMethodField = value;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000971F File Offset: 0x0000791F
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00009727 File Offset: 0x00007927
		[XmlArrayItem("Trackpoint", typeof(Trackpoint_t), IsNullable = false)]
		public Trackpoint_t[] Track
		{
			get
			{
				return this.trackField;
			}
			set
			{
				this.trackField = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00009730 File Offset: 0x00007930
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00009738 File Offset: 0x00007938
		public string Notes
		{
			get
			{
				return this.notesField;
			}
			set
			{
				this.notesField = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00009741 File Offset: 0x00007941
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00009749 File Offset: 0x00007949
		[XmlAttribute]
		public DateTime StartTime
		{
			get
			{
				return this.startTimeField;
			}
			set
			{
				this.startTimeField = value;
			}
		}

		// Token: 0x0400010C RID: 268
		private double totalTimeSecondsField;

		// Token: 0x0400010D RID: 269
		private double distanceMetersField;

		// Token: 0x0400010E RID: 270
		private double maximumSpeedField;

		// Token: 0x0400010F RID: 271
		private bool maximumSpeedFieldSpecified;

		// Token: 0x04000110 RID: 272
		private ushort caloriesField;

		// Token: 0x04000111 RID: 273
		private HeartRateInBeatsPerMinute_t averageHeartRateBpmField;

		// Token: 0x04000112 RID: 274
		private HeartRateInBeatsPerMinute_t maximumHeartRateBpmField;

		// Token: 0x04000113 RID: 275
		private Intensity_t intensityField;

		// Token: 0x04000114 RID: 276
		private byte cadenceField;

		// Token: 0x04000115 RID: 277
		private bool cadenceFieldSpecified;

		// Token: 0x04000116 RID: 278
		private TriggerMethod_t triggerMethodField;

		// Token: 0x04000117 RID: 279
		private Trackpoint_t[] trackField;

		// Token: 0x04000118 RID: 280
		private string notesField;

		// Token: 0x04000119 RID: 281
		private DateTime startTimeField;
	}
}
