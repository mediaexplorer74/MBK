using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Activity_t
{
	private DateTime idField;

	private ActivityLap_t[] lapField;

	private string notesField;

	private Training_t trainingField;

	private AbstractSource_t creatorField;

	private Sport_t sportField;

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

	[XmlElement("Lap")]
	public ActivityLap_t[] Lap
	{
		get
		{
			return lapField;
		}
		set
		{
			lapField = value;
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

	public Training_t Training
	{
		get
		{
			return trainingField;
		}
		set
		{
			trainingField = value;
		}
	}

	public AbstractSource_t Creator
	{
		get
		{
			return creatorField;
		}
		set
		{
			creatorField = value;
		}
	}

	[XmlAttribute]
	public Sport_t Sport
	{
		get
		{
			return sportField;
		}
		set
		{
			sportField = value;
		}
	}
}
