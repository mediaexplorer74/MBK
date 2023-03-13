using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Time_t : Duration_t
{
	private ushort secondsField;

	public ushort Seconds
	{
		get
		{
			return secondsField;
		}
		set
		{
			secondsField = value;
		}
	}
}
