using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000052 RID: 82
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Week_t
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x000099D8 File Offset: 0x00007BD8
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x000099E0 File Offset: 0x00007BE0
		public string Notes
		{
			get
			{
				return this.notesField;
			}
			set
			{
				this.notesField = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x000099E9 File Offset: 0x00007BE9
		// (set) Token: 0x060002FA RID: 762 RVA: 0x000099F1 File Offset: 0x00007BF1
		[XmlAttribute(DataType = "date")]
		public DateTime StartDay
		{
			get
			{
				return this.startDayField;
			}
			set
			{
				this.startDayField = value;
			}
		}

		// Token: 0x04000149 RID: 329
		private string notesField;

		// Token: 0x0400014A RID: 330
		private DateTime startDayField;
	}
}
