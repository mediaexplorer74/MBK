using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000035 RID: 53
	[XmlInclude(typeof(UserInitiated_t))]
	[XmlInclude(typeof(CaloriesBurned_t))]
	[XmlInclude(typeof(HeartRateBelow_t))]
	[XmlInclude(typeof(HeartRateAbove_t))]
	[XmlInclude(typeof(Distance_t))]
	[XmlInclude(typeof(Time_t))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public abstract class Duration_t
	{
	}
}
