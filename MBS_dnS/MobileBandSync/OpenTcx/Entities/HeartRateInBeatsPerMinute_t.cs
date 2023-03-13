using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200001D RID: 29
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class HeartRateInBeatsPerMinute_t : HeartRateValue_t
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000091B0 File Offset: 0x000073B0
		// (set) Token: 0x060001DA RID: 474 RVA: 0x000091B8 File Offset: 0x000073B8
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

		// Token: 0x040000B6 RID: 182
		private byte valueField;
	}
}
