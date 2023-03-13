using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000051 RID: 81
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class MultiSportFolder_t
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00009983 File Offset: 0x00007B83
		// (set) Token: 0x060002ED RID: 749 RVA: 0x0000998B File Offset: 0x00007B8B
		[XmlElement("Folder")]
		public MultiSportFolder_t[] Folder
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

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00009994 File Offset: 0x00007B94
		// (set) Token: 0x060002EF RID: 751 RVA: 0x0000999C File Offset: 0x00007B9C
		[XmlElement("MultisportActivityRef")]
		public ActivityReference_t[] MultisportActivityRef
		{
			get
			{
				return this.multisportActivityRefField;
			}
			set
			{
				this.multisportActivityRefField = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x000099A5 File Offset: 0x00007BA5
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x000099AD File Offset: 0x00007BAD
		[XmlElement("Week")]
		public Week_t[] Week
		{
			get
			{
				return this.weekField;
			}
			set
			{
				this.weekField = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x000099B6 File Offset: 0x00007BB6
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x000099BE File Offset: 0x00007BBE
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x000099C7 File Offset: 0x00007BC7
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x000099CF File Offset: 0x00007BCF
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

		// Token: 0x04000144 RID: 324
		private MultiSportFolder_t[] folderField;

		// Token: 0x04000145 RID: 325
		private ActivityReference_t[] multisportActivityRefField;

		// Token: 0x04000146 RID: 326
		private Week_t[] weekField;

		// Token: 0x04000147 RID: 327
		private string notesField;

		// Token: 0x04000148 RID: 328
		private string nameField;
	}
}
