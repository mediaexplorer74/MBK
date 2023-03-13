using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Cadence_t : Target_t
{
	private double lowField;

	private double highField;

	public double Low
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

	public double High
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
