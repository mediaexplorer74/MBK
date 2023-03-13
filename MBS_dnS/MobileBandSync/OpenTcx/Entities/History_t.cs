using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000016 RID: 22
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class History_t
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00008F90 File Offset: 0x00007190
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00008F98 File Offset: 0x00007198
		public HistoryFolder_t Running
		{
			get
			{
				return this.runningField;
			}
			set
			{
				this.runningField = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00008FA1 File Offset: 0x000071A1
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00008FA9 File Offset: 0x000071A9
		public HistoryFolder_t Biking
		{
			get
			{
				return this.bikingField;
			}
			set
			{
				this.bikingField = value;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00008FB2 File Offset: 0x000071B2
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00008FBA File Offset: 0x000071BA
		public HistoryFolder_t Other
		{
			get
			{
				return this.otherField;
			}
			set
			{
				this.otherField = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00008FC3 File Offset: 0x000071C3
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00008FCB File Offset: 0x000071CB
		public MultiSportFolder_t MultiSport
		{
			get
			{
				return this.multiSportField;
			}
			set
			{
				this.multiSportField = value;
			}
		}

		// Token: 0x04000085 RID: 133
		private HistoryFolder_t runningField;

		// Token: 0x04000086 RID: 134
		private HistoryFolder_t bikingField;

		// Token: 0x04000087 RID: 135
		private HistoryFolder_t otherField;

		// Token: 0x04000088 RID: 136
		private MultiSportFolder_t multiSportField;
	}
}
