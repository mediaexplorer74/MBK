using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200002D RID: 45
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class CustomSpeedZone_t : Zone_t
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000236 RID: 566 RVA: 0x00009470 File Offset: 0x00007670
		// (set) Token: 0x06000237 RID: 567 RVA: 0x00009478 File Offset: 0x00007678
		public SpeedType_t ViewAs
		{
			get
			{
				return this.viewAsField;
			}
			set
			{
				this.viewAsField = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000238 RID: 568 RVA: 0x00009481 File Offset: 0x00007681
		// (set) Token: 0x06000239 RID: 569 RVA: 0x00009489 File Offset: 0x00007689
		public double LowInMetersPerSecond
		{
			get
			{
				return this.lowInMetersPerSecondField;
			}
			set
			{
				this.lowInMetersPerSecondField = value;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600023A RID: 570 RVA: 0x00009492 File Offset: 0x00007692
		// (set) Token: 0x0600023B RID: 571 RVA: 0x0000949A File Offset: 0x0000769A
		public double HighInMetersPerSecond
		{
			get
			{
				return this.highInMetersPerSecondField;
			}
			set
			{
				this.highInMetersPerSecondField = value;
			}
		}

		// Token: 0x040000E9 RID: 233
		private SpeedType_t viewAsField;

		// Token: 0x040000EA RID: 234
		private double lowInMetersPerSecondField;

		// Token: 0x040000EB RID: 235
		private double highInMetersPerSecondField;
	}
}
