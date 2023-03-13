using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class CaloriesBurned_t : Duration_t
{
	private ushort caloriesField;

	public ushort Calories
	{
		get
		{
			return caloriesField;
		}
		set
		{
			caloriesField = value;
		}
	}
}
