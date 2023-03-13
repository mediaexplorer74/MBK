using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class MultiSportSession_t
{
	private DateTime idField;

	private FirstSport_t firstSportField;

	private NextSport_t[] nextSportField;

	private string notesField;

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

	public FirstSport_t FirstSport
	{
		get
		{
			return firstSportField;
		}
		set
		{
			firstSportField = value;
		}
	}

	[XmlElement("NextSport")]
	public NextSport_t[] NextSport
	{
		get
		{
			return nextSportField;
		}
		set
		{
			nextSportField = value;
		}
	}

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
}
