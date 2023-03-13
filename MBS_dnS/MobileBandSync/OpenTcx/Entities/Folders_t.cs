using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000015 RID: 21
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Folders_t
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00008F5D File Offset: 0x0000715D
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00008F65 File Offset: 0x00007165
		public History_t History
		{
			get
			{
				return this.historyField;
			}
			set
			{
				this.historyField = value;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00008F6E File Offset: 0x0000716E
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00008F76 File Offset: 0x00007176
		public Workouts_t Workouts
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

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00008F7F File Offset: 0x0000717F
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00008F87 File Offset: 0x00007187
		public Courses_t Courses
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

		// Token: 0x04000082 RID: 130
		private History_t historyField;

		// Token: 0x04000083 RID: 131
		private Workouts_t workoutsField;

		// Token: 0x04000084 RID: 132
		private Courses_t coursesField;
	}
}
