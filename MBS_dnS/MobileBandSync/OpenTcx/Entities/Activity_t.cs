using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000044 RID: 68
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Activity_t
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00009752 File Offset: 0x00007952
		// (set) Token: 0x0600029F RID: 671 RVA: 0x0000975A File Offset: 0x0000795A
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

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00009763 File Offset: 0x00007963
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x0000976B File Offset: 0x0000796B
		[XmlElement("Lap")]
		public ActivityLap_t[] Lap
		{
			get
			{
				return this.lapField;
			}
			set
			{
				this.lapField = value;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00009774 File Offset: 0x00007974
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x0000977C File Offset: 0x0000797C
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

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00009785 File Offset: 0x00007985
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x0000978D File Offset: 0x0000798D
		public Training_t Training
		{
			get
			{
				return this.trainingField;
			}
			set
			{
				this.trainingField = value;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00009796 File Offset: 0x00007996
		// (set) Token: 0x060002A7 RID: 679 RVA: 0x0000979E File Offset: 0x0000799E
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

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x000097A7 File Offset: 0x000079A7
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x000097AF File Offset: 0x000079AF
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

		// Token: 0x04000120 RID: 288
		private DateTime idField;

		// Token: 0x04000121 RID: 289
		private ActivityLap_t[] lapField;

		// Token: 0x04000122 RID: 290
		private string notesField;

		// Token: 0x04000123 RID: 291
		private Training_t trainingField;

		// Token: 0x04000124 RID: 292
		private AbstractSource_t creatorField;

		// Token: 0x04000125 RID: 293
		private Sport_t sportField;
	}
}
