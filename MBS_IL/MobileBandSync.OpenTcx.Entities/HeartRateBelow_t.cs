using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class HeartRateBelow_t : Duration_t
{
	private HeartRateValue_t heartRateField;

	public HeartRateValue_t HeartRate
	{
		get
		{
			return heartRateField;
		}
		set
		{
			heartRateField = value;
		}
	}
}
