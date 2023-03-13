using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class History_t
{
	private HistoryFolder_t runningField;

	private HistoryFolder_t bikingField;

	private HistoryFolder_t otherField;

	private MultiSportFolder_t multiSportField;

	public HistoryFolder_t Running
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

	public HistoryFolder_t Biking
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

	public HistoryFolder_t Other
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

	public MultiSportFolder_t MultiSport
	{
		get
		{
			return multiSportField;
		}
		set
		{
			multiSportField = value;
		}
	}
}
