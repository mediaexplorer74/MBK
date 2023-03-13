using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000041 RID: 65
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class NextSport_t
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00009642 File Offset: 0x00007842
		// (set) Token: 0x0600027D RID: 637 RVA: 0x0000964A File Offset: 0x0000784A
		public ActivityLap_t Transition
		{
			get
			{
				return this.transitionField;
			}
			set
			{
				this.transitionField = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00009653 File Offset: 0x00007853
		// (set) Token: 0x0600027F RID: 639 RVA: 0x0000965B File Offset: 0x0000785B
		public Activity_t Activity
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

		// Token: 0x0400010A RID: 266
		private ActivityLap_t transitionField;

		// Token: 0x0400010B RID: 267
		private Activity_t activityField;
	}
}
