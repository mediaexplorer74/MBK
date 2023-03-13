using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;
using MobileBandSync.Common;
using Windows.ApplicationModel.Resources;
using Windows.Globalization;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Popups;

namespace MobileBandSync.Data;

public sealed class WorkoutDataSource
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static UICommandInvokedHandler _003C_003E9__59_0;

		public static UICommandInvokedHandler _003C_003E9__59_1;

		public static Func<DateTime, DateTime> _003C_003E9__63_0;

		public static Func<WorkoutItem, IEnumerable<TrackItem>> _003C_003E9__67_0;

		internal void _003CInitDatabase_003Eb__59_0(IUICommand cmd)
		{
		}

		internal void _003CInitDatabase_003Eb__59_1(IUICommand cmd)
		{
		}

		internal DateTime _003CReadWorkoutsFromSensorLogs_003Eb__63_0(DateTime d)
		{
			return d;
		}

		internal IEnumerable<TrackItem> _003CGetItemAsync_003Eb__67_0(WorkoutItem workout)
		{
			return workout.Items;
		}
	}

	public const bool _offlineTest = false;

	public static CultureInfo AppCultureInfo = new CultureInfo(Language.CurrentInputMethodLanguageTag);

	public static string BandName = "MS Band 2";

	private const string WorkoutDbName = "workouts.db";

	private const string WorkoutFolderName = "Workouts";

	private const string WorkoutDbFolderName = "WorkoutDB";

	private static WorkoutDataSource _workoutDataSource = new WorkoutDataSource();

	public ulong TotalDistance;

	public ulong NumHRWorkouts;

	public ulong TotalHR;

	public ulong TotalAvgSpeed;

	private ObservableCollection<WorkoutItem> _workouts = new ObservableCollection<WorkoutItem>();

	public ObservableCollection<WorkoutItem> Workouts
	{
		get
		{
			return _workouts;
		}
		set
		{
			_workouts = value;
		}
	}

	public StorageFolder WorkoutsFolder { get; private set; }

	public WorkoutFilterData CurrentFilter { get; set; }

	public static WorkoutDataSource DataSource => _workoutDataSource;

	public StorageFolder DatabaseFolder { get; private set; }

	public SensorLog SensorLogEngine { get; private set; }

	public static bool DbInitialized { get; private set; }

	public StorageFolder WorkoutDbFolder { get; private set; }

	public string MapServiceToken { get; set; }

	public static ObservableCollection<WorkoutItem> WorkoutList => _workoutDataSource.Workouts;

	public string Summary { get; set; }

	public static string GetMapServiceToken()
	{
		return _workoutDataSource.MapServiceToken;
	}

	public static ObservableCollection<WorkoutItem> GetWorkouts()
	{
		return _workoutDataSource.Workouts;
	}

	public static void SetMapServiceToken(string strServiceToken)
	{
		_workoutDataSource.MapServiceToken = strServiceToken;
	}

	public WorkoutDataSource()
	{
		SqliteEngine.UseWinSqlite3();
	}

	public static async Task<IEnumerable<WorkoutItem>> GetWorkoutsAsync(bool bForceReload = false, WorkoutFilterData workoutFilter = null)
	{
		_ = 1;
		try
		{
			if (!DbInitialized)
			{
				if (_workoutDataSource == null)
				{
					_workoutDataSource = new WorkoutDataSource();
				}
				DbInitialized = await _workoutDataSource.InitDatabase();
			}
			await _workoutDataSource.GetWorkoutDataAsync(bForceReload, workoutFilter);
		}
		catch (Exception)
		{
		}
		return _workoutDataSource.Workouts;
	}

	public static async Task<string> GetWorkoutSummaryAsync()
	{
		return _workoutDataSource.Summary;
	}

	public static async Task<List<WorkoutItem>> ImportFromSensorlog(StorageFolder sensorLogFolder, Action<string> Status, Action<ulong, ulong> Progress)
	{
		_workoutDataSource.SensorLogEngine.Sequences.Clear();
		List<Workout> list = await _workoutDataSource.ReadWorkoutsFromSensorLogs(sensorLogFolder);
		if (list != null && list.Count > 0)
		{
			int num = 0;
			foreach (Workout item in list)
			{
				if (item.TrackPoints != null)
				{
					num += item.TrackPoints.Count;
				}
			}
			ulong num2 = _workoutDataSource.SensorLogEngine.BufferSize / (ulong)num;
			_workoutDataSource.SensorLogEngine.StepLength = num2;
			return await _workoutDataSource.AddWorkouts(list, bAddToDb: false, Status, Progress, num2);
		}
		return new List<WorkoutItem>();
	}

	public static async Task<List<WorkoutItem>> ImportFromSensorlog(byte[] btSensorLog, Action<string> Status, Action<ulong, ulong> Progress)
	{
		if (!DbInitialized)
		{
			DbInitialized = await _workoutDataSource.InitDatabase();
		}
		_workoutDataSource.SensorLogEngine.Sequences.Clear();
		List<Workout> list = await _workoutDataSource.ReadWorkoutsFromSensorLogBuffer(btSensorLog);
		if (list != null && list.Count > 0)
		{
			int num = 0;
			foreach (Workout item in list)
			{
				if (item.Type != EventType.Sleeping)
				{
					if (item.TrackPoints != null)
					{
						num += item.TrackPoints.Count;
					}
				}
				else if (item.TrackPoints != null)
				{
					num += item.TrackPoints.Count;
				}
			}
			ulong num2 = _workoutDataSource.SensorLogEngine.BufferSize / (ulong)num;
			DataSource.SensorLogEngine.StepLength = num2;
			return await _workoutDataSource.AddWorkouts(list, bAddToDb: false, Status, Progress, num2);
		}
		return new List<WorkoutItem>();
	}

	public async Task<bool> InitDatabase(bool bDeleteOldDb = false)
	{
		TaskAwaiter<StorageFolder> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(KnownFolders.DocumentsLibrary.CreateFolderAsync("Workouts", (CreationCollisionOption)3));
		TaskAwaiter<StorageFolder> taskAwaiter2 = default(TaskAwaiter<StorageFolder>);
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<StorageFolder>);
		}
		StorageFolder result = taskAwaiter.GetResult();
		WorkoutsFolder = result;
		taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(KnownFolders.DocumentsLibrary.CreateFolderAsync("WorkoutDB", (CreationCollisionOption)3));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
		}
		result = taskAwaiter.GetResult();
		WorkoutDbFolder = result;
		DatabaseFolder = ApplicationData.Current.LocalFolder;
		if (WorkoutsFolder == null || DatabaseFolder == null)
		{
			return false;
		}
		TaskAwaiter<StorageFile> taskAwaiter4 = default(TaskAwaiter<StorageFile>);
		TaskAwaiter<IUICommand> taskAwaiter10 = default(TaskAwaiter<IUICommand>);
		TaskAwaiter<StorageFile> taskAwaiter3;
		try
		{
			object obj = _003C_003Ec._003C_003E9__59_0;
			if (obj == null)
			{
				UICommandInvokedHandler val = delegate
				{
				};
				obj = (object)val;
				_003C_003Ec._003C_003E9__59_0 = val;
			}
			UICommand yesCommand = new UICommand("Yes", (UICommandInvokedHandler)obj);
			object obj2 = _003C_003Ec._003C_003E9__59_1;
			if (obj2 == null)
			{
				UICommandInvokedHandler val2 = delegate
				{
				};
				obj2 = (object)val2;
				_003C_003Ec._003C_003E9__59_1 = val2;
			}
			UICommand item = new UICommand("No", (UICommandInvokedHandler)obj2);
			MessageDialog dialog = new MessageDialog("Do you want to replace the DB with the newer one found in the WorkoutDb folder?", "Copy new database");
			dialog.put_Options((MessageDialogOptions)0);
			dialog.Commands.Add((IUICommand)(object)yesCommand);
			dialog.Commands.Add((IUICommand)(object)item);
			taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(DatabaseFolder.GetFileAsync("workouts.db"));
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<StorageFile>);
			}
			StorageFile result2 = taskAwaiter3.GetResult();
			StorageFile oldDb = result2;
			if (oldDb != null)
			{
				TaskAwaiter taskAwaiter6 = default(TaskAwaiter);
				if (bDeleteOldDb)
				{
					TaskAwaiter taskAwaiter5 = WindowsRuntimeSystemExtensions.GetAwaiter(oldDb.DeleteAsync());
					if (!taskAwaiter5.IsCompleted)
					{
						await taskAwaiter5;
						taskAwaiter5 = taskAwaiter6;
					}
					taskAwaiter5.GetResult();
				}
				else
				{
					try
					{
						taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(WorkoutDbFolder.GetFileAsync("workouts.db"));
						if (!taskAwaiter3.IsCompleted)
						{
							await taskAwaiter3;
							taskAwaiter3 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<StorageFile>);
						}
						result2 = taskAwaiter3.GetResult();
						StorageFile databaseFile = result2;
						if (databaseFile != null)
						{
							TaskAwaiter<BasicProperties> taskAwaiter7 = WindowsRuntimeSystemExtensions.GetAwaiter<BasicProperties>(oldDb.GetBasicPropertiesAsync());
							TaskAwaiter<BasicProperties> taskAwaiter8 = default(TaskAwaiter<BasicProperties>);
							if (!taskAwaiter7.IsCompleted)
							{
								await taskAwaiter7;
								taskAwaiter7 = taskAwaiter8;
								taskAwaiter8 = default(TaskAwaiter<BasicProperties>);
							}
							BasicProperties result3 = taskAwaiter7.GetResult();
							BasicProperties oldProp = result3;
							taskAwaiter7 = WindowsRuntimeSystemExtensions.GetAwaiter<BasicProperties>(databaseFile.GetBasicPropertiesAsync());
							if (!taskAwaiter7.IsCompleted)
							{
								await taskAwaiter7;
								taskAwaiter7 = taskAwaiter8;
							}
							if (taskAwaiter7.GetResult().DateModified > oldProp.DateModified)
							{
								TaskAwaiter<IUICommand> taskAwaiter9 = WindowsRuntimeSystemExtensions.GetAwaiter<IUICommand>(dialog.ShowAsync());
								if (!taskAwaiter9.IsCompleted)
								{
									await taskAwaiter9;
									taskAwaiter9 = taskAwaiter10;
									taskAwaiter10 = default(TaskAwaiter<IUICommand>);
								}
								if (taskAwaiter9.GetResult() == yesCommand)
								{
									TaskAwaiter taskAwaiter5 = WindowsRuntimeSystemExtensions.GetAwaiter(oldDb.DeleteAsync());
									if (!taskAwaiter5.IsCompleted)
									{
										await taskAwaiter5;
										taskAwaiter5 = taskAwaiter6;
									}
									taskAwaiter5.GetResult();
									taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(databaseFile.CopyAsync((IStorageFolder)(object)DatabaseFolder));
									if (!taskAwaiter3.IsCompleted)
									{
										await taskAwaiter3;
										taskAwaiter3 = taskAwaiter4;
										taskAwaiter4 = default(TaskAwaiter<StorageFile>);
									}
									taskAwaiter3.GetResult();
								}
							}
						}
					}
					catch
					{
					}
				}
				return true;
			}
		}
		catch
		{
			try
			{
				taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(WorkoutDbFolder.GetFileAsync("workouts.db"));
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<StorageFile>);
				}
				StorageFile result4 = taskAwaiter3.GetResult();
				if (result4 != null && !bDeleteOldDb)
				{
					taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(result4.CopyAsync((IStorageFolder)(object)DatabaseFolder));
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter4;
						taskAwaiter4 = default(TaskAwaiter<StorageFile>);
					}
					taskAwaiter3.GetResult();
					return true;
				}
			}
			catch
			{
			}
		}
		taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(DatabaseFolder.CreateFileAsync("workouts.db", (CreationCollisionOption)3));
		if (!taskAwaiter3.IsCompleted)
		{
			await taskAwaiter3;
			taskAwaiter3 = taskAwaiter4;
		}
		taskAwaiter3.GetResult();
		string text = Path.Combine(new string[2] { DatabaseFolder.Path, "workouts.db" });
		using (SqliteConnection db = new SqliteConnection($"Filename={text}"))
		{
			try
			{
				await db.OpenAsync();
				await new SqliteCommand("CREATE TABLE IF NOT EXISTS Tracks (TrackId INTEGER PRIMARY KEY AUTOINCREMENT, WorkoutId INTEGER NOT NULL, SecFromStart INT, LongDelta INT, LatDelta INT, Elevation INT, Heartrate TINYINT, Barometer INT, Cadence TINYINT, SkinTemp TINYINT, GSR INT, UVExposure INT )", db).ExecuteReaderAsync();
				await new SqliteCommand("CREATE TABLE IF NOT EXISTS Sleep (SleepId INTEGER PRIMARY KEY AUTOINCREMENT, SleepActivityId INTEGER NOT NULL, SecFromStart INT, SegmentType TINYINT, SleepType TINYINT, Heartrate TINYINT )", db).ExecuteReaderAsync();
				await new SqliteCommand("CREATE TABLE IF NOT EXISTS Workouts (WorkoutId INTEGER PRIMARY KEY AUTOINCREMENT, WorkoutType TINYINT, Title NVARCHAR(128) NULL, Notes NVARCHAR(2048) NULL, Start DATETIME, End DATETIME, AvgHR TINYINT, MaxHR TINYINT, Calories INT, AvgSpeed INT, MaxSpeed INT, DurationSec INT, LongitudeStart INT8, LatitudeStart INT8, DistanceMeters INT8, LongDeltaRectSW INT, LatDeltaRectSW INT, LongDeltaRectNE INT, LatDeltaRectNE INT )", db).ExecuteReaderAsync();
			}
			catch (Exception ex)
			{
				TaskAwaiter<IUICommand> taskAwaiter9 = WindowsRuntimeSystemExtensions.GetAwaiter<IUICommand>(new MessageDialog(ex.Message, "Error").ShowAsync());
				if (!taskAwaiter9.IsCompleted)
				{
					await taskAwaiter9;
					taskAwaiter9 = taskAwaiter10;
				}
				taskAwaiter9.GetResult();
			}
		}
		return true;
	}

	public static async Task<List<long>> StoreWorkouts(List<WorkoutItem> workouts, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0uL)
	{
		List<long> listResult = new List<long>();
		string text = Path.Combine(new string[2]
		{
			ApplicationData.Current.LocalFolder.Path,
			"workouts.db"
		});
		using (SqliteConnection db = new SqliteConnection($"Filename={text}"))
		{
			await db.OpenAsync();
			foreach (WorkoutItem workout in workouts)
			{
				if (workout.Items.Count > 0)
				{
					List<long> list = listResult;
					list.Add(await workout.StoreWorkout(db, Progress, ulStepLength));
				}
			}
		}
		return listResult;
	}

	public static async Task<bool> BackupDatabase(StorageFolder targetFolder = null)
	{
		bool bResult = false;
		TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(ApplicationData.Current.LocalFolder.GetFileAsync("workouts.db"));
		TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<StorageFile>);
		}
		StorageFile result = taskAwaiter.GetResult();
		StorageFile database = result;
		if (database != null)
		{
			if (targetFolder == null)
			{
				TaskAwaiter<StorageFolder> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(KnownFolders.DocumentsLibrary.CreateFolderAsync("WorkoutDB", (CreationCollisionOption)3));
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter<StorageFolder> taskAwaiter4 = default(TaskAwaiter<StorageFolder>);
					taskAwaiter3 = taskAwaiter4;
				}
				StorageFolder result2 = taskAwaiter3.GetResult();
				targetFolder = result2;
			}
			taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(database.CopyAsync((IStorageFolder)(object)targetFolder, database.Name, (NameCollisionOption)1));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
			}
			result = taskAwaiter.GetResult();
			bResult = result != null;
		}
		return bResult;
	}

	public async Task<List<Workout>> ReadWorkoutsFromSensorLogBuffer(byte[] btSensorLog)
	{
		if (SensorLogEngine == null || btSensorLog == null)
		{
			return null;
		}
		try
		{
			using MemoryStream memStream = new MemoryStream(btSensorLog);
			SensorLogEngine.BufferSize = (ulong)btSensorLog.Length;
			await SensorLogEngine.Read(memStream);
		}
		catch (Exception)
		{
		}
		try
		{
			if (SensorLogEngine.Sequences.Count > 0)
			{
				return await SensorLogEngine.CreateWorkouts((ExportType)120);
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	public async Task<List<Workout>> ReadWorkoutsFromSensorLogs(StorageFolder SensorLogFolder)
	{
		if (SensorLogEngine == null || SensorLogFolder == null)
		{
			return null;
		}
		string path = SensorLogFolder.Path;
		string strTempDir = path;
		SensorLogEngine.BufferSize = 0uL;
		try
		{
			Dictionary<DateTime, string> dictFiles = new Dictionary<DateTime, string>();
			TaskAwaiter<IReadOnlyList<StorageFile>> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<IReadOnlyList<StorageFile>>(SensorLogFolder.GetFilesAsync());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<IReadOnlyList<StorageFile>> taskAwaiter2 = default(TaskAwaiter<IReadOnlyList<StorageFile>>);
				taskAwaiter = taskAwaiter2;
			}
			IReadOnlyList<StorageFile> result = taskAwaiter.GetResult();
			TaskAwaiter<BasicProperties> taskAwaiter4 = default(TaskAwaiter<BasicProperties>);
			foreach (StorageFile file in result)
			{
				TaskAwaiter<BasicProperties> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<BasicProperties>(file.GetBasicPropertiesAsync());
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					taskAwaiter3 = taskAwaiter4;
					taskAwaiter4 = default(TaskAwaiter<BasicProperties>);
				}
				BasicProperties result2 = taskAwaiter3.GetResult();
				SensorLogEngine.BufferSize += result2.Size;
				string text = file.Path.Substring(strTempDir.Length + 1);
				int.Parse(text.Substring(text.Length - 12, 3));
				int second = int.Parse(text.Substring(text.Length - 14, 2));
				int minute = int.Parse(text.Substring(text.Length - 16, 2));
				int hour = int.Parse(text.Substring(text.Length - 18, 2));
				int day = int.Parse(text.Substring(text.Length - 20, 2));
				int month = int.Parse(text.Substring(text.Length - 22, 2));
				int year = int.Parse(text.Substring(text.Length - 24, 2));
				DateTime key = new DateTime(year, month, day, hour, minute, second);
				dictFiles.Add(key, text);
			}
			IOrderedEnumerable<DateTime> orderedEnumerable = dictFiles.Keys.OrderBy((DateTime d) => d);
			foreach (DateTime item in orderedEnumerable)
			{
				string text2 = dictFiles[item];
				using Stream fileStream = await WindowsRuntimeStorageExtensions.OpenStreamForReadAsync((IStorageFolder)(object)SensorLogFolder, text2);
				await SensorLogEngine.Read(fileStream);
			}
		}
		catch (Exception)
		{
		}
		try
		{
			if (SensorLogEngine.Sequences.Count > 0)
			{
				return await SensorLogEngine.CreateWorkouts((ExportType)120);
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	public async Task<List<WorkoutItem>> AddWorkouts(List<Workout> Workouts, bool bAddToDb = false, Action<string> Status = null, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0uL)
	{
		List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
		_ = Workouts.Count;
		try
		{
			string dbpath = Path.Combine(new string[2]
			{
				ApplicationData.Current.LocalFolder.Path,
				"workouts.db"
			});
			ResourceLoader resourceLoader = ResourceLoader.GetForViewIndependentUse();
			int iIndex = 0;
			foreach (Workout Workout in Workouts)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				WorkoutItem workoutData = new WorkoutItem
				{
					WorkoutType = (byte)Workout.Type,
					LongDeltaRectSW = 0,
					LatDeltaRectSW = 0,
					LongDeltaRectNE = 0,
					LatDeltaRectNE = 0,
					Items = new ObservableCollection<TrackItem>(),
					DbPath = dbpath,
					Parent = WorkoutList,
					Index = iIndex++
				};
				if ((Workout.Type == EventType.Running || Workout.Type == EventType.Hike || Workout.Type == EventType.Walking || Workout.Type == EventType.Sleeping || Workout.Type == EventType.Biking) && Workout.TrackPoints.Count > 0)
				{
					switch (Workout.Type)
					{
					}
					workoutData.Start = Workout.StartTime;
					workoutData.End = Workout.EndTime;
					workoutData.Notes = Workout.Notes;
					workoutData.WorkoutType = (byte)Workout.Type;
					if (Workout.Type == EventType.Sleeping)
					{
						if (Workout.SleepSummary != null)
						{
							workoutData.Title = Workout.StartTime.ToString(AppCultureInfo) + " " + resourceLoader.GetString("WorkoutSleep") + " " + Workout.SleepSummary.Duration.ToString("hh\\:mm");
							workoutData.AvgHR = (byte)Workout.SleepSummary.HFAverage;
							workoutData.MaxHR = (byte)Workout.SleepSummary.HFMax;
							workoutData.Calories = Workout.SleepSummary.CaloriesBurned;
							workoutData.FallAsleepDuration = Workout.SleepSummary.FallAsleepTime;
							workoutData.AwakeDuration = Workout.SleepSummary.Duration - Workout.SleepSummary.TotalRestfulSleepDuration - Workout.SleepSummary.TotalRestlessSleepDuration;
							workoutData.DurationSec = Workout.SleepSummary.Duration.Milliseconds / 1000;
							workoutData.NumberOfWakeups = (int)Workout.SleepSummary.TimesAwoke;
							workoutData.TotalRestfulSleepDuration = Workout.SleepSummary.TotalRestfulSleepDuration;
							workoutData.SleepEfficiencyPercentage = (int)Math.Ceiling((float)(Workout.SleepSummary.Duration.Milliseconds * 100 / Workout.SleepSummary.TotalRestfulSleepDuration.Milliseconds));
							workoutData.TotalRestlessSleepDuration = Workout.SleepSummary.TotalRestlessSleepDuration;
							workoutData.SleepDuration = Workout.SleepSummary.Duration;
							workoutData.Feeling = Workout.SleepSummary.Feeling;
						}
						else
						{
							workoutData.Title = Workout.StartTime.ToString(AppCultureInfo) + " " + resourceLoader.GetString("WorkoutUnknown");
						}
						foreach (WorkoutPoint trackPoint in Workout.TrackPoints)
						{
							TrackItem trackItem = new TrackItem
							{
								WorkoutId = workoutData.WorkoutId,
								LatDelta = 0,
								LongDelta = 0
							};
							trackItem.SecFromStart = (int)(trackPoint.Time - workoutData.Start).TotalSeconds;
							trackItem.Heartrate = (byte)trackPoint.HeartRateBpm;
							trackItem.Elevation = (int)trackPoint.Elevation;
							trackItem.Cadence = trackPoint.Cadence;
							trackItem.GSR = (int)trackPoint.GalvanicSkinResponse;
							trackItem.SkinTemp = trackPoint.SkinTemperature;
							trackItem.Barometer = 0;
							workoutData.Items.Add(trackItem);
						}
					}
					else
					{
						if (Workout.Summary != null)
						{
							string text;
							if (Workout.Type == EventType.Biking)
							{
								text = resourceLoader.GetString("WorkoutBiking");
							}
							else if (Workout.Type == EventType.Hike)
							{
								text = resourceLoader.GetString("WorkoutHiking");
							}
							else if (Workout.Summary.HFAverage > 120)
							{
								text = ((Workout.Summary.HFAverage < 140) ? resourceLoader.GetString("WorkoutWarmup") : ((Workout.Summary.HFAverage < 145) ? resourceLoader.GetString("WorkoutLight") : ((Workout.Summary.HFAverage < 151) ? resourceLoader.GetString("WorkoutModerate") : ((Workout.Summary.HFAverage >= 160) ? resourceLoader.GetString("WorkoutMaximum") : resourceLoader.GetString("WorkoutHard")))));
							}
							else
							{
								workoutData.WorkoutType = 16;
								text = resourceLoader.GetString("WorkoutWalking");
							}
							double num5 = Workout.Summary.Distance / Workout.Summary.Duration;
							double num6 = 1000.0 / num5 / 60.0;
							double num7 = num6 % 1.0;
							double num8 = 0.6 * num7;
							num6 -= num7;
							num6 += num8;
							workoutData.AvgSpeed = (int)Math.Ceiling(num6 * 1000.0);
							workoutData.MaxSpeed = (int)Workout.Summary.MaximumSpeed;
							workoutData.Calories = Workout.Summary.CaloriesBurned;
							workoutData.DurationSec = (int)Workout.Summary.Duration;
							workoutData.AvgHR = (byte)Workout.Summary.HFAverage;
							workoutData.MaxHR = (byte)Workout.Summary.HFMax;
							workoutData.DistanceMeters = (long)Workout.Summary.Distance;
							workoutData.Title = Workout.StartTime.ToString(AppCultureInfo) + " " + text + " " + ((double)workoutData.DistanceMeters / 1000.0).ToString("F2", AppCultureInfo) + " km " + num6.ToString("F2", AppCultureInfo) + " min/km " + workoutData.AvgHR.ToString("F0") + " bpm";
							if (workoutData.Notes == null || workoutData.Notes.Length == 0)
							{
								workoutData.Notes = "Sensor log import " + DateTime.Now.ToString(AppCultureInfo);
							}
						}
						else
						{
							workoutData.Title = Workout.StartTime.ToString(AppCultureInfo) + " Workout";
						}
						foreach (WorkoutPoint trackPoint2 in Workout.TrackPoints)
						{
							TrackItem trackItem2 = new TrackItem
							{
								WorkoutId = workoutData.WorkoutId
							};
							trackItem2.SecFromStart = (int)(trackPoint2.Time - workoutData.Start).TotalSeconds;
							trackItem2.Heartrate = (byte)trackPoint2.HeartRateBpm;
							trackItem2.Elevation = (int)trackPoint2.Elevation;
							trackItem2.Cadence = (byte)trackPoint2.Cadence;
							trackItem2.GSR = (int)trackPoint2.GalvanicSkinResponse;
							trackItem2.SkinTemp = trackPoint2.SkinTemperature;
							trackItem2.Barometer = 0;
							if (workoutData.LongitudeStart == 0L)
							{
								workoutData.LongitudeStart = (long)(trackPoint2.Position.LongitudeDegrees * 10000000.0);
								trackItem2.LongDelta = 0;
							}
							else
							{
								trackItem2.LongDelta = (int)(trackPoint2.Position.LongitudeDegrees * 10000000.0 - (double)workoutData.LongitudeStart);
							}
							if (workoutData.LatitudeStart == 0L)
							{
								workoutData.LatitudeStart = (long)(trackPoint2.Position.LatitudeDegrees * 10000000.0);
								trackItem2.LatDelta = 0;
							}
							else
							{
								trackItem2.LatDelta = (int)(trackPoint2.Position.LatitudeDegrees * 10000000.0 - (double)workoutData.LatitudeStart);
							}
							workoutData.Items.Add(trackItem2);
							num = Math.Min(num, trackItem2.LatDelta);
							num2 = Math.Min(num2, trackItem2.LongDelta);
							num3 = Math.Max(num3, trackItem2.LatDelta);
							num4 = Math.Max(num4, trackItem2.LongDelta);
						}
						workoutData.LatDeltaRectNE = num3;
						workoutData.LatDeltaRectSW = num;
						workoutData.LongDeltaRectNE = num4;
						workoutData.LongDeltaRectSW = num2;
					}
				}
				if (workoutData != null && bAddToDb)
				{
					await workoutData.StoreWorkout();
				}
				listWorkouts.Add(workoutData);
			}
		}
		catch (Exception ex)
		{
			TaskAwaiter<IUICommand> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<IUICommand>(new MessageDialog(ex.Message, "Error").ShowAsync());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<IUICommand> taskAwaiter2 = default(TaskAwaiter<IUICommand>);
				taskAwaiter = taskAwaiter2;
			}
			taskAwaiter.GetResult();
		}
		return listWorkouts;
	}

	public static async Task<WorkoutItem> GetWorkoutAsync(int workoutId)
	{
		await _workoutDataSource.GetWorkoutDataAsync();
		IEnumerable<WorkoutItem> source = _workoutDataSource.Workouts.Where((WorkoutItem workout) => workout.WorkoutId == workoutId);
		if (source.Count() > 0)
		{
			return source.First();
		}
		return null;
	}

	public static async Task UpdateWorkoutAsync(int workoutId, string strTitle, string strNotes)
	{
		await _workoutDataSource.GetWorkoutDataAsync();
		IEnumerable<WorkoutItem> source = _workoutDataSource.Workouts.Where((WorkoutItem workout) => workout.WorkoutId == workoutId);
		if (source.Count() > 0)
		{
			WorkoutItem workoutItem = source.First();
			workoutItem.Title = strTitle;
			workoutItem.Notes = strNotes;
		}
	}

	public static async Task<TrackItem> GetItemAsync(string uniqueId)
	{
		await _workoutDataSource.GetWorkoutDataAsync();
		IEnumerable<TrackItem> source = from item in _workoutDataSource.Workouts.SelectMany((WorkoutItem workout) => workout.Items)
			where item.UniqueId.Equals(uniqueId)
			select item;
		if (source.Count() == 1)
		{
			return source.First();
		}
		return null;
	}

	private async Task GetWorkoutDataAsync(bool bForceReload = false, WorkoutFilterData filterData = null)
	{
		if (bForceReload || Workouts.Count == 0)
		{
			if (bForceReload)
			{
				Workouts.Clear();
			}
			if (SensorLogEngine == null)
			{
				SensorLogEngine = new SensorLog();
			}
			Workouts = await WorkoutItem.ReadWorkouts(filterData);
		}
	}
}
