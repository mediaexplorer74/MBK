using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000033 RID: 51
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class HeartRate_t : Target_t
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000247 RID: 583 RVA: 0x000094DE File Offset: 0x000076DE
		// (set) Token: 0x06000248 RID: 584 RVA: 0x000094E6 File Offset: 0x000076E6
		public Zone_t HeartRateZone
		{
			get
			{
				return this.heartRateZoneField;
			}
			set
			{
				this.heartRateZoneField = value;
			}
		}

		// Token: 0x040000F2 RID: 242
		private Zone_t heartRateZoneField;
	}
}
