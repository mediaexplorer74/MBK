using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200003D RID: 61
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Step_t : AbstractStep_t
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000956E File Offset: 0x0000776E
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00009576 File Offset: 0x00007776
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

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000957F File Offset: 0x0000777F
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00009587 File Offset: 0x00007787
		public Duration_t Duration
		{
			get
			{
				return this.durationField;
			}
			set
			{
				this.durationField = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00009590 File Offset: 0x00007790
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00009598 File Offset: 0x00007798
		public Intensity_t Intensity
		{
			get
			{
				return this.intensityField;
			}
			set
			{
				this.intensityField = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000267 RID: 615 RVA: 0x000095A1 File Offset: 0x000077A1
		// (set) Token: 0x06000268 RID: 616 RVA: 0x000095A9 File Offset: 0x000077A9
		public Target_t Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x040000FA RID: 250
		private string nameField;

		// Token: 0x040000FB RID: 251
		private Duration_t durationField;

		// Token: 0x040000FC RID: 252
		private Intensity_t intensityField;

		// Token: 0x040000FD RID: 253
		private Target_t targetField;
	}
}
