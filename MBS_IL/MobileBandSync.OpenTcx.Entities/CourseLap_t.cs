using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public class CourseLap_t
{
	private double totalTimeSecondsField;

	private double distanceMetersField;

	private Position_t beginPositionField;

	private double beginAltitudeMetersField;

	private bool beginAltitudeMetersFieldSpecified;

	private Position_t endPositionField;

	private double endAltitudeMetersField;

	private bool endAltitudeMetersFieldSpecified;

	private HeartRateInBeatsPerMinute_t averageHeartRateBpmField;

	private HeartRateInBeatsPerMinute_t maximumHeartRateBpmField;

	private Intensity_t intensityField;

	private byte cadenceField;

	private bool cadenceFieldSpecified;

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

	public Position_t BeginPosition
	{
		get
		{
			return beginPositionField;
		}
		set
		{
			beginPositionField = value;
		}
	}

	public double BeginAltitudeMeters
	{
		get
		{
			return beginAltitudeMetersField;
		}
		set
		{
			beginAltitudeMetersField = value;
		}
	}

	[XmlIgnore]
	public bool BeginAltitudeMetersSpecified
	{
		get
		{
			return beginAltitudeMetersFieldSpecified;
		}
		set
		{
			beginAltitudeMetersFieldSpecified = value;
		}
	}

	public Position_t EndPosition
	{
		get
		{
			return endPositionField;
		}
		set
		{
			endPositionField = value;
		}
	}

	public double EndAltitudeMeters
	{
		get
		{
			return endAltitudeMetersField;
		}
		set
		{
			endAltitudeMetersField = value;
		}
	}

	[XmlIgnore]
	public bool EndAltitudeMetersSpecified
	{
		get
		{
			return endAltitudeMetersFieldSpecified;
		}
		set
		{
			endAltitudeMetersFieldSpecified = value;
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
}
