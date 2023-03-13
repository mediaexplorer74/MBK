using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200003F RID: 63
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Workout_t
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600026F RID: 623 RVA: 0x000095DC File Offset: 0x000077DC
		// (set) Token: 0x06000270 RID: 624 RVA: 0x000095E4 File Offset: 0x000077E4
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

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000271 RID: 625 RVA: 0x000095ED File Offset: 0x000077ED
		// (set) Token: 0x06000272 RID: 626 RVA: 0x000095F5 File Offset: 0x000077F5
		[XmlElement("Step")]
		public AbstractStep_t[] Step
		{
			get
			{
				return this.stepField;
			}
			set
			{
				this.stepField = value;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000273 RID: 627 RVA: 0x000095FE File Offset: 0x000077FE
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00009606 File Offset: 0x00007806
		[XmlElement("ScheduledOn", DataType = "date")]
		public DateTime[] ScheduledOn
		{
			get
			{
				return this.scheduledOnField;
			}
			set
			{
				this.scheduledOnField = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000275 RID: 629 RVA: 0x0000960F File Offset: 0x0000780F
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00009617 File Offset: 0x00007817
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

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00009620 File Offset: 0x00007820
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00009628 File Offset: 0x00007828
		public AbstractSource_t Creator
		{
			get
			{
				return this.creatorField;
			}
			set
			{
				this.creatorField = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00009631 File Offset: 0x00007831
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00009639 File Offset: 0x00007839
		[XmlAttribute]
		public Sport_t Sport
		{
			get
			{
				return this.sportField;
			}
			set
			{
				this.sportField = value;
			}
		}

		// Token: 0x04000100 RID: 256
		private string nameField;

		// Token: 0x04000101 RID: 257
		private AbstractStep_t[] stepField;

		// Token: 0x04000102 RID: 258
		private DateTime[] scheduledOnField;

		// Token: 0x04000103 RID: 259
		private string notesField;

		// Token: 0x04000104 RID: 260
		private AbstractSource_t creatorField;

		// Token: 0x04000105 RID: 261
		private Sport_t sportField;
	}
}
