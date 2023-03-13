using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Position_t
{
	private double latitudeDegreesField;

	private double longitudeDegreesField;

	public double LatitudeDegrees
	{
		get
		{
			return latitudeDegreesField;
		}
		set
		{
			latitudeDegreesField = value;
		}
	}

	public double LongitudeDegrees
	{
		get
		{
			return longitudeDegreesField;
		}
		set
		{
			longitudeDegreesField = value;
		}
	}
}
