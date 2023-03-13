using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200002C RID: 44
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class PredefinedHeartRateZone_t : Zone_t
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0000945F File Offset: 0x0000765F
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00009467 File Offset: 0x00007667
		[XmlElement(DataType = "positiveInteger")]
		public string Number
		{
			get
			{
				return this.numberField;
			}
			set
			{
				this.numberField = value;
			}
		}

		// Token: 0x040000E8 RID: 232
		private string numberField;
	}
}
