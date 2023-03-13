using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200001F RID: 31
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class HeartRateAsPercentOfMax_t : HeartRateValue_t
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001DD RID: 477 RVA: 0x000091C9 File Offset: 0x000073C9
		// (set) Token: 0x060001DE RID: 478 RVA: 0x000091D1 File Offset: 0x000073D1
		public byte Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x040000B7 RID: 183
		private byte valueField;
	}
}
