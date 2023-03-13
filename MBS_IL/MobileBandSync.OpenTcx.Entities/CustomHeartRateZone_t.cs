using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class CustomHeartRateZone_t : Zone_t
{
	private HeartRateValue_t lowField;

	private HeartRateValue_t highField;

	public HeartRateValue_t Low
	{
		get
		{
			return lowField;
		}
		set
		{
			lowField = value;
		}
	}

	public HeartRateValue_t High
	{
		get
		{
			return highField;
		}
		set
		{
			highField = value;
		}
	}
}
