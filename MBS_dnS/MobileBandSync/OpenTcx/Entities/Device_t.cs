using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000029 RID: 41
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Device_t : AbstractSource_t
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00009402 File Offset: 0x00007602
		// (set) Token: 0x06000227 RID: 551 RVA: 0x0000940A File Offset: 0x0000760A
		public uint UnitId
		{
			get
			{
				return this.unitIdField;
			}
			set
			{
				this.unitIdField = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00009413 File Offset: 0x00007613
		// (set) Token: 0x06000229 RID: 553 RVA: 0x0000941B File Offset: 0x0000761B
		public ushort ProductID
		{
			get
			{
				return this.productIDField;
			}
			set
			{
				this.productIDField = value;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00009424 File Offset: 0x00007624
		// (set) Token: 0x0600022B RID: 555 RVA: 0x0000942C File Offset: 0x0000762C
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

		// Token: 0x040000E3 RID: 227
		private uint unitIdField;

		// Token: 0x040000E4 RID: 228
		private ushort productIDField;

		// Token: 0x040000E5 RID: 229
		private Version_t versionField;
	}
}
