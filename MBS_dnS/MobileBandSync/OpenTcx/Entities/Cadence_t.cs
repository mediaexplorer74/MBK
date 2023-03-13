using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000032 RID: 50
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Cadence_t : Target_t
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000094BC File Offset: 0x000076BC
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000094C4 File Offset: 0x000076C4
		public double Low
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

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000094CD File Offset: 0x000076CD
		// (set) Token: 0x06000245 RID: 581 RVA: 0x000094D5 File Offset: 0x000076D5
		public double High
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

		// Token: 0x040000F0 RID: 240
		private double lowField;

		// Token: 0x040000F1 RID: 241
		private double highField;
	}
}
