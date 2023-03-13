using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class HeartRate_t : Target_t
{
	private Zone_t heartRateZoneField;

	public Zone_t HeartRateZone
	{
		get
		{
			return heartRateZoneField;
		}
		set
		{
			heartRateZoneField = value;
		}
	}
}
