using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000039 RID: 57
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class HeartRateAbove_t : Duration_t
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0000952A File Offset: 0x0000772A
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00009532 File Offset: 0x00007732
		public HeartRateValue_t HeartRate
		{
			get
			{
				return this.heartRateField;
			}
			set
			{
				this.heartRateField = value;
			}
		}

		// Token: 0x040000F6 RID: 246
		private HeartRateValue_t heartRateField;
	}
}
