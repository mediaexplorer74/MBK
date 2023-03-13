using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000047 RID: 71
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Plan_t
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000980D File Offset: 0x00007A0D
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x00009815 File Offset: 0x00007A15
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000981E File Offset: 0x00007A1E
		// (set) Token: 0x060002BA RID: 698 RVA: 0x00009826 File Offset: 0x00007A26
		[XmlAttribute]
		public TrainingType_t Type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000982F File Offset: 0x00007A2F
		// (set) Token: 0x060002BC RID: 700 RVA: 0x00009837 File Offset: 0x00007A37
		[XmlAttribute]
		public bool IntervalWorkout
		{
			get
			{
				return this.intervalWorkoutField;
			}
			set
			{
				this.intervalWorkoutField = value;
			}
		}

		// Token: 0x0400012B RID: 299
		private string nameField;

		// Token: 0x0400012C RID: 300
		private TrainingType_t typeField;

		// Token: 0x0400012D RID: 301
		private bool intervalWorkoutField;
	}
}
