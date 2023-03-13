using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000021 RID: 33
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Course_t
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x000091DA File Offset: 0x000073DA
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x000091E2 File Offset: 0x000073E2
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x000091EB File Offset: 0x000073EB
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x000091F3 File Offset: 0x000073F3
		[XmlElement("Lap")]
		public CourseLap_t[] Lap
		{
			get
			{
				return this.lapField;
			}
			set
			{
				this.lapField = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x000091FC File Offset: 0x000073FC
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x00009204 File Offset: 0x00007404
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

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000920D File Offset: 0x0000740D
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00009215 File Offset: 0x00007415
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

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000921E File Offset: 0x0000741E
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x00009226 File Offset: 0x00007426
		[XmlElement("CoursePoint")]
		public CoursePoint_t[] CoursePoint
		{
			get
			{
				return this.coursePointField;
			}
			set
			{
				this.coursePointField = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000922F File Offset: 0x0000742F
		// (set) Token: 0x060001EB RID: 491 RVA: 0x00009237 File Offset: 0x00007437
		public AbstractSource_t Creator
		{
			get
			{
				return this.creatorField;
			}
			set
			{
				this.creatorField = value;
			}
		}

		// Token: 0x040000BB RID: 187
		private string nameField;

		// Token: 0x040000BC RID: 188
		private CourseLap_t[] lapField;

		// Token: 0x040000BD RID: 189
		private Trackpoint_t[] trackField;

		// Token: 0x040000BE RID: 190
		private string notesField;

		// Token: 0x040000BF RID: 191
		private CoursePoint_t[] coursePointField;

		// Token: 0x040000C0 RID: 192
		private AbstractSource_t creatorField;
	}
}
