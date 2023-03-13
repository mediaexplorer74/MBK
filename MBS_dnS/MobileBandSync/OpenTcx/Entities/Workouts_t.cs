using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000050 RID: 80
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Workouts_t
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00009950 File Offset: 0x00007B50
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x00009958 File Offset: 0x00007B58
		public WorkoutFolder_t Running
		{
			get
			{
				return this.runningField;
			}
			set
			{
				this.runningField = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00009961 File Offset: 0x00007B61
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x00009969 File Offset: 0x00007B69
		public WorkoutFolder_t Biking
		{
			get
			{
				return this.bikingField;
			}
			set
			{
				this.bikingField = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00009972 File Offset: 0x00007B72
		// (set) Token: 0x060002EA RID: 746 RVA: 0x0000997A File Offset: 0x00007B7A
		public WorkoutFolder_t Other
		{
			get
			{
				return this.otherField;
			}
			set
			{
				this.otherField = value;
			}
		}

		// Token: 0x04000141 RID: 321
		private WorkoutFolder_t runningField;

		// Token: 0x04000142 RID: 322
		private WorkoutFolder_t bikingField;

		// Token: 0x04000143 RID: 323
		private WorkoutFolder_t otherField;
	}
}
