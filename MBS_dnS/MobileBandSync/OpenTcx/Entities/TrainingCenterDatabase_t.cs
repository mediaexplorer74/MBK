using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000014 RID: 20
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	[XmlRoot("TrainingCenterDatabase", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2", IsNullable = false)]
	public class TrainingCenterDatabase_t
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00008F08 File Offset: 0x00007108
		// (set) Token: 0x06000182 RID: 386 RVA: 0x00008F10 File Offset: 0x00007110
		public Folders_t Folders
		{
			get
			{
				return this.foldersField;
			}
			set
			{
				this.foldersField = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00008F19 File Offset: 0x00007119
		// (set) Token: 0x06000184 RID: 388 RVA: 0x00008F21 File Offset: 0x00007121
		public ActivityList_t Activities
		{
			get
			{
				return this.activitiesField;
			}
			set
			{
				this.activitiesField = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00008F2A File Offset: 0x0000712A
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00008F32 File Offset: 0x00007132
		[XmlArrayItem("Workout", IsNullable = false)]
		public Workout_t[] Workouts
		{
			get
			{
				return this.workoutsField;
			}
			set
			{
				this.workoutsField = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00008F3B File Offset: 0x0000713B
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00008F43 File Offset: 0x00007143
		[XmlArrayItem("Course", IsNullable = false)]
		public Course_t[] Courses
		{
			get
			{
				return this.coursesField;
			}
			set
			{
				this.coursesField = value;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00008F4C File Offset: 0x0000714C
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00008F54 File Offset: 0x00007154
		public AbstractSource_t Author
		{
			get
			{
				return this.authorField;
			}
			set
			{
				this.authorField = value;
			}
		}

		// Token: 0x0400007D RID: 125
		private Folders_t foldersField;

		// Token: 0x0400007E RID: 126
		private ActivityList_t activitiesField;

		// Token: 0x0400007F RID: 127
		private Workout_t[] workoutsField;

		// Token: 0x04000080 RID: 128
		private Course_t[] coursesField;

		// Token: 0x04000081 RID: 129
		private AbstractSource_t authorField;
	}
}
