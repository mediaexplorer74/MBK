using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000027 RID: 39
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Version_t
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000219 RID: 537 RVA: 0x0000939C File Offset: 0x0000759C
		// (set) Token: 0x0600021A RID: 538 RVA: 0x000093A4 File Offset: 0x000075A4
		public ushort VersionMajor
		{
			get
			{
				return this.versionMajorField;
			}
			set
			{
				this.versionMajorField = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000093AD File Offset: 0x000075AD
		// (set) Token: 0x0600021C RID: 540 RVA: 0x000093B5 File Offset: 0x000075B5
		public ushort VersionMinor
		{
			get
			{
				return this.versionMinorField;
			}
			set
			{
				this.versionMinorField = value;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600021D RID: 541 RVA: 0x000093BE File Offset: 0x000075BE
		// (set) Token: 0x0600021E RID: 542 RVA: 0x000093C6 File Offset: 0x000075C6
		public ushort BuildMajor
		{
			get
			{
				return this.buildMajorField;
			}
			set
			{
				this.buildMajorField = value;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600021F RID: 543 RVA: 0x000093CF File Offset: 0x000075CF
		// (set) Token: 0x06000220 RID: 544 RVA: 0x000093D7 File Offset: 0x000075D7
		[XmlIgnore]
		public bool BuildMajorSpecified
		{
			get
			{
				return this.buildMajorFieldSpecified;
			}
			set
			{
				this.buildMajorFieldSpecified = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000221 RID: 545 RVA: 0x000093E0 File Offset: 0x000075E0
		// (set) Token: 0x06000222 RID: 546 RVA: 0x000093E8 File Offset: 0x000075E8
		public ushort BuildMinor
		{
			get
			{
				return this.buildMinorField;
			}
			set
			{
				this.buildMinorField = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000223 RID: 547 RVA: 0x000093F1 File Offset: 0x000075F1
		// (set) Token: 0x06000224 RID: 548 RVA: 0x000093F9 File Offset: 0x000075F9
		[XmlIgnore]
		public bool BuildMinorSpecified
		{
			get
			{
				return this.buildMinorFieldSpecified;
			}
			set
			{
				this.buildMinorFieldSpecified = value;
			}
		}

		// Token: 0x040000D8 RID: 216
		private ushort versionMajorField;

		// Token: 0x040000D9 RID: 217
		private ushort versionMinorField;

		// Token: 0x040000DA RID: 218
		private ushort buildMajorField;

		// Token: 0x040000DB RID: 219
		private bool buildMajorFieldSpecified;

		// Token: 0x040000DC RID: 220
		private ushort buildMinorField;

		// Token: 0x040000DD RID: 221
		private bool buildMinorFieldSpecified;
	}
}
