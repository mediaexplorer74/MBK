using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Device_t : AbstractSource_t
{
	private uint unitIdField;

	private ushort productIDField;

	private Version_t versionField;

	public uint UnitId
	{
		get
		{
			return unitIdField;
		}
		set
		{
			unitIdField = value;
		}
	}

	public ushort ProductID
	{
		get
		{
			return productIDField;
		}
		set
		{
			productIDField = value;
		}
	}

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
}
