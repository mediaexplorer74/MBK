using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000046 RID: 70
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class QuickWorkout_t
	{
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x000097EB File Offset: 0x000079EB
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x000097F3 File Offset: 0x000079F3
		public double TotalTimeSeconds
		{
			get
			{
				return this.totalTimeSecondsField;
			}
			set
			{
				this.totalTimeSecondsField = value;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x000097FC File Offset: 0x000079FC
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00009804 File Offset: 0x00007A04
		public double DistanceMeters
		{
			get
			{
				return this.distanceMetersField;
			}
			set
			{
				this.distanceMetersField = value;
			}
		}

		// Token: 0x04000129 RID: 297
		private double totalTimeSecondsField;

		// Token: 0x0400012A RID: 298
		private double distanceMetersField;
	}
}
