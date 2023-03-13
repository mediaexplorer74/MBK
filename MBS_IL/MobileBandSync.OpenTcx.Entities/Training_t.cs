using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Training_t
{
	private QuickWorkout_t quickWorkoutResultsField;

	private Plan_t planField;

	private bool virtualPartnerField;

	public QuickWorkout_t QuickWorkoutResults
	{
		get
		{
			return quickWorkoutResultsField;
		}
		set
		{
			quickWorkoutResultsField = value;
		}
	}

	public Plan_t Plan
	{
		get
		{
			return planField;
		}
		set
		{
			planField = value;
		}
	}

	[XmlAttribute]
	public bool VirtualPartner
	{
		get
		{
			return virtualPartnerField;
		}
		set
		{
			virtualPartnerField = value;
		}
	}
}
