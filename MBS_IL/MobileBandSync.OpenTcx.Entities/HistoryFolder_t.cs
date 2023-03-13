using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class HistoryFolder_t
{
	private HistoryFolder_t[] folderField;

	private ActivityReference_t[] activityRefField;

	private Week_t[] weekField;

	private string notesField;

	private string nameField;

	[XmlElement("Folder")]
	public HistoryFolder_t[] Folder
	{
		get
		{
			return folderField;
		}
		set
		{
			folderField = value;
		}
	}

	[XmlElement("ActivityRef")]
	public ActivityReference_t[] ActivityRef
	{
		get
		{
			return activityRefField;
		}
		set
		{
			activityRefField = value;
		}
	}

	[XmlElement("Week")]
	public Week_t[] Week
	{
		get
		{
			return weekField;
		}
		set
		{
			weekField = value;
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

	[XmlAttribute]
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
}
