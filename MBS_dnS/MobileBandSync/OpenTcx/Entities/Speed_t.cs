using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000034 RID: 52
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Speed_t : Target_t
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600024A RID: 586 RVA: 0x000094EF File Offset: 0x000076EF
		// (set) Token: 0x0600024B RID: 587 RVA: 0x000094F7 File Offset: 0x000076F7
		public Zone_t SpeedZone
		{
			get
			{
				return this.speedZoneField;
			}
			set
			{
				this.speedZoneField = value;
			}
		}

		// Token: 0x040000F3 RID: 243
		private Zone_t speedZoneField;
	}
}
