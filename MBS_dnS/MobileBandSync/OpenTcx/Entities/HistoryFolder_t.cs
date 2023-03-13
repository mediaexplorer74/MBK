using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000017 RID: 23
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class HistoryFolder_t
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00008FD4 File Offset: 0x000071D4
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00008FDC File Offset: 0x000071DC
		[XmlElement("Folder")]
		public HistoryFolder_t[] Folder
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00008FE5 File Offset: 0x000071E5
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00008FED File Offset: 0x000071ED
		[XmlElement("ActivityRef")]
		public ActivityReference_t[] ActivityRef
		{
			get
			{
				return this.activityRefField;
			}
			set
			{
				this.activityRefField = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00008FF6 File Offset: 0x000071F6
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00008FFE File Offset: 0x000071FE
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

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00009007 File Offset: 0x00007207
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x0000900F File Offset: 0x0000720F
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

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00009018 File Offset: 0x00007218
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00009020 File Offset: 0x00007220
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

		// Token: 0x04000089 RID: 137
		private HistoryFolder_t[] folderField;

		// Token: 0x0400008A RID: 138
		private ActivityReference_t[] activityRefField;

		// Token: 0x0400008B RID: 139
		private Week_t[] weekField;

		// Token: 0x0400008C RID: 140
		private string notesField;

		// Token: 0x0400008D RID: 141
		private string nameField;
	}
}
