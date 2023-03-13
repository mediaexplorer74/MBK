using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Step_t : AbstractStep_t
{
	private string nameField;

	private Duration_t durationField;

	private Intensity_t intensityField;

	private Target_t targetField;

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

	public Duration_t Duration
	{
		get
		{
			return durationField;
		}
		set
		{
			durationField = value;
		}
	}

	public Intensity_t Intensity
	{
		get
		{
			return intensityField;
		}
		set
		{
			intensityField = value;
		}
	}

	public Target_t Target
	{
		get
		{
			return targetField;
		}
		set
		{
			targetField = value;
		}
	}
}
