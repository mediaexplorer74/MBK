using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class CourseFolder_t
{
	private CourseFolder_t[] folderField;

	private NameKeyReference_t[] courseNameRefField;

	private string notesField;

	private string nameField;

	[XmlElement("Folder")]
	public CourseFolder_t[] Folder
	{
		get
		{
			return folderField;
		}
		set
		{
			folderField = value;
		}
	}

	[XmlElement("CourseNameRef")]
	public NameKeyReference_t[] CourseNameRef
	{
		get
		{
			return courseNameRefField;
		}
		set
		{
			courseNameRefField = value;
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

	[XmlAttribute]
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
}
