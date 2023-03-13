using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000028 RID: 40
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public enum BuildType_t
	{
		// Token: 0x040000DF RID: 223
		Internal,
		// Token: 0x040000E0 RID: 224
		Alpha,
		// Token: 0x040000E1 RID: 225
		Beta,
		// Token: 0x040000E2 RID: 226
		Release
	}
}
