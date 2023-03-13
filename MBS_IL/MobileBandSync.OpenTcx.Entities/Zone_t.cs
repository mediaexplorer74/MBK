using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[XmlInclude(typeof(CustomHeartRateZone_t))]
[XmlInclude(typeof(PredefinedHeartRateZone_t))]
[XmlInclude(typeof(CustomSpeedZone_t))]
[XmlInclude(typeof(PredefinedSpeedZone_t))]
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public abstract class Zone_t
{
}
