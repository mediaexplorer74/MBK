using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200001B RID: 27
	[GeneratedCode("xsd", "4.0.30319.1")]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public enum CoursePointType_t
	{
		// Token: 0x04000099 RID: 153
		Generic,
		// Token: 0x0400009A RID: 154
		Summit,
		// Token: 0x0400009B RID: 155
		Valley,
		// Token: 0x0400009C RID: 156
		Water,
		// Token: 0x0400009D RID: 157
		Food,
		// Token: 0x0400009E RID: 158
		Danger,
		// Token: 0x0400009F RID: 159
		Left,
		// Token: 0x040000A0 RID: 160
		Right,
		// Token: 0x040000A1 RID: 161
		Straight,
		// Token: 0x040000A2 RID: 162
		[XmlEnum("First Aid")]
		FirstAid,
		// Token: 0x040000A3 RID: 163
		[XmlEnum("4th Category")]
		Item4thCategory,
		// Token: 0x040000A4 RID: 164
		[XmlEnum("3rd Category")]
		Item3rdCategory,
		// Token: 0x040000A5 RID: 165
		[XmlEnum("2nd Category")]
		Item2ndCategory,
		// Token: 0x040000A6 RID: 166
		[XmlEnum("1st Category")]
		Item1stCategory,
		// Token: 0x040000A7 RID: 167
		[XmlEnum("Hors Category")]
		HorsCategory,
		// Token: 0x040000A8 RID: 168
		Sprint
	}
}
