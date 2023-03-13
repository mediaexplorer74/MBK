using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class PredefinedHeartRateZone_t : Zone_t
{
	private string numberField;

	[XmlElement(DataType = "positiveInteger")]
	public string Number
	{
		get
		{
			return numberField;
		}
		set
		{
			numberField = value;
		}
	}
}
