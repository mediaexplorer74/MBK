using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using MobileBandSync.Common;
using MobileBandSync.OpenTcx;
using MobileBandSync.OpenTcx.Entities;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace MobileBandSync.Data;

public class WorkoutItem
{
	private EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>> m_currentWorkout;

	private string _title;

	public string UniqueId => Guid.NewGuid().ToString("B");

	public string Subtitle
	{
		get
		{
			return Notes;
		}
		set
		{
			Modified = Notes != value;
			Notes = value;
		}
	}

	public string Description { get; set; }

	public string ImagePath { get; private set; }

	public ObservableCollection<TrackItem> Items { get; set; }

	public ObservableCollection<SleepItem> SleepItems { get; set; }

	public int WorkoutId { get; set; }

	public byte WorkoutType { get; set; }

	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			Modified = _title != value;
			_title = value;
		}
	}

	public string Notes { get; set; }

	public DateTime Start { get; set; }

	public DateTime End { get; set; }

	public byte AvgHR { get; set; }

	public byte MaxHR { get; set; }

	public int Calories { get; set; }

	public int AvgSpeed { get; set; }

	public int MaxSpeed { get; set; }

	public int DurationSec { get; set; }

	public long DistanceMeters { get; set; }

	public long LongitudeStart { get; set; }

	public long LatitudeStart { get; set; }

	public int LongDeltaRectSW { get; set; }

	public int LatDeltaRectSW { get; set; }

	public int LongDeltaRectNE { get; set; }

	public int LatDeltaRectNE { get; set; }

	public string DbPath { get; set; }

	public string FilenameTCX { get; set; }

	public string TCXBuffer { get; set; }

	public int Index { get; set; }

	public TimeSpan AwakeDuration
	{
		get
		{
			return new TimeSpan(0, 0, 0, AvgSpeed);
		}
		set
		{
			AvgSpeed = (int)value.TotalSeconds;
		}
	}

	public TimeSpan SleepDuration
	{
		get
		{
			return new TimeSpan(0, 0, 0, MaxSpeed);
		}
		set
		{
			MaxSpeed = (int)value.TotalSeconds;
		}
	}

	public int NumberOfWakeups
	{
		get
		{
			return DurationSec;
		}
		set
		{
			DurationSec = value;
		}
	}

	public TimeSpan FallAsleepDuration
	{
		get
		{
			return new TimeSpan(0, 0, 0, (int)DistanceMeters);
		}
		set
		{
			DistanceMeters = (long)value.TotalSeconds;
		}
	}

	public int SleepEfficiencyPercentage
	{
		get
		{
			return LongDeltaRectSW;
		}
		set
		{
			LongDeltaRectSW = value;
		}
	}

	public TimeSpan TotalRestlessSleepDuration
	{
		get
		{
			return new TimeSpan(0, 0, 0, LatDeltaRectSW);
		}
		set
		{
			LatDeltaRectSW = (int)value.TotalSeconds;
		}
	}

	public TimeSpan TotalRestfulSleepDuration
	{
		get
		{
			return new TimeSpan(0, 0, 0, LongDeltaRectNE);
		}
		set
		{
			LongDeltaRectNE = (int)value.TotalSeconds;
		}
	}

	public uint Feeling
	{
		get
		{
			return (uint)LatDeltaRectNE;
		}
		set
		{
			LatDeltaRectNE = (int)value;
		}
	}

	public string WorkoutImageSource => (EventType)WorkoutType switch
	{
		EventType.Walking => "Resources/walking.png", 
		EventType.Running => "Resources/running.png", 
		EventType.Biking => "Resources/biking.png", 
		EventType.Sleeping => "Resources/sleep.png", 
		_ => "Resources/walking.png", 
	};

	public Visibility DownVisibility
	{
		get
		{
			if (Parent != null && Parent.Count > 0)
			{
				for (int num = Index; num > 0; num--)
				{
					if ((WorkoutType == 21 && Parent[num - 1].WorkoutType == 21) || (WorkoutType != 21 && Parent[num - 1].WorkoutType != 21))
					{
						return (Visibility)0;
					}
				}
			}
			return (Visibility)1;
		}
	}

	public Visibility UpVisibility
	{
		get
		{
			if (Parent != null && Parent.Count > 0)
			{
				for (int i = Index; i < Parent.Count - 1; i++)
				{
					if ((WorkoutType == 21 && Parent[i + 1].WorkoutType == 21) || (WorkoutType != 21 && Parent[i + 1].WorkoutType != 21))
					{
						return (Visibility)0;
					}
				}
			}
			return (Visibility)1;
		}
	}

	public ObservableCollection<WorkoutItem> Parent { get; set; }

	public ObservableCollection<DiagramData> HeartRateChart { get; private set; }

	public ObservableCollection<DiagramData> ElevationChart { get; private set; }

	public ObservableCollection<DiagramData> CadenceNormChart { get; private set; }

	public ObservableCollection<DiagramData> SpeedChart { get; private set; }

	public bool Modified { get; set; }

	public event EventHandler<TracksLoadedEventArgs> TracksLoaded
	{
		add
		{
			if (m_currentWorkout == null)
			{
				EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>>.GetOrCreateEventRegistrationTokenTable(ref m_currentWorkout).AddEventHandler(value);
			}
		}
		remove
		{
			EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>>.GetOrCreateEventRegistrationTokenTable(ref m_currentWorkout).RemoveEventHandler(value);
		}
	}

	public WorkoutItem(string uniqueId, string title, string subtitle, string imagePath, string description)
	{
		Title = title;
		Description = description;
		ImagePath = imagePath;
		Items = new ObservableCollection<TrackItem>();
		HeartRateChart = new ObservableCollection<DiagramData>();
		ElevationChart = new ObservableCollection<DiagramData>();
		CadenceNormChart = new ObservableCollection<DiagramData>();
		SpeedChart = new ObservableCollection<DiagramData>();
	}

	public WorkoutItem()
	{
		HeartRateChart = new ObservableCollection<DiagramData>();
		ElevationChart = new ObservableCollection<DiagramData>();
		CadenceNormChart = new ObservableCollection<DiagramData>();
		SpeedChart = new ObservableCollection<DiagramData>();
	}

	internal void OnTracksLoaded(WorkoutItem workout)
	{
		EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>>.GetOrCreateEventRegistrationTokenTable(ref m_currentWorkout).InvocationList?.Invoke(this, new TracksLoadedEventArgs(workout));
	}

	public WorkoutItem GetPrevSibling()
	{
		if (Parent != null && Parent.Count > 0)
		{
			for (int num = Index; num > 0; num--)
			{
				if ((WorkoutType == 21 && Parent[num - 1].WorkoutType == 21) || (WorkoutType != 21 && Parent[num - 1].WorkoutType != 21))
				{
					return Parent[num - 1];
				}
			}
		}
		return null;
	}

	public WorkoutItem GetNextSibling()
	{
		if (Parent != null && Parent.Count > 0)
		{
			for (int i = Index; i < Parent.Count - 1; i++)
			{
				if ((WorkoutType == 21 && Parent[i + 1].WorkoutType == 21) || (WorkoutType != 21 && Parent[i + 1].WorkoutType != 21))
				{
					return Parent[i + 1];
				}
			}
		}
		return null;
	}

	public override string ToString()
	{
		return Title;
	}

	public async Task<bool> StoreWorkout()
	{
		bool result = false;
		string text = Path.Combine(new string[2]
		{
			ApplicationData.Current.LocalFolder.Path,
			"workouts.db"
		});
		using (SqliteConnection db = new SqliteConnection($"Filename={text}"))
		{
			await db.OpenAsync();
			result = await StoreWorkout(db, null, 0uL) != -1;
		}
		return result;
	}

	public async Task CopyToExternal(string tcxFile)
	{
		try
		{
			string targetFile = tcxFile.Substring(tcxFile.LastIndexOf('\\') + 1);
			TaskAwaiter<StorageFolder> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(StorageFolder.GetFolderFromPathAsync(tcxFile.Remove(tcxFile.LastIndexOf('\\'))));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<StorageFolder> taskAwaiter2 = default(TaskAwaiter<StorageFolder>);
				taskAwaiter = taskAwaiter2;
			}
			StorageFolder result = taskAwaiter.GetResult();
			StorageFolder targetPath = result;
			TaskAwaiter<StorageFile> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(ApplicationData.Current.LocalFolder.GetFileAsync(targetFile));
			TaskAwaiter<StorageFile> taskAwaiter4 = default(TaskAwaiter<StorageFile>);
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<StorageFile>);
			}
			taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(taskAwaiter3.GetResult().CopyAsync((IStorageFolder)(object)targetPath, targetFile, (NameCollisionOption)1));
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				taskAwaiter3 = taskAwaiter4;
			}
			taskAwaiter3.GetResult();
		}
		catch (Exception)
		{
		}
	}

	public async Task<bool> ExportWorkout(StorageFile tcxFile)
	{
		bool bResult = false;
		if (tcxFile != null)
		{
			try
			{
				TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(ApplicationData.Current.LocalFolder.CreateFileAsync(tcxFile.Name, (CreationCollisionOption)1));
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
					taskAwaiter = taskAwaiter2;
				}
				StorageFile result = taskAwaiter.GetResult();
				StorageFile createFile = result;
				TCXBuffer = GenerateTcxBuffer();
				TaskAwaiter taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter(FileIO.WriteTextAsync((IStorageFile)(object)createFile, TCXBuffer));
				TaskAwaiter taskAwaiter4 = default(TaskAwaiter);
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
				bResult = TCXBuffer.Length > 0;
				await CopyToExternal(tcxFile.Path);
				taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter(createFile.DeleteAsync());
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
				}
				taskAwaiter3.GetResult();
			}
			catch (Exception ex)
			{
				TaskAwaiter<IUICommand> taskAwaiter5 = WindowsRuntimeSystemExtensions.GetAwaiter<IUICommand>(new MessageDialog(ex.Message, "Error").ShowAsync());
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter<IUICommand> taskAwaiter6 = default(TaskAwaiter<IUICommand>);
					taskAwaiter5 = taskAwaiter6;
				}
				taskAwaiter5.GetResult();
			}
		}
		return bResult;
	}

	public async Task UpdateWorkout()
	{
		string text = Path.Combine(new string[2]
		{
			ApplicationData.Current.LocalFolder.Path,
			"workouts.db"
		});
		using SqliteConnection db = new SqliteConnection($"Filename={text}");
		await db.OpenAsync();
		SqliteCommand sqliteCommand = new SqliteCommand();
		sqliteCommand.Connection = db;
		sqliteCommand.CommandText = "UPDATE Workouts SET Title=@Title, Notes=@Notes WHERE WorkoutId=@WorkoutId";
		sqliteCommand.Parameters.AddWithValue("@WorkoutId", WorkoutId);
		sqliteCommand.Parameters.AddWithValue("@Title", Title);
		sqliteCommand.Parameters.AddWithValue("@Notes", Notes);
		await sqliteCommand.ExecuteReaderAsync();
	}

	public async Task<long> StoreWorkout(SqliteConnection dbParam, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0uL)
	{
		long lResult = -1L;
		if (dbParam != null)
		{
			long lastId = 0L;
			await Task.Run(delegate
			{
				SqliteCommand sqliteCommand = new SqliteCommand();
				sqliteCommand.Connection = dbParam;
				sqliteCommand.CommandText = "INSERT INTO Workouts VALUES (NULL, @WorkoutType, @Title, @Notes, @Start, @End, @AvgHR, @MaxHR, @Calories, @AvgSpeed, @MaxSpeed, @DurationSec, @LongitudeStart, @LatitudeStart, @DistanceMeters, @LongDeltaRectSW, @LatDeltaRectSW, @LongDeltaRectNE, @LatDeltaRectNE);";
				sqliteCommand.Parameters.AddWithValue("@WorkoutType", WorkoutType);
				sqliteCommand.Parameters.AddWithValue("@Title", Title);
				sqliteCommand.Parameters.AddWithValue("@Notes", Notes);
				sqliteCommand.Parameters.AddWithValue("@Start", Start);
				sqliteCommand.Parameters.AddWithValue("@End", End);
				sqliteCommand.Parameters.AddWithValue("@AvgHR", AvgHR);
				sqliteCommand.Parameters.AddWithValue("@MaxHR", MaxHR);
				sqliteCommand.Parameters.AddWithValue("@Calories", Calories);
				sqliteCommand.Parameters.AddWithValue("@AvgSpeed", AvgSpeed);
				sqliteCommand.Parameters.AddWithValue("@MaxSpeed", MaxSpeed);
				sqliteCommand.Parameters.AddWithValue("@DurationSec", DurationSec);
				sqliteCommand.Parameters.AddWithValue("@LongitudeStart", LongitudeStart);
				sqliteCommand.Parameters.AddWithValue("@LatitudeStart", LatitudeStart);
				sqliteCommand.Parameters.AddWithValue("@DistanceMeters", DistanceMeters);
				sqliteCommand.Parameters.AddWithValue("@LongDeltaRectSW", LongDeltaRectSW);
				sqliteCommand.Parameters.AddWithValue("@LatDeltaRectSW", LatDeltaRectSW);
				sqliteCommand.Parameters.AddWithValue("@LongDeltaRectNE", LongDeltaRectNE);
				sqliteCommand.Parameters.AddWithValue("@LatDeltaRectNE", LatDeltaRectNE);
				sqliteCommand.ExecuteReader();
				lastId = (long)new SqliteCommand
				{
					Connection = dbParam,
					CommandText = "select last_insert_rowid()"
				}.ExecuteScalar();
				int num2 = (WorkoutId = (int)lastId);
				lResult = num2;
			});
			SqliteCommand insertTrackCommand = new SqliteCommand();
			insertTrackCommand.Connection = dbParam;
			if (WorkoutType == 21)
			{
				insertTrackCommand.CommandText = "INSERT INTO Sleep VALUES (NULL, @SleepActivityId, @SecFromStart, @SegmentType, @SleepType, @Heartrate);";
				foreach (TrackItem sleep in Items)
				{
					byte skinTempRaw2 = (byte)((sleep.SkinTemp > 0.0) ? ((byte)(sleep.SkinTemp * 10.0 - 200.0)) : 0);
					await Task.Run(delegate
					{
						insertTrackCommand.Parameters.AddWithValue("@SleepActivityId", lastId);
						insertTrackCommand.Parameters.AddWithValue("@SecFromStart", sleep.SecFromStart);
						insertTrackCommand.Parameters.AddWithValue("@SegmentType", skinTempRaw2);
						insertTrackCommand.Parameters.AddWithValue("@SleepType", sleep.Cadence);
						insertTrackCommand.Parameters.AddWithValue("@Heartrate", sleep.Heartrate);
						insertTrackCommand.ExecuteReader();
						insertTrackCommand.Parameters.Clear();
					});
					Progress?.Invoke(ulStepLength, 0uL);
				}
			}
			else
			{
				insertTrackCommand.CommandText = "INSERT INTO Tracks VALUES (NULL, @WorkoutId, @SecFromStart, @LongDelta, @LatDelta, @Elevation, @Heartrate, @Barometer, @Cadence, @SkinTemp, @GSR, @UVExposure);";
				foreach (TrackItem track in Items)
				{
					byte skinTempRaw = (byte)((track.SkinTemp > 0.0) ? ((byte)(track.SkinTemp * 10.0 - 200.0)) : 0);
					await Task.Run(delegate
					{
						insertTrackCommand.Parameters.AddWithValue("@WorkoutId", lastId);
						insertTrackCommand.Parameters.AddWithValue("@SecFromStart", track.SecFromStart);
						insertTrackCommand.Parameters.AddWithValue("@LongDelta", track.LongDelta);
						insertTrackCommand.Parameters.AddWithValue("@LatDelta", track.LatDelta);
						insertTrackCommand.Parameters.AddWithValue("@Elevation", track.Elevation);
						insertTrackCommand.Parameters.AddWithValue("@Heartrate", track.Heartrate);
						insertTrackCommand.Parameters.AddWithValue("@Barometer", track.Barometer);
						insertTrackCommand.Parameters.AddWithValue("@Cadence", track.Cadence);
						insertTrackCommand.Parameters.AddWithValue("@SkinTemp", skinTempRaw);
						insertTrackCommand.Parameters.AddWithValue("@GSR", track.GSR);
						insertTrackCommand.Parameters.AddWithValue("@UVExposure", track.UV);
						insertTrackCommand.ExecuteReader();
						insertTrackCommand.Parameters.Clear();
					});
					Progress?.Invoke(ulStepLength, 0uL);
				}
			}
		}
		return lResult;
	}

	public static async Task<ObservableCollection<WorkoutItem>> ReadWorkouts(WorkoutFilterData filterData = null)
	{
		ObservableCollection<WorkoutItem> workouts = new ObservableCollection<WorkoutItem>();
		string text = Path.Combine(new string[2]
		{
			ApplicationData.Current.LocalFolder.Path,
			"workouts.db"
		});
		using (SqliteConnection db = new SqliteConnection($"Filename={text}"))
		{
			await db.OpenAsync();
			SqliteCommand sqliteCommand = new SqliteCommand();
			sqliteCommand.Connection = db;
			if (filterData == null && WorkoutDataSource.DataSource.CurrentFilter == null)
			{
				sqliteCommand.CommandText = "SELECT * FROM Workouts ORDER BY Start DESC";
			}
			else
			{
				if (filterData == null)
				{
					filterData = WorkoutDataSource.DataSource.CurrentFilter;
				}
				sqliteCommand.CommandText = "SELECT * FROM Workouts WHERE Start >= @StartDate AND End <= @EndDate";
				if (filterData.IsWalkingWorkout == true || filterData.IsSleepingWorkout == true || filterData.IsRunningWorkout == true || filterData.IsBikingWorkout == true)
				{
					sqliteCommand.CommandText += " AND ( ";
					if (filterData.IsWalkingWorkout == true)
					{
						sqliteCommand.CommandText += "WorkoutType = 16 OR ";
					}
					if (filterData.IsBikingWorkout == true)
					{
						sqliteCommand.CommandText += "WorkoutType = 6 OR ";
					}
					if (filterData.IsRunningWorkout == true)
					{
						sqliteCommand.CommandText += "WorkoutType = 4 OR ";
					}
					if (filterData.IsSleepingWorkout == true)
					{
						sqliteCommand.CommandText += "WorkoutType = 21 ";
					}
					sqliteCommand.CommandText = sqliteCommand.CommandText.TrimEnd(' ', 'O', 'R');
					sqliteCommand.CommandText += " ) ";
				}
				if (filterData.MapBoundingBox != null)
				{
					double num = Math.Min(filterData.MapBoundingBox.NorthwestCorner.Latitude, filterData.MapBoundingBox.SoutheastCorner.Latitude);
					double num2 = Math.Max(filterData.MapBoundingBox.NorthwestCorner.Latitude, filterData.MapBoundingBox.SoutheastCorner.Latitude);
					double num3 = Math.Min(filterData.MapBoundingBox.NorthwestCorner.Longitude, filterData.MapBoundingBox.SoutheastCorner.Longitude);
					double num4 = Math.Max(filterData.MapBoundingBox.NorthwestCorner.Longitude, filterData.MapBoundingBox.SoutheastCorner.Longitude);
					sqliteCommand.CommandText += " AND LongitudeStart >= @Long1 AND LongitudeStart <= @Long2";
					sqliteCommand.CommandText += " AND LatitudeStart >= @Lat1 AND LatitudeStart <= @Lat2";
					sqliteCommand.Parameters.AddWithValue("@Long1", num3 * 10000000.0);
					sqliteCommand.Parameters.AddWithValue("@Long2", num4 * 10000000.0);
					sqliteCommand.Parameters.AddWithValue("@Lat1", num * 10000000.0);
					sqliteCommand.Parameters.AddWithValue("@Lat2", num2 * 10000000.0);
				}
				sqliteCommand.CommandText += " ORDER BY Start DESC";
				sqliteCommand.Parameters.AddWithValue("@StartDate", filterData.Start);
				sqliteCommand.Parameters.AddWithValue("@EndDate", filterData.End);
			}
			int iIndex = 0;
			using SqliteDataReader reader = await sqliteCommand.ExecuteReaderAsync();
			WorkoutDataSource.DataSource.TotalDistance = 0uL;
			WorkoutDataSource.DataSource.TotalHR = 0uL;
			WorkoutDataSource.DataSource.NumHRWorkouts = 0uL;
			WorkoutDataSource.DataSource.TotalAvgSpeed = 0uL;
			while (await reader.ReadAsync())
			{
				WorkoutItem workoutItem = new WorkoutItem
				{
					WorkoutId = reader.GetInt32(0),
					WorkoutType = reader.GetByte(1),
					Title = reader.GetString(2),
					Notes = reader.GetString(3),
					Start = reader.GetDateTime(4).ToUniversalTime(),
					End = reader.GetDateTime(5).ToUniversalTime(),
					AvgHR = reader.GetByte(6),
					MaxHR = reader.GetByte(7),
					Calories = reader.GetInt32(8),
					AvgSpeed = reader.GetInt32(9),
					MaxSpeed = reader.GetInt32(10),
					DurationSec = reader.GetInt32(11),
					LongitudeStart = reader.GetInt64(12),
					LatitudeStart = reader.GetInt64(13),
					DistanceMeters = reader.GetInt64(14),
					LongDeltaRectSW = reader.GetInt32(15),
					LatDeltaRectSW = reader.GetInt32(16),
					LongDeltaRectNE = reader.GetInt32(17),
					LatDeltaRectNE = reader.GetInt32(18),
					Items = new ObservableCollection<TrackItem>(),
					SleepItems = new ObservableCollection<SleepItem>(),
					Parent = workouts,
					Index = iIndex++
				};
				if (workoutItem.WorkoutType != 21)
				{
					WorkoutDataSource.DataSource.TotalDistance += (ulong)workoutItem.DistanceMeters;
				}
				string text2 = ((workoutItem.WorkoutType == 4) ? "Running" : ((workoutItem.WorkoutType == 6) ? "Biking" : ((workoutItem.WorkoutType == 21) ? "Sleeping" : "Walking")));
				if (workoutItem.WorkoutType != 21 && workoutItem.AvgHR > 0)
				{
					text2 = ((workoutItem.AvgHR <= 120) ? "Walking" : ((workoutItem.AvgHR < 140) ? "WarmUp" : ((workoutItem.AvgHR < 145) ? "Light" : ((workoutItem.AvgHR < 151) ? "Moderate" : ((workoutItem.AvgHR >= 158) ? "Maximum" : "Hard")))));
				}
				if (workoutItem.AvgHR > 0)
				{
					WorkoutDataSource.DataSource.TotalHR += workoutItem.AvgHR;
					WorkoutDataSource.DataSource.NumHRWorkouts++;
				}
				double num5 = (double)workoutItem.AvgSpeed / 1000.0;
				workoutItem.FilenameTCX = workoutItem.Start.Year.ToString("D4") + workoutItem.Start.Month.ToString("D2") + workoutItem.Start.Day.ToString("D2") + "_" + workoutItem.Start.Hour.ToString("D2") + workoutItem.Start.Minute.ToString("D2") + "_" + text2 + "_" + ((double)workoutItem.DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + num5.ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + workoutItem.AvgHR.ToString("F0") + ".tcx";
				workouts.Add(workoutItem);
			}
		}
		WorkoutDataSource.DataSource.Summary = ((WorkoutDataSource.DataSource.TotalDistance != 0) ? ((double)WorkoutDataSource.DataSource.TotalDistance / 1000.0).ToString("0,0.00", WorkoutDataSource.AppCultureInfo) : "0") + " km, Ø " + WorkoutDataSource.DataSource.TotalHR / WorkoutDataSource.DataSource.NumHRWorkouts + " bpm";
		return workouts;
	}

	public static async Task<WorkoutItem> ReadWorkoutFromTcx(string strTcxPath)
	{
		WorkoutItem workout = null;
		StorageFile fileTcx = null;
		try
		{
			TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(StorageFile.GetFileFromPathAsync(strTcxPath));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
				taskAwaiter = taskAwaiter2;
			}
			StorageFile result = taskAwaiter.GetResult();
			fileTcx = result;
		}
		catch (Exception)
		{
		}
		if (fileTcx != null)
		{
			try
			{
				TrainingCenterDatabase_t trainingCenterDatabase_t = await new Tcx().AnalyzeTcxFile(strTcxPath);
				if (trainingCenterDatabase_t == null)
				{
					return workout;
				}
				if (trainingCenterDatabase_t.Activities == null)
				{
					return workout;
				}
				if (trainingCenterDatabase_t.Activities.Activity[0] == null)
				{
					return workout;
				}
				if (trainingCenterDatabase_t.Activities.Activity[0].Lap[0] == null)
				{
					return workout;
				}
				DateTime id = trainingCenterDatabase_t.Activities.Activity[0].Id;
				int num = 0;
				long num2 = 0L;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 1;
				ActivityLap_t[] lap = trainingCenterDatabase_t.Activities.Activity[0].Lap;
				foreach (ActivityLap_t activityLap_t in lap)
				{
					num += (int)activityLap_t.TotalTimeSeconds;
					num2 += (long)activityLap_t.DistanceMeters;
					num3 += activityLap_t.Calories;
					if (activityLap_t.MaximumHeartRateBpm != null)
					{
						num4 = Math.Max(num4, activityLap_t.MaximumHeartRateBpm.Value);
					}
					if (activityLap_t.AverageHeartRateBpm != null)
					{
						num5 += activityLap_t.AverageHeartRateBpm.Value;
						num6++;
					}
				}
				workout = new WorkoutItem
				{
					WorkoutType = (byte)((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Running) ? 4u : ((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Biking) ? 6u : 32u)),
					Notes = trainingCenterDatabase_t.Activities.Activity[0].Notes,
					Start = id.ToUniversalTime(),
					End = id.AddSeconds(num).ToUniversalTime(),
					MaxHR = (byte)num4,
					Calories = num3,
					DurationSec = num,
					DistanceMeters = num2,
					Items = new ObservableCollection<TrackItem>(),
					SleepItems = new ObservableCollection<SleepItem>()
				};
				if (num5 > 0 && num6 > 0)
				{
					workout.AvgHR = (byte)(num5 / num6);
				}
				double num7 = (double)workout.DistanceMeters / (double)workout.DurationSec;
				double num8 = 1000.0 / num7 / 60.0;
				double num9 = num8 % 1.0;
				double num10 = 0.6 * num9;
				num8 -= num9;
				num8 += num10;
				workout.AvgSpeed = (int)Math.Ceiling(num8 * 1000.0);
				string text = ((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Running) ? "Running" : ((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Biking) ? "Biking" : "Walking"));
				if (workout.AvgHR > 0)
				{
					text = ((workout.AvgHR <= 120) ? "Walking" : ((workout.AvgHR < 140) ? "WarmUp" : ((workout.AvgHR < 145) ? "Light" : ((workout.AvgHR < 151) ? "Moderate" : ((workout.AvgHR >= 158) ? "Maximum" : "Hard")))));
				}
				if (trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeedSpecified)
				{
					workout.MaxSpeed = (int)trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeed;
				}
				workout.FilenameTCX = id.Year.ToString("D4") + id.Month.ToString("D2") + id.Day.ToString("D2") + "_" + id.Hour.ToString("D2") + id.Minute.ToString("D2") + "_" + text + "_" + ((double)(workout.DistanceMeters / 1000)).ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + num8.ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + workout.AvgHR.ToString("F0") + ".tcx";
				workout.Title = id.ToString(WorkoutDataSource.AppCultureInfo) + " " + text + " " + ((double)workout.DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo) + " km " + num8.ToString("F2", WorkoutDataSource.AppCultureInfo) + " min/km " + workout.AvgHR.ToString("F0") + " bpm";
				if (workout.Notes == null || workout.Notes.Length == 0)
				{
					workout.Notes = "TCX import " + DateTime.Now.ToString(WorkoutDataSource.AppCultureInfo);
				}
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				lap = trainingCenterDatabase_t.Activities.Activity[0].Lap;
				for (int i = 0; i < lap.Length; i++)
				{
					Trackpoint_t[] track = lap[i].Track;
					foreach (Trackpoint_t trackpoint_t in track)
					{
						if (trackpoint_t.Position != null)
						{
							TrackItem trackItem = new TrackItem();
							workout.Items.Add(trackItem);
							if (workout.LongitudeStart == 0L)
							{
								workout.LongitudeStart = (long)(trackpoint_t.Position.LongitudeDegrees * 10000000.0);
								workout.LatitudeStart = (long)(trackpoint_t.Position.LatitudeDegrees * 10000000.0);
								trackItem.LongDelta = 0;
								trackItem.LatDelta = 0;
							}
							else
							{
								trackItem.LongDelta = (int)((long)(trackpoint_t.Position.LongitudeDegrees * 10000000.0) - workout.LongitudeStart);
								trackItem.LatDelta = (int)((long)(trackpoint_t.Position.LatitudeDegrees * 10000000.0) - workout.LatitudeStart);
							}
							num11 = Math.Min(num11, trackItem.LatDelta);
							num12 = Math.Min(num12, trackItem.LongDelta);
							num13 = Math.Max(num13, trackItem.LatDelta);
							num14 = Math.Max(num14, trackItem.LongDelta);
							if (trackpoint_t.AltitudeMetersSpecified)
							{
								trackItem.Elevation = (int)trackpoint_t.AltitudeMeters;
							}
							if (trackpoint_t.CadenceSpecified)
							{
								trackItem.Cadence = trackpoint_t.Cadence;
							}
							if (trackpoint_t.HeartRateBpm != null)
							{
								trackItem.Heartrate = trackpoint_t.HeartRateBpm.Value;
							}
							if (workout.Start == DateTime.MinValue)
							{
								workout.Start = trackpoint_t.Time.ToUniversalTime();
							}
							trackItem.SecFromStart = (int)(trackpoint_t.Time.ToUniversalTime() - workout.Start).TotalSeconds;
						}
					}
				}
				workout.LatDeltaRectNE = num13;
				workout.LatDeltaRectSW = num11;
				workout.LongDeltaRectNE = num14;
				workout.LongDeltaRectSW = num12;
				return workout;
			}
			catch (Exception)
			{
				return workout;
			}
		}
		return workout;
	}

	public async Task ReadTrackData(CancellationToken token)
	{
		string dbpath = Path.Combine(new string[2]
		{
			ApplicationData.Current.LocalFolder.Path,
			"workouts.db"
		});
		await Task.Run(delegate
		{
			using SqliteConnection sqliteConnection = new SqliteConnection($"Filename={dbpath}");
			try
			{
				sqliteConnection.Open();
				SqliteCommand sqliteCommand = new SqliteCommand
				{
					Connection = sqliteConnection
				};
				if (Items != null && Items.Count > 0)
				{
					OnTracksLoaded(this);
				}
				else
				{
					token.ThrowIfCancellationRequested();
					sqliteCommand.CommandText = "SELECT * FROM Tracks WHERE WorkoutId = $id";
					sqliteCommand.Parameters.AddWithValue("$id", WorkoutId);
					Items = new ObservableCollection<TrackItem>();
					using (SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
					{
						double totalSeconds = (End - Start).TotalSeconds;
						double num = -1.0;
						double num2 = (totalSeconds - num) / 150.0;
						uint num3 = 0u;
						double lat = (double)LatitudeStart / 10000000.0;
						double @long = (double)LongitudeStart / 10000000.0;
						int num4 = 0;
						List<DiagramData> list = new List<DiagramData>();
						HeartRateChart.Clear();
						ElevationChart.Clear();
						CadenceNormChart.Clear();
						SpeedChart.Clear();
						int num5 = -999;
						double num6 = -999.0;
						double num7 = 0.0;
						TrackItem trackItem = null;
						int num8 = 0;
						while (sqliteDataReader.Read())
						{
							TrackItem trackItem2 = new TrackItem
							{
								TrackId = sqliteDataReader.GetInt32(0),
								WorkoutId = sqliteDataReader.GetInt32(1),
								SecFromStart = sqliteDataReader.GetInt32(2),
								LongDelta = sqliteDataReader.GetInt32(3),
								LatDelta = sqliteDataReader.GetInt32(4),
								Elevation = sqliteDataReader.GetInt32(5),
								Heartrate = sqliteDataReader.GetByte(6),
								Barometer = sqliteDataReader.GetInt32(7),
								Cadence = sqliteDataReader.GetByte(8),
								SkinTemp = (int)sqliteDataReader.GetByte(9),
								GSR = sqliteDataReader.GetInt32(10),
								UV = sqliteDataReader.GetInt32(11)
							};
							double skinTemp = ((trackItem2.SkinTemp > 0.0) ? ((trackItem2.SkinTemp + 200.0) / 10.0) : 0.0);
							trackItem2.SkinTemp = skinTemp;
							double num9 = (double)(LatitudeStart + trackItem2.LatDelta) / 10000000.0;
							double num10 = (double)(LongitudeStart + trackItem2.LongDelta) / 10000000.0;
							int secFromStart = trackItem2.SecFromStart;
							trackItem2.DistMeter = GetDistMeter(lat, @long, num9, num10);
							if (trackItem != null && num8 <= 40 && trackItem2.DistMeter > (double)((WorkoutType == 6) ? 120 : 50))
							{
								Items.Clear();
								trackItem2.DistMeter = 0.0;
							}
							if (num8 >= Items.Count - 40 && trackItem2.DistMeter > (double)((WorkoutType == 6) ? 200 : 150))
							{
								num8++;
							}
							else
							{
								num8++;
								int num11 = secFromStart - num4;
								trackItem2.SpeedMeterPerSecond = ((num11 > 1) ? (trackItem2.DistMeter / (double)num11) : 0.0);
								num7 = (trackItem2.TotalMeters = num7 + trackItem2.DistMeter);
								trackItem = trackItem2;
								Items.Add(trackItem2);
								lat = num9;
								@long = num10;
								num4 = secFromStart;
								num5 = ((num5 != -999) ? Math.Min(trackItem2.Elevation, num5) : trackItem2.Elevation);
								num6 = ((num6 != -999.0) ? Math.Max(trackItem2.SpeedMeterPerSecond, num6) : trackItem2.SpeedMeterPerSecond);
							}
						}
						if (Items.Count > 0)
						{
							int num13 = 0;
							int num14 = -1;
							double num15 = 150.0 / num6;
							foreach (TrackItem item in Items)
							{
								if (num14 < 0 || item.SecFromStart - num14 >= 10)
								{
									num14 = item.SecFromStart;
									if (num < 0.0)
									{
										num = item.SecFromStart;
									}
									if ((double)item.SecFromStart >= num)
									{
										double min = (double)item.SecFromStart / 60.0;
										HeartRateChart.Add(new DiagramData
										{
											Min = min,
											Value = (int)item.Heartrate,
											Index = num13
										});
										ElevationChart.Add(new DiagramData
										{
											Min = min,
											Value = Math.Max(-10, item.Elevation - num5)
										});
										list.Add(new DiagramData
										{
											Min = min,
											Value = item.Cadence
										});
										num3 = Math.Max(num3, item.Cadence);
										SpeedChart.Add(new DiagramData
										{
											Min = min,
											Value = item.SpeedMeterPerSecond * num15
										});
										num += num2;
									}
								}
								num13++;
							}
						}
						if (num3 != 0)
						{
							double num16 = ((num3 != 0) ? ((double)(int)MaxHR / (double)(2 * num3)) : 1.0);
							foreach (DiagramData item2 in list)
							{
								token.ThrowIfCancellationRequested();
								CadenceNormChart.Add(new DiagramData
								{
									Min = item2.Min,
									Value = item2.Value * num16
								});
							}
						}
						OnTracksLoaded(this);
					}
					sqliteCommand.Parameters.Clear();
				}
			}
			catch (Exception)
			{
			}
		});
	}

	public async Task ReadSleepData(CancellationToken token)
	{
		string dbpath = Path.Combine(new string[2]
		{
			ApplicationData.Current.LocalFolder.Path,
			"workouts.db"
		});
		await Task.Run(delegate
		{
			using SqliteConnection sqliteConnection = new SqliteConnection($"Filename={dbpath}");
			try
			{
				sqliteConnection.Open();
				SqliteCommand sqliteCommand = new SqliteCommand
				{
					Connection = sqliteConnection
				};
				if (Items != null && Items.Count > 0)
				{
					OnTracksLoaded(this);
				}
				else
				{
					token.ThrowIfCancellationRequested();
					sqliteCommand.CommandText = "SELECT * FROM Sleep WHERE SleepActivityId = $id";
					sqliteCommand.Parameters.AddWithValue("$id", WorkoutId);
					Items = new ObservableCollection<TrackItem>();
					using (SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
					{
						double totalSeconds = (End - Start).TotalSeconds;
						double num = -1.0;
						_ = (totalSeconds - num) / 150.0;
						while (sqliteDataReader.Read())
						{
							TrackItem trackItem = new TrackItem
							{
								TrackId = sqliteDataReader.GetInt32(0),
								WorkoutId = sqliteDataReader.GetInt32(1),
								SecFromStart = sqliteDataReader.GetInt32(2),
								SkinTemp = sqliteDataReader.GetInt32(3),
								LongDelta = 0,
								LatDelta = 0,
								Elevation = 0,
								Barometer = 0,
								Cadence = (uint)sqliteDataReader.GetInt32(4),
								Heartrate = sqliteDataReader.GetByte(5),
								GSR = 0,
								UV = 0
							};
							double skinTemp = ((trackItem.SkinTemp > 0.0) ? ((trackItem.SkinTemp + 200.0) / 10.0) : 0.0);
							trackItem.SkinTemp = skinTemp;
							_ = trackItem.SecFromStart;
							Items.Add(trackItem);
						}
						OnTracksLoaded(this);
					}
					sqliteCommand.Parameters.Clear();
				}
			}
			catch (Exception)
			{
			}
		});
	}

	public double GetDistMeter(double lat1, double long1, double lat2, double long2)
	{
		double d = (lat1 + lat2) / 2.0 * 0.01745;
		double num = 111.3 * Math.Cos(d) * (long1 - long2);
		double num2 = 111.3 * (lat1 - lat2);
		return Math.Sqrt(num * num + num2 * num2) * 1000.0;
	}

	public string GenerateTcxBuffer()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		if (Items.Count <= 0)
		{
			return result;
		}
		ExportType exportType = (ExportType)120;
		try
		{
			Tcx tcx = new Tcx();
			new XmlDocument();
			if (WorkoutType == 4 || WorkoutType == 32 || WorkoutType == 6 || WorkoutType == 16)
			{
				if (Items.Count > 0)
				{
					ExportType exportType2 = exportType;
					switch ((EventType)WorkoutType)
					{
					case EventType.Running:
					case EventType.Hike:
						exportType2 &= (ExportType)120;
						break;
					case EventType.Biking:
						exportType2 &= (ExportType)104;
						break;
					default:
						exportType2 &= ExportType.HeartRate;
						break;
					}
					TrainingCenterDatabase_t trainingCenterDatabase_t = new TrainingCenterDatabase_t();
					trainingCenterDatabase_t.Activities = new ActivityList_t();
					trainingCenterDatabase_t.Activities.Activity = new Activity_t[1];
					trainingCenterDatabase_t.Activities.Activity[0] = new Activity_t();
					trainingCenterDatabase_t.Activities.Activity[0].Id = Start;
					trainingCenterDatabase_t.Activities.Activity[0].Notes = Notes;
					trainingCenterDatabase_t.Activities.Activity[0].Sport = ((WorkoutType == 6) ? Sport_t.Biking : Sport_t.Running);
					trainingCenterDatabase_t.Activities.Activity[0].Lap = new ActivityLap_t[1];
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0] = new ActivityLap_t();
					double num = 0.0;
					trainingCenterDatabase_t.Activities.Activity[0].Sport = ((WorkoutType == 6) ? Sport_t.Biking : Sport_t.Running);
					string text;
					if (AvgHR != 0)
					{
						if (AvgHR > 120)
						{
							text = ((AvgHR < 140) ? "WarmUp" : ((AvgHR < 145) ? "Light" : ((AvgHR < 151) ? "Moderate" : ((AvgHR >= 158) ? "Maximum" : "Hard"))));
						}
						else
						{
							trainingCenterDatabase_t.Activities.Activity[0].Sport = Sport_t.Other;
							text = "Walking";
						}
						if ((exportType & ExportType.HeartRate) == ExportType.HeartRate)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm.Value = AvgHR;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm.Value = MaxHR;
						}
					}
					else
					{
						text = ((WorkoutType == 6) ? "Biking" : ((WorkoutType == 4) ? "Running" : "Walking"));
					}
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeed = MaxSpeed;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeedSpecified = true;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TotalTimeSeconds = DurationSec;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Calories = (ushort)Calories;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].DistanceMeters = DistanceMeters;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Intensity = Intensity_t.Active;
					num = (double)DistanceMeters / (double)DurationSec;
					double num2 = 1000.0 / num / 60.0;
					double num3 = num2 % 1.0;
					double num4 = 0.6 * num3;
					num2 -= num3;
					num2 += num4;
					FilenameTCX = Start.Year.ToString("D4") + Start.Month.ToString("D2") + Start.Day.ToString("D2") + "_" + Start.Hour.ToString("D2") + Start.Minute.ToString("D2") + "_" + text + "_" + ((double)DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + num2.ToString("F2", WorkoutDataSource.AppCultureInfo) + "_" + AvgHR.ToString("F0") + ".tcx";
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].StartTime = Start;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TriggerMethod = TriggerMethod_t.Manual;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track = new Trackpoint_t[Items.Count];
					int num5 = 0;
					foreach (TrackItem item in Items)
					{
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5] = new Trackpoint_t();
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Time = Start.AddSeconds(item.SecFromStart);
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorState = SensorState_t.Present;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorStateSpecified = true;
						if ((exportType & ExportType.HeartRate) == ExportType.HeartRate)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm = new HeartRateInBeatsPerMinute_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm.Value = item.Heartrate;
						}
						if ((exportType & ExportType.Cadence) == ExportType.Cadence && WorkoutType != 6)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Cadence = (byte)item.Cadence;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].CadenceSpecified = true;
						}
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMeters = item.Elevation;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMetersSpecified = true;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position = new Position_t();
						double latitudeDegrees = (double)(LatitudeStart + item.LatDelta) / 10000000.0;
						double longitudeDegrees = (double)(LongitudeStart + item.LongDelta) / 10000000.0;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LatitudeDegrees = latitudeDegrees;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LongitudeDegrees = longitudeDegrees;
						num5++;
					}
					string text2 = tcx.GenerateTcx(trainingCenterDatabase_t);
					if (text2 != null)
					{
						if (text2.Length > 0)
						{
							return text2.Replace("\"utf-16\"", "\"UTF-8\"");
						}
						return result;
					}
					return result;
				}
				return result;
			}
			return result;
		}
		catch (Exception)
		{
			return "";
		}
	}
}
