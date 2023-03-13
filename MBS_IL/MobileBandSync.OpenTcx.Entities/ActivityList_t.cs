using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class ActivityList_t
{
	private Activity_t[] activityField;

	private MultiSportSession_t[] multiSportSessionField;

	[XmlElement("Activity")]
	public Activity_t[] Activity
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

	[XmlElement("MultiSportSession")]
	public MultiSportSession_t[] MultiSportSession
	{
		get
		{
			return multiSportSessionField;
		}
		set
		{
			multiSportSessionField = value;
		}
	}
}
