using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class HeartRateInBeatsPerMinute_t : HeartRateValue_t
{
	private byte valueField;

	public byte Value
	{
		get
		{
			return valueField;
		}
		set
		{
			valueField = value;
		}
	}
}
