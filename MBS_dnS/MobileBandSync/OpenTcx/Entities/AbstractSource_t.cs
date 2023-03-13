using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000024 RID: 36
	[XmlInclude(typeof(Application_t))]
	[XmlInclude(typeof(Device_t))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public abstract class AbstractSource_t
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000204 RID: 516 RVA: 0x000092FB File Offset: 0x000074FB
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00009303 File Offset: 0x00007503
		[XmlElement(DataType = "token")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x040000CF RID: 207
		private string nameField;
	}
}
