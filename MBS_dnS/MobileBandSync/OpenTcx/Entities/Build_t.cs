using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000026 RID: 38
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Build_t
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00009347 File Offset: 0x00007547
		// (set) Token: 0x0600020F RID: 527 RVA: 0x0000934F File Offset: 0x0000754F
		public Version_t Version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00009358 File Offset: 0x00007558
		// (set) Token: 0x06000211 RID: 529 RVA: 0x00009360 File Offset: 0x00007560
		public BuildType_t Type
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

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00009369 File Offset: 0x00007569
		// (set) Token: 0x06000213 RID: 531 RVA: 0x00009371 File Offset: 0x00007571
		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return this.typeFieldSpecified;
			}
			set
			{
				this.typeFieldSpecified = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000214 RID: 532 RVA: 0x0000937A File Offset: 0x0000757A
		// (set) Token: 0x06000215 RID: 533 RVA: 0x00009382 File Offset: 0x00007582
		[XmlElement(DataType = "token")]
		public string Time
		{
			get
			{
				return this.timeField;
			}
			set
			{
				this.timeField = value;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000216 RID: 534 RVA: 0x0000938B File Offset: 0x0000758B
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00009393 File Offset: 0x00007593
		[XmlElement(DataType = "token")]
		public string Builder
		{
			get
			{
				return this.builderField;
			}
			set
			{
				this.builderField = value;
			}
		}

		// Token: 0x040000D3 RID: 211
		private Version_t versionField;

		// Token: 0x040000D4 RID: 212
		private BuildType_t typeField;

		// Token: 0x040000D5 RID: 213
		private bool typeFieldSpecified;

		// Token: 0x040000D6 RID: 214
		private string timeField;

		// Token: 0x040000D7 RID: 215
		private string builderField;
	}
}
