using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200003A RID: 58
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public class Distance_t : Duration_t
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0000953B File Offset: 0x0000773B
		// (set) Token: 0x06000259 RID: 601 RVA: 0x00009543 File Offset: 0x00007743
		public ushort Meters
		{
			get
			{
				return this.metersField;
			}
			set
			{
				this.metersField = value;
			}
		}

		// Token: 0x040000F7 RID: 247
		private ushort metersField;
	}
}
