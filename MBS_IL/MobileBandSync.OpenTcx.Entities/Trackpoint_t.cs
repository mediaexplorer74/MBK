using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class Trackpoint_t
{
	private DateTime timeField;

	private Position_t positionField;

	private double altitudeMetersField;

	private bool altitudeMetersFieldSpecified;

	private double distanceMetersField;

	private bool distanceMetersFieldSpecified;

	private HeartRateInBeatsPerMinute_t heartRateBpmField;

	private byte cadenceField;

	private bool cadenceFieldSpecified;

	private SensorState_t sensorStateField;

	private bool sensorStateFieldSpecified;

	public DateTime Time
	{
		get
		{
			return timeField;
		}
		set
		{
			timeField = value;
		}
	}

	public Position_t Position
	{
		get
		{
			return positionField;
		}
		set
		{
			positionField = value;
		}
	}

	public double AltitudeMeters
	{
		get
		{
			return altitudeMetersField;
		}
		set
		{
			altitudeMetersField = value;
		}
	}

	[XmlIgnore]
	public bool AltitudeMetersSpecified
	{
		get
		{
			return altitudeMetersFieldSpecified;
		}
		set
		{
			altitudeMetersFieldSpecified = value;
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

	[XmlIgnore]
	public bool DistanceMetersSpecified
	{
		get
		{
			return distanceMetersFieldSpecified;
		}
		set
		{
			distanceMetersFieldSpecified = value;
		}
	}

	public HeartRateInBeatsPerMinute_t HeartRateBpm
	{
		get
		{
			return heartRateBpmField;
		}
		set
		{
			heartRateBpmField = value;
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

	public SensorState_t SensorState
	{
		get
		{
			return sensorStateField;
		}
		set
		{
			sensorStateField = value;
		}
	}

	[XmlIgnore]
	public bool SensorStateSpecified
	{
		get
		{
			return sensorStateFieldSpecified;
		}
		set
		{
			sensorStateFieldSpecified = value;
		}
	}
}
