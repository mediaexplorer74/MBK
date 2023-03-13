using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000045 RID: 69
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Training_t
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002AB RID: 683 RVA: 0x000097B8 File Offset: 0x000079B8
		// (set) Token: 0x060002AC RID: 684 RVA: 0x000097C0 File Offset: 0x000079C0
		public QuickWorkout_t QuickWorkoutResults
		{
			get
			{
				return this.quickWorkoutResultsField;
			}
			set
			{
				this.quickWorkoutResultsField = value;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002AD RID: 685 RVA: 0x000097C9 File Offset: 0x000079C9
		// (set) Token: 0x060002AE RID: 686 RVA: 0x000097D1 File Offset: 0x000079D1
		public Plan_t Plan
		{
			get
			{
				return this.planField;
			}
			set
			{
				this.planField = value;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002AF RID: 687 RVA: 0x000097DA File Offset: 0x000079DA
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x000097E2 File Offset: 0x000079E2
		[XmlAttribute]
		public bool VirtualPartner
		{
			get
			{
				return this.virtualPartnerField;
			}
			set
			{
				this.virtualPartnerField = value;
			}
		}

		// Token: 0x04000126 RID: 294
		private QuickWorkout_t quickWorkoutResultsField;

		// Token: 0x04000127 RID: 295
		private Plan_t planField;

		// Token: 0x04000128 RID: 296
		private bool virtualPartnerField;
	}
}
