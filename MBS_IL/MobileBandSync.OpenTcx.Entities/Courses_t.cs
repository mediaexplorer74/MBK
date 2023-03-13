using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Courses_t
{
	private CourseFolder_t courseFolderField;

	public CourseFolder_t CourseFolder
	{
		get
		{
			return courseFolderField;
		}
		set
		{
			courseFolderField = value;
		}
	}
}
