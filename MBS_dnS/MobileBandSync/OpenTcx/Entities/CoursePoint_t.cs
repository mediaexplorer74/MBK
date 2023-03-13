using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000019 RID: 25
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class CoursePoint_t
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000903A File Offset: 0x0000723A
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00009042 File Offset: 0x00007242
		[XmlElement(DataType = "token")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000904B File Offset: 0x0000724B
		// (set) Token: 0x060001AD RID: 429 RVA: 0x00009053 File Offset: 0x00007253
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000905C File Offset: 0x0000725C
		// (set) Token: 0x060001AF RID: 431 RVA: 0x00009064 File Offset: 0x00007264
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

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000906D File Offset: 0x0000726D
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x00009075 File Offset: 0x00007275
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

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000907E File Offset: 0x0000727E
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00009086 File Offset: 0x00007286
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

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000908F File Offset: 0x0000728F
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00009097 File Offset: 0x00007297
		public CoursePointType_t PointType
		{
			get
			{
				return this.pointTypeField;
			}
			set
			{
				this.pointTypeField = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x000090A0 File Offset: 0x000072A0
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x000090A8 File Offset: 0x000072A8
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

		// Token: 0x0400008F RID: 143
		private string nameField;

		// Token: 0x04000090 RID: 144
		private DateTime timeField;

		// Token: 0x04000091 RID: 145
		private Position_t positionField;

		// Token: 0x04000092 RID: 146
		private double altitudeMetersField;

		// Token: 0x04000093 RID: 147
		private bool altitudeMetersFieldSpecified;

		// Token: 0x04000094 RID: 148
		private CoursePointType_t pointTypeField;

		// Token: 0x04000095 RID: 149
		private string notesField;
	}
}
