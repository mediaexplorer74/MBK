using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using MobileBandSync.Data;
using MobileBandSync.MSFTBandLib;
using MobileBandSync.MSFTBandLib.UWP;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Resources;
using Windows.Storage;

namespace MobileBandSync.Common
{
	// Token: 0x020000A3 RID: 163
	public class SyncViewModel : INotifyPropertyChanged
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600061C RID: 1564 RVA: 0x0000FE84 File Offset: 0x0000E084
		// (remove) Token: 0x0600061D RID: 1565 RVA: 0x0000FEBC File Offset: 0x0000E0BC
		public event PropertyChangedEventHandler PropertyChanged = delegate(object <sender>, PropertyChangedEventArgs <e>)
		{
		};

		// Token: 0x0600061E RID: 1566 RVA: 0x0000FEF4 File Offset: 0x0000E0F4
		public SyncViewModel()
		{
			this.ResourceLoader = ResourceLoader.GetForViewIndependentUse();
			this.Enabled = false;
			this.Connected = false;
			this.ConnectionText = this.ResourceLoader.GetString("NotConnected");
			this.DeviceText = "";
			this.StatusText = "";
			this.SyncProgress = 0.0;
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0000FFC5 File Offset: 0x0000E1C5
		// (set) Token: 0x06000620 RID: 1568 RVA: 0x0000FFCD File Offset: 0x0000E1CD
		public ResourceLoader ResourceLoader { get; private set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x0000FFD6 File Offset: 0x0000E1D6
		// (set) Token: 0x06000622 RID: 1570 RVA: 0x0000FFDE File Offset: 0x0000E1DE
		public bool Enabled
		{
			get
			{
				return this._bEnabled;
			}
			set
			{
				this._bEnabled = value;
				this.OnPropertyChanged("Enabled");
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0000FFF2 File Offset: 0x0000E1F2
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x0000FFFA File Offset: 0x0000E1FA
		public double SyncProgress
		{
			get
			{
				return this._dProgress;
			}
			set
			{
				if (this._dProgress != value)
				{
					this._dProgress = value;
					this.OnPropertyChanged("SyncProgress");
				}
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x00010017 File Offset: 0x0000E217
		// (set) Token: 0x06000626 RID: 1574 RVA: 0x0001001F File Offset: 0x0000E21F
		public string StatusText
		{
			get
			{
				return this._strStatusText;
			}
			set
			{
				this._strStatusText = value;
				this.OnPropertyChanged("StatusText");
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00010033 File Offset: 0x0000E233
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x0001003B File Offset: 0x0000E23B
		public string ConnectionText
		{
			get
			{
				return this._strConnectionText;
			}
			set
			{
				this._strConnectionText = value;
				this.OnPropertyChanged("ConnectionText");
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x0001004F File Offset: 0x0000E24F
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x00010057 File Offset: 0x0000E257
		public string ConnectionLog
		{
			get
			{
				return this._strConnectionLog;
			}
			set
			{
				this._strConnectionLog = value;
				this.OnPropertyChanged("ConnectionLog");
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x0001006B File Offset: 0x0000E26B
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x00010073 File Offset: 0x0000E273
		public string DeviceText
		{
			get
			{
				return this._strDeviceText;
			}
			set
			{
				this._strDeviceText = value;
				this.OnPropertyChanged("DeviceText");
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00010087 File Offset: 0x0000E287
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x0001008F File Offset: 0x0000E28F
		public bool CleanupSensorLog
		{
			get
			{
				return this._bCleanupSensorLog;
			}
			set
			{
				this._bCleanupSensorLog = value;
				this.OnPropertyChanged("CleanupSensorLog");
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x000100A3 File Offset: 0x0000E2A3
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x000100AB File Offset: 0x0000E2AB
		public bool StoreSensorLogLocally
		{
			get
			{
				return this._bStoreSensorLogLocally;
			}
			set
			{
				this._bStoreSensorLogLocally = value;
				this.OnPropertyChanged("StoreSensorLogLocally");
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x000100BF File Offset: 0x0000E2BF
		public BandClientUWP BandClient
		{
			get
			{
				return this._bandClient;
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x000100C7 File Offset: 0x0000E2C7
		public void OnPropertyChanged(string propertyName = null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x000100DC File Offset: 0x0000E2DC
		public async Task<bool> StartDeviceSearch()
		{
			this.Connected = false;
			this.ConnectionText = this.ResourceLoader.GetString("NotConnected");
			this.DeviceText = "";
			this.StatusText = "";
			this.SyncProgress = 0.0;
			this.Enabled = false;
			if (this.BandClient != null)
			{
				try
				{
					List<BandInterface> list = await this.BandClient.GetPairedBands();
					if (list.Count > 0)
					{
						this.ConnectionText = this.ResourceLoader.GetString("SearchingDevice");
					}
					this.CurrentBand = null;
					foreach (BandInterface band in list)
					{
						try
						{
							await band.Connect(new Action<ulong, ulong>(this.Progress));
							this.CurrentBand = band;
							this.Connected = true;
							break;
						}
						catch (Exception)
						{
							this.CurrentBand = null;
						}
						band = null;
					}
					List<BandInterface>.Enumerator enumerator = default(List<BandInterface>.Enumerator);
				}
				catch (Exception)
				{
				}
				if (this.CurrentBand != null)
				{
					string str = this.ResourceLoader.GetString("Connected");
					this.ConnectionText = str + ": #" + await this.CurrentBand.GetSerialNumber();
					str = null;
					string name = this.CurrentBand.GetName();
					this.DeviceText = name;
					WorkoutDataSource.BandName = name;
					this.Connected = true;
					this.Enabled = true;
				}
				else
				{
					this.CurrentBand = new Band<BandSocketUWP>("", "");
					this.ConnectionText = this.ResourceLoader.GetString("NotConnected");
				}
			}
			return this.Connected;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00010121 File Offset: 0x0000E321
		public void Report(string strReport)
		{
			if (strReport != null && strReport.Length > 0)
			{
				this.ConnectionLog += strReport;
			}
			this.ConnectionLog += Environment.NewLine;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00010157 File Offset: 0x0000E357
		public void Status(string strStatus)
		{
			if (strStatus != null && strStatus.Length > 0)
			{
				this.StatusText = strStatus;
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001016C File Offset: 0x0000E36C
		public async Task<IEnumerable<WorkoutItem>> StartDeviceSync()
		{
			if (this.Connected && this.CurrentBand != null)
			{
				this.Enabled = false;
				this.StatusText = this.ResourceLoader.GetString("Downloading");
				WorkoutDataSource.BandName = this.CurrentBand.GetName();
				byte[] array = await this.CurrentBand.GetSensorLog(new Action<string>(this.Report), new Action<ulong, ulong>(this.Progress), this.CleanupSensorLog, this.StoreSensorLogLocally);
				if (array != null)
				{
					this.Report(null);
					this.StatusText = this.ResourceLoader.GetString("Importing");
					try
					{
						int num = array.Length;
						List<WorkoutItem> list = await WorkoutDataSource.ImportFromSensorlog(array, new Action<string>(this.Status), new Action<ulong, ulong>(this.Progress));
						if (this.CurrentBand != null && list.Count > 0)
						{
							this.StatusText = string.Concat(new object[]
							{
								this.ResourceLoader.GetString("Storing"),
								" ",
								list.Count,
								" ",
								(list.Count == 1) ? this.ResourceLoader.GetString("Workout") : this.ResourceLoader.GetString("Workouts")
							});
							ulong stepLength = WorkoutDataSource.DataSource.SensorLogEngine.StepLength;
							await WorkoutDataSource.StoreWorkouts(list, new Action<ulong, ulong>(this.Progress), stepLength);
							IEnumerable<WorkoutItem> result = await WorkoutDataSource.GetWorkoutsAsync(true, null);
							this.Report(null);
							this.Progress(0UL, 0UL);
							this.StatusText = "";
							this.Enabled = true;
							return result;
						}
					}
					catch (Exception)
					{
					}
				}
			}
			this.Report(null);
			this.Progress(0UL, 0UL);
			this.StatusText = "";
			this.Enabled = true;
			return null;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x000101B4 File Offset: 0x0000E3B4
		public async Task<IEnumerable<WorkoutItem>> StartSyncFromLogs()
		{
			this.Enabled = false;
			WorkoutDataSource.BandName = "Virtual Test Band";
			List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
			StorageFolder storageFolder = await KnownFolders.DocumentsLibrary.CreateFolderAsync("SensorLog", 3);
			if (storageFolder != null)
			{
				try
				{
					this.StatusText = "Reading from sensor log";
					listWorkouts = await WorkoutDataSource.ImportFromSensorlog(storageFolder, new Action<string>(this.Status), new Action<ulong, ulong>(this.Progress));
				}
				catch (Exception)
				{
				}
			}
			if (listWorkouts.Count > 0)
			{
				this.Progress(0UL, WorkoutDataSource.DataSource.SensorLogEngine.BufferSize);
				this.StatusText = "Storing " + listWorkouts.Count + ((listWorkouts.Count == 1) ? " workout" : " workouts");
				ulong stepLength = WorkoutDataSource.DataSource.SensorLogEngine.StepLength;
				await WorkoutDataSource.StoreWorkouts(listWorkouts, new Action<ulong, ulong>(this.Progress), stepLength);
			}
			this.Report(null);
			this.Progress(0UL, 0UL);
			this.StatusText = "";
			this.Enabled = true;
			return (listWorkouts.Count <= 0) ? null : (await WorkoutDataSource.GetWorkoutsAsync(true, null));
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x000101FC File Offset: 0x0000E3FC
		public async void Progress(ulong uiCompleted, ulong uiTotal)
		{
			if (uiTotal > 0UL && this.TotalProgress != uiTotal)
			{
				this.TotalProgress = uiTotal;
				this.CompletedProgress = 0UL;
				this.SyncProgress = 0.0;
			}
			if (this.TotalProgress != 0UL)
			{
				if (uiCompleted == 0UL && uiTotal == 0UL)
				{
					this.SyncProgress = 0.0;
					this.TotalProgress = 0UL;
					this.CompletedProgress = 0UL;
				}
				else
				{
					this.CompletedProgress = Math.Min(this.TotalProgress, this.CompletedProgress + uiCompleted);
					float uiVal = this.CompletedProgress * 100UL / this.TotalProgress;
					if ((double)uiVal >= this._dProgress + 1.0)
					{
						await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(0, delegate()
						{
							this.SyncProgress = (ulong)uiVal;
						});
					}
				}
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x00010245 File Offset: 0x0000E445
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x0001024D File Offset: 0x0000E44D
		public bool Connected { get; set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x00010256 File Offset: 0x0000E456
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x0001025E File Offset: 0x0000E45E
		public BandInterface CurrentBand { get; set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00010267 File Offset: 0x0000E467
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x0001026F File Offset: 0x0000E46F
		public ulong TotalProgress { get; private set; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00010278 File Offset: 0x0000E478
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x00010280 File Offset: 0x0000E480
		public ulong CompletedProgress { get; private set; }

		// Token: 0x04000407 RID: 1031
		private bool _bEnabled = true;

		// Token: 0x04000408 RID: 1032
		private bool _bCleanupSensorLog = true;

		// Token: 0x04000409 RID: 1033
		private bool _bStoreSensorLogLocally;

		// Token: 0x0400040A RID: 1034
		private double _dProgress;

		// Token: 0x0400040B RID: 1035
		private string _strStatusText = "";

		// Token: 0x0400040C RID: 1036
		private string _strConnectionText = "";

		// Token: 0x0400040D RID: 1037
		private string _strDeviceText = "";

		// Token: 0x0400040E RID: 1038
		private string _strConnectionLog = "";

		// Token: 0x04000411 RID: 1041
		private BandClientUWP _bandClient = new BandClientUWP();
	}
}
