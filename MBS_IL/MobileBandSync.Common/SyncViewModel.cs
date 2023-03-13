using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MobileBandSync.Data;
using MobileBandSync.MSFTBandLib;
using MobileBandSync.MSFTBandLib.UWP;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.UI.Core;

namespace MobileBandSync.Common;

public class SyncViewModel : INotifyPropertyChanged
{
	private bool _bEnabled = true;

	private bool _bCleanupSensorLog = true;

	private bool _bStoreSensorLogLocally;

	private double _dProgress;

	private string _strStatusText = "";

	private string _strConnectionText = "";

	private string _strDeviceText = "";

	private string _strConnectionLog = "";

	private BandClientUWP _bandClient = new BandClientUWP();

	public ResourceLoader ResourceLoader { get; private set; }

	public bool Enabled
	{
		get
		{
			return _bEnabled;
		}
		set
		{
			_bEnabled = value;
			OnPropertyChanged("Enabled");
		}
	}

	public double SyncProgress
	{
		get
		{
			return _dProgress;
		}
		set
		{
			if (_dProgress != value)
			{
				_dProgress = value;
				OnPropertyChanged("SyncProgress");
			}
		}
	}

	public string StatusText
	{
		get
		{
			return _strStatusText;
		}
		set
		{
			_strStatusText = value;
			OnPropertyChanged("StatusText");
		}
	}

	public string ConnectionText
	{
		get
		{
			return _strConnectionText;
		}
		set
		{
			_strConnectionText = value;
			OnPropertyChanged("ConnectionText");
		}
	}

	public string ConnectionLog
	{
		get
		{
			return _strConnectionLog;
		}
		set
		{
			_strConnectionLog = value;
			OnPropertyChanged("ConnectionLog");
		}
	}

	public string DeviceText
	{
		get
		{
			return _strDeviceText;
		}
		set
		{
			_strDeviceText = value;
			OnPropertyChanged("DeviceText");
		}
	}

	public bool CleanupSensorLog
	{
		get
		{
			return _bCleanupSensorLog;
		}
		set
		{
			_bCleanupSensorLog = value;
			OnPropertyChanged("CleanupSensorLog");
		}
	}

	public bool StoreSensorLogLocally
	{
		get
		{
			return _bStoreSensorLogLocally;
		}
		set
		{
			_bStoreSensorLogLocally = value;
			OnPropertyChanged("StoreSensorLogLocally");
		}
	}

	public BandClientUWP BandClient => _bandClient;

	public bool Connected { get; set; }

	public BandInterface CurrentBand { get; set; }

	public ulong TotalProgress { get; private set; }

	public ulong CompletedProgress { get; private set; }

	public event PropertyChangedEventHandler PropertyChanged = delegate
	{
	};

	public SyncViewModel()
	{
		ResourceLoader = ResourceLoader.GetForViewIndependentUse();
		Enabled = false;
		Connected = false;
		ConnectionText = ResourceLoader.GetString("NotConnected");
		DeviceText = "";
		StatusText = "";
		SyncProgress = 0.0;
	}

	public void OnPropertyChanged(string propertyName = null)
	{
		this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	}

	public async Task<bool> StartDeviceSearch()
	{
		Connected = false;
		ConnectionText = ResourceLoader.GetString("NotConnected");
		DeviceText = "";
		StatusText = "";
		SyncProgress = 0.0;
		Enabled = false;
		if (BandClient != null)
		{
			try
			{
				List<BandInterface> list = await BandClient.GetPairedBands();
				if (list.Count > 0)
				{
					ConnectionText = ResourceLoader.GetString("SearchingDevice");
				}
				CurrentBand = null;
				foreach (BandInterface band in list)
				{
					try
					{
						await band.Connect(Progress);
						CurrentBand = band;
						Connected = true;
					}
					catch (Exception)
					{
						CurrentBand = null;
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
			if (CurrentBand != null)
			{
				string @string = ResourceLoader.GetString("Connected");
				string connectionText = @string + ": #" + await CurrentBand.GetSerialNumber();
				ConnectionText = connectionText;
				connectionText = (DeviceText = CurrentBand.GetName());
				WorkoutDataSource.BandName = connectionText;
				Connected = true;
				Enabled = true;
			}
			else
			{
				CurrentBand = new Band<BandSocketUWP>("", "");
				ConnectionText = ResourceLoader.GetString("NotConnected");
			}
		}
		return Connected;
	}

	public void Report(string strReport)
	{
		if (strReport != null && strReport.Length > 0)
		{
			ConnectionLog += strReport;
		}
		ConnectionLog += Environment.NewLine;
	}

	public void Status(string strStatus)
	{
		if (strStatus != null && strStatus.Length > 0)
		{
			StatusText = strStatus;
		}
	}

	public async Task<IEnumerable<WorkoutItem>> StartDeviceSync()
	{
		if (Connected && CurrentBand != null)
		{
			Enabled = false;
			StatusText = ResourceLoader.GetString("Downloading");
			WorkoutDataSource.BandName = CurrentBand.GetName();
			byte[] array = await CurrentBand.GetSensorLog(Report, Progress, CleanupSensorLog, StoreSensorLogLocally);
			if (array != null)
			{
				Report(null);
				StatusText = ResourceLoader.GetString("Importing");
				try
				{
					_ = array.Length;
					List<WorkoutItem> list = await WorkoutDataSource.ImportFromSensorlog(array, Status, Progress);
					if (CurrentBand != null && list.Count > 0)
					{
						StatusText = ResourceLoader.GetString("Storing") + " " + list.Count + " " + ((list.Count == 1) ? ResourceLoader.GetString("Workout") : ResourceLoader.GetString("Workouts"));
						ulong stepLength = WorkoutDataSource.DataSource.SensorLogEngine.StepLength;
						await WorkoutDataSource.StoreWorkouts(list, Progress, stepLength);
						IEnumerable<WorkoutItem> result = await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true);
						Report(null);
						Progress(0uL, 0uL);
						StatusText = "";
						Enabled = true;
						return result;
					}
				}
				catch (Exception)
				{
				}
			}
		}
		Report(null);
		Progress(0uL, 0uL);
		StatusText = "";
		Enabled = true;
		return null;
	}

	public async Task<IEnumerable<WorkoutItem>> StartSyncFromLogs()
	{
		Enabled = false;
		WorkoutDataSource.BandName = "Virtual Test Band";
		List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
		TaskAwaiter<StorageFolder> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(KnownFolders.DocumentsLibrary.CreateFolderAsync("SensorLog", (CreationCollisionOption)3));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<StorageFolder> taskAwaiter2 = default(TaskAwaiter<StorageFolder>);
			taskAwaiter = taskAwaiter2;
		}
		StorageFolder result = taskAwaiter.GetResult();
		if (result != null)
		{
			try
			{
				StatusText = "Reading from sensor log";
				listWorkouts = await WorkoutDataSource.ImportFromSensorlog(result, Status, Progress);
			}
			catch (Exception)
			{
			}
		}
		if (listWorkouts.Count > 0)
		{
			Progress(0uL, WorkoutDataSource.DataSource.SensorLogEngine.BufferSize);
			StatusText = "Storing " + listWorkouts.Count + ((listWorkouts.Count == 1) ? " workout" : " workouts");
			ulong stepLength = WorkoutDataSource.DataSource.SensorLogEngine.StepLength;
			await WorkoutDataSource.StoreWorkouts(listWorkouts, Progress, stepLength);
		}
		Report(null);
		Progress(0uL, 0uL);
		StatusText = "";
		Enabled = true;
		return (listWorkouts.Count <= 0) ? null : (await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true));
	}

	public async void Progress(ulong uiCompleted, ulong uiTotal)
	{
		if (uiTotal != 0 && TotalProgress != uiTotal)
		{
			TotalProgress = uiTotal;
			CompletedProgress = 0uL;
			SyncProgress = 0.0;
		}
		if (TotalProgress == 0L)
		{
			return;
		}
		if (uiCompleted == 0L && uiTotal == 0L)
		{
			SyncProgress = 0.0;
			TotalProgress = 0uL;
			CompletedProgress = 0uL;
			return;
		}
		CompletedProgress = Math.Min(TotalProgress, CompletedProgress + uiCompleted);
		float uiVal = (float)(CompletedProgress * 100) / (float)TotalProgress;
		if ((double)uiVal >= _dProgress + 1.0)
		{
			TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority)0, (DispatchedHandler)delegate
			{
				SyncProgress = (ulong)uiVal;
			}));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
				taskAwaiter = taskAwaiter2;
			}
			taskAwaiter.GetResult();
		}
	}
}
