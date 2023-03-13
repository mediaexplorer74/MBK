namespace MobileBandSync.Common;

public enum SensorLogType
{
	Timestamp = 0,
	SequenceID = 15,
	UtcOffset = 19,
	SkinTemperature = 66,
	Waypoint = 83,
	Sensor = 104,
	HeartRate = 128,
	Steps = 130,
	DailySummary = 230,
	WorkoutMarker = 208,
	WorkoutMarker2 = 210,
	WorkoutSummary = 161,
	Counter = 164,
	Unknown = 255,
	Sleep = 153,
	SleepSummary = 213,
	Timestamp2 = 224,
	Timestamp3 = 13,
	Timestamp4 = 226
}
