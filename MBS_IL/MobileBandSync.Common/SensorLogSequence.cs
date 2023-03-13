using System;
using System.Collections.Generic;

namespace MobileBandSync.Common;

public class SensorLogSequence
{
	public DateTime? TimeStamp { get; set; }

	public TimeSpan? Duration { get; set; }

	public int ID { get; set; }

	public int UtcOffset { get; set; }

	public List<HeartRate> HeartRates { get; }

	public List<Waypoint> Waypoints { get; }

	public List<Counter> Counters { get; }

	public List<SkinTemperature> Temperatures { get; }

	public List<Sensor> SensorList { get; }

	public List<Steps> StepSnapshots { get; }

	public List<SleepSummary> SleepSummaries { get; }

	public List<WorkoutMarker> WorkoutMarkers { get; }

	public List<WorkoutMarker2> WorkoutMarkers2 { get; }

	public List<SensorValueCollection1> SensorValues1 { get; }

	public List<SensorValueCollection2> SensorValues2 { get; }

	public List<SensorValueCollection3> SensorValues3 { get; }

	public List<UnknownData> AdditionalData { get; }

	public List<WorkoutSummary> WorkoutSummaries { get; }

	public List<DailySummary> DailySummaries { get; }

	public SensorLogSequence(long lFileTime)
	{
		if (lFileTime > 0)
		{
			TimeStamp = DateTime.FromFileTime(lFileTime);
		}
		else
		{
			TimeStamp = DateTime.MinValue;
		}
		HeartRates = new List<HeartRate>();
		Waypoints = new List<Waypoint>();
		AdditionalData = new List<UnknownData>();
		Counters = new List<Counter>();
		Temperatures = new List<SkinTemperature>();
		WorkoutMarkers = new List<WorkoutMarker>();
		WorkoutMarkers2 = new List<WorkoutMarker2>();
		SensorValues1 = new List<SensorValueCollection1>();
		SensorValues2 = new List<SensorValueCollection2>();
		SensorValues3 = new List<SensorValueCollection3>();
		StepSnapshots = new List<Steps>();
		SleepSummaries = new List<SleepSummary>();
		WorkoutSummaries = new List<WorkoutSummary>();
		DailySummaries = new List<DailySummary>();
		SensorList = new List<Sensor>();
	}
}
