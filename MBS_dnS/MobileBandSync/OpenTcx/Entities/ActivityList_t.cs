using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200004B RID: 75
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class ActivityList_t
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00009895 File Offset: 0x00007A95
		// (set) Token: 0x060002CB RID: 715 RVA: 0x0000989D File Offset: 0x00007A9D
		[XmlElement("Activity")]
		public Activity_t[] Activity
		{
			get
			{
				return this.activityField;
			}
			set
			{
				this.activityField = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060002CC RID: 716 RVA: 0x000098A6 File Offset: 0x00007AA6
		// (set) Token: 0x060002CD RID: 717 RVA: 0x000098AE File Offset: 0x00007AAE
		[XmlElement("MultiSportSession")]
		public MultiSportSession_t[] MultiSportSession
		{
			get
			{
				return this.multiSportSessionField;
			}
			set
			{
				this.multiSportSessionField = value;
			}
		}

		// Token: 0x04000136 RID: 310
		private Activity_t[] activityField;

		// Token: 0x04000137 RID: 311
		private MultiSportSession_t[] multiSportSessionField;
	}
}
