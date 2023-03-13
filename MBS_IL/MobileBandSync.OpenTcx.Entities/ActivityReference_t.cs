using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class ActivityReference_t
{
	private DateTime idField;

	public DateTime Id
	{
		get
		{
			return idField;
		}
		set
		{
			idField = value;
		}
	}
}
