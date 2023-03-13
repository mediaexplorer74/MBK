using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200002F RID: 47
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class PredefinedSpeedZone_t : Zone_t
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600023D RID: 573 RVA: 0x000094A3 File Offset: 0x000076A3
		// (set) Token: 0x0600023E RID: 574 RVA: 0x000094AB File Offset: 0x000076AB
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

		// Token: 0x040000EF RID: 239
		private string numberField;
	}
}
