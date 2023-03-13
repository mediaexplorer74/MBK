using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Workouts_t
{
	private WorkoutFolder_t runningField;

	private WorkoutFolder_t bikingField;

	private WorkoutFolder_t otherField;

	public WorkoutFolder_t Running
	{
		get
		{
			return runningField;
		}
		set
		{
			runningField = value;
		}
	}

	public WorkoutFolder_t Biking
	{
		get
		{
			return bikingField;
		}
		set
		{
			bikingField = value;
		}
	}

	public WorkoutFolder_t Other
	{
		get
		{
			return otherField;
		}
		set
		{
			otherField = value;
		}
	}
}
