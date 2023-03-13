using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200002B RID: 43
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class CustomHeartRateZone_t : Zone_t
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00009435 File Offset: 0x00007635
		// (set) Token: 0x0600022F RID: 559 RVA: 0x0000943D File Offset: 0x0000763D
		public HeartRateValue_t Low
		{
			get
			{
				return this.lowField;
			}
			set
			{
				this.lowField = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00009446 File Offset: 0x00007646
		// (set) Token: 0x06000231 RID: 561 RVA: 0x0000944E File Offset: 0x0000764E
		public HeartRateValue_t High
		{
			get
			{
				return this.highField;
			}
			set
			{
				this.highField = value;
			}
		}

		// Token: 0x040000E6 RID: 230
		private HeartRateValue_t lowField;

		// Token: 0x040000E7 RID: 231
		private HeartRateValue_t highField;
	}
}
