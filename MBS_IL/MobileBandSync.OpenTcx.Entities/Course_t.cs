using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Course_t
{
	private string nameField;

	private CourseLap_t[] lapField;

	private Trackpoint_t[] trackField;

	private string notesField;

	private CoursePoint_t[] coursePointField;

	private AbstractSource_t creatorField;

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

	[XmlElement("Lap")]
	public CourseLap_t[] Lap
	{
		get
		{
			return lapField;
		}
		set
		{
			lapField = value;
		}
	}

	[XmlArrayItem("Trackpoint", typeof(Trackpoint_t), IsNullable = false)]
	public Trackpoint_t[] Track
	{
		get
		{
			return trackField;
		}
		set
		{
			trackField = value;
		}
	}

	public string Notes
	{
		get
		{
			return notesField;
		}
		set
		{
			notesField = value;
		}
	}

	[XmlElement("CoursePoint")]
	public CoursePoint_t[] CoursePoint
	{
		get
		{
			return coursePointField;
		}
		set
		{
			coursePointField = value;
		}
	}

	public AbstractSource_t Creator
	{
		get
		{
			return creatorField;
		}
		set
		{
			creatorField = value;
		}
	}
}
