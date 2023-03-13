using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200003C RID: 60
	[XmlInclude(typeof(Step_t))]
	[XmlInclude(typeof(Repeat_t))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public abstract class AbstractStep_t
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0000955D File Offset: 0x0000775D
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00009565 File Offset: 0x00007765
		[XmlElement(DataType = "positiveInteger")]
		public string StepId
		{
			get
			{
				return this.stepIdField;
			}
			set
			{
				this.stepIdField = value;
			}
		}

		// Token: 0x040000F9 RID: 249
		private string stepIdField;
	}
}
