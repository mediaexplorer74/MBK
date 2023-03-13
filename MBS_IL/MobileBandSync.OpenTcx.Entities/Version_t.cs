using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Version_t
{
	private ushort versionMajorField;

	private ushort versionMinorField;

	private ushort buildMajorField;

	private bool buildMajorFieldSpecified;

	private ushort buildMinorField;

	private bool buildMinorFieldSpecified;

	public ushort VersionMajor
	{
		get
		{
			return versionMajorField;
		}
		set
		{
			versionMajorField = value;
		}
	}

	public ushort VersionMinor
	{
		get
		{
			return versionMinorField;
		}
		set
		{
			versionMinorField = value;
		}
	}

	public ushort BuildMajor
	{
		get
		{
			return buildMajorField;
		}
		set
		{
			buildMajorField = value;
		}
	}

	[XmlIgnore]
	public bool BuildMajorSpecified
	{
		get
		{
			return buildMajorFieldSpecified;
		}
		set
		{
			buildMajorFieldSpecified = value;
		}
	}

	public ushort BuildMinor
	{
		get
		{
			return buildMinorField;
		}
		set
		{
			buildMinorField = value;
		}
	}

	[XmlIgnore]
	public bool BuildMinorSpecified
	{
		get
		{
			return buildMinorFieldSpecified;
		}
		set
		{
			buildMinorFieldSpecified = value;
		}
	}
}
