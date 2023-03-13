using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200004C RID: 76
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class CourseFolder_t
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060002CF RID: 719 RVA: 0x000098B7 File Offset: 0x00007AB7
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x000098BF File Offset: 0x00007ABF
		[XmlElement("Folder")]
		public CourseFolder_t[] Folder
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

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x000098C8 File Offset: 0x00007AC8
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x000098D0 File Offset: 0x00007AD0
		[XmlElement("CourseNameRef")]
		public NameKeyReference_t[] CourseNameRef
		{
			get
			{
				return this.courseNameRefField;
			}
			set
			{
				this.courseNameRefField = value;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x000098D9 File Offset: 0x00007AD9
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x000098E1 File Offset: 0x00007AE1
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

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x000098EA File Offset: 0x00007AEA
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x000098F2 File Offset: 0x00007AF2
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

		// Token: 0x04000138 RID: 312
		private CourseFolder_t[] folderField;

		// Token: 0x04000139 RID: 313
		private NameKeyReference_t[] courseNameRefField;

		// Token: 0x0400013A RID: 314
		private string notesField;

		// Token: 0x0400013B RID: 315
		private string nameField;
	}
}
