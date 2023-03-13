using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200003E RID: 62
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Repeat_t : AbstractStep_t
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600026A RID: 618 RVA: 0x000095BA File Offset: 0x000077BA
		// (set) Token: 0x0600026B RID: 619 RVA: 0x000095C2 File Offset: 0x000077C2
		[XmlElement(DataType = "positiveInteger")]
		public string Repetitions
		{
			get
			{
				return this.repetitionsField;
			}
			set
			{
				this.repetitionsField = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600026C RID: 620 RVA: 0x000095CB File Offset: 0x000077CB
		// (set) Token: 0x0600026D RID: 621 RVA: 0x000095D3 File Offset: 0x000077D3
		[XmlElement("Child")]
		public AbstractStep_t[] Child
		{
			get
			{
				return this.childField;
			}
			set
			{
				this.childField = value;
			}
		}

		// Token: 0x040000FE RID: 254
		private string repetitionsField;

		// Token: 0x040000FF RID: 255
		private AbstractStep_t[] childField;
	}
}
