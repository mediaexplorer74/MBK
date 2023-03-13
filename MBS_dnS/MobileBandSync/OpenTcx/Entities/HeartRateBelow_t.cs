using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000038 RID: 56
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class HeartRateBelow_t : Duration_t
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00009519 File Offset: 0x00007719
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00009521 File Offset: 0x00007721
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

		// Token: 0x040000F5 RID: 245
		private HeartRateValue_t heartRateField;
	}
}
