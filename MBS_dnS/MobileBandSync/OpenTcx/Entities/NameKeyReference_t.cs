using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200004D RID: 77
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class NameKeyReference_t
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x000098FB File Offset: 0x00007AFB
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00009903 File Offset: 0x00007B03
		[XmlElement(DataType = "token")]
		public string Id
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

		// Token: 0x0400013C RID: 316
		private string idField;
	}
}
