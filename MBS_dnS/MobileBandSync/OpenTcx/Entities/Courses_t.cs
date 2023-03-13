using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200004E RID: 78
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Courses_t
	{
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060002DB RID: 731 RVA: 0x0000990C File Offset: 0x00007B0C
		// (set) Token: 0x060002DC RID: 732 RVA: 0x00009914 File Offset: 0x00007B14
		public CourseFolder_t CourseFolder
		{
			get
			{
				return this.courseFolderField;
			}
			set
			{
				this.courseFolderField = value;
			}
		}

		// Token: 0x0400013D RID: 317
		private CourseFolder_t courseFolderField;
	}
}
