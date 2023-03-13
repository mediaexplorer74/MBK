using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MobileBandSync.Data;
using MobileBandSync.OpenTcx;
using MobileBandSync.OpenTcx.Entities;
using Windows.ApplicationModel.Resources;
using Windows.Data.Xml.Dom;

namespace MobileBandSync.Common;

public class SensorLog
{
	private Stream DataStream;

	public Dictionary<uint, Dictionary<uint, uint>> IdOccurencies = new Dictionary<uint, Dictionary<uint, uint>>();

	public List<SensorLogSequence> Sequences { get; }

	public ulong BufferSize { get; set; }

	public ulong StepLength { get; internal set; }

	public string BandName { get; set; }

	public SensorLog()
	{
		Sequences = new List<SensorLogSequence>();
	}

	public static bool IsSensorLog(Stream stream, out DateTime dtStartDate)
	{
		bool result = false;
		dtStartDate = DateTime.MinValue;
		if (stream.CanRead && stream.CanSeek)
		{
			stream.Seek(0L, SeekOrigin.Begin);
			if (stream.ReadByte() == 0)
			{
				int num = stream.ReadByte();
				if (num == 8)
				{
					byte[] array = new byte[num];
					stream.Read(array, 0, num);
					long num2 = BitConverter.ToInt64(array, 0);
					if (num2 > 0)
					{
						dtStartDate = DateTime.FromFileTime(num2);
						result = true;
					}
				}
			}
		}
		return result;
	}

	public async Task<bool> Read(Stream stream)
	{
		DataStream = stream;
		DateTime LastTimeStamp = DateTime.MinValue;
		ushort CurrentSleepType = 9999;
		ushort CurrentSegmentType = 9999;
		if (DataStream.CanSeek)
		{
			await Task.Run(delegate
			{
				SensorLogSequence sensorLogSequence2 = null;
				int num = -1;
				DateTime dateTime = DateTime.Now;
				DateTime dateTime2 = DateTime.Now;
				TimeSpan timeSpan = TimeSpan.MinValue;
				DataStream.Seek(0L, SeekOrigin.Begin);
				do
				{
					try
					{
						num = DataStream.ReadByte();
						if (num == -1)
						{
							break;
						}
						int num2 = DataStream.ReadByte();
						SensorLogType sensorLogType = (SensorLogType)num;
						byte[] array = new byte[num2];
						DataStream.Read(array, 0, num2);
						switch (sensorLogType)
						{
						case SensorLogType.Timestamp:
						{
							long num7 = BitConverter.ToInt64(array, 0);
							if (num7 > 0)
							{
								if (sensorLogSequence2 == null)
								{
									sensorLogSequence2 = new SensorLogSequence(num7);
									dateTime = DateTime.FromFileTime(num7);
									dateTime2 = DateTime.FromFileTimeUtc(num7);
									if (Sequences.Count > 0)
									{
										SensorLogSequence sensorLogSequence3 = Sequences[Sequences.Count - 1];
										if (sensorLogSequence3 != null)
										{
											DateTime value2 = dateTime;
											DateTime? timeStamp3 = sensorLogSequence3.TimeStamp;
											sensorLogSequence3.Duration = value2 - timeStamp3;
										}
									}
								}
								else
								{
									dateTime = (LastTimeStamp = DateTime.FromFileTime(num7));
									dateTime2 = DateTime.FromFileTimeUtc(num7);
								}
							}
							break;
						}
						case SensorLogType.Timestamp3:
						case SensorLogType.Timestamp2:
						case SensorLogType.Timestamp4:
						{
							long num5 = BitConverter.ToInt64(array, 1);
							if (num5 > 0)
							{
								dateTime = DateTime.FromFileTime(num5);
								dateTime2 = DateTime.FromFileTimeUtc(num5);
							}
							break;
						}
						case SensorLogType.UtcOffset:
							if (sensorLogSequence2 != null)
							{
								sensorLogSequence2.UtcOffset = BitConverter.ToInt16(array, 0);
								timeSpan = new TimeSpan(0, sensorLogSequence2.UtcOffset, 0);
							}
							break;
						case SensorLogType.SequenceID:
							if (sensorLogSequence2 != null)
							{
								sensorLogSequence2.ID = BitConverter.ToInt32(array, 0);
								Sequences.Add(sensorLogSequence2);
								sensorLogSequence2 = null;
							}
							break;
						case SensorLogType.Steps:
							if (sensorLogSequence2 != null && CurrentSleepType == 9999 && CurrentSegmentType == 9999)
							{
								sensorLogSequence2.StepSnapshots.Add(new Steps
								{
									Counter = BitConverter.ToUInt32(array, 0),
									TimeStamp = dateTime
								});
							}
							break;
						case SensorLogType.HeartRate:
							if (sensorLogSequence2 != null)
							{
								sensorLogSequence2.HeartRates.Add(new HeartRate
								{
									Bpm = array[0],
									Accuracy = array[1],
									TimeStamp = dateTime
								});
								if (CurrentSleepType != 9999 && CurrentSegmentType != 9999)
								{
									sensorLogSequence2.StepSnapshots.Add(new Steps
									{
										Counter = 0u,
										SleepType = CurrentSleepType,
										SegmentType = CurrentSegmentType,
										TimeStamp = dateTime
									});
								}
							}
							break;
						case SensorLogType.WorkoutMarker:
							if (sensorLogSequence2 != null)
							{
								int num6 = array[1];
								if (num6 != 4 && num6 != 6 && num6 != 21 && num6 != 32)
								{
									num6 = 99;
								}
								DateTime timeStamp2 = ((num6 != 21) ? (dateTime2 + timeSpan) : LastTimeStamp);
								if (num6 == 21)
								{
									CurrentSleepType = 0;
									CurrentSegmentType = 0;
								}
								else
								{
									CurrentSleepType = 9999;
									CurrentSegmentType = 9999;
								}
								sensorLogSequence2.WorkoutMarkers.Add(new WorkoutMarker
								{
									Action = (DistanceAnnotationType)array[0],
									WorkoutType = (EventType)num6,
									Value2 = array[2],
									TimeStamp = timeStamp2
								});
							}
							break;
						case SensorLogType.WorkoutMarker2:
							sensorLogSequence2?.WorkoutMarkers2.Add(new WorkoutMarker2
							{
								Value1 = BitConverter.ToInt16(array, 0),
								Value2 = BitConverter.ToInt32(array, 2),
								TimeStamp = LastTimeStamp
							});
							break;
						case SensorLogType.Sensor:
							sensorLogSequence2?.SensorList.Add(new Sensor
							{
								Value1 = BitConverter.ToUInt32(array, 0),
								GalvanicSkinResponse = BitConverter.ToUInt32(array, 4),
								Value2 = BitConverter.ToUInt32(array, 8),
								Value3 = BitConverter.ToUInt32(array, 12),
								TimeStamp = dateTime
							});
							break;
						case SensorLogType.SkinTemperature:
							if (sensorLogSequence2 != null)
							{
								double num9 = BitConverter.ToInt16(array, 0);
								sensorLogSequence2.Temperatures.Add(new SkinTemperature
								{
									DegreeCelsius = ((num9 > 0.0) ? (num9 / 100.0) : 0.0),
									TimeStamp = dateTime
								});
							}
							break;
						case SensorLogType.Waypoint:
							if (sensorLogSequence2 != null)
							{
								double num10 = BitConverter.ToInt32(array, 2);
								double num11 = BitConverter.ToInt32(array, 6);
								double num12 = BitConverter.ToInt32(array, 10);
								double num13 = BitConverter.ToInt16(array, 0);
								double num14 = BitConverter.ToInt32(array, 14);
								double num15 = BitConverter.ToInt32(array, 18);
								sensorLogSequence2.Waypoints.Add(new Waypoint
								{
									SpeedOverGround = ((num13 > 0.0) ? (num13 / 100.0) : 0.0),
									Latitude = num10 / 10000000.0,
									Longitude = num11 / 10000000.0,
									ElevationFromMeanSeaLevel = num12 / 100.0,
									EstimatedHorizontalError = ((num14 > 0.0) ? (num14 / 100.0) : 0.0),
									EstimatedVerticalError = ((num15 > 0.0) ? (num15 / 100.0) : 0.0),
									TimeStamp = dateTime
								});
							}
							break;
						case SensorLogType.Counter:
							if (sensorLogSequence2 != null)
							{
								sensorLogSequence2.Counters.Add(new Counter
								{
									Value1 = BitConverter.ToInt32(array, 0),
									Value2 = BitConverter.ToInt32(array, 4)
								});
								dateTime = dateTime.AddSeconds(1.0);
								dateTime2 = dateTime2.AddSeconds(1.0);
							}
							break;
						case SensorLogType.WorkoutSummary:
							if (sensorLogSequence2 != null)
							{
								long num16 = BitConverter.ToInt64(array, 0);
								long num17 = BitConverter.ToInt64(array, 38);
								DateTime startDate2 = ((num16 > 0) ? DateTime.FromFileTime(num16) : DateTime.MinValue);
								DateTime intermediateDate2 = ((num17 > 0) ? DateTime.FromFileTime(num17) : DateTime.MinValue);
								double num18 = BitConverter.ToInt32(array, 10);
								double num19 = BitConverter.ToInt32(array, 14);
								double num20 = BitConverter.ToInt32(array, 18);
								double num21 = BitConverter.ToInt32(array, 22);
								int caloriesBurned = BitConverter.ToInt32(array, 26);
								int hFAverage = BitConverter.ToInt32(array, 30);
								int hFMax = BitConverter.ToInt32(array, 34);
								int utcDiffHrs = BitConverter.ToInt32(array, 46);
								double num22 = BitConverter.ToInt32(array, 50);
								sensorLogSequence2.WorkoutSummaries.Add(new WorkoutSummary
								{
									StartDate = startDate2,
									IntermediateDate = intermediateDate2,
									Duration = num18 / 1000.0,
									Distance = num19 / 100.0,
									AverageSpeed = num20 / 100.0,
									MaximumSpeed = num21 / 100.0,
									CaloriesBurned = caloriesBurned,
									HFAverage = hFAverage,
									HFMax = hFMax,
									UtcDiffHrs = utcDiffHrs,
									TotalElevation = num22 / 100.0,
									UnknownValue1 = BitConverter.ToInt16(array, 8),
									UnknownValue2 = BitConverter.ToInt32(array, 54),
									UnknownValue3 = BitConverter.ToInt32(array, 58),
									UnknownValue4 = BitConverter.ToInt32(array, 62),
									UnknownValue5 = BitConverter.ToInt32(array, 66),
									UnknownValue6 = BitConverter.ToInt32(array, 70),
									UnknownValue7 = BitConverter.ToInt32(array, 74)
								});
							}
							break;
						case SensorLogType.DailySummary:
							if (sensorLogSequence2 != null)
							{
								long num8 = BitConverter.ToInt64(array, 1);
								sensorLogSequence2.DailySummaries.Add(new DailySummary
								{
									Flag = array[0],
									Date = ((num8 > 0) ? DateTime.FromFileTime(num8) : DateTime.MinValue)
								});
							}
							break;
						case SensorLogType.Sleep:
							if (sensorLogSequence2 != null)
							{
								CurrentSleepType = BitConverter.ToUInt16(array, 0);
								CurrentSegmentType = BitConverter.ToUInt16(array, 2);
							}
							break;
						case SensorLogType.SleepSummary:
							if (sensorLogSequence2 != null)
							{
								long num3 = BitConverter.ToInt64(array, 0);
								long num4 = BitConverter.ToInt64(array, 38);
								DateTime startDate = ((num3 > 0) ? DateTime.FromFileTime(num3) : DateTime.MinValue);
								DateTime intermediateDate = ((num4 > 0) ? DateTime.FromFileTime(num4) : DateTime.MinValue);
								sensorLogSequence2.SleepSummaries.Add(new SleepSummary
								{
									StartDate = startDate,
									IntermediateDate = intermediateDate,
									Duration = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 10)),
									Version = BitConverter.ToInt16(array, 8),
									TimesAwoke = BitConverter.ToInt32(array, 14),
									TotalRestlessSleepDuration = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 18)),
									TotalRestfulSleepDuration = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 22)),
									CaloriesBurned = BitConverter.ToInt32(array, 26),
									HFAverage = BitConverter.ToInt32(array, 30),
									HFMax = BitConverter.ToInt32(array, 34),
									FallAsleepTime = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 46)),
									Feeling = BitConverter.ToUInt32(array, 50)
								});
							}
							break;
						default:
							switch (num)
							{
							}
							break;
						}
					}
					catch (Exception)
					{
						break;
					}
				}
				while (num >= 0);
			});
		}
		if (Sequences.Count > 0)
		{
			SensorLogSequence sensorLogSequence = Sequences[Sequences.Count - 1];
			if (sensorLogSequence != null && LastTimeStamp != DateTime.MinValue)
			{
				DateTime value = LastTimeStamp;
				DateTime? timeStamp = sensorLogSequence.TimeStamp;
				if (value > timeStamp)
				{
					value = LastTimeStamp;
					timeStamp = sensorLogSequence.TimeStamp;
					sensorLogSequence.Duration = value - timeStamp;
				}
			}
		}
		return true;
	}

	public async Task<List<Workout>> CreateWorkouts(ExportType type = (ExportType)26)
	{
		List<Workout> Workouts = new List<Workout>();
		await Task.Run(delegate
		{
			Workout currenWorkout = null;
			ResourceLoader forViewIndependentUse = ResourceLoader.GetForViewIndependentUse();
			Dictionary<DateTime, int> dictionary = new Dictionary<DateTime, int>();
			Dictionary<DateTime, double> dictionary2 = new Dictionary<DateTime, double>();
			Dictionary<DateTime, GpsPosition> dictionary3 = new Dictionary<DateTime, GpsPosition>();
			Dictionary<DateTime, uint> dictionary4 = new Dictionary<DateTime, uint>();
			Dictionary<DateTime, double> dictionary5 = new Dictionary<DateTime, double>();
			Dictionary<DateTime, uint> dictionary6 = new Dictionary<DateTime, uint>();
			DateTime endTime = DateTime.Now;
			double num = 48.6721393;
			double num2 = 9.24037;
			double num3 = 5E-05;
			double num4 = num;
			double num5 = num2;
			foreach (SensorLogSequence sequence in Sequences)
			{
				if (sequence.WorkoutSummaries.Count > 0 && Workouts.Count > 0)
				{
					((currenWorkout == null) ? Workouts[Workouts.Count - 1] : currenWorkout).Summary = sequence.WorkoutSummaries[sequence.WorkoutSummaries.Count - 1];
					num4 = num;
					num5 = num2;
				}
				if (sequence.SleepSummaries.Count > 0 && Workouts.Count > 0)
				{
					((currenWorkout == null) ? Workouts[Workouts.Count - 1] : currenWorkout).SleepSummary = sequence.SleepSummaries[sequence.SleepSummaries.Count - 1];
				}
				if (sequence.WorkoutMarkers.Count > 0)
				{
					foreach (WorkoutMarker workoutMarker in sequence.WorkoutMarkers)
					{
						if (workoutMarker.Action == DistanceAnnotationType.Start)
						{
							if (currenWorkout != null)
							{
								currenWorkout.EndTime = endTime;
								AddWorkoutData(ref currenWorkout, dictionary, dictionary2, dictionary3, dictionary4, dictionary5, dictionary6);
								if (!Workouts.Contains(currenWorkout))
								{
									Workouts.Add(currenWorkout);
								}
								currenWorkout = null;
								dictionary.Clear();
								dictionary2.Clear();
								dictionary3.Clear();
								dictionary5.Clear();
								dictionary4.Clear();
								dictionary6.Clear();
							}
							currenWorkout = new Workout();
							Workout workout = currenWorkout;
							DateTime lastSplitTime = (currenWorkout.StartTime = workoutMarker.TimeStamp);
							workout.LastSplitTime = lastSplitTime;
							currenWorkout.Type = workoutMarker.WorkoutType;
							if (!Workouts.Contains(currenWorkout))
							{
								Workouts.Add(currenWorkout);
							}
							currenWorkout.Filename = currenWorkout.Type.ToString() + "-" + currenWorkout.StartTime.Year.ToString("D4", WorkoutDataSource.AppCultureInfo) + currenWorkout.StartTime.Month.ToString("D2", WorkoutDataSource.AppCultureInfo) + currenWorkout.StartTime.Day.ToString("D2", WorkoutDataSource.AppCultureInfo) + currenWorkout.StartTime.Hour.ToString("D2", WorkoutDataSource.AppCultureInfo) + currenWorkout.StartTime.Minute.ToString("D2", WorkoutDataSource.AppCultureInfo) + currenWorkout.StartTime.Second.ToString("D2", WorkoutDataSource.AppCultureInfo) + ".tcx";
							currenWorkout.Notes = string.Format(forViewIndependentUse.GetString("GeneratedString"), new object[2]
							{
								WorkoutDataSource.BandName,
								currenWorkout.StartTime.ToString(WorkoutDataSource.AppCultureInfo)
							});
						}
						else if (workoutMarker.Action == DistanceAnnotationType.Split)
						{
							if (currenWorkout == null && Workouts.Count > 0)
							{
								currenWorkout = Workouts[Workouts.Count - 1];
								Workouts.RemoveAt(Workouts.Count - 1);
							}
							if (currenWorkout != null)
							{
								currenWorkout.LastSplitTime = workoutMarker.TimeStamp;
							}
						}
						else if (workoutMarker.Action == DistanceAnnotationType.Pause)
						{
							if (currenWorkout != null)
							{
								DateTime lastSplitTime = (currenWorkout.EndTime = workoutMarker.TimeStamp);
								endTime = lastSplitTime;
								AddWorkoutData(ref currenWorkout, dictionary, dictionary2, dictionary3, dictionary4, dictionary5, dictionary6);
								if (!Workouts.Contains(currenWorkout))
								{
									Workouts.Add(currenWorkout);
								}
								if (currenWorkout.Type == EventType.Sleeping)
								{
									num4 = num;
									num5 = num2;
								}
								currenWorkout = null;
								dictionary.Clear();
								dictionary2.Clear();
								dictionary3.Clear();
								dictionary5.Clear();
								dictionary4.Clear();
								dictionary6.Clear();
							}
						}
						else
						{
							endTime = workoutMarker.TimeStamp;
							if (currenWorkout != null && currenWorkout.EndTime == DateTime.MinValue)
							{
								currenWorkout.EndTime = endTime;
							}
						}
					}
				}
				if (currenWorkout != null)
				{
					if ((type & ExportType.HeartRate) == ExportType.HeartRate && sequence.HeartRates.Count > 0)
					{
						if (currenWorkout.Type == EventType.Sleeping)
						{
							List<HeartRate> list = new List<HeartRate>();
							foreach (HeartRate heartRate in sequence.HeartRates)
							{
								if (heartRate.Accuracy >= 9)
								{
									list.Add(heartRate);
								}
							}
							double num6 = 0.0;
							_ = sequence.Duration.Value;
							if (sequence.Duration > TimeSpan.FromSeconds(1.0))
							{
								num6 = sequence.Duration.Value.TotalSeconds / (double)list.Count;
							}
							double num7 = 0.0;
							DateTime dateTime = sequence.TimeStamp.Value;
							foreach (HeartRate item in list)
							{
								DateTime dateTime2 = sequence.TimeStamp.Value + TimeSpan.FromSeconds(num7);
								if (num7 == 0.0 || dateTime2 >= dateTime + TimeSpan.FromSeconds(60.0))
								{
									dictionary[dateTime2] = item.Bpm;
									dictionary3[dateTime2] = new GpsPosition
									{
										LatitudeDegrees = num4,
										LongitudeDegrees = num5
									};
									dictionary2[dateTime2] = 360.0;
									num4 += num3;
									num5 += num3;
									dateTime = dateTime2;
								}
								num7 += num6;
							}
						}
						else
						{
							foreach (HeartRate heartRate2 in sequence.HeartRates)
							{
								if (heartRate2.TimeStamp >= currenWorkout.LastSplitTime - TimeSpan.FromSeconds(10.0) && (heartRate2.Accuracy >= 8 || (heartRate2.Accuracy >= 5 && heartRate2.TimeStamp <= currenWorkout.LastSplitTime + TimeSpan.FromSeconds(120.0))))
								{
									dictionary[heartRate2.TimeStamp] = heartRate2.Bpm;
								}
							}
						}
					}
					if (sequence.SensorList.Count > 0)
					{
						foreach (Sensor sensor in sequence.SensorList)
						{
							dictionary4[sensor.TimeStamp] = sensor.GalvanicSkinResponse;
						}
					}
					if (sequence.StepSnapshots.Count > 0)
					{
						foreach (Steps stepSnapshot in sequence.StepSnapshots)
						{
							if (currenWorkout.Type == EventType.Sleeping)
							{
								DateTime key = new DateTime(stepSnapshot.TimeStamp.Year, stepSnapshot.TimeStamp.Month, stepSnapshot.TimeStamp.Day, stepSnapshot.TimeStamp.Hour, stepSnapshot.TimeStamp.Minute, stepSnapshot.TimeStamp.Second, stepSnapshot.TimeStamp.Kind);
								if (!dictionary6.ContainsKey(key))
								{
									dictionary6[key] = (uint)((stepSnapshot.SleepType << 16) | stepSnapshot.SegmentType);
								}
							}
							else
							{
								dictionary6[stepSnapshot.TimeStamp] = stepSnapshot.Counter;
							}
						}
					}
					if (sequence.Temperatures.Count > 0)
					{
						foreach (SkinTemperature temperature in sequence.Temperatures)
						{
							dictionary5[temperature.TimeStamp] = temperature.DegreeCelsius;
						}
					}
					if (sequence.Waypoints.Count > 0)
					{
						DateTime dateTime3 = currenWorkout.LastSplitTime - TimeSpan.FromSeconds(20.0);
						DateTime dateTime4 = dateTime3;
						int num8 = ((currenWorkout.Type == EventType.Running || currenWorkout.Type == EventType.Biking) ? 20 : 150);
						int num9 = ((currenWorkout.Type == EventType.Running || currenWorkout.Type == EventType.Biking) ? 135 : 300);
						foreach (Waypoint waypoint in sequence.Waypoints)
						{
							if (waypoint.TimeStamp >= currenWorkout.LastSplitTime - TimeSpan.FromSeconds(10.0))
							{
								if (waypoint.EstimatedHorizontalError <= (double)num8 || waypoint.EstimatedVerticalError <= (double)num8)
								{
									if (waypoint.TimeStamp - dateTime3 >= TimeSpan.FromSeconds(3.0))
									{
										dateTime4 = (dateTime3 = waypoint.TimeStamp);
										dictionary3[waypoint.TimeStamp] = new GpsPosition
										{
											LatitudeDegrees = waypoint.Latitude,
											LongitudeDegrees = waypoint.Longitude
										};
										dictionary2[waypoint.TimeStamp] = waypoint.ElevationFromMeanSeaLevel;
									}
								}
								else if ((waypoint.EstimatedHorizontalError <= (double)num9 || waypoint.EstimatedVerticalError <= (double)num9) && waypoint.TimeStamp - dateTime4 >= TimeSpan.FromSeconds(3.0))
								{
									dateTime4 = waypoint.TimeStamp;
									dictionary3[waypoint.TimeStamp] = new GpsPosition
									{
										LatitudeDegrees = waypoint.Latitude,
										LongitudeDegrees = waypoint.Longitude
									};
									dictionary2[waypoint.TimeStamp] = waypoint.ElevationFromMeanSeaLevel;
								}
							}
						}
					}
				}
			}
			if ((type & ExportType.TCX) == ExportType.TCX)
			{
				AddTcxExport(ref Workouts, type);
			}
		});
		return Workouts;
	}

	public bool AddWorkoutData(ref Workout currenWorkout, Dictionary<DateTime, int> heartRateList, Dictionary<DateTime, double> elevationList, Dictionary<DateTime, GpsPosition> positionList, Dictionary<DateTime, uint> galvanicList, Dictionary<DateTime, double> temperatureList, Dictionary<DateTime, uint> stepsList)
	{
		uint galvanicSkinResponse = 0u;
		uint num = 0u;
		uint num2 = 0u;
		DateTime dateTime = DateTime.MinValue;
		uint cadence = 0u;
		double skinTemperature = 0.0;
		if (currenWorkout.Type == EventType.Sleeping)
		{
			foreach (DateTime key2 in heartRateList.Keys)
			{
				_ = DateTime.MinValue;
				if (!stepsList.ContainsKey(key2))
				{
					for (DateTime dateTime2 = key2; dateTime2 >= key2 - TimeSpan.FromSeconds(120.0); dateTime2 -= TimeSpan.FromSeconds(1.0))
					{
						dateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second, key2.Kind);
						if (stepsList.ContainsKey(dateTime2))
						{
							num = stepsList[dateTime2];
							break;
						}
					}
				}
				else
				{
					num = stepsList[key2];
				}
				if (!galvanicList.ContainsKey(key2))
				{
					for (DateTime dateTime3 = key2; dateTime3 >= key2 - TimeSpan.FromSeconds(10.0); dateTime3 -= TimeSpan.FromSeconds(1.0))
					{
						if (galvanicList.ContainsKey(dateTime3))
						{
							galvanicSkinResponse = galvanicList[dateTime3];
							break;
						}
					}
				}
				else
				{
					galvanicSkinResponse = galvanicList[key2];
				}
				if (!temperatureList.ContainsKey(key2))
				{
					for (DateTime dateTime4 = key2; dateTime4 >= key2 - TimeSpan.FromSeconds(10.0); dateTime4 -= TimeSpan.FromSeconds(1.0))
					{
						if (temperatureList.ContainsKey(dateTime4))
						{
							skinTemperature = temperatureList[dateTime4];
							break;
						}
					}
				}
				else
				{
					skinTemperature = temperatureList[key2];
				}
				currenWorkout.TrackPoints.Add(new WorkoutPoint
				{
					Time = key2,
					Position = new GpsPosition
					{
						LatitudeDegrees = 0.0,
						LongitudeDegrees = 0.0
					},
					Elevation = 0.0,
					HeartRateBpm = heartRateList[key2],
					GalvanicSkinResponse = galvanicSkinResponse,
					SkinTemperature = skinTemperature,
					Cadence = num
				});
			}
		}
		else
		{
			foreach (DateTime key3 in positionList.Keys)
			{
				if (!positionList.ContainsKey(key3) || !elevationList.ContainsKey(key3))
				{
					continue;
				}
				DateTime key = DateTime.MinValue;
				if (!heartRateList.ContainsKey(key3))
				{
					for (DateTime dateTime5 = key3; dateTime5 >= key3 - TimeSpan.FromSeconds(10.0); dateTime5 -= TimeSpan.FromSeconds(1.0))
					{
						if (heartRateList.ContainsKey(dateTime5))
						{
							key = dateTime5;
							break;
						}
					}
				}
				else
				{
					key = key3;
				}
				if (!galvanicList.ContainsKey(key3))
				{
					for (DateTime dateTime6 = key3; dateTime6 >= key3 - TimeSpan.FromSeconds(10.0); dateTime6 -= TimeSpan.FromSeconds(1.0))
					{
						if (galvanicList.ContainsKey(dateTime6))
						{
							galvanicSkinResponse = galvanicList[dateTime6];
							break;
						}
					}
				}
				else
				{
					galvanicSkinResponse = galvanicList[key3];
				}
				if (!stepsList.ContainsKey(key3))
				{
					for (DateTime dateTime7 = key3; dateTime7 >= key3 - TimeSpan.FromSeconds(50.0); dateTime7 -= TimeSpan.FromSeconds(1.0))
					{
						if (stepsList.ContainsKey(dateTime7))
						{
							num = stepsList[dateTime7];
							break;
						}
					}
				}
				else
				{
					num = stepsList[key3];
				}
				if (!temperatureList.ContainsKey(key3))
				{
					for (DateTime dateTime8 = key3; dateTime8 >= key3 - TimeSpan.FromSeconds(10.0); dateTime8 -= TimeSpan.FromSeconds(1.0))
					{
						if (temperatureList.ContainsKey(dateTime8))
						{
							skinTemperature = temperatureList[dateTime8];
							break;
						}
					}
				}
				else
				{
					skinTemperature = temperatureList[key3];
				}
				if (num > num2)
				{
					if (num2 != 0)
					{
						uint num3 = num - num2;
						double num4 = (key3 - dateTime).TotalSeconds / 60.0;
						cadence = (uint)((double)num3 / num4);
					}
					num2 = num;
					dateTime = key3;
				}
				if (heartRateList.Count > 0 && heartRateList.ContainsKey(key))
				{
					currenWorkout.LastHR = heartRateList[key];
				}
				currenWorkout.TrackPoints.Add(new WorkoutPoint
				{
					Time = key3,
					Position = positionList[key3],
					Elevation = elevationList[key3],
					HeartRateBpm = currenWorkout.LastHR,
					GalvanicSkinResponse = galvanicSkinResponse,
					SkinTemperature = skinTemperature,
					Cadence = cadence
				});
			}
		}
		return true;
	}

	public bool AddTcxExport(ref List<Workout> Workouts, ExportType type)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Tcx tcx = new Tcx();
		new XmlDocument();
		bool result = Workouts.Count > 0;
		try
		{
			foreach (Workout Workout in Workouts)
			{
				if ((Workout.Type != EventType.Running && Workout.Type != EventType.Hike && Workout.Type != EventType.Sleeping && Workout.Type != EventType.Biking) || Workout.TrackPoints.Count <= 0)
				{
					continue;
				}
				ExportType exportType = type;
				switch (Workout.Type)
				{
				case EventType.Running:
				case EventType.Hike:
					exportType &= (ExportType)120;
					break;
				case EventType.Biking:
					exportType &= (ExportType)104;
					break;
				default:
					exportType &= ExportType.HeartRate;
					break;
				}
				TrainingCenterDatabase_t trainingCenterDatabase_t = new TrainingCenterDatabase_t();
				trainingCenterDatabase_t.Activities = new ActivityList_t();
				trainingCenterDatabase_t.Activities.Activity = new Activity_t[1];
				trainingCenterDatabase_t.Activities.Activity[0] = new Activity_t();
				trainingCenterDatabase_t.Activities.Activity[0].Id = Workout.StartTime;
				trainingCenterDatabase_t.Activities.Activity[0].Notes = Workout.Notes;
				trainingCenterDatabase_t.Activities.Activity[0].Sport = ((Workout.Type == EventType.Biking) ? Sport_t.Biking : Sport_t.Running);
				trainingCenterDatabase_t.Activities.Activity[0].Lap = new ActivityLap_t[1];
				trainingCenterDatabase_t.Activities.Activity[0].Lap[0] = new ActivityLap_t();
				if (Workout.Summary != null)
				{
					double num = 0.0;
					trainingCenterDatabase_t.Activities.Activity[0].Sport = Sport_t.Running;
					ResourceLoader forViewIndependentUse = ResourceLoader.GetForViewIndependentUse();
					string text;
					if (Workout.Type != EventType.Biking)
					{
						text = ((Workout.Type == EventType.Hike) ? forViewIndependentUse.GetString("WorkoutHiking") : ((Workout.Summary.HFAverage <= 120) ? forViewIndependentUse.GetString("WorkoutWalking") : ((Workout.Summary.HFAverage < 140) ? forViewIndependentUse.GetString("WorkoutWarmup") : ((Workout.Summary.HFAverage < 145) ? forViewIndependentUse.GetString("WorkoutLight") : ((Workout.Summary.HFAverage < 151) ? forViewIndependentUse.GetString("WorkoutModerate") : ((Workout.Summary.HFAverage >= 160) ? forViewIndependentUse.GetString("WorkoutMaximum") : forViewIndependentUse.GetString("WorkoutHard")))))));
					}
					else
					{
						text = forViewIndependentUse.GetString("WorkoutBiking");
						trainingCenterDatabase_t.Activities.Activity[0].Sport = Sport_t.Biking;
					}
					if ((type & ExportType.HeartRate) == ExportType.HeartRate)
					{
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t();
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm.Value = (byte)Workout.Summary.HFAverage;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t();
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm.Value = (byte)Workout.Summary.HFMax;
					}
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeed = Workout.Summary.MaximumSpeed;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeedSpecified = true;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TotalTimeSeconds = Workout.Summary.Duration;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Calories = (ushort)Workout.Summary.CaloriesBurned;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].DistanceMeters = Workout.Summary.Distance;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Intensity = Intensity_t.Active;
					num = Workout.Summary.Distance / Workout.Summary.Duration;
					double num2 = 1000.0 / num / 60.0;
					double num3 = num2 % 1.0;
					double num4 = 0.6 * num3;
					num2 -= num3;
					num2 += num4;
					Workout.Filename = Workout.StartTime.Year.ToString("D4", WorkoutDataSource.AppCultureInfo) + Workout.StartTime.Month.ToString("D2", WorkoutDataSource.AppCultureInfo) + Workout.StartTime.Day.ToString("D2", WorkoutDataSource.AppCultureInfo) + "_" + Workout.StartTime.Hour.ToString("D2", WorkoutDataSource.AppCultureInfo) + Workout.StartTime.Minute.ToString("D2", WorkoutDataSource.AppCultureInfo) + "_" + text + "_" + (Workout.Summary.Distance / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + num2.ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + Workout.Summary.HFAverage.ToString("F0") + ".tcx";
				}
				else
				{
					trainingCenterDatabase_t.Activities.Activity[0].Sport = ((Workout.Type == EventType.Biking) ? Sport_t.Biking : Sport_t.Running);
				}
				trainingCenterDatabase_t.Activities.Activity[0].Lap[0].StartTime = Workout.StartTime;
				trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TriggerMethod = TriggerMethod_t.Manual;
				trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track = new Trackpoint_t[Workout.TrackPoints.Count];
				int num5 = 0;
				foreach (WorkoutPoint trackPoint in Workout.TrackPoints)
				{
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5] = new Trackpoint_t();
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Time = trackPoint.Time;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorState = SensorState_t.Present;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorStateSpecified = true;
					if ((type & ExportType.HeartRate) == ExportType.HeartRate)
					{
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm = new HeartRateInBeatsPerMinute_t();
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm.Value = (byte)trackPoint.HeartRateBpm;
					}
					if ((type & ExportType.Cadence) == ExportType.Cadence && Workout.Type != EventType.Biking)
					{
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Cadence = (byte)trackPoint.Cadence;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].CadenceSpecified = true;
					}
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMeters = trackPoint.Elevation;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMetersSpecified = true;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position = new Position_t();
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LatitudeDegrees = trackPoint.Position.LatitudeDegrees;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LongitudeDegrees = trackPoint.Position.LongitudeDegrees;
					num5++;
				}
				string text2 = tcx.GenerateTcx(trainingCenterDatabase_t);
				if (text2 != null && text2.Length > 0)
				{
					Workout.TCXBuffer = text2.Replace("\"utf-16\"", "\"UTF-8\"");
				}
			}
			return result;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static string ToBinaryString(uint num)
	{
		return Convert.ToString(num, 2).PadLeft(16, '0');
	}
}
