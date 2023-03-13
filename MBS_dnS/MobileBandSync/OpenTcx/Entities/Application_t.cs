using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000025 RID: 37
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Application_t : AbstractSource_t
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000930C File Offset: 0x0000750C
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00009314 File Offset: 0x00007514
		public Build_t Build
		{
			get
			{
				return this.buildField;
			}
			set
			{
				this.buildField = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000931D File Offset: 0x0000751D
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00009325 File Offset: 0x00007525
		[XmlElement(DataType = "token")]
		public string LangID
		{
			get
			{
				return this.langIDField;
			}
			set
			{
				this.langIDField = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000932E File Offset: 0x0000752E
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00009336 File Offset: 0x00007536
		[XmlElement(DataType = "token")]
		public string PartNumber
		{
			get
			{
				return this.partNumberField;
			}
			set
			{
				this.partNumberField = value;
			}
		}

		// Token: 0x040000D0 RID: 208
		private Build_t buildField;

		// Token: 0x040000D1 RID: 209
		private string langIDField;

		// Token: 0x040000D2 RID: 210
		private string partNumberField;
	}
}
