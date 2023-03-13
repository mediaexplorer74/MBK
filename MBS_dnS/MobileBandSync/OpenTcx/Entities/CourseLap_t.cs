using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200001C RID: 28
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class CourseLap_t
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001BE RID: 446 RVA: 0x000090D3 File Offset: 0x000072D3
		// (set) Token: 0x060001BF RID: 447 RVA: 0x000090DB File Offset: 0x000072DB
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

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x000090E4 File Offset: 0x000072E4
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x000090EC File Offset: 0x000072EC
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

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x000090F5 File Offset: 0x000072F5
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x000090FD File Offset: 0x000072FD
		public Position_t BeginPosition
		{
			get
			{
				return this.beginPositionField;
			}
			set
			{
				this.beginPositionField = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00009106 File Offset: 0x00007306
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000910E File Offset: 0x0000730E
		public double BeginAltitudeMeters
		{
			get
			{
				return this.beginAltitudeMetersField;
			}
			set
			{
				this.beginAltitudeMetersField = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00009117 File Offset: 0x00007317
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x0000911F File Offset: 0x0000731F
		[XmlIgnore]
		public bool BeginAltitudeMetersSpecified
		{
			get
			{
				return this.beginAltitudeMetersFieldSpecified;
			}
			set
			{
				this.beginAltitudeMetersFieldSpecified = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00009128 File Offset: 0x00007328
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00009130 File Offset: 0x00007330
		public Position_t EndPosition
		{
			get
			{
				return this.endPositionField;
			}
			set
			{
				this.endPositionField = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00009139 File Offset: 0x00007339
		// (set) Token: 0x060001CB RID: 459 RVA: 0x00009141 File Offset: 0x00007341
		public double EndAltitudeMeters
		{
			get
			{
				return this.endAltitudeMetersField;
			}
			set
			{
				this.endAltitudeMetersField = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001CC RID: 460 RVA: 0x0000914A File Offset: 0x0000734A
		// (set) Token: 0x060001CD RID: 461 RVA: 0x00009152 File Offset: 0x00007352
		[XmlIgnore]
		public bool EndAltitudeMetersSpecified
		{
			get
			{
				return this.endAltitudeMetersFieldSpecified;
			}
			set
			{
				this.endAltitudeMetersFieldSpecified = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001CE RID: 462 RVA: 0x0000915B File Offset: 0x0000735B
		// (set) Token: 0x060001CF RID: 463 RVA: 0x00009163 File Offset: 0x00007363
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

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x0000916C File Offset: 0x0000736C
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x00009174 File Offset: 0x00007374
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

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000917D File Offset: 0x0000737D
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x00009185 File Offset: 0x00007385
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

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000918E File Offset: 0x0000738E
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x00009196 File Offset: 0x00007396
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

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x0000919F File Offset: 0x0000739F
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x000091A7 File Offset: 0x000073A7
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

		// Token: 0x040000A9 RID: 169
		private double totalTimeSecondsField;

		// Token: 0x040000AA RID: 170
		private double distanceMetersField;

		// Token: 0x040000AB RID: 171
		private Position_t beginPositionField;

		// Token: 0x040000AC RID: 172
		private double beginAltitudeMetersField;

		// Token: 0x040000AD RID: 173
		private bool beginAltitudeMetersFieldSpecified;

		// Token: 0x040000AE RID: 174
		private Position_t endPositionField;

		// Token: 0x040000AF RID: 175
		private double endAltitudeMetersField;

		// Token: 0x040000B0 RID: 176
		private bool endAltitudeMetersFieldSpecified;

		// Token: 0x040000B1 RID: 177
		private HeartRateInBeatsPerMinute_t averageHeartRateBpmField;

		// Token: 0x040000B2 RID: 178
		private HeartRateInBeatsPerMinute_t maximumHeartRateBpmField;

		// Token: 0x040000B3 RID: 179
		private Intensity_t intensityField;

		// Token: 0x040000B4 RID: 180
		private byte cadenceField;

		// Token: 0x040000B5 RID: 181
		private bool cadenceFieldSpecified;
	}
}
