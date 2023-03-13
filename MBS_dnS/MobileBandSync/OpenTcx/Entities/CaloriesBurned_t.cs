using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000037 RID: 55
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class CaloriesBurned_t : Duration_t
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00009508 File Offset: 0x00007708
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00009510 File Offset: 0x00007710
		public ushort Calories
		{
			get
			{
				return this.caloriesField;
			}
			set
			{
				this.caloriesField = value;
			}
		}

		// Token: 0x040000F4 RID: 244
		private ushort caloriesField;
	}
}
