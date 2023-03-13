using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;
using MobileBandSync.Common;
using Windows.ApplicationModel.Resources;
using Windows.Globalization;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Popups;

namespace MobileBandSync.Data
{
	// Token: 0x02000079 RID: 121
	public sealed class WorkoutDataSource
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000BFBF File Offset: 0x0000A1BF
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000BFC7 File Offset: 0x0000A1C7
		public ObservableCollection<WorkoutItem> Workouts
		{
			get
			{
				return this._workouts;
			}
			set
			{
				this._workouts = value;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000BFD0 File Offset: 0x0000A1D0
		// (set) Token: 0x060003E9 RID: 1001 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
		public StorageFolder WorkoutsFolder { get; private set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000BFE1 File Offset: 0x0000A1E1
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x0000BFE9 File Offset: 0x0000A1E9
		public WorkoutFilterData CurrentFilter { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000BFF2 File Offset: 0x0000A1F2
		public static WorkoutDataSource DataSource
		{
			get
			{
				return WorkoutDataSource._workoutDataSource;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060003ED RID: 1005 RVA: 0x0000BFF9 File Offset: 0x0000A1F9
		// (set) Token: 0x060003EE RID: 1006 RVA: 0x0000C001 File Offset: 0x0000A201
		public StorageFolder DatabaseFolder { get; private set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000C00A File Offset: 0x0000A20A
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000C012 File Offset: 0x0000A212
		public SensorLog SensorLogEngine { get; private set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0000C01B File Offset: 0x0000A21B
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000C022 File Offset: 0x0000A222
		public static bool DbInitialized { get; private set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000C02A File Offset: 0x0000A22A
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0000C032 File Offset: 0x0000A232
		public StorageFolder WorkoutDbFolder { get; private set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000C03B File Offset: 0x0000A23B
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0000C043 File Offset: 0x0000A243
		public string MapServiceToken { get; set; }

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000C04C File Offset: 0x0000A24C
		public static string GetMapServiceToken()
		{
			return WorkoutDataSource._workoutDataSource.MapServiceToken;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000C058 File Offset: 0x0000A258
		public static ObservableCollection<WorkoutItem> GetWorkouts()
		{
			return WorkoutDataSource._workoutDataSource.Workouts;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000C064 File Offset: 0x0000A264
		public static void SetMapServiceToken(string strServiceToken)
		{
			WorkoutDataSource._workoutDataSource.MapServiceToken = strServiceToken;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000C071 File Offset: 0x0000A271
		public WorkoutDataSource()
		{
			SqliteEngine.UseWinSqlite3();
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000C08C File Offset: 0x0000A28C
		public static async Task<IEnumerable<WorkoutItem>> GetWorkoutsAsync(bool bForceReload = false, WorkoutFilterData workoutFilter = null)
		{
			try
			{
				if (!WorkoutDataSource.DbInitialized)
				{
					if (WorkoutDataSource._workoutDataSource == null)
					{
						WorkoutDataSource._workoutDataSource = new WorkoutDataSource();
					}
					WorkoutDataSource.DbInitialized = await WorkoutDataSource._workoutDataSource.InitDatabase(false);
				}
				await WorkoutDataSource._workoutDataSource.GetWorkoutDataAsync(bForceReload, workoutFilter);
			}
			catch (Exception)
			{
			}
			return WorkoutDataSource._workoutDataSource.Workouts;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000C0DC File Offset: 0x0000A2DC
		public static async Task<string> GetWorkoutSummaryAsync()
		{
			return WorkoutDataSource._workoutDataSource.Summary;
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000C058 File Offset: 0x0000A258
		public static ObservableCollection<WorkoutItem> WorkoutList
		{
			get
			{
				return WorkoutDataSource._workoutDataSource.Workouts;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x0000C119 File Offset: 0x0000A319
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x0000C121 File Offset: 0x0000A321
		public string Summary { get; set; }

		// Token: 0x06000400 RID: 1024 RVA: 0x0000C12C File Offset: 0x0000A32C
		public static async Task<List<WorkoutItem>> ImportFromSensorlog(StorageFolder sensorLogFolder, Action<string> Status, Action<ulong, ulong> Progress)
		{
			WorkoutDataSource._workoutDataSource.SensorLogEngine.Sequences.Clear();
			List<Workout> list = await WorkoutDataSource._workoutDataSource.ReadWorkoutsFromSensorLogs(sensorLogFolder);
			List<WorkoutItem> result;
			if (list != null && list.Count > 0)
			{
				int num = 0;
				foreach (Workout workout in list)
				{
					if (workout.TrackPoints != null)
					{
						num += workout.TrackPoints.Count;
					}
				}
				ulong num2 = WorkoutDataSource._workoutDataSource.SensorLogEngine.BufferSize / (ulong)((long)num);
				WorkoutDataSource._workoutDataSource.SensorLogEngine.StepLength = num2;
				result = await WorkoutDataSource._workoutDataSource.AddWorkouts(list, false, Status, Progress, num2);
			}
			else
			{
				result = new List<WorkoutItem>();
			}
			return result;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000C184 File Offset: 0x0000A384
		public static async Task<List<WorkoutItem>> ImportFromSensorlog(byte[] btSensorLog, Action<string> Status, Action<ulong, ulong> Progress)
		{
			if (!WorkoutDataSource.DbInitialized)
			{
				WorkoutDataSource.DbInitialized = await WorkoutDataSource._workoutDataSource.InitDatabase(false);
			}
			WorkoutDataSource._workoutDataSource.SensorLogEngine.Sequences.Clear();
			List<Workout> list = await WorkoutDataSource._workoutDataSource.ReadWorkoutsFromSensorLogBuffer(btSensorLog);
			List<WorkoutItem> result;
			if (list != null && list.Count > 0)
			{
				int num = 0;
				foreach (Workout workout in list)
				{
					if (workout.Type != EventType.Sleeping)
					{
						if (workout.TrackPoints != null)
						{
							num += workout.TrackPoints.Count;
						}
					}
					else if (workout.TrackPoints != null)
					{
						num += workout.TrackPoints.Count;
					}
				}
				ulong num2 = WorkoutDataSource._workoutDataSource.SensorLogEngine.BufferSize / (ulong)((long)num);
				WorkoutDataSource.DataSource.SensorLogEngine.StepLength = num2;
				result = await WorkoutDataSource._workoutDataSource.AddWorkouts(list, false, Status, Progress, num2);
			}
			else
			{
				result = new List<WorkoutItem>();
			}
			return result;
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000C1DC File Offset: 0x0000A3DC
		public async Task<bool> InitDatabase(bool bDeleteOldDb = false)
		{
			StorageFolder storageFolder = await KnownFolders.DocumentsLibrary.CreateFolderAsync("Workouts", 3);
			this.WorkoutsFolder = storageFolder;
			storageFolder = await KnownFolders.DocumentsLibrary.CreateFolderAsync("WorkoutDB", 3);
			this.WorkoutDbFolder = storageFolder;
			this.DatabaseFolder = ApplicationData.Current.LocalFolder;
			bool result;
			if (this.WorkoutsFolder == null || this.DatabaseFolder == null)
			{
				result = false;
			}
			else
			{
				int num = 0;
				try
				{
					UICommand yesCommand = new UICommand("Yes", delegate(IUICommand cmd)
					{
					});
					UICommand item = new UICommand("No", delegate(IUICommand cmd)
					{
					});
					MessageDialog dialog = new MessageDialog("Do you want to replace the DB with the newer one found in the WorkoutDb folder?", "Copy new database");
					dialog.put_Options(0);
					dialog.Commands.Add(yesCommand);
					dialog.Commands.Add(item);
					StorageFile oldDb = await this.DatabaseFolder.GetFileAsync("workouts.db");
					if (oldDb != null)
					{
						if (bDeleteOldDb)
						{
							await oldDb.DeleteAsync();
						}
						else
						{
							try
							{
								StorageFile databaseFile = await this.WorkoutDbFolder.GetFileAsync("workouts.db");
								if (databaseFile != null)
								{
									BasicProperties oldProp = await oldDb.GetBasicPropertiesAsync();
									if ((await databaseFile.GetBasicPropertiesAsync()).DateModified > oldProp.DateModified && await dialog.ShowAsync() == yesCommand)
									{
										await oldDb.DeleteAsync();
										await databaseFile.CopyAsync(this.DatabaseFolder);
									}
									oldProp = null;
								}
								databaseFile = null;
							}
							catch
							{
							}
						}
						return true;
					}
					yesCommand = null;
					dialog = null;
					oldDb = null;
				}
				catch
				{
					num = 1;
				}
				if (num == 1)
				{
					try
					{
						StorageFile storageFile = await this.WorkoutDbFolder.GetFileAsync("workouts.db");
						if (storageFile != null && !bDeleteOldDb)
						{
							await storageFile.CopyAsync(this.DatabaseFolder);
							return true;
						}
					}
					catch
					{
					}
				}
				await this.DatabaseFolder.CreateFileAsync("workouts.db", 3);
				string text = Path.Combine(new string[]
				{
					this.DatabaseFolder.Path,
					"workouts.db"
				});
				using (SqliteConnection db = new SqliteConnection(string.Format("Filename={0}", new object[]
				{
					text
				})))
				{
					num = 0;
					try
					{
						await db.OpenAsync();
						await new SqliteCommand("CREATE TABLE IF NOT EXISTS Tracks (TrackId INTEGER PRIMARY KEY AUTOINCREMENT, WorkoutId INTEGER NOT NULL, SecFromStart INT, LongDelta INT, LatDelta INT, Elevation INT, Heartrate TINYINT, Barometer INT, Cadence TINYINT, SkinTemp TINYINT, GSR INT, UVExposure INT )", db).ExecuteReaderAsync();
						await new SqliteCommand("CREATE TABLE IF NOT EXISTS Sleep (SleepId INTEGER PRIMARY KEY AUTOINCREMENT, SleepActivityId INTEGER NOT NULL, SecFromStart INT, SegmentType TINYINT, SleepType TINYINT, Heartrate TINYINT )", db).ExecuteReaderAsync();
						await new SqliteCommand("CREATE TABLE IF NOT EXISTS Workouts (WorkoutId INTEGER PRIMARY KEY AUTOINCREMENT, WorkoutType TINYINT, Title NVARCHAR(128) NULL, Notes NVARCHAR(2048) NULL, Start DATETIME, End DATETIME, AvgHR TINYINT, MaxHR TINYINT, Calories INT, AvgSpeed INT, MaxSpeed INT, DurationSec INT, LongitudeStart INT8, LatitudeStart INT8, DistanceMeters INT8, LongDeltaRectSW INT, LatDeltaRectSW INT, LongDeltaRectNE INT, LatDeltaRectNE INT )", db).ExecuteReaderAsync();
					}
					catch (Exception obj)
					{
						num = 1;
					}
					object obj;
					if (num == 1)
					{
						await new MessageDialog(((Exception)obj).Message, "Error").ShowAsync();
					}
					obj = null;
				}
				SqliteConnection db = null;
				result = true;
			}
			return result;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000C22C File Offset: 0x0000A42C
		public static async Task<List<long>> StoreWorkouts(List<WorkoutItem> workouts, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0UL)
		{
			List<long> listResult = new List<long>();
			string text = Path.Combine(new string[]
			{
				ApplicationData.Current.LocalFolder.Path,
				"workouts.db"
			});
			using (SqliteConnection db = new SqliteConnection(string.Format("Filename={0}", new object[]
			{
				text
			})))
			{
				await db.OpenAsync();
				foreach (WorkoutItem workoutItem in workouts)
				{
					if (workoutItem.Items.Count > 0)
					{
						List<long> list = listResult;
						list.Add(await workoutItem.StoreWorkout(db, Progress, ulStepLength));
						list = null;
					}
				}
				List<WorkoutItem>.Enumerator enumerator = default(List<WorkoutItem>.Enumerator);
			}
			SqliteConnection db = null;
			return listResult;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000C284 File Offset: 0x0000A484
		public static async Task<bool> BackupDatabase(StorageFolder targetFolder = null)
		{
			bool bResult = false;
			StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("workouts.db");
			StorageFile database = storageFile;
			if (database != null)
			{
				if (targetFolder == null)
				{
					targetFolder = await KnownFolders.DocumentsLibrary.CreateFolderAsync("WorkoutDB", 3);
				}
				storageFile = await database.CopyAsync(targetFolder, database.Name, 1);
				bResult = (storageFile != null);
			}
			return bResult;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000C2CC File Offset: 0x0000A4CC
		public async Task<List<Workout>> ReadWorkoutsFromSensorLogBuffer(byte[] btSensorLog)
		{
			List<Workout> result;
			if (this.SensorLogEngine == null || btSensorLog == null)
			{
				result = null;
			}
			else
			{
				try
				{
					using (MemoryStream memStream = new MemoryStream(btSensorLog))
					{
						this.SensorLogEngine.BufferSize = (ulong)((long)btSensorLog.Length);
						await this.SensorLogEngine.Read(memStream);
					}
					MemoryStream memStream = null;
				}
				catch (Exception)
				{
				}
				try
				{
					if (this.SensorLogEngine.Sequences.Count > 0)
					{
						return await this.SensorLogEngine.CreateWorkouts((ExportType)120);
					}
				}
				catch (Exception)
				{
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000C31C File Offset: 0x0000A51C
		public async Task<List<Workout>> ReadWorkoutsFromSensorLogs(StorageFolder SensorLogFolder)
		{
			List<Workout> result;
			if (this.SensorLogEngine == null || SensorLogFolder == null)
			{
				result = null;
			}
			else
			{
				string path = SensorLogFolder.Path;
				string strTempDir = path;
				this.SensorLogEngine.BufferSize = 0UL;
				try
				{
					Dictionary<DateTime, string> dictFiles = new Dictionary<DateTime, string>();
					IReadOnlyList<StorageFile> readOnlyList = await SensorLogFolder.GetFilesAsync();
					foreach (StorageFile file in readOnlyList)
					{
						BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
						this.SensorLogEngine.BufferSize += basicProperties.Size;
						string text = file.Path.Substring(strTempDir.Length + 1);
						int.Parse(text.Substring(text.Length - 12, 3));
						int second = int.Parse(text.Substring(text.Length - 14, 2));
						int minute = int.Parse(text.Substring(text.Length - 16, 2));
						int hour = int.Parse(text.Substring(text.Length - 18, 2));
						int day = int.Parse(text.Substring(text.Length - 20, 2));
						int month = int.Parse(text.Substring(text.Length - 22, 2));
						DateTime key = new DateTime(int.Parse(text.Substring(text.Length - 24, 2)), month, day, hour, minute, second);
						dictFiles.Add(key, text);
						file = null;
					}
					IEnumerator<StorageFile> enumerator = null;
					IOrderedEnumerable<DateTime> orderedEnumerable = from d in dictFiles.Keys
					orderby d
					select d;
					foreach (DateTime key2 in orderedEnumerable)
					{
						using (Stream fileStream = await SensorLogFolder.OpenStreamForReadAsync(dictFiles[key2]))
						{
							await this.SensorLogEngine.Read(fileStream);
						}
						Stream fileStream = null;
					}
					IEnumerator<DateTime> enumerator2 = null;
					dictFiles = null;
				}
				catch (Exception)
				{
				}
				try
				{
					if (this.SensorLogEngine.Sequences.Count > 0)
					{
						return await this.SensorLogEngine.CreateWorkouts((ExportType)120);
					}
				}
				catch (Exception)
				{
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000C36C File Offset: 0x0000A56C
		public async Task<List<WorkoutItem>> AddWorkouts(List<Workout> Workouts, bool bAddToDb = false, Action<string> Status = null, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0UL)
		{
			List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
			int count = Workouts.Count;
			ExportType type = (ExportType)120;
			int num = 0;
			int num6;
			try
			{
				string dbpath = Path.Combine(new string[]
				{
					ApplicationData.Current.LocalFolder.Path,
					"workouts.db"
				});
				ResourceLoader resourceLoader = ResourceLoader.GetForViewIndependentUse();
				int iIndex = 0;
				foreach (Workout workout in Workouts)
				{
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					WorkoutItem workoutItem = new WorkoutItem();
					workoutItem.WorkoutType = (byte)workout.Type;
					workoutItem.LongDeltaRectSW = 0;
					workoutItem.LatDeltaRectSW = 0;
					workoutItem.LongDeltaRectNE = 0;
					workoutItem.LatDeltaRectNE = 0;
					workoutItem.Items = new ObservableCollection<TrackItem>();
					workoutItem.DbPath = dbpath;
					workoutItem.Parent = WorkoutDataSource.WorkoutList;
					num6 = iIndex;
					iIndex = num6 + 1;
					workoutItem.Index = num6;
					WorkoutItem workoutData = workoutItem;
					if ((workout.Type == EventType.Running || workout.Type == EventType.Hike || workout.Type == EventType.Walking || workout.Type == EventType.Sleeping || workout.Type == EventType.Biking) && workout.TrackPoints.Count > 0)
					{
						ExportType exportType = type;
						EventType type2 = workout.Type;
						if (type2 <= EventType.Biking)
						{
							if (type2 == EventType.Running)
							{
								goto IL_18D;
							}
							if (type2 != EventType.Biking)
							{
								goto IL_19F;
							}
							exportType &= (ExportType)104;
						}
						else
						{
							if (type2 == EventType.Walking || type2 == EventType.Hike)
							{
								goto IL_18D;
							}
							goto IL_19F;
						}
						IL_1A6:
						workoutData.Start = workout.StartTime;
						workoutData.End = workout.EndTime;
						workoutData.Notes = workout.Notes;
						workoutData.WorkoutType = (byte)workout.Type;
						if (workout.Type == EventType.Sleeping)
						{
							if (workout.SleepSummary != null)
							{
								workoutData.Title = string.Concat(new string[]
								{
									workout.StartTime.ToString(WorkoutDataSource.AppCultureInfo),
									" ",
									resourceLoader.GetString("WorkoutSleep"),
									" ",
									workout.SleepSummary.Duration.ToString("hh\\:mm")
								});
								workoutData.AvgHR = (byte)workout.SleepSummary.HFAverage;
								workoutData.MaxHR = (byte)workout.SleepSummary.HFMax;
								workoutData.Calories = workout.SleepSummary.CaloriesBurned;
								workoutData.FallAsleepDuration = workout.SleepSummary.FallAsleepTime;
								workoutData.AwakeDuration = workout.SleepSummary.Duration - workout.SleepSummary.TotalRestfulSleepDuration - workout.SleepSummary.TotalRestlessSleepDuration;
								workoutData.DurationSec = workout.SleepSummary.Duration.Milliseconds / 1000;
								workoutData.NumberOfWakeups = (int)workout.SleepSummary.TimesAwoke;
								workoutData.TotalRestfulSleepDuration = workout.SleepSummary.TotalRestfulSleepDuration;
								workoutData.SleepEfficiencyPercentage = (int)Math.Ceiling((double)((float)(workout.SleepSummary.Duration.Milliseconds * 100 / workout.SleepSummary.TotalRestfulSleepDuration.Milliseconds)));
								workoutData.TotalRestlessSleepDuration = workout.SleepSummary.TotalRestlessSleepDuration;
								workoutData.SleepDuration = workout.SleepSummary.Duration;
								workoutData.Feeling = workout.SleepSummary.Feeling;
							}
							else
							{
								workoutData.Title = workout.StartTime.ToString(WorkoutDataSource.AppCultureInfo) + " " + resourceLoader.GetString("WorkoutUnknown");
							}
							using (List<WorkoutPoint>.Enumerator enumerator2 = workout.TrackPoints.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									WorkoutPoint workoutPoint = enumerator2.Current;
									TrackItem trackItem = new TrackItem
									{
										WorkoutId = workoutData.WorkoutId,
										LatDelta = 0,
										LongDelta = 0
									};
									trackItem.SecFromStart = (int)(workoutPoint.Time - workoutData.Start).TotalSeconds;
									trackItem.Heartrate = (byte)workoutPoint.HeartRateBpm;
									trackItem.Elevation = (int)workoutPoint.Elevation;
									trackItem.Cadence = workoutPoint.Cadence;
									trackItem.GSR = (int)workoutPoint.GalvanicSkinResponse;
									trackItem.SkinTemp = workoutPoint.SkinTemperature;
									trackItem.Barometer = 0;
									workoutData.Items.Add(trackItem);
								}
								goto IL_A76;
							}
						}
						if (workout.Summary != null)
						{
							string @string;
							if (workout.Type == EventType.Biking)
							{
								@string = resourceLoader.GetString("WorkoutBiking");
							}
							else if (workout.Type == EventType.Hike)
							{
								@string = resourceLoader.GetString("WorkoutHiking");
							}
							else if (workout.Summary.HFAverage <= 120)
							{
								workoutData.WorkoutType = 16;
								@string = resourceLoader.GetString("WorkoutWalking");
							}
							else if (workout.Summary.HFAverage < 140)
							{
								@string = resourceLoader.GetString("WorkoutWarmup");
							}
							else if (workout.Summary.HFAverage < 145)
							{
								@string = resourceLoader.GetString("WorkoutLight");
							}
							else if (workout.Summary.HFAverage < 151)
							{
								@string = resourceLoader.GetString("WorkoutModerate");
							}
							else if (workout.Summary.HFAverage < 160)
							{
								@string = resourceLoader.GetString("WorkoutHard");
							}
							else
							{
								@string = resourceLoader.GetString("WorkoutMaximum");
							}
							double num7 = workout.Summary.Distance / workout.Summary.Duration;
							double num8 = 1000.0 / num7 / 60.0;
							double num9 = num8 % 1.0;
							double num10 = 0.6 * num9;
							num8 -= num9;
							num8 += num10;
							workoutData.AvgSpeed = (int)Math.Ceiling(num8 * 1000.0);
							workoutData.MaxSpeed = (int)workout.Summary.MaximumSpeed;
							workoutData.Calories = workout.Summary.CaloriesBurned;
							workoutData.DurationSec = (int)workout.Summary.Duration;
							workoutData.AvgHR = (byte)workout.Summary.HFAverage;
							workoutData.MaxHR = (byte)workout.Summary.HFMax;
							workoutData.DistanceMeters = (long)workout.Summary.Distance;
							workoutData.Title = string.Concat(new string[]
							{
								workout.StartTime.ToString(WorkoutDataSource.AppCultureInfo),
								" ",
								@string,
								" ",
								((double)workoutData.DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo),
								" km ",
								num8.ToString("F2", WorkoutDataSource.AppCultureInfo),
								" min/km ",
								workoutData.AvgHR.ToString("F0"),
								" bpm"
							});
							if (workoutData.Notes == null || workoutData.Notes.Length == 0)
							{
								workoutData.Notes = "Sensor log import " + DateTime.Now.ToString(WorkoutDataSource.AppCultureInfo);
							}
						}
						else
						{
							workoutData.Title = workout.StartTime.ToString(WorkoutDataSource.AppCultureInfo) + " Workout";
						}
						foreach (WorkoutPoint workoutPoint2 in workout.TrackPoints)
						{
							TrackItem trackItem2 = new TrackItem
							{
								WorkoutId = workoutData.WorkoutId
							};
							trackItem2.SecFromStart = (int)(workoutPoint2.Time - workoutData.Start).TotalSeconds;
							trackItem2.Heartrate = (byte)workoutPoint2.HeartRateBpm;
							trackItem2.Elevation = (int)workoutPoint2.Elevation;
							trackItem2.Cadence = (uint)((byte)workoutPoint2.Cadence);
							trackItem2.GSR = (int)workoutPoint2.GalvanicSkinResponse;
							trackItem2.SkinTemp = workoutPoint2.SkinTemperature;
							trackItem2.Barometer = 0;
							if (workoutData.LongitudeStart == 0L)
							{
								workoutData.LongitudeStart = (long)(workoutPoint2.Position.LongitudeDegrees * 10000000.0);
								trackItem2.LongDelta = 0;
							}
							else
							{
								trackItem2.LongDelta = (int)(workoutPoint2.Position.LongitudeDegrees * 10000000.0 - (double)workoutData.LongitudeStart);
							}
							if (workoutData.LatitudeStart == 0L)
							{
								workoutData.LatitudeStart = (long)(workoutPoint2.Position.LatitudeDegrees * 10000000.0);
								trackItem2.LatDelta = 0;
							}
							else
							{
								trackItem2.LatDelta = (int)(workoutPoint2.Position.LatitudeDegrees * 10000000.0 - (double)workoutData.LatitudeStart);
							}
							workoutData.Items.Add(trackItem2);
							num2 = Math.Min(num2, trackItem2.LatDelta);
							num3 = Math.Min(num3, trackItem2.LongDelta);
							num4 = Math.Max(num4, trackItem2.LatDelta);
							num5 = Math.Max(num5, trackItem2.LongDelta);
						}
						workoutData.LatDeltaRectNE = num4;
						workoutData.LatDeltaRectSW = num2;
						workoutData.LongDeltaRectNE = num5;
						workoutData.LongDeltaRectSW = num3;
						goto IL_A76;
						IL_18D:
						exportType &= (ExportType)120;
						goto IL_1A6;
						IL_19F:
						exportType &= (ExportType)40;
						goto IL_1A6;
					}
					IL_A76:
					if (workoutData != null && bAddToDb)
					{
						await workoutData.StoreWorkout();
					}
					listWorkouts.Add(workoutData);
					workoutData = null;
				}
				List<Workout>.Enumerator enumerator = default(List<Workout>.Enumerator);
				dbpath = null;
				resourceLoader = null;
			}
			catch (Exception obj)
			{
				num = 1;
			}
			num6 = num;
			object obj;
			if (num6 == 1)
			{
				await new MessageDialog(((Exception)obj).Message, "Error").ShowAsync();
			}
			obj = null;
			return listWorkouts;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000C3BC File Offset: 0x0000A5BC
		public static async Task<WorkoutItem> GetWorkoutAsync(int workoutId)
		{
			await WorkoutDataSource._workoutDataSource.GetWorkoutDataAsync(false, null);
			IEnumerable<WorkoutItem> source = from workout in WorkoutDataSource._workoutDataSource.Workouts
			where workout.WorkoutId == workoutId
			select workout;
			WorkoutItem result;
			if (source.Count<WorkoutItem>() > 0)
			{
				result = source.First<WorkoutItem>();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000C404 File Offset: 0x0000A604
		public static async Task UpdateWorkoutAsync(int workoutId, string strTitle, string strNotes)
		{
			await WorkoutDataSource._workoutDataSource.GetWorkoutDataAsync(false, null);
			IEnumerable<WorkoutItem> source = from workout in WorkoutDataSource._workoutDataSource.Workouts
			where workout.WorkoutId == workoutId
			select workout;
			if (source.Count<WorkoutItem>() > 0)
			{
				WorkoutItem workoutItem = source.First<WorkoutItem>();
				workoutItem.Title = strTitle;
				workoutItem.Notes = strNotes;
			}
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000C45C File Offset: 0x0000A65C
		public static async Task<TrackItem> GetItemAsync(string uniqueId)
		{
			await WorkoutDataSource._workoutDataSource.GetWorkoutDataAsync(false, null);
			IEnumerable<TrackItem> source = from item in WorkoutDataSource._workoutDataSource.Workouts.SelectMany((WorkoutItem workout) => workout.Items)
			where item.UniqueId.Equals(uniqueId)
			select item;
			TrackItem result;
			if (source.Count<TrackItem>() == 1)
			{
				result = source.First<TrackItem>();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000C4A4 File Offset: 0x0000A6A4
		private async Task GetWorkoutDataAsync(bool bForceReload = false, WorkoutFilterData filterData = null)
		{
			if (bForceReload || this.Workouts.Count == 0)
			{
				if (bForceReload)
				{
					this.Workouts.Clear();
				}
				if (this.SensorLogEngine == null)
				{
					this.SensorLogEngine = new SensorLog();
				}
				ObservableCollection<WorkoutItem> workouts = await WorkoutItem.ReadWorkouts(filterData);
				this.Workouts = workouts;
			}
		}

		// Token: 0x040002DF RID: 735
		public const bool _offlineTest = false;

		// Token: 0x040002E0 RID: 736
		public static CultureInfo AppCultureInfo = new CultureInfo(Language.CurrentInputMethodLanguageTag);

		// Token: 0x040002E1 RID: 737
		public static string BandName = "MS Band 2";

		// Token: 0x040002E2 RID: 738
		private const string WorkoutDbName = "workouts.db";

		// Token: 0x040002E3 RID: 739
		private const string WorkoutFolderName = "Workouts";

		// Token: 0x040002E4 RID: 740
		private const string WorkoutDbFolderName = "WorkoutDB";

		// Token: 0x040002E5 RID: 741
		private static WorkoutDataSource _workoutDataSource = new WorkoutDataSource();

		// Token: 0x040002E6 RID: 742
		public ulong TotalDistance;

		// Token: 0x040002E7 RID: 743
		public ulong NumHRWorkouts;

		// Token: 0x040002E8 RID: 744
		public ulong TotalHR;

		// Token: 0x040002E9 RID: 745
		public ulong TotalAvgSpeed;

		// Token: 0x040002EA RID: 746
		private ObservableCollection<WorkoutItem> _workouts = new ObservableCollection<WorkoutItem>();
	}
}
