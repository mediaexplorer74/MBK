using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[XmlInclude(typeof(Step_t))]
[XmlInclude(typeof(Repeat_t))]
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public abstract class AbstractStep_t
{
	private string stepIdField;

	[XmlElement(DataType = "positiveInteger")]
	public string StepId
	{
		get
		{
			return stepIdField;
		}
		set
		{
			stepIdField = value;
		}
	}
}
