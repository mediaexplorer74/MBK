using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class CustomSpeedZone_t : Zone_t
{
	private SpeedType_t viewAsField;

	private double lowInMetersPerSecondField;

	private double highInMetersPerSecondField;

	public SpeedType_t ViewAs
	{
		get
		{
			return viewAsField;
		}
		set
		{
			viewAsField = value;
		}
	}

	public double LowInMetersPerSecond
	{
		get
		{
			return lowInMetersPerSecondField;
		}
		set
		{
			lowInMetersPerSecondField = value;
		}
	}

	public double HighInMetersPerSecond
	{
		get
		{
			return highInMetersPerSecondField;
		}
		set
		{
			highInMetersPerSecondField = value;
		}
	}
}
