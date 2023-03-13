using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Folders_t
{
	private History_t historyField;

	private Workouts_t workoutsField;

	private Courses_t coursesField;

	public History_t History
	{
		get
		{
			return historyField;
		}
		set
		{
			historyField = value;
		}
	}

	public Workouts_t Workouts
	{
		get
		{
			return workoutsField;
		}
		set
		{
			workoutsField = value;
		}
	}

	public Courses_t Courses
	{
		get
		{
			return coursesField;
		}
		set
		{
			coursesField = value;
		}
	}
}
