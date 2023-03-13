using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200004F RID: 79
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class WorkoutFolder_t
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000991D File Offset: 0x00007B1D
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00009925 File Offset: 0x00007B25
		[XmlElement("Folder")]
		public WorkoutFolder_t[] Folder
		{
			get
			{
				return this.folderField;
			}
			set
			{
				this.folderField = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000992E File Offset: 0x00007B2E
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00009936 File Offset: 0x00007B36
		[XmlElement("WorkoutNameRef")]
		public NameKeyReference_t[] WorkoutNameRef
		{
			get
			{
				return this.workoutNameRefField;
			}
			set
			{
				this.workoutNameRefField = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0000993F File Offset: 0x00007B3F
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00009947 File Offset: 0x00007B47
		[XmlAttribute]
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

		// Token: 0x0400013E RID: 318
		private WorkoutFolder_t[] folderField;

		// Token: 0x0400013F RID: 319
		private NameKeyReference_t[] workoutNameRefField;

		// Token: 0x04000140 RID: 320
		private string nameField;
	}
}
