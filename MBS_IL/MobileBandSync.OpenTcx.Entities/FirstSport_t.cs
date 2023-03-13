using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class FirstSport_t
{
	private Activity_t activityField;

	public Activity_t Activity
	{
		get
		{
			return activityField;
		}
		set
		{
			activityField = value;
		}
	}
}
