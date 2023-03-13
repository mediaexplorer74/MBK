using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Plan_t
{
	private string nameField;

	private TrainingType_t typeField;

	private bool intervalWorkoutField;

	[XmlElement(DataType = "token")]
	public string Name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
		}
	}

	[XmlAttribute]
	public TrainingType_t Type
	{
		get
		{
			return typeField;
		}
		set
		{
			typeField = value;
		}
	}

	[XmlAttribute]
	public bool IntervalWorkout
	{
		get
		{
			return intervalWorkoutField;
		}
		set
		{
			intervalWorkoutField = value;
		}
	}
}
