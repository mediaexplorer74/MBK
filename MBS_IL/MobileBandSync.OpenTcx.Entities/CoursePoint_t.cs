using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class CoursePoint_t
{
	private string nameField;

	private DateTime timeField;

	private Position_t positionField;

	private double altitudeMetersField;

	private bool altitudeMetersFieldSpecified;

	private CoursePointType_t pointTypeField;

	private string notesField;

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

	public DateTime Time
	{
		get
		{
			return timeField;
		}
		set
		{
			timeField = value;
		}
	}

	public Position_t Position
	{
		get
		{
			return positionField;
		}
		set
		{
			positionField = value;
		}
	}

	public double AltitudeMeters
	{
		get
		{
			return altitudeMetersField;
		}
		set
		{
			altitudeMetersField = value;
		}
	}

	[XmlIgnore]
	public bool AltitudeMetersSpecified
	{
		get
		{
			return altitudeMetersFieldSpecified;
		}
		set
		{
			altitudeMetersFieldSpecified = value;
		}
	}

	public CoursePointType_t PointType
	{
		get
		{
			return pointTypeField;
		}
		set
		{
			pointTypeField = value;
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
}
