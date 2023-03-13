using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using MobileBandSync.Common;
using MobileBandSync.Data;
using Windows.ApplicationModel.Resources;
using Windows.Devices.Geolocation;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync;

public sealed class HubPage : Page, IComponentConnector
{
	private readonly NavigationHelper navigationHelper;

	private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

	private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

	public WorkoutData PageWorkoutData = new WorkoutData();

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private DatePicker startDatePicker;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private DatePicker endDatePicker;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private MapControl MapPicker;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private CheckBox chkMap;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private CheckBox chkWalk;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private CheckBox chkSleep;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private CheckBox chkRun;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private CheckBox chkBike;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid LayoutRoot;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Hub Hub;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private bool _contentLoaded;

	public NavigationHelper NavigationHelper => navigationHelper;

	public ObservableDictionary DefaultViewModel => defaultViewModel;

	public SyncViewModel SyncView { get; set; }

	public DispatcherTimer DeviceTimer { get; private set; }

	public string MapServiceToken { get; private set; }

	public bool FilterAccepted { get; private set; }

	public bool MapPickerInitialized { get; private set; }

	public ToggleButton ToggleFilter { get; private set; }

	public HubPage()
	{
		InitializeComponent();
		DisplayInformation.put_AutoRotationPreferences((DisplayOrientations)2);
		((Page)this).put_NavigationCacheMode((NavigationCacheMode)1);
		navigationHelper = new NavigationHelper((Page)(object)this);
		navigationHelper.LoadState += NavigationHelper_LoadState;
		navigationHelper.SaveState += NavigationHelper_SaveState;
		SyncView = new SyncViewModel();
		MapServiceToken = "AobMbD2yKlST1QB_mh1mPfpnJGDtpm0lefHMTVPqU0NQR58-xEVO3KhAaOaqJL6y";
		WorkoutDataSource.SetMapServiceToken(MapServiceToken);
	}

	private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
	{
		if (DefaultViewModel.ContainsKey("WorkoutData"))
		{
			DefaultViewModel.Remove("WorkoutData");
		}
		WorkoutData pageWorkoutData = PageWorkoutData;
		pageWorkoutData.Workouts = await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true);
		pageWorkoutData = PageWorkoutData;
		pageWorkoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
		DefaultViewModel["WorkoutData"] = PageWorkoutData;
		if (!DefaultViewModel.ContainsKey("SyncView"))
		{
			SyncView.Enabled = false;
			SyncView.Connected = false;
			DefaultViewModel["SyncView"] = SyncView;
			SyncView.ConnectionText = "Disconnected";
			SyncView.DeviceText = "";
			SyncView.StatusText = "";
			SyncView.ConnectionLog = "";
			if (!(await SyncView.StartDeviceSearch()))
			{
				DeviceTimer = new DispatcherTimer();
				DeviceTimer.put_Interval(new TimeSpan(0, 0, 10));
				DispatcherTimer deviceTimer = DeviceTimer;
				WindowsRuntimeMarshal.AddEventHandler((Func<EventHandler<object>, EventRegistrationToken>)deviceTimer.add_Tick, (Action<EventRegistrationToken>)deviceTimer.remove_Tick, (EventHandler<object>)OnDeviceTimer);
				DeviceTimer.Start();
			}
		}
	}

	private async void OnDeviceTimer(object sender, object e)
	{
		DeviceTimer.Stop();
		if (!(await SyncView.StartDeviceSearch()))
		{
			DeviceTimer.Start();
		}
	}

	private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
	{
	}

	private void WorkoutItem_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (e.ClickedItem == null)
			{
				return;
			}
			int workoutId = ((WorkoutItem)e.ClickedItem).WorkoutId;
			if (e.ClickedItem is WorkoutItem workoutItem)
			{
				Type typeFromHandle = typeof(SectionPage);
				if (workoutItem.WorkoutType == 21)
				{
					typeFromHandle = typeof(SleepPage);
				}
				((Page)this).Frame.Navigate(typeFromHandle, (object)workoutId);
			}
		}
		catch
		{
		}
	}

	private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
	{
		string uniqueId = ((TrackItem)e.ClickedItem).UniqueId;
		if (!((Page)this).Frame.Navigate(typeof(ItemPage), (object)uniqueId))
		{
			throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
		}
	}

	public async void btnSync_Click(object sender, RoutedEventArgs e)
	{
		await SyncView.StartDeviceSync();
		PageWorkoutData.Workouts = WorkoutDataSource.GetWorkouts();
		WorkoutData pageWorkoutData = PageWorkoutData;
		pageWorkoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
		if (PageWorkoutData.Workouts != null)
		{
			if (DefaultViewModel.ContainsKey("WorkoutData"))
			{
				DefaultViewModel.Remove("WorkoutData");
			}
			DefaultViewModel["WorkoutData"] = PageWorkoutData;
		}
	}

	protected override void OnNavigatedTo(NavigationEventArgs e)
	{
		navigationHelper.OnNavigatedTo(e);
	}

	protected override void OnNavigatedFrom(NavigationEventArgs e)
	{
		navigationHelper.OnNavigatedFrom(e);
	}

	private async void BackupDatabase_Tapped(object sender, TappedRoutedEventArgs e)
	{
		FolderPicker val = new FolderPicker();
		val.put_SuggestedStartLocation((PickerLocationId)0);
		val.FileTypeFilter.Add("*");
		TaskAwaiter<StorageFolder> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(val.PickSingleFolderAsync());
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<StorageFolder> taskAwaiter2 = default(TaskAwaiter<StorageFolder>);
			taskAwaiter = taskAwaiter2;
		}
		StorageFolder result = taskAwaiter.GetResult();
		if (result != null)
		{
			await WorkoutDataSource.BackupDatabase(result);
		}
	}

	private async void ToggleButton_Checked(object sender, RoutedEventArgs e)
	{
		object obj = ((IDictionary<object, object>)((FrameworkElement)this).Resources)[(object)"MyFlyout"];
		Flyout val = (Flyout)((obj is Flyout) ? obj : null);
		ToggleButton val2 = (ToggleButton)((sender is ToggleButton) ? sender : null);
		if (val2 == null)
		{
			return;
		}
		ToggleFilter = val2;
		if (DateTime.Now - startDatePicker.Date < new TimeSpan(1, 0, 0))
		{
			startDatePicker.put_Date((DateTimeOffset)(DateTime.Now - new TimeSpan(5475, 0, 0, 0, 0)));
		}
		if (DateTime.Now - endDatePicker.Date < new TimeSpan(1, 0, 0))
		{
			endDatePicker.put_Date((DateTimeOffset)DateTime.Now);
		}
		((FlyoutBase)val).ShowAt((FrameworkElement)(object)val2);
		if (MapPickerInitialized)
		{
			return;
		}
		MapPickerInitialized = true;
		try
		{
			Geolocator val3 = new Geolocator();
			val3.put_DesiredAccuracyInMeters((uint?)500u);
			Geoposition pos = default(Geoposition);
			_ = pos;
			TaskAwaiter<Geoposition> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<Geoposition>(val3.GetGeopositionAsync());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<Geoposition> taskAwaiter2 = default(TaskAwaiter<Geoposition>);
				taskAwaiter = taskAwaiter2;
			}
			Geoposition result = taskAwaiter.GetResult();
			pos = result;
			((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)1, (DispatchedHandler)delegate
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Unknown result type (might be due to invalid IL or missing references)
				//IL_0057: Unknown result type (might be due to invalid IL or missing references)
				//IL_007c: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Expected O, but got Unknown
				BasicGeoposition val4 = default(BasicGeoposition);
				val4.Latitude = pos.Coordinate.Latitude;
				val4.Longitude = pos.Coordinate.Longitude;
				val4.Altitude = pos.Coordinate.Altitude.Value;
				BasicGeoposition val5 = val4;
				MapPicker.put_ZoomLevel(10.0);
				MapPicker.put_Center(new Geopoint(val5));
			});
		}
		catch
		{
		}
	}

	private async void ButtonOK_Tapped(object sender, TappedRoutedEventArgs e)
	{
		FilterAccepted = true;
		object obj = ((IDictionary<object, object>)((FrameworkElement)this).Resources)[(object)"MyFlyout"];
		((FlyoutBase)((obj is Flyout) ? obj : null)).Hide();
		WorkoutDataSource dataSource = WorkoutDataSource.DataSource;
		WorkoutFilterData workoutFilterData = new WorkoutFilterData();
		_ = startDatePicker.Date;
		workoutFilterData.Start = startDatePicker.Date.DateTime;
		_ = endDatePicker.Date;
		workoutFilterData.End = endDatePicker.Date.DateTime;
		workoutFilterData.IsBikingWorkout = ((ToggleButton)chkBike).IsChecked;
		workoutFilterData.IsRunningWorkout = ((ToggleButton)chkRun).IsChecked;
		workoutFilterData.IsWalkingWorkout = ((ToggleButton)chkWalk).IsChecked;
		workoutFilterData.IsSleepingWorkout = ((ToggleButton)chkSleep).IsChecked;
		dataSource.CurrentFilter = workoutFilterData;
		if (((ToggleButton)chkMap).IsChecked == true)
		{
			WorkoutDataSource.DataSource.CurrentFilter.SetBounds(MapPicker);
			WorkoutDataSource.DataSource.CurrentFilter.MapSelected = true;
		}
		else
		{
			WorkoutDataSource.DataSource.CurrentFilter.SetBounds(null);
		}
		WorkoutData pageWorkoutData = PageWorkoutData;
		pageWorkoutData.Workouts = await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true, WorkoutDataSource.DataSource.CurrentFilter);
		pageWorkoutData = PageWorkoutData;
		pageWorkoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
		if (DefaultViewModel.ContainsKey("WorkoutData"))
		{
			DefaultViewModel.Remove("WorkoutData");
		}
		DefaultViewModel["WorkoutData"] = PageWorkoutData;
	}

	private void ButtonCancel_Tapped(object sender, TappedRoutedEventArgs e)
	{
		object obj = ((IDictionary<object, object>)((FrameworkElement)this).Resources)[(object)"MyFlyout"];
		((FlyoutBase)((obj is Flyout) ? obj : null)).Hide();
	}

	private async void ToggleFilter_Unchecked(object sender, RoutedEventArgs e)
	{
		WorkoutDataSource.DataSource.CurrentFilter = null;
		WorkoutData pageWorkoutData = PageWorkoutData;
		pageWorkoutData.Workouts = await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true);
		pageWorkoutData = PageWorkoutData;
		pageWorkoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
		if (DefaultViewModel.ContainsKey("WorkoutData"))
		{
			DefaultViewModel.Remove("WorkoutData");
		}
		DefaultViewModel["WorkoutData"] = PageWorkoutData;
	}

	private async void Flyout_Closed(object sender, object e)
	{
		if (!FilterAccepted)
		{
			if (ToggleFilter != null)
			{
				ToggleFilter.put_IsChecked((bool?)false);
			}
			WorkoutDataSource.DataSource.CurrentFilter = null;
			WorkoutData pageWorkoutData = PageWorkoutData;
			pageWorkoutData.Workouts = await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true);
			pageWorkoutData = PageWorkoutData;
			pageWorkoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
			if (DefaultViewModel.ContainsKey("WorkoutData"))
			{
				DefaultViewModel.Remove("WorkoutData");
			}
			DefaultViewModel["WorkoutData"] = PageWorkoutData;
		}
		FilterAccepted = false;
	}

	private async void PlusButton_Tapped(object sender, TappedRoutedEventArgs e)
	{
		FileOpenPicker val = new FileOpenPicker();
		val.put_SuggestedStartLocation((PickerLocationId)0);
		val.FileTypeFilter.Add(".tcx");
		TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(val.PickSingleFileAsync());
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
			taskAwaiter = taskAwaiter2;
		}
		StorageFile result = taskAwaiter.GetResult();
		if (result == null)
		{
			return;
		}
		List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
		WorkoutItem workoutItem = await WorkoutItem.ReadWorkoutFromTcx(result.Path);
		if (workoutItem != null)
		{
			listWorkouts.Add(workoutItem);
			await WorkoutDataSource.StoreWorkouts(listWorkouts, null, 0uL);
			WorkoutData pageWorkoutData = PageWorkoutData;
			pageWorkoutData.Workouts = await WorkoutDataSource.GetWorkoutsAsync(bForceReload: true);
			pageWorkoutData = PageWorkoutData;
			pageWorkoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
			if (DefaultViewModel.ContainsKey("WorkoutData"))
			{
				DefaultViewModel.Remove("WorkoutData");
			}
			DefaultViewModel["WorkoutData"] = PageWorkoutData;
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Application.LoadComponent((object)this, new Uri("ms-appx:///HubPage.xaml"), (ComponentResourceLocation)0);
			startDatePicker = (DatePicker)((FrameworkElement)this).FindName("startDatePicker");
			endDatePicker = (DatePicker)((FrameworkElement)this).FindName("endDatePicker");
			MapPicker = (MapControl)((FrameworkElement)this).FindName("MapPicker");
			chkMap = (CheckBox)((FrameworkElement)this).FindName("chkMap");
			chkWalk = (CheckBox)((FrameworkElement)this).FindName("chkWalk");
			chkSleep = (CheckBox)((FrameworkElement)this).FindName("chkSleep");
			chkRun = (CheckBox)((FrameworkElement)this).FindName("chkRun");
			chkBike = (CheckBox)((FrameworkElement)this).FindName("chkBike");
			LayoutRoot = (Grid)((FrameworkElement)this).FindName("LayoutRoot");
			Hub = (Hub)((FrameworkElement)this).FindName("Hub");
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void Connect(int connectionId, object target)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
		{
			FlyoutBase val5 = (FlyoutBase)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<EventHandler<object>, EventRegistrationToken>)val5.add_Closed, (Action<EventRegistrationToken>)val5.remove_Closed, (EventHandler<object>)Flyout_Closed);
			break;
		}
		case 2:
		{
			UIElement val3 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val3.add_Tapped, (Action<EventRegistrationToken>)val3.remove_Tapped, new TappedEventHandler(PlusButton_Tapped));
			break;
		}
		case 3:
		{
			ToggleButton val4 = (ToggleButton)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<RoutedEventHandler, EventRegistrationToken>)val4.add_Checked, (Action<EventRegistrationToken>)val4.remove_Checked, new RoutedEventHandler(ToggleButton_Checked));
			val4 = (ToggleButton)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<RoutedEventHandler, EventRegistrationToken>)val4.add_Unchecked, (Action<EventRegistrationToken>)val4.remove_Unchecked, new RoutedEventHandler(ToggleFilter_Unchecked));
			break;
		}
		case 4:
		{
			UIElement val3 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val3.add_Tapped, (Action<EventRegistrationToken>)val3.remove_Tapped, new TappedEventHandler(BackupDatabase_Tapped));
			break;
		}
		case 5:
		{
			UIElement val3 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val3.add_Tapped, (Action<EventRegistrationToken>)val3.remove_Tapped, new TappedEventHandler(ButtonOK_Tapped));
			break;
		}
		case 6:
		{
			UIElement val3 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val3.add_Tapped, (Action<EventRegistrationToken>)val3.remove_Tapped, new TappedEventHandler(ButtonCancel_Tapped));
			break;
		}
		case 7:
		{
			ButtonBase val2 = (ButtonBase)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<RoutedEventHandler, EventRegistrationToken>)val2.add_Click, (Action<EventRegistrationToken>)val2.remove_Click, new RoutedEventHandler(btnSync_Click));
			break;
		}
		case 8:
		{
			ListViewBase val = (ListViewBase)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<ItemClickEventHandler, EventRegistrationToken>)val.add_ItemClick, (Action<EventRegistrationToken>)val.remove_ItemClick, new ItemClickEventHandler(WorkoutItem_ItemClick));
			break;
		}
		}
		_contentLoaded = true;
	}
}
