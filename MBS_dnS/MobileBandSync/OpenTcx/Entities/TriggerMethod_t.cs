using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000043 RID: 67
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public enum TriggerMethod_t
	{
		// Token: 0x0400011B RID: 283
		Manual,
		// Token: 0x0400011C RID: 284
		Distance,
		// Token: 0x0400011D RID: 285
		Location,
		// Token: 0x0400011E RID: 286
		Time,
		// Token: 0x0400011F RID: 287
		HeartRate
	}
}
