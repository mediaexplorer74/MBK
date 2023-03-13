using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Workout_t
{
	private string nameField;

	private AbstractStep_t[] stepField;

	private DateTime[] scheduledOnField;

	private string notesField;

	private AbstractSource_t creatorField;

	private Sport_t sportField;

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

	[XmlElement("Step")]
	public AbstractStep_t[] Step
	{
		get
		{
			return stepField;
		}
		set
		{
			stepField = value;
		}
	}

	[XmlElement("ScheduledOn", DataType = "date")]
	public DateTime[] ScheduledOn
	{
		get
		{
			return scheduledOnField;
		}
		set
		{
			scheduledOnField = value;
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
