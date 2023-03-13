using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Build_t
{
	private Version_t versionField;

	private BuildType_t typeField;

	private bool typeFieldSpecified;

	private string timeField;

	private string builderField;

	public Version_t Version
	{
		get
		{
			return versionField;
		}
		set
		{
			versionField = value;
		}
	}

	public BuildType_t Type
	{
		get
		{
			return typeField;
		}
		set
		{
			typeField = value;
		}
	}

	[XmlIgnore]
	public bool TypeSpecified
	{
		get
		{
			return typeFieldSpecified;
		}
		set
		{
			typeFieldSpecified = value;
		}
	}

	[XmlElement(DataType = "token")]
	public string Time
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

	[XmlElement(DataType = "token")]
	public string Builder
	{
		get
		{
			return builderField;
		}
		set
		{
			builderField = value;
		}
	}
}
