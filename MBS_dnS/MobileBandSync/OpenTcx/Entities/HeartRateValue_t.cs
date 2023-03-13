using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x0200001E RID: 30
	[XmlInclude(typeof(HeartRateAsPercentOfMax_t))]
	[XmlInclude(typeof(HeartRateInBeatsPerMinute_t))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public abstract class HeartRateValue_t
	{
	}
}
