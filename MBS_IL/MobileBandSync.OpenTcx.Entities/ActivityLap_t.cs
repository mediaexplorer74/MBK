using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class ActivityLap_t
{
	private double totalTimeSecondsField;

	private double distanceMetersField;

	private double maximumSpeedField;

	private bool maximumSpeedFieldSpecified;

	private ushort caloriesField;

	private HeartRateInBeatsPerMinute_t averageHeartRateBpmField;

	private HeartRateInBeatsPerMinute_t maximumHeartRateBpmField;

	private Intensity_t intensityField;

	private byte cadenceField;

	private bool cadenceFieldSpecified;

	private TriggerMethod_t triggerMethodField;

	private Trackpoint_t[] trackField;

	private string notesField;

	private DateTime startTimeField;

	public double TotalTimeSeconds
	{
		get
		{
			return totalTimeSecondsField;
		}
		set
		{
			totalTimeSecondsField = value;
		}
	}

	public double DistanceMeters
	{
		get
		{
			return distanceMetersField;
		}
		set
		{
			distanceMetersField = value;
		}
	}

	public double MaximumSpeed
	{
		get
		{
			return maximumSpeedField;
		}
		set
		{
			maximumSpeedField = value;
		}
	}

	[XmlIgnore]
	public bool MaximumSpeedSpecified
	{
		get
		{
			return maximumSpeedFieldSpecified;
		}
		set
		{
			maximumSpeedFieldSpecified = value;
		}
	}

	public ushort Calories
	{
		get
		{
			return caloriesField;
		}
		set
		{
			caloriesField = value;
		}
	}

	public HeartRateInBeatsPerMinute_t AverageHeartRateBpm
	{
		get
		{
			return averageHeartRateBpmField;
		}
		set
		{
			averageHeartRateBpmField = value;
		}
	}

	public HeartRateInBeatsPerMinute_t MaximumHeartRateBpm
	{
		get
		{
			return maximumHeartRateBpmField;
		}
		set
		{
			maximumHeartRateBpmField = value;
		}
	}

	public Intensity_t Intensity
	{
		get
		{
			return intensityField;
		}
		set
		{
			intensityField = value;
		}
	}

	public byte Cadence
	{
		get
		{
			return cadenceField;
		}
		set
		{
			cadenceField = value;
		}
	}

	[XmlIgnore]
	public bool CadenceSpecified
	{
		get
		{
			return cadenceFieldSpecified;
		}
		set
		{
			cadenceFieldSpecified = value;
		}
	}

	public TriggerMethod_t TriggerMethod
	{
		get
		{
			return triggerMethodField;
		}
		set
		{
			triggerMethodField = value;
		}
	}

	[XmlArrayItem("Trackpoint", typeof(Trackpoint_t), IsNullable = false)]
	public Trackpoint_t[] Track
	{
		get
		{
			return trackField;
		}
		set
		{
			trackField = value;
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
	public DateTime StartTime
	{
		get
		{
			return startTimeField;
		}
		set
		{
			startTimeField = value;
		}
	}
}
