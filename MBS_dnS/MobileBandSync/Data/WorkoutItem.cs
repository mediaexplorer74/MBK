using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace MobileBandSync.Data
{
	// Token: 0x0200007B RID: 123
	public class WorkoutItem
	{
		// Token: 0x06000414 RID: 1044 RVA: 0x0000C554 File Offset: 0x0000A754
		public WorkoutItem(string uniqueId, string title, string subtitle, string imagePath, string description)
		{
			this.Title = title;
			this.Description = description;
			this.ImagePath = imagePath;
			this.Items = new ObservableCollection<TrackItem>();
			this.HeartRateChart = new ObservableCollection<DiagramData>();
			this.ElevationChart = new ObservableCollection<DiagramData>();
			this.CadenceNormChart = new ObservableCollection<DiagramData>();
			this.SpeedChart = new ObservableCollection<DiagramData>();
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0000C5B5 File Offset: 0x0000A7B5
		public WorkoutItem()
		{
			this.HeartRateChart = new ObservableCollection<DiagramData>();
			this.ElevationChart = new ObservableCollection<DiagramData>();
			this.CadenceNormChart = new ObservableCollection<DiagramData>();
			this.SpeedChart = new ObservableCollection<DiagramData>();
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x0000C5EC File Offset: 0x0000A7EC
		public string UniqueId
		{
			get
			{
				return Guid.NewGuid().ToString("B");
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000C60B File Offset: 0x0000A80B
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000C613 File Offset: 0x0000A813
		public string Subtitle
		{
			get
			{
				return this.Notes;
			}
			set
			{
				this.Modified = (this.Notes != value);
				this.Notes = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000C62E File Offset: 0x0000A82E
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000C636 File Offset: 0x0000A836
		public string Description { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000C63F File Offset: 0x0000A83F
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x0000C647 File Offset: 0x0000A847
		public string ImagePath { get; private set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000C650 File Offset: 0x0000A850
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x0000C658 File Offset: 0x0000A858
		public ObservableCollection<TrackItem> Items { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000C661 File Offset: 0x0000A861
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x0000C669 File Offset: 0x0000A869
		public ObservableCollection<SleepItem> SleepItems { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000C672 File Offset: 0x0000A872
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x0000C67A File Offset: 0x0000A87A
		public int WorkoutId { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000C683 File Offset: 0x0000A883
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x0000C68B File Offset: 0x0000A88B
		public byte WorkoutType { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000C694 File Offset: 0x0000A894
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x0000C69C File Offset: 0x0000A89C
		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this.Modified = (this._title != value);
				this._title = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000C6B7 File Offset: 0x0000A8B7
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0000C6BF File Offset: 0x0000A8BF
		public string Notes { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0000C6D0 File Offset: 0x0000A8D0
		public DateTime Start { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000C6D9 File Offset: 0x0000A8D9
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x0000C6E1 File Offset: 0x0000A8E1
		public DateTime End { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0000C6EA File Offset: 0x0000A8EA
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x0000C6F2 File Offset: 0x0000A8F2
		public byte AvgHR { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000C6FB File Offset: 0x0000A8FB
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x0000C703 File Offset: 0x0000A903
		public byte MaxHR { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000C70C File Offset: 0x0000A90C
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0000C714 File Offset: 0x0000A914
		public int Calories { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000C71D File Offset: 0x0000A91D
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000C725 File Offset: 0x0000A925
		public int AvgSpeed { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000C72E File Offset: 0x0000A92E
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000C736 File Offset: 0x0000A936
		public int MaxSpeed { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000C73F File Offset: 0x0000A93F
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000C747 File Offset: 0x0000A947
		public int DurationSec { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000C750 File Offset: 0x0000A950
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000C758 File Offset: 0x0000A958
		public long DistanceMeters { get; set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0000C761 File Offset: 0x0000A961
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x0000C769 File Offset: 0x0000A969
		public long LongitudeStart { get; set; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x0000C772 File Offset: 0x0000A972
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0000C77A File Offset: 0x0000A97A
		public long LatitudeStart { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000C783 File Offset: 0x0000A983
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000C78B File Offset: 0x0000A98B
		public int LongDeltaRectSW { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000C794 File Offset: 0x0000A994
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000C79C File Offset: 0x0000A99C
		public int LatDeltaRectSW { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000C7A5 File Offset: 0x0000A9A5
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x0000C7AD File Offset: 0x0000A9AD
		public int LongDeltaRectNE { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000C7B6 File Offset: 0x0000A9B6
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0000C7BE File Offset: 0x0000A9BE
		public int LatDeltaRectNE { get; set; }

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000C7C7 File Offset: 0x0000A9C7
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x0000C7CF File Offset: 0x0000A9CF
		public string DbPath { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000C7D8 File Offset: 0x0000A9D8
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
		public string FilenameTCX { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000C7E9 File Offset: 0x0000A9E9
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0000C7F1 File Offset: 0x0000A9F1
		public string TCXBuffer { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000C7FA File Offset: 0x0000A9FA
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000C802 File Offset: 0x0000AA02
		public int Index { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000C80B File Offset: 0x0000AA0B
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000C81B File Offset: 0x0000AA1B
		public TimeSpan AwakeDuration
		{
			get
			{
				return new TimeSpan(0, 0, 0, this.AvgSpeed);
			}
			set
			{
				this.AvgSpeed = (int)value.TotalSeconds;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000C82B File Offset: 0x0000AA2B
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000C83B File Offset: 0x0000AA3B
		public TimeSpan SleepDuration
		{
			get
			{
				return new TimeSpan(0, 0, 0, this.MaxSpeed);
			}
			set
			{
				this.MaxSpeed = (int)value.TotalSeconds;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000C84B File Offset: 0x0000AA4B
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0000C853 File Offset: 0x0000AA53
		public int NumberOfWakeups
		{
			get
			{
				return this.DurationSec;
			}
			set
			{
				this.DurationSec = value;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0000C85C File Offset: 0x0000AA5C
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x0000C86D File Offset: 0x0000AA6D
		public TimeSpan FallAsleepDuration
		{
			get
			{
				return new TimeSpan(0, 0, 0, (int)this.DistanceMeters);
			}
			set
			{
				this.DistanceMeters = (long)value.TotalSeconds;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0000C87D File Offset: 0x0000AA7D
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x0000C885 File Offset: 0x0000AA85
		public int SleepEfficiencyPercentage
		{
			get
			{
				return this.LongDeltaRectSW;
			}
			set
			{
				this.LongDeltaRectSW = value;
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000C88E File Offset: 0x0000AA8E
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000C89E File Offset: 0x0000AA9E
		public TimeSpan TotalRestlessSleepDuration
		{
			get
			{
				return new TimeSpan(0, 0, 0, this.LatDeltaRectSW);
			}
			set
			{
				this.LatDeltaRectSW = (int)value.TotalSeconds;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000C8AE File Offset: 0x0000AAAE
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x0000C8BE File Offset: 0x0000AABE
		public TimeSpan TotalRestfulSleepDuration
		{
			get
			{
				return new TimeSpan(0, 0, 0, this.LongDeltaRectNE);
			}
			set
			{
				this.LongDeltaRectNE = (int)value.TotalSeconds;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000C8CE File Offset: 0x0000AACE
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x0000C8D6 File Offset: 0x0000AAD6
		public uint Feeling
		{
			get
			{
				return (uint)this.LatDeltaRectNE;
			}
			set
			{
				this.LatDeltaRectNE = (int)value;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000C8E0 File Offset: 0x0000AAE0
		public string WorkoutImageSource
		{
			get
			{
				EventType workoutType = (EventType)this.WorkoutType;
				if (workoutType <= EventType.Biking)
				{
					if (workoutType == EventType.Running)
					{
						return "Resources/running.png";
					}
					if (workoutType == EventType.Biking)
					{
						return "Resources/biking.png";
					}
				}
				else
				{
					if (workoutType == EventType.Walking)
					{
						return "Resources/walking.png";
					}
					if (workoutType == EventType.Sleeping)
					{
						return "Resources/sleep.png";
					}
				}
				return "Resources/walking.png";
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000C92C File Offset: 0x0000AB2C
		public Visibility DownVisibility
		{
			get
			{
				if (this.Parent != null && this.Parent.Count > 0)
				{
					for (int i = this.Index; i > 0; i--)
					{
						if ((this.WorkoutType == 21 && this.Parent[i - 1].WorkoutType == 21) || (this.WorkoutType != 21 && this.Parent[i - 1].WorkoutType != 21))
						{
							return 0;
						}
					}
				}
				return 1;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000C9A8 File Offset: 0x0000ABA8
		public Visibility UpVisibility
		{
			get
			{
				if (this.Parent != null && this.Parent.Count > 0)
				{
					for (int i = this.Index; i < this.Parent.Count - 1; i++)
					{
						if ((this.WorkoutType == 21 && this.Parent[i + 1].WorkoutType == 21) || (this.WorkoutType != 21 && this.Parent[i + 1].WorkoutType != 21))
						{
							return 0;
						}
					}
				}
				return 1;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000462 RID: 1122 RVA: 0x0000CA2D File Offset: 0x0000AC2D
		// (remove) Token: 0x06000463 RID: 1123 RVA: 0x0000CA49 File Offset: 0x0000AC49
		public event EventHandler<TracksLoadedEventArgs> TracksLoaded
		{
			add
			{
				if (this.m_currentWorkout == null)
				{
					EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>>.GetOrCreateEventRegistrationTokenTable(ref this.m_currentWorkout).AddEventHandler(value);
				}
			}
			remove
			{
				EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>>.GetOrCreateEventRegistrationTokenTable(ref this.m_currentWorkout).RemoveEventHandler(value);
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000CA5C File Offset: 0x0000AC5C
		internal void OnTracksLoaded(WorkoutItem workout)
		{
			EventHandler<TracksLoadedEventArgs> invocationList = EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>>.GetOrCreateEventRegistrationTokenTable(ref this.m_currentWorkout).InvocationList;
			if (invocationList != null)
			{
				invocationList(this, new TracksLoadedEventArgs(workout));
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000CA8C File Offset: 0x0000AC8C
		public WorkoutItem GetPrevSibling()
		{
			if (this.Parent != null && this.Parent.Count > 0)
			{
				for (int i = this.Index; i > 0; i--)
				{
					if ((this.WorkoutType == 21 && this.Parent[i - 1].WorkoutType == 21) || (this.WorkoutType != 21 && this.Parent[i - 1].WorkoutType != 21))
					{
						return this.Parent[i - 1];
					}
				}
			}
			return null;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000CB14 File Offset: 0x0000AD14
		public WorkoutItem GetNextSibling()
		{
			if (this.Parent != null && this.Parent.Count > 0)
			{
				for (int i = this.Index; i < this.Parent.Count - 1; i++)
				{
					if ((this.WorkoutType == 21 && this.Parent[i + 1].WorkoutType == 21) || (this.WorkoutType != 21 && this.Parent[i + 1].WorkoutType != 21))
					{
						return this.Parent[i + 1];
					}
				}
			}
			return null;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x0000CBA6 File Offset: 0x0000ADA6
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x0000CBAE File Offset: 0x0000ADAE
		public ObservableCollection<WorkoutItem> Parent { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x0000CBB7 File Offset: 0x0000ADB7
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x0000CBBF File Offset: 0x0000ADBF
		public ObservableCollection<DiagramData> HeartRateChart { get; private set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x0000CBC8 File Offset: 0x0000ADC8
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
		public ObservableCollection<DiagramData> ElevationChart { get; private set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x0000CBD9 File Offset: 0x0000ADD9
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x0000CBE1 File Offset: 0x0000ADE1
		public ObservableCollection<DiagramData> CadenceNormChart { get; private set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x0000CBEA File Offset: 0x0000ADEA
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x0000CBF2 File Offset: 0x0000ADF2
		public ObservableCollection<DiagramData> SpeedChart { get; private set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x0000CBFB File Offset: 0x0000ADFB
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x0000CC03 File Offset: 0x0000AE03
		public bool Modified { get; set; }

		// Token: 0x06000473 RID: 1139 RVA: 0x0000CC0C File Offset: 0x0000AE0C
		public override string ToString()
		{
			return this.Title;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0000CC14 File Offset: 0x0000AE14
		public async Task<bool> StoreWorkout()
		{
			bool result = false;
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
				result = (await this.StoreWorkout(db, null, 0UL) != -1L);
			}
			SqliteConnection db = null;
			return result;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public async Task CopyToExternal(string tcxFile)
		{
			try
			{
				string targetFile = tcxFile.Substring(tcxFile.LastIndexOf('\\') + 1);
				StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(tcxFile.Remove(tcxFile.LastIndexOf('\\')));
				StorageFolder targetPath = storageFolder;
				await(await ApplicationData.Current.LocalFolder.GetFileAsync(targetFile)).CopyAsync(targetPath, targetFile, 1);
				targetFile = null;
				targetPath = null;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000CCA4 File Offset: 0x0000AEA4
		public async Task<bool> ExportWorkout(StorageFile tcxFile)
		{
			bool bResult = false;
			if (tcxFile != null)
			{
				int num = 0;
				try
				{
					StorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(tcxFile.Name, 1);
					StorageFile createFile = storageFile;
					this.TCXBuffer = this.GenerateTcxBuffer();
					await FileIO.WriteTextAsync(createFile, this.TCXBuffer);
					bResult = (this.TCXBuffer.Length > 0);
					await this.CopyToExternal(tcxFile.Path);
					await createFile.DeleteAsync();
					createFile = null;
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
			return bResult;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		public async Task UpdateWorkout()
		{
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
				SqliteCommand sqliteCommand = new SqliteCommand();
				sqliteCommand.Connection = db;
				sqliteCommand.CommandText = "UPDATE Workouts SET Title=@Title, Notes=@Notes WHERE WorkoutId=@WorkoutId";
				sqliteCommand.Parameters.AddWithValue("@WorkoutId", this.WorkoutId);
				sqliteCommand.Parameters.AddWithValue("@Title", this.Title);
				sqliteCommand.Parameters.AddWithValue("@Notes", this.Notes);
				await sqliteCommand.ExecuteReaderAsync();
			}
			SqliteConnection db = null;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000CD3C File Offset: 0x0000AF3C
		public async Task<long> StoreWorkout(SqliteConnection dbParam, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0UL)
		{
			WorkoutItem.<>c__DisplayClass181_0 CS$<>8__locals1 = new WorkoutItem.<>c__DisplayClass181_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.dbParam = dbParam;
			CS$<>8__locals1.lResult = -1L;
			if (CS$<>8__locals1.dbParam != null)
			{
				WorkoutItem.<>c__DisplayClass181_1 CS$<>8__locals2 = new WorkoutItem.<>c__DisplayClass181_1();
				CS$<>8__locals2.CS$<>8__locals1 = CS$<>8__locals1;
				CS$<>8__locals2.lastId = 0L;
				await Task.Run(delegate()
				{
					SqliteCommand sqliteCommand = new SqliteCommand();
					sqliteCommand.Connection = CS$<>8__locals2.CS$<>8__locals1.dbParam;
					sqliteCommand.CommandText = "INSERT INTO Workouts VALUES (NULL, @WorkoutType, @Title, @Notes, @Start, @End, @AvgHR, @MaxHR, @Calories, @AvgSpeed, @MaxSpeed, @DurationSec, @LongitudeStart, @LatitudeStart, @DistanceMeters, @LongDeltaRectSW, @LatDeltaRectSW, @LongDeltaRectNE, @LatDeltaRectNE);";
					sqliteCommand.Parameters.AddWithValue("@WorkoutType", CS$<>8__locals2.CS$<>8__locals1.<>4__this.WorkoutType);
					sqliteCommand.Parameters.AddWithValue("@Title", CS$<>8__locals2.CS$<>8__locals1.<>4__this.Title);
					sqliteCommand.Parameters.AddWithValue("@Notes", CS$<>8__locals2.CS$<>8__locals1.<>4__this.Notes);
					sqliteCommand.Parameters.AddWithValue("@Start", CS$<>8__locals2.CS$<>8__locals1.<>4__this.Start);
					sqliteCommand.Parameters.AddWithValue("@End", CS$<>8__locals2.CS$<>8__locals1.<>4__this.End);
					sqliteCommand.Parameters.AddWithValue("@AvgHR", CS$<>8__locals2.CS$<>8__locals1.<>4__this.AvgHR);
					sqliteCommand.Parameters.AddWithValue("@MaxHR", CS$<>8__locals2.CS$<>8__locals1.<>4__this.MaxHR);
					sqliteCommand.Parameters.AddWithValue("@Calories", CS$<>8__locals2.CS$<>8__locals1.<>4__this.Calories);
					sqliteCommand.Parameters.AddWithValue("@AvgSpeed", CS$<>8__locals2.CS$<>8__locals1.<>4__this.AvgSpeed);
					sqliteCommand.Parameters.AddWithValue("@MaxSpeed", CS$<>8__locals2.CS$<>8__locals1.<>4__this.MaxSpeed);
					sqliteCommand.Parameters.AddWithValue("@DurationSec", CS$<>8__locals2.CS$<>8__locals1.<>4__this.DurationSec);
					sqliteCommand.Parameters.AddWithValue("@LongitudeStart", CS$<>8__locals2.CS$<>8__locals1.<>4__this.LongitudeStart);
					sqliteCommand.Parameters.AddWithValue("@LatitudeStart", CS$<>8__locals2.CS$<>8__locals1.<>4__this.LatitudeStart);
					sqliteCommand.Parameters.AddWithValue("@DistanceMeters", CS$<>8__locals2.CS$<>8__locals1.<>4__this.DistanceMeters);
					sqliteCommand.Parameters.AddWithValue("@LongDeltaRectSW", CS$<>8__locals2.CS$<>8__locals1.<>4__this.LongDeltaRectSW);
					sqliteCommand.Parameters.AddWithValue("@LatDeltaRectSW", CS$<>8__locals2.CS$<>8__locals1.<>4__this.LatDeltaRectSW);
					sqliteCommand.Parameters.AddWithValue("@LongDeltaRectNE", CS$<>8__locals2.CS$<>8__locals1.<>4__this.LongDeltaRectNE);
					sqliteCommand.Parameters.AddWithValue("@LatDeltaRectNE", CS$<>8__locals2.CS$<>8__locals1.<>4__this.LatDeltaRectNE);
					sqliteCommand.ExecuteReader();
					CS$<>8__locals2.lastId = (long)new SqliteCommand
					{
						Connection = CS$<>8__locals2.CS$<>8__locals1.dbParam,
						CommandText = "select last_insert_rowid()"
					}.ExecuteScalar();
					CS$<>8__locals2.CS$<>8__locals1.lResult = (long)(CS$<>8__locals2.CS$<>8__locals1.<>4__this.WorkoutId = (int)CS$<>8__locals2.lastId);
				});
				CS$<>8__locals2.insertTrackCommand = new SqliteCommand();
				CS$<>8__locals2.insertTrackCommand.Connection = CS$<>8__locals2.CS$<>8__locals1.dbParam;
				if (this.WorkoutType == 21)
				{
					CS$<>8__locals2.insertTrackCommand.CommandText = "INSERT INTO Sleep VALUES (NULL, @SleepActivityId, @SecFromStart, @SegmentType, @SleepType, @Heartrate);";
					using (IEnumerator<TrackItem> enumerator = this.Items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							WorkoutItem.<>c__DisplayClass181_2 CS$<>8__locals3 = new WorkoutItem.<>c__DisplayClass181_2();
							CS$<>8__locals3.CS$<>8__locals2 = CS$<>8__locals2;
							CS$<>8__locals3.sleep = enumerator.Current;
							byte skinTempRaw = (CS$<>8__locals3.sleep.SkinTemp > 0.0) ? ((byte)(CS$<>8__locals3.sleep.SkinTemp * 10.0 - 200.0)) : 0;
							await Task.Run(delegate()
							{
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.Parameters.AddWithValue("@SleepActivityId", CS$<>8__locals3.CS$<>8__locals2.lastId);
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.Parameters.AddWithValue("@SecFromStart", CS$<>8__locals3.sleep.SecFromStart);
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.Parameters.AddWithValue("@SegmentType", skinTempRaw);
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.Parameters.AddWithValue("@SleepType", CS$<>8__locals3.sleep.Cadence);
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.Parameters.AddWithValue("@Heartrate", CS$<>8__locals3.sleep.Heartrate);
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.ExecuteReader();
								CS$<>8__locals3.CS$<>8__locals2.insertTrackCommand.Parameters.Clear();
							});
							if (Progress != null)
							{
								Progress(ulStepLength, 0UL);
							}
						}
					}
					IEnumerator<TrackItem> enumerator = null;
				}
				else
				{
					CS$<>8__locals2.insertTrackCommand.CommandText = "INSERT INTO Tracks VALUES (NULL, @WorkoutId, @SecFromStart, @LongDelta, @LatDelta, @Elevation, @Heartrate, @Barometer, @Cadence, @SkinTemp, @GSR, @UVExposure);";
					using (IEnumerator<TrackItem> enumerator = this.Items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							WorkoutItem.<>c__DisplayClass181_4 CS$<>8__locals5 = new WorkoutItem.<>c__DisplayClass181_4();
							CS$<>8__locals5.CS$<>8__locals4 = CS$<>8__locals2;
							CS$<>8__locals5.track = enumerator.Current;
							byte skinTempRaw = (CS$<>8__locals5.track.SkinTemp > 0.0) ? ((byte)(CS$<>8__locals5.track.SkinTemp * 10.0 - 200.0)) : 0;
							await Task.Run(delegate()
							{
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@WorkoutId", CS$<>8__locals5.CS$<>8__locals4.lastId);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@SecFromStart", CS$<>8__locals5.track.SecFromStart);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@LongDelta", CS$<>8__locals5.track.LongDelta);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@LatDelta", CS$<>8__locals5.track.LatDelta);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@Elevation", CS$<>8__locals5.track.Elevation);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@Heartrate", CS$<>8__locals5.track.Heartrate);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@Barometer", CS$<>8__locals5.track.Barometer);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@Cadence", CS$<>8__locals5.track.Cadence);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@SkinTemp", skinTempRaw);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@GSR", CS$<>8__locals5.track.GSR);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.AddWithValue("@UVExposure", CS$<>8__locals5.track.UV);
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.ExecuteReader();
								CS$<>8__locals5.CS$<>8__locals4.insertTrackCommand.Parameters.Clear();
							});
							if (Progress != null)
							{
								Progress(ulStepLength, 0UL);
							}
						}
					}
					IEnumerator<TrackItem> enumerator = null;
				}
				CS$<>8__locals2 = null;
			}
			return CS$<>8__locals1.lResult;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000CD9C File Offset: 0x0000AF9C
		public static async Task<ObservableCollection<WorkoutItem>> ReadWorkouts(WorkoutFilterData filterData = null)
		{
			ObservableCollection<WorkoutItem> workouts = new ObservableCollection<WorkoutItem>();
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
						SqliteCommand sqliteCommand2 = sqliteCommand;
						sqliteCommand2.CommandText += " AND ( ";
						if (filterData.IsWalkingWorkout == true)
						{
							SqliteCommand sqliteCommand3 = sqliteCommand;
							sqliteCommand3.CommandText += "WorkoutType = 16 OR ";
						}
						if (filterData.IsBikingWorkout == true)
						{
							SqliteCommand sqliteCommand4 = sqliteCommand;
							sqliteCommand4.CommandText += "WorkoutType = 6 OR ";
						}
						if (filterData.IsRunningWorkout == true)
						{
							SqliteCommand sqliteCommand5 = sqliteCommand;
							sqliteCommand5.CommandText += "WorkoutType = 4 OR ";
						}
						if (filterData.IsSleepingWorkout == true)
						{
							SqliteCommand sqliteCommand6 = sqliteCommand;
							sqliteCommand6.CommandText += "WorkoutType = 21 ";
						}
						sqliteCommand.CommandText = sqliteCommand.CommandText.TrimEnd(new char[]
						{
							' ',
							'O',
							'R'
						});
						SqliteCommand sqliteCommand7 = sqliteCommand;
						sqliteCommand7.CommandText += " ) ";
					}
					if (filterData.MapBoundingBox != null)
					{
						double num = Math.Min(filterData.MapBoundingBox.NorthwestCorner.Latitude, filterData.MapBoundingBox.SoutheastCorner.Latitude);
						double num2 = Math.Max(filterData.MapBoundingBox.NorthwestCorner.Latitude, filterData.MapBoundingBox.SoutheastCorner.Latitude);
						double num3 = Math.Min(filterData.MapBoundingBox.NorthwestCorner.Longitude, filterData.MapBoundingBox.SoutheastCorner.Longitude);
						double num4 = Math.Max(filterData.MapBoundingBox.NorthwestCorner.Longitude, filterData.MapBoundingBox.SoutheastCorner.Longitude);
						SqliteCommand sqliteCommand8 = sqliteCommand;
						sqliteCommand8.CommandText += " AND LongitudeStart >= @Long1 AND LongitudeStart <= @Long2";
						SqliteCommand sqliteCommand9 = sqliteCommand;
						sqliteCommand9.CommandText += " AND LatitudeStart >= @Lat1 AND LatitudeStart <= @Lat2";
						sqliteCommand.Parameters.AddWithValue("@Long1", num3 * 10000000.0);
						sqliteCommand.Parameters.AddWithValue("@Long2", num4 * 10000000.0);
						sqliteCommand.Parameters.AddWithValue("@Lat1", num * 10000000.0);
						sqliteCommand.Parameters.AddWithValue("@Lat2", num2 * 10000000.0);
					}
					SqliteCommand sqliteCommand10 = sqliteCommand;
					sqliteCommand10.CommandText += " ORDER BY Start DESC";
					sqliteCommand.Parameters.AddWithValue("@StartDate", filterData.Start);
					sqliteCommand.Parameters.AddWithValue("@EndDate", filterData.End);
				}
				int iIndex = 0;
				using (SqliteDataReader reader = await sqliteCommand.ExecuteReaderAsync())
				{
					WorkoutDataSource.DataSource.TotalDistance = 0UL;
					WorkoutDataSource.DataSource.TotalHR = 0UL;
					WorkoutDataSource.DataSource.NumHRWorkouts = 0UL;
					WorkoutDataSource.DataSource.TotalAvgSpeed = 0UL;
					while (await reader.ReadAsync())
					{
						WorkoutItem workoutItem = new WorkoutItem();
						workoutItem.WorkoutId = reader.GetInt32(0);
						workoutItem.WorkoutType = reader.GetByte(1);
						workoutItem.Title = reader.GetString(2);
						workoutItem.Notes = reader.GetString(3);
						workoutItem.Start = reader.GetDateTime(4).ToUniversalTime();
						workoutItem.End = reader.GetDateTime(5).ToUniversalTime();
						workoutItem.AvgHR = reader.GetByte(6);
						workoutItem.MaxHR = reader.GetByte(7);
						workoutItem.Calories = reader.GetInt32(8);
						workoutItem.AvgSpeed = reader.GetInt32(9);
						workoutItem.MaxSpeed = reader.GetInt32(10);
						workoutItem.DurationSec = reader.GetInt32(11);
						workoutItem.LongitudeStart = reader.GetInt64(12);
						workoutItem.LatitudeStart = reader.GetInt64(13);
						workoutItem.DistanceMeters = reader.GetInt64(14);
						workoutItem.LongDeltaRectSW = reader.GetInt32(15);
						workoutItem.LatDeltaRectSW = reader.GetInt32(16);
						workoutItem.LongDeltaRectNE = reader.GetInt32(17);
						workoutItem.LatDeltaRectNE = reader.GetInt32(18);
						workoutItem.Items = new ObservableCollection<TrackItem>();
						workoutItem.SleepItems = new ObservableCollection<SleepItem>();
						workoutItem.Parent = workouts;
						workoutItem.Index = iIndex++;
						if (workoutItem.WorkoutType != 21)
						{
							WorkoutDataSource.DataSource.TotalDistance += (ulong)workoutItem.DistanceMeters;
						}
						string text2 = (workoutItem.WorkoutType == 4) ? "Running" : ((workoutItem.WorkoutType == 6) ? "Biking" : ((workoutItem.WorkoutType == 21) ? "Sleeping" : "Walking"));
						if (workoutItem.WorkoutType != 21 && workoutItem.AvgHR > 0)
						{
							text2 = ((workoutItem.AvgHR > 120) ? ((workoutItem.AvgHR >= 140) ? ((workoutItem.AvgHR >= 145) ? ((workoutItem.AvgHR >= 151) ? ((workoutItem.AvgHR >= 158) ? "Maximum" : "Hard") : "Moderate") : "Light") : "WarmUp") : "Walking");
						}
						if (workoutItem.AvgHR > 0)
						{
							WorkoutDataSource.DataSource.TotalHR += (ulong)workoutItem.AvgHR;
							WorkoutDataSource.DataSource.NumHRWorkouts += 1UL;
						}
						double num5 = (double)workoutItem.AvgSpeed / 1000.0;
						workoutItem.FilenameTCX = string.Concat(new string[]
						{
							workoutItem.Start.Year.ToString("D4"),
							workoutItem.Start.Month.ToString("D2"),
							workoutItem.Start.Day.ToString("D2"),
							"_",
							workoutItem.Start.Hour.ToString("D2"),
							workoutItem.Start.Minute.ToString("D2"),
							"_",
							text2,
							"_",
							((double)workoutItem.DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo),
							"_",
							num5.ToString("F2", WorkoutDataSource.AppCultureInfo),
							"_",
							workoutItem.AvgHR.ToString("F0"),
							".tcx"
						});
						workouts.Add(workoutItem);
					}
				}
				SqliteDataReader reader = null;
			}
			SqliteConnection db = null;
			WorkoutDataSource.DataSource.Summary = ((WorkoutDataSource.DataSource.TotalDistance > 0UL) ? (WorkoutDataSource.DataSource.TotalDistance / 1000.0).ToString("0,0.00", WorkoutDataSource.AppCultureInfo) : "0") + " km, Ø " + (WorkoutDataSource.DataSource.TotalHR / WorkoutDataSource.DataSource.NumHRWorkouts).ToString() + " bpm";
			return workouts;
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000CDE4 File Offset: 0x0000AFE4
		public static async Task<WorkoutItem> ReadWorkoutFromTcx(string strTcxPath)
		{
			WorkoutItem workout = null;
			StorageFile fileTcx = null;
			try
			{
				StorageFile storageFile = await StorageFile.GetFileFromPathAsync(strTcxPath);
				fileTcx = storageFile;
			}
			catch (Exception)
			{
			}
			if (fileTcx != null)
			{
				try
				{
					TrainingCenterDatabase_t trainingCenterDatabase_t = await new Tcx().AnalyzeTcxFile(strTcxPath);
					if (trainingCenterDatabase_t != null && trainingCenterDatabase_t.Activities != null && trainingCenterDatabase_t.Activities.Activity[0] != null && trainingCenterDatabase_t.Activities.Activity[0].Lap[0] != null)
					{
						DateTime id = trainingCenterDatabase_t.Activities.Activity[0].Id;
						int num = 0;
						long num2 = 0L;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						int num6 = 1;
						foreach (ActivityLap_t activityLap_t in trainingCenterDatabase_t.Activities.Activity[0].Lap)
						{
							num += (int)activityLap_t.TotalTimeSeconds;
							num2 += (long)activityLap_t.DistanceMeters;
							num3 += (int)activityLap_t.Calories;
							if (activityLap_t.MaximumHeartRateBpm != null)
							{
								num4 = Math.Max(num4, (int)activityLap_t.MaximumHeartRateBpm.Value);
							}
							if (activityLap_t.AverageHeartRateBpm != null)
							{
								num5 += (int)activityLap_t.AverageHeartRateBpm.Value;
								num6++;
							}
						}
						workout = new WorkoutItem
						{
							WorkoutType = ((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Running) ? 4 : ((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Biking) ? 6 : 32)),
							Notes = trainingCenterDatabase_t.Activities.Activity[0].Notes,
							Start = id.ToUniversalTime(),
							End = id.AddSeconds((double)num).ToUniversalTime(),
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
						double num7 = 1000.0 / ((double)workout.DistanceMeters / (double)workout.DurationSec) / 60.0;
						double num8 = num7 % 1.0;
						double num9 = 0.6 * num8;
						num7 = num7 - num8 + num9;
						workout.AvgSpeed = (int)Math.Ceiling(num7 * 1000.0);
						string text = (trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Running) ? "Running" : ((trainingCenterDatabase_t.Activities.Activity[0].Sport == Sport_t.Biking) ? "Biking" : "Walking");
						if (workout.AvgHR > 0)
						{
							text = ((workout.AvgHR > 120) ? ((workout.AvgHR >= 140) ? ((workout.AvgHR >= 145) ? ((workout.AvgHR >= 151) ? ((workout.AvgHR >= 158) ? "Maximum" : "Hard") : "Moderate") : "Light") : "WarmUp") : "Walking");
						}
						if (trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeedSpecified)
						{
							workout.MaxSpeed = (int)trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeed;
						}
						workout.FilenameTCX = string.Concat(new string[]
						{
							id.Year.ToString("D4"),
							id.Month.ToString("D2"),
							id.Day.ToString("D2"),
							"_",
							id.Hour.ToString("D2"),
							id.Minute.ToString("D2"),
							"_",
							text,
							"_",
							((double)(workout.DistanceMeters / 1000L)).ToString("F2", WorkoutDataSource.AppCultureInfo),
							"_",
							num7.ToString("F2", WorkoutDataSource.AppCultureInfo),
							"_",
							workout.AvgHR.ToString("F0"),
							".tcx"
						});
						workout.Title = string.Concat(new string[]
						{
							id.ToString(WorkoutDataSource.AppCultureInfo),
							" ",
							text,
							" ",
							((double)workout.DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo),
							" km ",
							num7.ToString("F2", WorkoutDataSource.AppCultureInfo),
							" min/km ",
							workout.AvgHR.ToString("F0"),
							" bpm"
						});
						if (workout.Notes == null || workout.Notes.Length == 0)
						{
							workout.Notes = "TCX import " + DateTime.Now.ToString(WorkoutDataSource.AppCultureInfo);
						}
						int num10 = 0;
						int num11 = 0;
						int num12 = 0;
						int num13 = 0;
						ActivityLap_t[] lap = trainingCenterDatabase_t.Activities.Activity[0].Lap;
						for (int i = 0; i < lap.Length; i++)
						{
							foreach (Trackpoint_t trackpoint_t in lap[i].Track)
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
									num10 = Math.Min(num10, trackItem.LatDelta);
									num11 = Math.Min(num11, trackItem.LongDelta);
									num12 = Math.Max(num12, trackItem.LatDelta);
									num13 = Math.Max(num13, trackItem.LongDelta);
									if (trackpoint_t.AltitudeMetersSpecified)
									{
										trackItem.Elevation = (int)trackpoint_t.AltitudeMeters;
									}
									if (trackpoint_t.CadenceSpecified)
									{
										trackItem.Cadence = (uint)trackpoint_t.Cadence;
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
						workout.LatDeltaRectNE = num12;
						workout.LatDeltaRectSW = num10;
						workout.LongDeltaRectNE = num13;
						workout.LongDeltaRectSW = num11;
					}
				}
				catch (Exception)
				{
				}
			}
			return workout;
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000CE2C File Offset: 0x0000B02C
		public async Task ReadTrackData(CancellationToken token)
		{
			string dbpath = Path.Combine(new string[]
			{
				ApplicationData.Current.LocalFolder.Path,
				"workouts.db"
			});
			await Task.Run(delegate()
			{
				using (SqliteConnection sqliteConnection = new SqliteConnection(string.Format("Filename={0}", new object[]
				{
					dbpath
				})))
				{
					try
					{
						sqliteConnection.Open();
						SqliteCommand sqliteCommand = new SqliteCommand();
						sqliteCommand.Connection = sqliteConnection;
						if (this.Items != null && this.Items.Count > 0)
						{
							this.OnTracksLoaded(this);
						}
						else
						{
							token.ThrowIfCancellationRequested();
							sqliteCommand.CommandText = "SELECT * FROM Tracks WHERE WorkoutId = $id";
							sqliteCommand.Parameters.AddWithValue("$id", this.WorkoutId);
							this.Items = new ObservableCollection<TrackItem>();
							using (SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
							{
								double totalSeconds = (this.End - this.Start).TotalSeconds;
								double num = -1.0;
								double num2 = (totalSeconds - num) / 150.0;
								uint num3 = 0U;
								double lat = (double)this.LatitudeStart / 10000000.0;
								double @long = (double)this.LongitudeStart / 10000000.0;
								int num4 = 0;
								List<DiagramData> list = new List<DiagramData>();
								this.HeartRateChart.Clear();
								this.ElevationChart.Clear();
								this.CadenceNormChart.Clear();
								this.SpeedChart.Clear();
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
										Cadence = (uint)sqliteDataReader.GetByte(8),
										SkinTemp = (double)sqliteDataReader.GetByte(9),
										GSR = sqliteDataReader.GetInt32(10),
										UV = sqliteDataReader.GetInt32(11)
									};
									double skinTemp = (trackItem2.SkinTemp > 0.0) ? ((trackItem2.SkinTemp + 200.0) / 10.0) : 0.0;
									trackItem2.SkinTemp = skinTemp;
									double num9 = (double)(this.LatitudeStart + (long)trackItem2.LatDelta) / 10000000.0;
									double num10 = (double)(this.LongitudeStart + (long)trackItem2.LongDelta) / 10000000.0;
									int secFromStart = trackItem2.SecFromStart;
									trackItem2.DistMeter = this.GetDistMeter(lat, @long, num9, num10);
									if (trackItem != null && num8 <= 40 && trackItem2.DistMeter > (double)((this.WorkoutType == 6) ? 120 : 50))
									{
										this.Items.Clear();
										trackItem2.DistMeter = 0.0;
									}
									if (num8 >= this.Items.Count - 40 && trackItem2.DistMeter > (double)((this.WorkoutType == 6) ? 200 : 150))
									{
										num8++;
									}
									else
									{
										num8++;
										int num11 = secFromStart - num4;
										trackItem2.SpeedMeterPerSecond = ((num11 > 1) ? (trackItem2.DistMeter / (double)num11) : 0.0);
										num7 += trackItem2.DistMeter;
										trackItem2.TotalMeters = num7;
										trackItem = trackItem2;
										this.Items.Add(trackItem2);
										lat = num9;
										@long = num10;
										num4 = secFromStart;
										num5 = ((num5 != -999) ? Math.Min(trackItem2.Elevation, num5) : trackItem2.Elevation);
										num6 = ((num6 != -999.0) ? Math.Max(trackItem2.SpeedMeterPerSecond, num6) : trackItem2.SpeedMeterPerSecond);
									}
								}
								if (this.Items.Count > 0)
								{
									int num12 = 0;
									int num13 = -1;
									double num14 = 150.0 / num6;
									foreach (TrackItem trackItem3 in this.Items)
									{
										if (num13 < 0 || trackItem3.SecFromStart - num13 >= 10)
										{
											num13 = trackItem3.SecFromStart;
											if (num < 0.0)
											{
												num = (double)trackItem3.SecFromStart;
											}
											if ((double)trackItem3.SecFromStart >= num)
											{
												double min = (double)trackItem3.SecFromStart / 60.0;
												this.HeartRateChart.Add(new DiagramData
												{
													Min = min,
													Value = (double)trackItem3.Heartrate,
													Index = num12
												});
												this.ElevationChart.Add(new DiagramData
												{
													Min = min,
													Value = (double)Math.Max(-10, trackItem3.Elevation - num5)
												});
												list.Add(new DiagramData
												{
													Min = min,
													Value = trackItem3.Cadence
												});
												num3 = Math.Max(num3, trackItem3.Cadence);
												this.SpeedChart.Add(new DiagramData
												{
													Min = min,
													Value = trackItem3.SpeedMeterPerSecond * num14
												});
												num += num2;
											}
										}
										num12++;
									}
								}
								if (num3 > 0U)
								{
									double num15 = (num3 > 0U) ? ((double)this.MaxHR / (2U * num3)) : 1.0;
									foreach (DiagramData diagramData in list)
									{
										token.ThrowIfCancellationRequested();
										this.CadenceNormChart.Add(new DiagramData
										{
											Min = diagramData.Min,
											Value = diagramData.Value * num15
										});
									}
								}
								this.OnTracksLoaded(this);
							}
							sqliteCommand.Parameters.Clear();
						}
					}
					catch (Exception)
					{
					}
				}
			});
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000CE7C File Offset: 0x0000B07C
		public async Task ReadSleepData(CancellationToken token)
		{
			string dbpath = Path.Combine(new string[]
			{
				ApplicationData.Current.LocalFolder.Path,
				"workouts.db"
			});
			await Task.Run(delegate()
			{
				using (SqliteConnection sqliteConnection = new SqliteConnection(string.Format("Filename={0}", new object[]
				{
					dbpath
				})))
				{
					try
					{
						sqliteConnection.Open();
						SqliteCommand sqliteCommand = new SqliteCommand();
						sqliteCommand.Connection = sqliteConnection;
						if (this.Items != null && this.Items.Count > 0)
						{
							this.OnTracksLoaded(this);
						}
						else
						{
							token.ThrowIfCancellationRequested();
							sqliteCommand.CommandText = "SELECT * FROM Sleep WHERE SleepActivityId = $id";
							sqliteCommand.Parameters.AddWithValue("$id", this.WorkoutId);
							this.Items = new ObservableCollection<TrackItem>();
							using (SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
							{
								double totalSeconds = (this.End - this.Start).TotalSeconds;
								double num = -1.0;
								double num2 = (totalSeconds - num) / 150.0;
								while (sqliteDataReader.Read())
								{
									TrackItem trackItem = new TrackItem
									{
										TrackId = sqliteDataReader.GetInt32(0),
										WorkoutId = sqliteDataReader.GetInt32(1),
										SecFromStart = sqliteDataReader.GetInt32(2),
										SkinTemp = (double)sqliteDataReader.GetInt32(3),
										LongDelta = 0,
										LatDelta = 0,
										Elevation = 0,
										Barometer = 0,
										Cadence = (uint)sqliteDataReader.GetInt32(4),
										Heartrate = sqliteDataReader.GetByte(5),
										GSR = 0,
										UV = 0
									};
									double skinTemp = (trackItem.SkinTemp > 0.0) ? ((trackItem.SkinTemp + 200.0) / 10.0) : 0.0;
									trackItem.SkinTemp = skinTemp;
									int secFromStart = trackItem.SecFromStart;
									this.Items.Add(trackItem);
								}
								this.OnTracksLoaded(this);
							}
							sqliteCommand.Parameters.Clear();
						}
					}
					catch (Exception)
					{
					}
				}
			});
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000CECC File Offset: 0x0000B0CC
		public double GetDistMeter(double lat1, double long1, double lat2, double long2)
		{
			double d = (lat1 + lat2) / 2.0 * 0.01745;
			double num = 111.3 * Math.Cos(d) * (long1 - long2);
			double num2 = 111.3 * (lat1 - lat2);
			return Math.Sqrt(num * num + num2 * num2) * 1000.0;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000CF2C File Offset: 0x0000B12C
		public string GenerateTcxBuffer()
		{
			string result = "";
			if (this.Items.Count <= 0)
			{
				return result;
			}
			ExportType exportType = (ExportType)120;
			try
			{
				Tcx tcx = new Tcx();
				new XmlDocument();
				if ((this.WorkoutType == 4 || this.WorkoutType == 32 || this.WorkoutType == 6 || this.WorkoutType == 16) && this.Items.Count > 0)
				{
					ExportType exportType2 = exportType;
					EventType workoutType = (EventType)this.WorkoutType;
					if (workoutType != EventType.Running)
					{
						if (workoutType == EventType.Biking)
						{
							exportType2 &= (ExportType)104;
							goto IL_8B;
						}
						if (workoutType != EventType.Hike)
						{
							exportType2 &= ExportType.HeartRate;
							goto IL_8B;
						}
					}
					exportType2 &= (ExportType)120;
					IL_8B:
					TrainingCenterDatabase_t trainingCenterDatabase_t = new TrainingCenterDatabase_t();
					trainingCenterDatabase_t.Activities = new ActivityList_t();
					trainingCenterDatabase_t.Activities.Activity = new Activity_t[1];
					trainingCenterDatabase_t.Activities.Activity[0] = new Activity_t();
					trainingCenterDatabase_t.Activities.Activity[0].Id = this.Start;
					trainingCenterDatabase_t.Activities.Activity[0].Notes = this.Notes;
					trainingCenterDatabase_t.Activities.Activity[0].Sport = ((this.WorkoutType == 6) ? Sport_t.Biking : Sport_t.Running);
					trainingCenterDatabase_t.Activities.Activity[0].Lap = new ActivityLap_t[1];
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0] = new ActivityLap_t();
					trainingCenterDatabase_t.Activities.Activity[0].Sport = ((this.WorkoutType == 6) ? Sport_t.Biking : Sport_t.Running);
					string text;
					if (this.AvgHR != 0)
					{
						if (this.AvgHR <= 120)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Sport = Sport_t.Other;
							text = "Walking";
						}
						else if (this.AvgHR < 140)
						{
							text = "WarmUp";
						}
						else if (this.AvgHR < 145)
						{
							text = "Light";
						}
						else if (this.AvgHR < 151)
						{
							text = "Moderate";
						}
						else if (this.AvgHR < 158)
						{
							text = "Hard";
						}
						else
						{
							text = "Maximum";
						}
						if ((exportType & ExportType.HeartRate) == ExportType.HeartRate)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm = new HeartRateInBeatsPerMinute_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].AverageHeartRateBpm.Value = this.AvgHR;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm = new HeartRateInBeatsPerMinute_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumHeartRateBpm.Value = this.MaxHR;
						}
					}
					else
					{
						text = ((this.WorkoutType == 6) ? "Biking" : ((this.WorkoutType == 4) ? "Running" : "Walking"));
					}
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeed = (double)this.MaxSpeed;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].MaximumSpeedSpecified = true;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TotalTimeSeconds = (double)this.DurationSec;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Calories = (ushort)this.Calories;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].DistanceMeters = (double)this.DistanceMeters;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Intensity = Intensity_t.Active;
					double num = (double)this.DistanceMeters / (double)this.DurationSec;
					double num2 = 1000.0 / num / 60.0;
					double num3 = num2 % 1.0;
					double num4 = 0.6 * num3;
					num2 -= num3;
					num2 += num4;
					this.FilenameTCX = string.Concat(new string[]
					{
						this.Start.Year.ToString("D4"),
						this.Start.Month.ToString("D2"),
						this.Start.Day.ToString("D2"),
						"_",
						this.Start.Hour.ToString("D2"),
						this.Start.Minute.ToString("D2"),
						"_",
						text,
						"_",
						((double)this.DistanceMeters / 1000.0).ToString("F2", WorkoutDataSource.AppCultureInfo),
						"_",
						num2.ToString("F2", WorkoutDataSource.AppCultureInfo),
						"_",
						this.AvgHR.ToString("F0"),
						".tcx"
					});
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].StartTime = this.Start;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].TriggerMethod = TriggerMethod_t.Manual;
					trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track = new Trackpoint_t[this.Items.Count];
					int num5 = 0;
					foreach (TrackItem trackItem in this.Items)
					{
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5] = new Trackpoint_t();
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Time = this.Start.AddSeconds((double)trackItem.SecFromStart);
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorState = SensorState_t.Present;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].SensorStateSpecified = true;
						if ((exportType & ExportType.HeartRate) == ExportType.HeartRate)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm = new HeartRateInBeatsPerMinute_t();
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].HeartRateBpm.Value = trackItem.Heartrate;
						}
						if ((exportType & ExportType.Cadence) == ExportType.Cadence && this.WorkoutType != 6)
						{
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Cadence = (byte)trackItem.Cadence;
							trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].CadenceSpecified = true;
						}
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMeters = (double)trackItem.Elevation;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].AltitudeMetersSpecified = true;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position = new Position_t();
						double latitudeDegrees = (double)(this.LatitudeStart + (long)trackItem.LatDelta) / 10000000.0;
						double longitudeDegrees = (double)(this.LongitudeStart + (long)trackItem.LongDelta) / 10000000.0;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LatitudeDegrees = latitudeDegrees;
						trainingCenterDatabase_t.Activities.Activity[0].Lap[0].Track[num5].Position.LongitudeDegrees = longitudeDegrees;
						num5++;
					}
					string text2 = tcx.GenerateTcx(trainingCenterDatabase_t);
					if (text2 != null && text2.Length > 0)
					{
						result = text2.Replace("\"utf-16\"", "\"UTF-8\"");
					}
				}
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x04000310 RID: 784
		private EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>> m_currentWorkout;

		// Token: 0x04000311 RID: 785
		private string _title;
	}
}
