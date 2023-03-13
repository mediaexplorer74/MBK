using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000018 RID: 24
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class ActivityReference_t
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00009029 File Offset: 0x00007229
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x00009031 File Offset: 0x00007231
		public DateTime Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x0400008E RID: 142
		private DateTime idField;
	}
}
