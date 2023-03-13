using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200004A RID: 74
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class MultiSportSession_t
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00009851 File Offset: 0x00007A51
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x00009859 File Offset: 0x00007A59
		public DateTime Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00009862 File Offset: 0x00007A62
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000986A File Offset: 0x00007A6A
		public FirstSport_t FirstSport
		{
			get
			{
				return this.firstSportField;
			}
			set
			{
				this.firstSportField = value;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x00009873 File Offset: 0x00007A73
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x0000987B File Offset: 0x00007A7B
		[XmlElement("NextSport")]
		public NextSport_t[] NextSport
		{
			get
			{
				return this.nextSportField;
			}
			set
			{
				this.nextSportField = value;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x00009884 File Offset: 0x00007A84
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x0000988C File Offset: 0x00007A8C
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

		// Token: 0x04000132 RID: 306
		private DateTime idField;

		// Token: 0x04000133 RID: 307
		private FirstSport_t firstSportField;

		// Token: 0x04000134 RID: 308
		private NextSport_t[] nextSportField;

		// Token: 0x04000135 RID: 309
		private string notesField;
	}
}
