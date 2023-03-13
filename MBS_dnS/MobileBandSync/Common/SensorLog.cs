using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MobileBandSync.Data;
using MobileBandSync.OpenTcx;
using MobileBandSync.OpenTcx.Entities;
using Windows.ApplicationModel.Resources;
using Windows.Data.Xml.Dom;

namespace MobileBandSync.Common
{
	// Token: 0x020000A0 RID: 160
	public class SensorLog
	{
		// Token: 0x06000601 RID: 1537 RVA: 0x0000EB8E File Offset: 0x0000CD8E
		public SensorLog()
		{
			this.Sequences = new List<SensorLogSequence>();
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0000EBAC File Offset: 0x0000CDAC
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
						if (num2 > 0L)
						{
							dtStartDate = DateTime.FromFileTime(num2);
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0000EC28 File Offset: 0x0000CE28
		public async Task<bool> Read(Stream stream)
		{
			this.DataStream = stream;
			DateTime LastTimeStamp = DateTime.MinValue;
			ushort CurrentSleepType = 9999;
			ushort CurrentSegmentType = 9999;
			if (this.DataStream.CanSeek)
			{
				await Task.Run(delegate()
				{
					SensorLogSequence sensorLogSequence2 = null;
					int num = -1;
					DateTime dateTime = DateTime.Now;
					DateTime d = DateTime.Now;
					TimeSpan t = TimeSpan.MinValue;
					this.DataStream.Seek(0L, SeekOrigin.Begin);
					do
					{
						try
						{
							num = this.DataStream.ReadByte();
							if (num == -1)
							{
								break;
							}
							int num2 = this.DataStream.ReadByte();
							SensorLogType sensorLogType = (SensorLogType)num;
							byte[] array = new byte[num2];
							this.DataStream.Read(array, 0, num2);
							if (sensorLogType <= SensorLogType.Steps)
							{
								if (sensorLogType <= SensorLogType.UtcOffset)
								{
									if (sensorLogType <= SensorLogType.Timestamp3)
									{
										if (sensorLogType != SensorLogType.Timestamp)
										{
											if (sensorLogType != SensorLogType.Timestamp3)
											{
												goto IL_A1B;
											}
										}
										else
										{
											long num3 = BitConverter.ToInt64(array, 0);
											if (num3 <= 0L)
											{
												goto IL_A48;
											}
											if (sensorLogSequence2 != null)
											{
												dateTime = (LastTimeStamp = DateTime.FromFileTime(num3));
												d = DateTime.FromFileTimeUtc(num3);
												goto IL_A48;
											}
											sensorLogSequence2 = new SensorLogSequence(num3);
											dateTime = DateTime.FromFileTime(num3);
											d = DateTime.FromFileTimeUtc(num3);
											if (this.Sequences.Count <= 0)
											{
												goto IL_A48;
											}
											SensorLogSequence sensorLogSequence3 = this.Sequences[this.Sequences.Count - 1];
											if (sensorLogSequence3 != null)
											{
												sensorLogSequence3.Duration = dateTime - sensorLogSequence3.TimeStamp;
												goto IL_A48;
											}
											goto IL_A48;
										}
									}
									else if (sensorLogType != SensorLogType.SequenceID)
									{
										if (sensorLogType != SensorLogType.UtcOffset)
										{
											goto IL_A1B;
										}
										if (sensorLogSequence2 != null)
										{
											sensorLogSequence2.UtcOffset = (int)BitConverter.ToInt16(array, 0);
											t = new TimeSpan(0, sensorLogSequence2.UtcOffset, 0);
											goto IL_A48;
										}
										goto IL_A48;
									}
									else
									{
										if (sensorLogSequence2 != null)
										{
											sensorLogSequence2.ID = BitConverter.ToInt32(array, 0);
											this.Sequences.Add(sensorLogSequence2);
											sensorLogSequence2 = null;
											goto IL_A48;
										}
										goto IL_A48;
									}
								}
								else if (sensorLogType <= SensorLogType.Waypoint)
								{
									if (sensorLogType != SensorLogType.SkinTemperature)
									{
										if (sensorLogType != SensorLogType.Waypoint)
										{
											goto IL_A1B;
										}
										if (sensorLogSequence2 != null)
										{
											double num4 = (double)BitConverter.ToInt32(array, 2);
											double num5 = (double)BitConverter.ToInt32(array, 6);
											double num6 = (double)BitConverter.ToInt32(array, 10);
											double num7 = (double)BitConverter.ToInt16(array, 0);
											double num8 = (double)BitConverter.ToInt32(array, 14);
											double num9 = (double)BitConverter.ToInt32(array, 18);
											sensorLogSequence2.Waypoints.Add(new Waypoint
											{
												SpeedOverGround = ((num7 > 0.0) ? (num7 / 100.0) : 0.0),
												Latitude = num4 / 10000000.0,
												Longitude = num5 / 10000000.0,
												ElevationFromMeanSeaLevel = num6 / 100.0,
												EstimatedHorizontalError = ((num8 > 0.0) ? (num8 / 100.0) : 0.0),
												EstimatedVerticalError = ((num9 > 0.0) ? (num9 / 100.0) : 0.0),
												TimeStamp = dateTime
											});
											goto IL_A48;
										}
										goto IL_A48;
									}
									else
									{
										if (sensorLogSequence2 != null)
										{
											double num10 = (double)BitConverter.ToInt16(array, 0);
											sensorLogSequence2.Temperatures.Add(new SkinTemperature
											{
												DegreeCelsius = ((num10 > 0.0) ? (num10 / 100.0) : 0.0),
												TimeStamp = dateTime
											});
											goto IL_A48;
										}
										goto IL_A48;
									}
								}
								else if (sensorLogType != SensorLogType.Sensor)
								{
									if (sensorLogType != SensorLogType.HeartRate)
									{
										if (sensorLogType != SensorLogType.Steps)
										{
											goto IL_A1B;
										}
										if (sensorLogSequence2 != null && CurrentSleepType == 9999 && CurrentSegmentType == 9999)
										{
											sensorLogSequence2.StepSnapshots.Add(new Steps
											{
												Counter = BitConverter.ToUInt32(array, 0),
												TimeStamp = dateTime
											});
											goto IL_A48;
										}
										goto IL_A48;
									}
									else
									{
										if (sensorLogSequence2 == null)
										{
											goto IL_A48;
										}
										sensorLogSequence2.HeartRates.Add(new HeartRate
										{
											Bpm = (int)array[0],
											Accuracy = (int)array[1],
											TimeStamp = dateTime
										});
										if (CurrentSleepType != 9999 && CurrentSegmentType != 9999)
										{
											sensorLogSequence2.StepSnapshots.Add(new Steps
											{
												Counter = 0U,
												SleepType = CurrentSleepType,
												SegmentType = CurrentSegmentType,
												TimeStamp = dateTime
											});
											goto IL_A48;
										}
										goto IL_A48;
									}
								}
								else
								{
									if (sensorLogSequence2 != null)
									{
										sensorLogSequence2.SensorList.Add(new Sensor
										{
											Value1 = BitConverter.ToUInt32(array, 0),
											GalvanicSkinResponse = BitConverter.ToUInt32(array, 4),
											Value2 = BitConverter.ToUInt32(array, 8),
											Value3 = BitConverter.ToUInt32(array, 12),
											TimeStamp = dateTime
										});
										goto IL_A48;
									}
									goto IL_A48;
								}
							}
							else if (sensorLogType <= SensorLogType.WorkoutMarker)
							{
								if (sensorLogType <= SensorLogType.WorkoutSummary)
								{
									if (sensorLogType != SensorLogType.Sleep)
									{
										if (sensorLogType != SensorLogType.WorkoutSummary)
										{
											goto IL_A1B;
										}
										if (sensorLogSequence2 != null)
										{
											long num11 = BitConverter.ToInt64(array, 0);
											long num12 = BitConverter.ToInt64(array, 38);
											DateTime startDate = (num11 > 0L) ? DateTime.FromFileTime(num11) : DateTime.MinValue;
											DateTime intermediateDate = (num12 > 0L) ? DateTime.FromFileTime(num12) : DateTime.MinValue;
											double num13 = (double)BitConverter.ToInt32(array, 10);
											double num14 = (double)BitConverter.ToInt32(array, 14);
											double num15 = (double)BitConverter.ToInt32(array, 18);
											double num16 = (double)BitConverter.ToInt32(array, 22);
											int caloriesBurned = BitConverter.ToInt32(array, 26);
											int hfaverage = BitConverter.ToInt32(array, 30);
											int hfmax = BitConverter.ToInt32(array, 34);
											int utcDiffHrs = BitConverter.ToInt32(array, 46);
											double num17 = (double)BitConverter.ToInt32(array, 50);
											sensorLogSequence2.WorkoutSummaries.Add(new WorkoutSummary
											{
												StartDate = startDate,
												IntermediateDate = intermediateDate,
												Duration = num13 / 1000.0,
												Distance = num14 / 100.0,
												AverageSpeed = num15 / 100.0,
												MaximumSpeed = num16 / 100.0,
												CaloriesBurned = caloriesBurned,
												HFAverage = hfaverage,
												HFMax = hfmax,
												UtcDiffHrs = utcDiffHrs,
												TotalElevation = num17 / 100.0,
												UnknownValue1 = (int)BitConverter.ToInt16(array, 8),
												UnknownValue2 = BitConverter.ToInt32(array, 54),
												UnknownValue3 = BitConverter.ToInt32(array, 58),
												UnknownValue4 = BitConverter.ToInt32(array, 62),
												UnknownValue5 = BitConverter.ToInt32(array, 66),
												UnknownValue6 = BitConverter.ToInt32(array, 70),
												UnknownValue7 = BitConverter.ToInt32(array, 74)
											});
											goto IL_A48;
										}
										goto IL_A48;
									}
									else
									{
										if (sensorLogSequence2 != null)
										{
											CurrentSleepType = BitConverter.ToUInt16(array, 0);
											CurrentSegmentType = BitConverter.ToUInt16(array, 2);
											goto IL_A48;
										}
										goto IL_A48;
									}
								}
								else if (sensorLogType != SensorLogType.Counter)
								{
									if (sensorLogType != SensorLogType.WorkoutMarker)
									{
										goto IL_A1B;
									}
									if (sensorLogSequence2 != null)
									{
										int num18 = (int)array[1];
										if (num18 != 4 && num18 != 6 && num18 != 21 && num18 != 32)
										{
											num18 = 99;
										}
										DateTime timeStamp = (num18 != 21) ? (d + t) : LastTimeStamp;
										if (num18 == 21)
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
											WorkoutType = (EventType)num18,
											Value2 = (int)array[2],
											TimeStamp = timeStamp
										});
										goto IL_A48;
									}
									goto IL_A48;
								}
								else
								{
									if (sensorLogSequence2 != null)
									{
										sensorLogSequence2.Counters.Add(new Counter
										{
											Value1 = (double)BitConverter.ToInt32(array, 0),
											Value2 = (double)BitConverter.ToInt32(array, 4)
										});
										dateTime = dateTime.AddSeconds(1.0);
										d = d.AddSeconds(1.0);
										goto IL_A48;
									}
									goto IL_A48;
								}
							}
							else if (sensorLogType <= SensorLogType.SleepSummary)
							{
								if (sensorLogType != SensorLogType.WorkoutMarker2)
								{
									if (sensorLogType != SensorLogType.SleepSummary)
									{
										goto IL_A1B;
									}
									if (sensorLogSequence2 != null)
									{
										long num19 = BitConverter.ToInt64(array, 0);
										long num20 = BitConverter.ToInt64(array, 38);
										DateTime startDate2 = (num19 > 0L) ? DateTime.FromFileTime(num19) : DateTime.MinValue;
										DateTime intermediateDate2 = (num20 > 0L) ? DateTime.FromFileTime(num20) : DateTime.MinValue;
										sensorLogSequence2.SleepSummaries.Add(new SleepSummary
										{
											StartDate = startDate2,
											IntermediateDate = intermediateDate2,
											Duration = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 10)),
											Version = (double)BitConverter.ToInt16(array, 8),
											TimesAwoke = (double)BitConverter.ToInt32(array, 14),
											TotalRestlessSleepDuration = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 18)),
											TotalRestfulSleepDuration = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 22)),
											CaloriesBurned = BitConverter.ToInt32(array, 26),
											HFAverage = BitConverter.ToInt32(array, 30),
											HFMax = BitConverter.ToInt32(array, 34),
											FallAsleepTime = new TimeSpan(0, 0, 0, 0, BitConverter.ToInt32(array, 46)),
											Feeling = BitConverter.ToUInt32(array, 50)
										});
										goto IL_A48;
									}
									goto IL_A48;
								}
								else
								{
									if (sensorLogSequence2 != null)
									{
										sensorLogSequence2.WorkoutMarkers2.Add(new WorkoutMarker2
										{
											Value1 = (int)BitConverter.ToInt16(array, 0),
											Value2 = BitConverter.ToInt32(array, 2),
											TimeStamp = LastTimeStamp
										});
										goto IL_A48;
									}
									goto IL_A48;
								}
							}
							else if (sensorLogType != SensorLogType.Timestamp2 && sensorLogType != SensorLogType.Timestamp4)
							{
								if (sensorLogType != SensorLogType.DailySummary)
								{
									goto IL_A1B;
								}
								if (sensorLogSequence2 != null)
								{
									long num21 = BitConverter.ToInt64(array, 1);
									sensorLogSequence2.DailySummaries.Add(new DailySummary
									{
										Flag = (uint)array[0],
										Date = ((num21 > 0L) ? DateTime.FromFileTime(num21) : DateTime.MinValue)
									});
									goto IL_A48;
								}
								goto IL_A48;
							}
							long num22 = BitConverter.ToInt64(array, 1);
							if (num22 > 0L)
							{
								dateTime = DateTime.FromFileTime(num22);
								d = DateTime.FromFileTimeUtc(num22);
								goto IL_A48;
							}
							goto IL_A48;
							IL_A1B:
							if (num == 134 || num == 213 || num == 17 || num == 20 || num == 2 || num == 3 || num == 4 || num == 14)
							{
							}
							IL_A48:;
						}
						catch (Exception)
						{
							break;
						}
					}
					while (num >= 0);
				});
			}
			if (this.Sequences.Count > 0)
			{
				SensorLogSequence sensorLogSequence = this.Sequences[this.Sequences.Count - 1];
				if (sensorLogSequence != null && LastTimeStamp != DateTime.MinValue && LastTimeStamp > sensorLogSequence.TimeStamp)
				{
					sensorLogSequence.Duration = LastTimeStamp - sensorLogSequence.TimeStamp;
				}
			}
			return true;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0000EC78 File Offset: 0x0000CE78
		public async Task<List<Workout>> CreateWorkouts(ExportType type = (ExportType)26)
		{
			List<Workout> Workouts = new List<Workout>();
			await Task.Run(delegate()
			{
				Workout workout = null;
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
				foreach (SensorLogSequence sensorLogSequence in this.Sequences)
				{
					if (sensorLogSequence.WorkoutSummaries.Count > 0 && Workouts.Count > 0)
					{
						((workout == null) ? Workouts[Workouts.Count - 1] : workout).Summary = sensorLogSequence.WorkoutSummaries[sensorLogSequence.WorkoutSummaries.Count - 1];
						num4 = num;
						num5 = num2;
					}
					if (sensorLogSequence.SleepSummaries.Count > 0 && Workouts.Count > 0)
					{
						((workout == null) ? Workouts[Workouts.Count - 1] : workout).SleepSummary = sensorLogSequence.SleepSummaries[sensorLogSequence.SleepSummaries.Count - 1];
					}
					if (sensorLogSequence.WorkoutMarkers.Count > 0)
					{
						foreach (WorkoutMarker workoutMarker in sensorLogSequence.WorkoutMarkers)
						{
							if (workoutMarker.Action == DistanceAnnotationType.Start)
							{
								if (workout != null)
								{
									workout.EndTime = endTime;
									this.AddWorkoutData(ref workout, dictionary, dictionary2, dictionary3, dictionary4, dictionary5, dictionary6);
									if (!Workouts.Contains(workout))
									{
										Workouts.Add(workout);
									}
									workout = null;
									dictionary.Clear();
									dictionary2.Clear();
									dictionary3.Clear();
									dictionary5.Clear();
									dictionary4.Clear();
									dictionary6.Clear();
								}
								workout = new Workout();
								workout.LastSplitTime = (workout.StartTime = workoutMarker.TimeStamp);
								workout.Type = workoutMarker.WorkoutType;
								if (!Workouts.Contains(workout))
								{
									Workouts.Add(workout);
								}
								workout.Filename = string.Concat(new string[]
								{
									workout.Type.ToString(),
									"-",
									workout.StartTime.Year.ToString("D4", WorkoutDataSource.AppCultureInfo),
									workout.StartTime.Month.ToString("D2", WorkoutDataSource.AppCultureInfo),
									workout.StartTime.Day.ToString("D2", WorkoutDataSource.AppCultureInfo),
									workout.StartTime.Hour.ToString("D2", WorkoutDataSource.AppCultureInfo),
									workout.StartTime.Minute.ToString("D2", WorkoutDataSource.AppCultureInfo),
									workout.StartTime.Second.ToString("D2", WorkoutDataSource.AppCultureInfo),
									".tcx"
								});
								workout.Notes = string.Format(forViewIndependentUse.GetString("GeneratedString"), new object[]
								{
									WorkoutDataSource.BandName,
									workout.StartTime.ToString(WorkoutDataSource.AppCultureInfo)
								});
							}
							else if (workoutMarker.Action == DistanceAnnotationType.Split)
							{
								if (workout == null && Workouts.Count > 0)
								{
									workout = Workouts[Workouts.Count - 1];
									Workouts.RemoveAt(Workouts.Count - 1);
								}
								if (workout != null)
								{
									workout.LastSplitTime = workoutMarker.TimeStamp;
								}
							}
							else if (workoutMarker.Action == DistanceAnnotationType.Pause)
							{
								if (workout != null)
								{
									endTime = (workout.EndTime = workoutMarker.TimeStamp);
									this.AddWorkoutData(ref workout, dictionary, dictionary2, dictionary3, dictionary4, dictionary5, dictionary6);
									if (!Workouts.Contains(workout))
									{
										Workouts.Add(workout);
									}
									if (workout.Type == EventType.Sleeping)
									{
										num4 = num;
										num5 = num2;
									}
									workout = null;
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
								if (workout != null && workout.EndTime == DateTime.MinValue)
								{
									workout.EndTime = endTime;
								}
							}
						}
					}
					if (workout != null)
					{
						if ((type & ExportType.HeartRate) == ExportType.HeartRate && sensorLogSequence.HeartRates.Count > 0)
						{
							if (workout.Type == EventType.Sleeping)
							{
								List<HeartRate> list = new List<HeartRate>();
								foreach (HeartRate heartRate in sensorLogSequence.HeartRates)
								{
									if (heartRate.Accuracy >= 9)
									{
										list.Add(heartRate);
									}
								}
								double num6 = 0.0;
								TimeSpan value = sensorLogSequence.Duration.Value;
								if (sensorLogSequence.Duration > TimeSpan.FromSeconds(1.0))
								{
									num6 = sensorLogSequence.Duration.Value.TotalSeconds / (double)list.Count;
								}
								double num7 = 0.0;
								DateTime d = sensorLogSequence.TimeStamp.Value;
								using (List<HeartRate>.Enumerator enumerator3 = list.GetEnumerator())
								{
									while (enumerator3.MoveNext())
									{
										HeartRate heartRate2 = enumerator3.Current;
										DateTime dateTime = sensorLogSequence.TimeStamp.Value + TimeSpan.FromSeconds(num7);
										if (num7 == 0.0 || dateTime >= d + TimeSpan.FromSeconds(60.0))
										{
											dictionary[dateTime] = heartRate2.Bpm;
											dictionary3[dateTime] = new GpsPosition
											{
												LatitudeDegrees = num4,
												LongitudeDegrees = num5
											};
											dictionary2[dateTime] = 360.0;
											num4 += num3;
											num5 += num3;
											d = dateTime;
										}
										num7 += num6;
									}
									goto IL_74B;
								}
							}
							foreach (HeartRate heartRate3 in sensorLogSequence.HeartRates)
							{
								if (heartRate3.TimeStamp >= workout.LastSplitTime - TimeSpan.FromSeconds(10.0) && (heartRate3.Accuracy >= 8 || (heartRate3.Accuracy >= 5 && heartRate3.TimeStamp <= workout.LastSplitTime + TimeSpan.FromSeconds(120.0))))
								{
									dictionary[heartRate3.TimeStamp] = heartRate3.Bpm;
								}
							}
						}
						IL_74B:
						if (sensorLogSequence.SensorList.Count > 0)
						{
							foreach (Sensor sensor in sensorLogSequence.SensorList)
							{
								dictionary4[sensor.TimeStamp] = sensor.GalvanicSkinResponse;
							}
						}
						if (sensorLogSequence.StepSnapshots.Count > 0)
						{
							foreach (Steps steps in sensorLogSequence.StepSnapshots)
							{
								if (workout.Type == EventType.Sleeping)
								{
									DateTime key = new DateTime(steps.TimeStamp.Year, steps.TimeStamp.Month, steps.TimeStamp.Day, steps.TimeStamp.Hour, steps.TimeStamp.Minute, steps.TimeStamp.Second, steps.TimeStamp.Kind);
									if (!dictionary6.ContainsKey(key))
									{
										dictionary6[key] = (uint)((int)steps.SleepType << 16 | (int)steps.SegmentType);
									}
								}
								else
								{
									dictionary6[steps.TimeStamp] = steps.Counter;
								}
							}
						}
						if (sensorLogSequence.Temperatures.Count > 0)
						{
							foreach (SkinTemperature skinTemperature in sensorLogSequence.Temperatures)
							{
								dictionary5[skinTemperature.TimeStamp] = skinTemperature.DegreeCelsius;
							}
						}
						if (sensorLogSequence.Waypoints.Count > 0)
						{
							DateTime dateTime2 = workout.LastSplitTime - TimeSpan.FromSeconds(20.0);
							DateTime d2 = dateTime2;
							int num8 = (workout.Type == EventType.Running || workout.Type == EventType.Biking) ? 20 : 150;
							int num9 = (workout.Type == EventType.Running || workout.Type == EventType.Biking) ? 135 : 300;
							foreach (Waypoint waypoint in sensorLogSequence.Waypoints)
							{
								if (waypoint.TimeStamp >= workout.LastSplitTime - TimeSpan.FromSeconds(10.0))
								{
									if (waypoint.EstimatedHorizontalError <= (double)num8 || waypoint.EstimatedVerticalError <= (double)num8)
									{
										if (waypoint.TimeStamp - dateTime2 >= TimeSpan.FromSeconds(3.0))
										{
											dateTime2 = (d2 = waypoint.TimeStamp);
											dictionary3[waypoint.TimeStamp] = new GpsPosition
											{
												LatitudeDegrees = waypoint.Latitude,
												LongitudeDegrees = waypoint.Longitude
											};
											dictionary2[waypoint.TimeStamp] = waypoint.ElevationFromMeanSeaLevel;
										}
									}
									else if ((waypoint.EstimatedHorizontalError <= (double)num9 || waypoint.EstimatedVerticalError <= (double)num9) && waypoint.TimeStamp - d2 >= TimeSpan.FromSeconds(3.0))
									{
										d2 = waypoint.TimeStamp;
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
					this.AddTcxExport(ref Workouts, type);
				}
			});
			return Workouts;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000ECC8 File Offset: 0x0000CEC8
		public bool AddWorkoutData(ref Workout currenWorkout, Dictionary<DateTime, int> heartRateList, Dictionary<DateTime, double> elevationList, Dictionary<DateTime, GpsPosition> positionList, Dictionary<DateTime, uint> galvanicList, Dictionary<DateTime, double> temperatureList, Dictionary<DateTime, uint> stepsList)
		{
			uint galvanicSkinResponse = 0U;
			uint num = 0U;
			uint num2 = 0U;
			DateTime d = DateTime.MinValue;
			uint cadence = 0U;
			double skinTemperature = 0.0;
			if (currenWorkout.Type == EventType.Sleeping)
			{
				using (Dictionary<DateTime, int>.KeyCollection.Enumerator enumerator = heartRateList.Keys.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DateTime dateTime = enumerator.Current;
						DateTime minValue = DateTime.MinValue;
						if (!stepsList.ContainsKey(dateTime))
						{
							DateTime dateTime2 = dateTime;
							while (dateTime2 >= dateTime - TimeSpan.FromSeconds(120.0))
							{
								dateTime2 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second, dateTime.Kind);
								if (stepsList.ContainsKey(dateTime2))
								{
									num = stepsList[dateTime2];
									break;
								}
								dateTime2 -= TimeSpan.FromSeconds(1.0);
							}
						}
						else
						{
							num = stepsList[dateTime];
						}
						if (!galvanicList.ContainsKey(dateTime))
						{
							DateTime dateTime3 = dateTime;
							while (dateTime3 >= dateTime - TimeSpan.FromSeconds(10.0))
							{
								if (galvanicList.ContainsKey(dateTime3))
								{
									galvanicSkinResponse = galvanicList[dateTime3];
									break;
								}
								dateTime3 -= TimeSpan.FromSeconds(1.0);
							}
						}
						else
						{
							galvanicSkinResponse = galvanicList[dateTime];
						}
						if (!temperatureList.ContainsKey(dateTime))
						{
							DateTime dateTime4 = dateTime;
							while (dateTime4 >= dateTime - TimeSpan.FromSeconds(10.0))
							{
								if (temperatureList.ContainsKey(dateTime4))
								{
									skinTemperature = temperatureList[dateTime4];
									break;
								}
								dateTime4 -= TimeSpan.FromSeconds(1.0);
							}
						}
						else
						{
							skinTemperature = temperatureList[dateTime];
						}
						currenWorkout.TrackPoints.Add(new WorkoutPoint
						{
							Time = dateTime,
							Position = new GpsPosition
							{
								LatitudeDegrees = 0.0,
								LongitudeDegrees = 0.0
							},
							Elevation = 0.0,
							HeartRateBpm = heartRateList[dateTime],
							GalvanicSkinResponse = galvanicSkinResponse,
							SkinTemperature = skinTemperature,
							Cadence = num
						});
					}
					return true;
				}
			}
			foreach (DateTime dateTime5 in positionList.Keys)
			{
				if (positionList.ContainsKey(dateTime5) && elevationList.ContainsKey(dateTime5))
				{
					DateTime key = DateTime.MinValue;
					if (!heartRateList.ContainsKey(dateTime5))
					{
						DateTime dateTime6 = dateTime5;
						while (dateTime6 >= dateTime5 - TimeSpan.FromSeconds(10.0))
						{
							if (heartRateList.ContainsKey(dateTime6))
							{
								key = dateTime6;
								break;
							}
							dateTime6 -= TimeSpan.FromSeconds(1.0);
						}
					}
					else
					{
						key = dateTime5;
					}
					if (!galvanicList.ContainsKey(dateTime5))
					{
						DateTime dateTime7 = dateTime5;
						while (dateTime7 >= dateTime5 - TimeSpan.FromSeconds(10.0))
						{
							if (galvanicList.ContainsKey(dateTime7))
							{
								galvanicSkinResponse = galvanicList[dateTime7];
								break;
							}
							dateTime7 -= TimeSpan.FromSeconds(1.0);
						}
					}
					else
					{
						galvanicSkinResponse = galvanicList[dateTime5];
					}
					if (!stepsList.ContainsKey(dateTime5))
					{
						DateTime dateTime8 = dateTime5;
						while (dateTime8 >= dateTime5 - TimeSpan.FromSeconds(50.0))
						{
							if (stepsList.ContainsKey(dateTime8))
							{
								num = stepsList[dateTime8];
								break;
							}
							dateTime8 -= TimeSpan.FromSeconds(1.0);
						}
					}
					else
					{
						num = stepsList[dateTime5];
					}
					if (!temperatureList.ContainsKey(dateTime5))
					{
						DateTime dateTime9 = dateTime5;
						while (dateTime9 >= dateTime5 - TimeSpan.FromSeconds(10.0))
						{
							if (temperatureList.ContainsKey(dateTime9))
							{
								skinTemperature = temperatureList[dateTime9];
								break;
							}
							dateTime9 -= TimeSpan.FromSeconds(1.0);
						}
					}
					else
					{
						skinTemperature = temperatureList[dateTime5];
					}
					if (num > num2)
					{
						if (num2 > 0U)
						{
							uint num3 = num - num2;
							double num4 = (dateTime5 - d).TotalSeconds / 60.0;
							cadence = (uint)(num3 / num4);
						}
						num2 = num;
						d = dateTime5;
					}
					if (heartRateList.Count > 0 && heartRateList.ContainsKey(key))
					{
						currenWorkout.LastHR = heartRateList[key];
					}
					currenWorkout.TrackPoints.Add(new WorkoutPoint
					{
						Time = dateTime5,
						Position = positionList[dateTime5],
						Elevation = elevationList[dateTime5],
						HeartRateBpm = currenWorkout.LastHR,
						GalvanicSkinResponse = galvanicSkinResponse,
						SkinTemperature = skinTemperature,
						Cadence = cadence
					});
				}
			}
			return true;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000F208 File Offset: 0x0000D408
		public bool AddTcxExport(ref List<Workout> Workouts, ExportType type)
		{
			Tcx tcx = new Tcx();
			new XmlDocument();
			bool result = Workouts.Count > 0;
			try
			{
				foreach (Workout workout in Workouts)
				{
					if ((workout.Type == EventType.Running || workout.Type == EventType.Hike || workout.Type == EventType.Sleeping || workout.Type == EventType.Biking) && workout.TrackPoints.Count > 0)
					{
						EventType type2 = workout.Type;
						if (type2 == EventType.Running)
						{
							goto IL_81;
						}
						ExportType exportType;
						if (type2 != EventType.Biking)
						{
							if (type2 == EventType.Hike)
							{
								goto IL_81;
							}
							exportType = (type & ExportType.HeartRate);
						}
						else
						{
							exportType = (type & (ExportType)104);
						}
						IL_99:
						TrainingCenterDatabase_t trainingCenterDatabase_t = new TrainingCenterDatabase_t();
						trainingCenterDatabase_t.Activities = new ActivityList_t();
						trainingCenterDatabase_t.Activities.Activity = new Activity_t[1];
						trainingCenterDatabase_t.Activities.Activity[0] = new Activity_t();
						trainingCenterDatabase_t.Activities.Activity[0].Id = workout.StartTime;
						trainingCenterDatabase_t.Activities.Activity[0].Notes = workout.Notes;
						trainingCenterDatabase_t.Activities.Activity[0].Sport = ((workout.Type == EventType.Biking) ? Sport_t.Biking : Sport_t.Running);
						trainingCenterDatabase_t.Activities.Activity[0].Lap = new ActivityLap_t[1];
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0] = new ActivityLap_t();
						if (workout.Summary != null)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Sport = Sport_t.Running;
							ResourceLoader forViewIndependentUse = ResourceLoader.GetForViewIndependentUse();
							string @string;
							if (workout.Type == EventType.Biking)
							{
								@string = forViewIndependentUse.GetString("WorkoutBiking");
								trainingCenterDatabase_t.Activities.Activity[0].Sport = Sport_t.Biking;
							}
							else if (workout.Type == EventType.Hike)
							{
								@string = forViewIndependentUse.GetString("WorkoutHiking");
							}
							else if (workout.Summary.HFAverage <= 120)
							{
								@string = forViewIndependentUse.GetString("WorkoutWalking");
							}
							else if (workout.Summary.HFAverage < 140)
							{
								@string = forViewIndependentUse.GetString("WorkoutWarmup");
							}
							else if (workout.Summary.HFAverage < 145)
							{
								@string = forViewIndependentUse.GetString("WorkoutLight");
							}
							else if (workout.Summary.HFAverage < 151)
							{
								@string = forViewIndependentUse.GetString("WorkoutModerate");
							}
							else if (workout.Summary.HFAverage < 160)
							{
								@string = forViewIndependentUse.GetString("WorkoutHard");
							}
							else
							{
								@string = forViewIndependentUse.GetString("WorkoutMaximum");
							}
							if ((type & ExportType.HeartRate) == ExportType.HeartRate)
							{
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t();
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm.Value = (byte)workout.Summary.HFAverage;
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t();
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm.Value = (byte)workout.Summary.HFMax;
							}
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeed = workout.Summary.MaximumSpeed;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeedSpecified = true;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TotalTimeSeconds = workout.Summary.Duration;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Calories = (ushort)workout.Summary.CaloriesBurned;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].DistanceMeters = workout.Summary.Distance;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Intensity = Intensity_t.Active;
							double num = workout.Summary.Distance / workout.Summary.Duration;
							double num2 = 1000.0 / num / 60.0;
							double num3 = num2 % 1.0;
							double num4 = 0.6 * num3;
							num2 -= num3;
							num2 += num4;
							workout.Filename = string.Concat(new string[]
							{
								workout.StartTime.Year.ToString("D4", WorkoutDataSource.AppCultureInfo),
								workout.StartTime.Month.ToString("D2", WorkoutDataSource.AppCultureInfo),
								workout.StartTime.Day.ToString("D2", WorkoutDataSource.AppCultureInfo),
								"_",
								workout.StartTime.Hour.ToString("D2", WorkoutDataSource.AppCultureInfo),
								workout.StartTime.Minute.ToString("D2", WorkoutDataSource.AppCultureInfo),
								"_",
								@string,
								"_",
								(workout.Summary.Distance / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo),
								"_",
								num2.ToString("F2", WorkoutDataSource.AppCultureInfo),
								"_",
								workout.Summary.HFAverage.ToString("F0"),
								".tcx"
							});
						}
						else
						{
							trainingCenterDatabase_t.Activities.Activity[0].Sport = ((workout.Type == EventType.Biking) ? Sport_t.Biking : Sport_t.Running);
						}
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].StartTime = workout.StartTime;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TriggerMethod = TriggerMethod_t.Manual;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track = new Trackpoint_t[workout.TrackPoints.Count];
						int num5 = 0;
						foreach (WorkoutPoint workoutPoint in workout.TrackPoints)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5] = new Trackpoint_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Time = workoutPoint.Time;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorState = SensorState_t.Present;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorStateSpecified = true;
							if ((type & ExportType.HeartRate) == ExportType.HeartRate)
							{
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm = new HeartRateInBeatsPerMinute_t();
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm.Value = (byte)workoutPoint.HeartRateBpm;
							}
							if ((type & ExportType.Cadence) == ExportType.Cadence && workout.Type != EventType.Biking)
							{
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Cadence = (byte)workoutPoint.Cadence;
								trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].CadenceSpecified = true;
							}
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMeters = workoutPoint.Elevation;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMetersSpecified = true;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position = new Position_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LatitudeDegrees = workoutPoint.Position.LatitudeDegrees;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LongitudeDegrees = workoutPoint.Position.LongitudeDegrees;
							num5++;
						}
						string text = tcx.GenerateTcx(trainingCenterDatabase_t);
						if (text != null && text.Length > 0)
						{
							workout.TCXBuffer = text.Replace("\"utf-16\"", "\"UTF-8\"");
							continue;
						}
						continue;
						IL_81:
						exportType = (type & (ExportType)120);
						goto IL_99;
					}
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0000FB50 File Offset: 0x0000DD50
		public static string ToBinaryString(uint num)
		{
			return Convert.ToString((long)((ulong)num), 2).PadLeft(16, '0');
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x0000FB63 File Offset: 0x0000DD63
		public List<SensorLogSequence> Sequences { get; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x0000FB6B File Offset: 0x0000DD6B
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x0000FB73 File Offset: 0x0000DD73
		public ulong BufferSize { get; set; }

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x0000FB7C File Offset: 0x0000DD7C
		// (set) Token: 0x0600060C RID: 1548 RVA: 0x0000FB84 File Offset: 0x0000DD84
		public ulong StepLength { get; internal set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x0000FB8D File Offset: 0x0000DD8D
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x0000FB95 File Offset: 0x0000DD95
		public string BandName { get; set; }

		// Token: 0x040003F8 RID: 1016
		private Stream DataStream;

		// Token: 0x040003F9 RID: 1017
		public Dictionary<uint, Dictionary<uint, uint>> IdOccurencies = new Dictionary<uint, Dictionary<uint, uint>>();
	}
}
