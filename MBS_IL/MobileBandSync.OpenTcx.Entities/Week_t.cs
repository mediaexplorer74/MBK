using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Week_t
{
	private string notesField;

	private DateTime startDayField;

	public string Notes
	{
		get
		{
			return notesField;
		}
		set
		{
			notesField = value;
		}
	}

	[XmlAttribute(DataType = "date")]
	public DateTime StartDay
	{
		get
		{
			return startDayField;
		}
		set
		{
			startDayField = value;
		}
	}
}
