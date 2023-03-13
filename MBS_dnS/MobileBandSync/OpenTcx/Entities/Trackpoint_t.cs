using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000022 RID: 34
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Trackpoint_t
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00009240 File Offset: 0x00007440
		// (set) Token: 0x060001EE RID: 494 RVA: 0x00009248 File Offset: 0x00007448
		public DateTime Time
		{
			get
			{
				return this.timeField;
			}
			set
			{
				this.timeField = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00009251 File Offset: 0x00007451
		// (set) Token: 0x060001F0 RID: 496 RVA: 0x00009259 File Offset: 0x00007459
		public Position_t Position
		{
			get
			{
				return this.positionField;
			}
			set
			{
				this.positionField = value;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x00009262 File Offset: 0x00007462
		// (set) Token: 0x060001F2 RID: 498 RVA: 0x0000926A File Offset: 0x0000746A
		public double AltitudeMeters
		{
			get
			{
				return this.altitudeMetersField;
			}
			set
			{
				this.altitudeMetersField = value;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00009273 File Offset: 0x00007473
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x0000927B File Offset: 0x0000747B
		[XmlIgnore]
		public bool AltitudeMetersSpecified
		{
			get
			{
				return this.altitudeMetersFieldSpecified;
			}
			set
			{
				this.altitudeMetersFieldSpecified = value;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00009284 File Offset: 0x00007484
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x0000928C File Offset: 0x0000748C
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

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00009295 File Offset: 0x00007495
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x0000929D File Offset: 0x0000749D
		[XmlIgnore]
		public bool DistanceMetersSpecified
		{
			get
			{
				return this.distanceMetersFieldSpecified;
			}
			set
			{
				this.distanceMetersFieldSpecified = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x000092A6 File Offset: 0x000074A6
		// (set) Token: 0x060001FA RID: 506 RVA: 0x000092AE File Offset: 0x000074AE
		public HeartRateInBeatsPerMinute_t HeartRateBpm
		{
			get
			{
				return this.heartRateBpmField;
			}
			set
			{
				this.heartRateBpmField = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001FB RID: 507 RVA: 0x000092B7 File Offset: 0x000074B7
		// (set) Token: 0x060001FC RID: 508 RVA: 0x000092BF File Offset: 0x000074BF
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

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001FD RID: 509 RVA: 0x000092C8 File Offset: 0x000074C8
		// (set) Token: 0x060001FE RID: 510 RVA: 0x000092D0 File Offset: 0x000074D0
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

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001FF RID: 511 RVA: 0x000092D9 File Offset: 0x000074D9
		// (set) Token: 0x06000200 RID: 512 RVA: 0x000092E1 File Offset: 0x000074E1
		public SensorState_t SensorState
		{
			get
			{
				return this.sensorStateField;
			}
			set
			{
				this.sensorStateField = value;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000092EA File Offset: 0x000074EA
		// (set) Token: 0x06000202 RID: 514 RVA: 0x000092F2 File Offset: 0x000074F2
		[XmlIgnore]
		public bool SensorStateSpecified
		{
			get
			{
				return this.sensorStateFieldSpecified;
			}
			set
			{
				this.sensorStateFieldSpecified = value;
			}
		}

		// Token: 0x040000C1 RID: 193
		private DateTime timeField;

		// Token: 0x040000C2 RID: 194
		private Position_t positionField;

		// Token: 0x040000C3 RID: 195
		private double altitudeMetersField;

		// Token: 0x040000C4 RID: 196
		private bool altitudeMetersFieldSpecified;

		// Token: 0x040000C5 RID: 197
		private double distanceMetersField;

		// Token: 0x040000C6 RID: 198
		private bool distanceMetersFieldSpecified;

		// Token: 0x040000C7 RID: 199
		private HeartRateInBeatsPerMinute_t heartRateBpmField;

		// Token: 0x040000C8 RID: 200
		private byte cadenceField;

		// Token: 0x040000C9 RID: 201
		private bool cadenceFieldSpecified;

		// Token: 0x040000CA RID: 202
		private SensorState_t sensorStateField;

		// Token: 0x040000CB RID: 203
		private bool sensorStateFieldSpecified;
	}
}
