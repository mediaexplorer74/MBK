using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Application_t : AbstractSource_t
{
	private Build_t buildField;

	private string langIDField;

	private string partNumberField;

	public Build_t Build
	{
		get
		{
			return buildField;
		}
		set
		{
			buildField = value;
		}
	}

	[XmlElement(DataType = "token")]
	public string LangID
	{
		get
		{
			return langIDField;
		}
		set
		{
			langIDField = value;
		}
	}

	[XmlElement(DataType = "token")]
	public string PartNumber
	{
		get
		{
			return partNumberField;
		}
		set
		{
			partNumberField = value;
		}
	}
}
