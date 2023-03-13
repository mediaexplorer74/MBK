using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
	// Token: 0x02000030 RID: 48
	[XmlInclude(typeof(None_t))]
	[XmlInclude(typeof(Cadence_t))]
	[XmlInclude(typeof(HeartRate_t))]
	[XmlInclude(typeof(Speed_t))]
	[GeneratedCode("xsd", "4.0.30319.1")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
	public abstract class Target_t
	{
	}
}
