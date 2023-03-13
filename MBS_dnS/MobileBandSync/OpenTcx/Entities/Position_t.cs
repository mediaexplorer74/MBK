using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200001A RID: 26
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Position_t
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x000090B1 File Offset: 0x000072B1
		// (set) Token: 0x060001BA RID: 442 RVA: 0x000090B9 File Offset: 0x000072B9
		public double LatitudeDegrees
		{
			get
			{
				return this.latitudeDegreesField;
			}
			set
			{
				this.latitudeDegreesField = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000090C2 File Offset: 0x000072C2
		// (set) Token: 0x060001BC RID: 444 RVA: 0x000090CA File Offset: 0x000072CA
		public double LongitudeDegrees
		{
			get
			{
				return this.longitudeDegreesField;
			}
			set
			{
				this.longitudeDegreesField = value;
			}
		}

		// Token: 0x04000096 RID: 150
		private double latitudeDegreesField;

		// Token: 0x04000097 RID: 151
		private double longitudeDegreesField;
	}
}
