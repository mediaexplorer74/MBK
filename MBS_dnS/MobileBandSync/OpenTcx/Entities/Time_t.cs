using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200003B RID: 59
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Time_t : Duration_t
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000954C File Offset: 0x0000774C
		// (set) Token: 0x0600025C RID: 604 RVA: 0x00009554 File Offset: 0x00007754
		public ushort Seconds
		{
			get
			{
				return this.secondsField;
			}
			set
			{
				this.secondsField = value;
			}
		}

		// Token: 0x040000F8 RID: 248
		private ushort secondsField;
	}
}
