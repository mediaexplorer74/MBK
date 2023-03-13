using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000049 RID: 73
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class FirstSport_t
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060002BE RID: 702 RVA: 0x00009840 File Offset: 0x00007A40
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00009848 File Offset: 0x00007A48
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

		// Token: 0x04000131 RID: 305
		private Activity_t activityField;
	}
}
