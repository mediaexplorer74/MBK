using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
[XmlRoot("TrainingCenterDatabase", Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2", IsNullable = false)]
public class TrainingCenterDatabase_t
{
	private Folders_t foldersField;

	private ActivityList_t activitiesField;

	private Workout_t[] workoutsField;

	private Course_t[] coursesField;

	private AbstractSource_t authorField;

	public Folders_t Folders
	{
		get
		{
			return foldersField;
		}
		set
		{
			foldersField = value;
		}
	}

	public ActivityList_t Activities
	{
		get
		{
			return activitiesField;
		}
		set
		{
			activitiesField = value;
		}
	}

	[XmlArrayItem("Workout", IsNullable = false)]
	public Workout_t[] Workouts
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

	[XmlArrayItem("Course", IsNullable = false)]
	public Course_t[] Courses
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

	public AbstractSource_t Author
	{
		get
		{
			return authorField;
		}
		set
		{
			authorField = value;
		}
	}
}
