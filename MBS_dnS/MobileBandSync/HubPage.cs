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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync
{
	// Token: 0x02000003 RID: 3
	public sealed class HubPage : Page, IComponentConnector
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000021B8 File Offset: 0x000003B8
		public HubPage()
		{
			this.InitializeComponent();
			DisplayInformation.put_AutoRotationPreferences(2);
			base.put_NavigationCacheMode(1);
			this.navigationHelper = new NavigationHelper(this);
			this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
			this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
			this.SyncView = new SyncViewModel();
			this.MapServiceToken = "AobMbD2yKlST1QB_mh1mPfpnJGDtpm0lefHMTVPqU0NQR58-xEVO3KhAaOaqJL6y";
			WorkoutDataSource.SetMapServiceToken(this.MapServiceToken);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000225F File Offset: 0x0000045F
		public NavigationHelper NavigationHelper
		{
			get
			{
				return this.navigationHelper;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002267 File Offset: 0x00000467
		public ObservableDictionary DefaultViewModel
		{
			get
			{
				return this.defaultViewModel;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000226F File Offset: 0x0000046F
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002277 File Offset: 0x00000477
		public SyncViewModel SyncView { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002280 File Offset: 0x00000480
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002288 File Offset: 0x00000488
		public DispatcherTimer DeviceTimer { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002291 File Offset: 0x00000491
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002299 File Offset: 0x00000499
		public string MapServiceToken { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000022A2 File Offset: 0x000004A2
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000022AA File Offset: 0x000004AA
		public bool FilterAccepted { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000022B3 File Offset: 0x000004B3
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000022BB File Offset: 0x000004BB
		public bool MapPickerInitialized { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000022C4 File Offset: 0x000004C4
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000022CC File Offset: 0x000004CC
		public ToggleButton ToggleFilter { get; private set; }

		// Token: 0x06000019 RID: 25 RVA: 0x000022D8 File Offset: 0x000004D8
		private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
		{
			if (this.DefaultViewModel.ContainsKey("WorkoutData"))
			{
				this.DefaultViewModel.Remove("WorkoutData");
			}
			WorkoutData workoutData = this.PageWorkoutData;
			IEnumerable<WorkoutItem> workouts = await WorkoutDataSource.GetWorkoutsAsync(true, null);
			workoutData.Workouts = workouts;
			workoutData = null;
			workoutData = this.PageWorkoutData;
			workoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
			workoutData = null;
			this.DefaultViewModel["WorkoutData"] = this.PageWorkoutData;
			if (!this.DefaultViewModel.ContainsKey("SyncView"))
			{
				this.SyncView.Enabled = false;
				this.SyncView.Connected = false;
				this.DefaultViewModel["SyncView"] = this.SyncView;
				this.SyncView.ConnectionText = "Disconnected";
				this.SyncView.DeviceText = "";
				this.SyncView.StatusText = "";
				this.SyncView.ConnectionLog = "";
				if (!(await this.SyncView.StartDeviceSearch()))
				{
					this.DeviceTimer = new DispatcherTimer();
					this.DeviceTimer.put_Interval(new TimeSpan(0, 0, 10));
					DispatcherTimer deviceTimer = this.DeviceTimer;
					WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(deviceTimer.add_Tick), new Action<EventRegistrationToken>(deviceTimer.remove_Tick), new EventHandler<object>(this.OnDeviceTimer));
					this.DeviceTimer.Start();
				}
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002314 File Offset: 0x00000514
		private async void OnDeviceTimer(object sender, object e)
		{
			this.DeviceTimer.Stop();
			if (!(await this.SyncView.StartDeviceSearch()))
			{
				this.DeviceTimer.Start();
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000234D File Offset: 0x0000054D
		private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
		{
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002350 File Offset: 0x00000550
		private void WorkoutItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (e.ClickedItem != null)
				{
					int workoutId = ((WorkoutItem)e.ClickedItem).WorkoutId;
					WorkoutItem workoutItem = e.ClickedItem as WorkoutItem;
					if (workoutItem != null)
					{
						Type typeFromHandle = typeof(SectionPage);
						if (workoutItem.WorkoutType == 21)
						{
							typeFromHandle = typeof(SleepPage);
						}
						base.Frame.Navigate(typeFromHandle, workoutId);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023D0 File Offset: 0x000005D0
		private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
		{
			string uniqueId = ((TrackItem)e.ClickedItem).UniqueId;
			if (!base.Frame.Navigate(typeof(ItemPage), uniqueId))
			{
				throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000241C File Offset: 0x0000061C
		public async void btnSync_Click(object sender, RoutedEventArgs e)
		{
			await this.SyncView.StartDeviceSync();
			IL_B5:
			this.PageWorkoutData.Workouts = WorkoutDataSource.GetWorkouts();
			WorkoutData workoutData = this.PageWorkoutData;
			workoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
			workoutData = null;
			if (this.PageWorkoutData.Workouts != null)
			{
				if (this.DefaultViewModel.ContainsKey("WorkoutData"))
				{
					this.DefaultViewModel.Remove("WorkoutData");
				}
				this.DefaultViewModel["WorkoutData"] = this.PageWorkoutData;
			}
			return;
			TaskAwaiter<IEnumerable<WorkoutItem>> taskAwaiter2;
			TaskAwaiter<IEnumerable<WorkoutItem>> taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<IEnumerable<WorkoutItem>>);
			taskAwaiter.GetResult();
			taskAwaiter = default(TaskAwaiter<IEnumerable<WorkoutItem>>);
			goto IL_B5;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002455 File Offset: 0x00000655
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedTo(e);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002463 File Offset: 0x00000663
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedFrom(e);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002474 File Offset: 0x00000674
		private async void BackupDatabase_Tapped(object sender, TappedRoutedEventArgs e)
		{
			FolderPicker folderPicker = new FolderPicker();
			folderPicker.put_SuggestedStartLocation(0);
			folderPicker.FileTypeFilter.Add("*");
			StorageFolder storageFolder = await folderPicker.PickSingleFolderAsync();
			if (storageFolder != null)
			{
				await WorkoutDataSource.BackupDatabase(storageFolder);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024A8 File Offset: 0x000006A8
		private async void ToggleButton_Checked(object sender, RoutedEventArgs e)
		{
			Flyout flyout = this.Resources["MyFlyout"] as Flyout;
			ToggleButton toggleButton = sender as ToggleButton;
			if (toggleButton != null)
			{
				this.ToggleFilter = toggleButton;
				if (DateTime.Now - this.startDatePicker.Date < new TimeSpan(1, 0, 0))
				{
					this.startDatePicker.put_Date(DateTime.Now - new TimeSpan(5475, 0, 0, 0, 0));
				}
				if (DateTime.Now - this.endDatePicker.Date < new TimeSpan(1, 0, 0))
				{
					this.endDatePicker.put_Date(DateTime.Now);
				}
				flyout.ShowAt(toggleButton);
				if (!this.MapPickerInitialized)
				{
					this.MapPickerInitialized = true;
					try
					{
						HubPage.<>c__DisplayClass42_0 CS$<>8__locals1 = new HubPage.<>c__DisplayClass42_0();
						CS$<>8__locals1.<>4__this = this;
						Geolocator geolocator = new Geolocator();
						geolocator.put_DesiredAccuracyInMeters(new uint?(500U));
						HubPage.<>c__DisplayClass42_0 CS$<>8__locals2 = CS$<>8__locals1;
						Geoposition pos = CS$<>8__locals2.pos;
						Geoposition pos2 = await geolocator.GetGeopositionAsync();
						CS$<>8__locals2.pos = pos2;
						CS$<>8__locals2 = null;
						this.Dispatcher.RunAsync(1, delegate()
						{
							BasicGeoposition basicGeoposition = default(BasicGeoposition);
							basicGeoposition.Latitude = CS$<>8__locals1.pos.Coordinate.Latitude;
							basicGeoposition.Longitude = CS$<>8__locals1.pos.Coordinate.Longitude;
							basicGeoposition.Altitude = CS$<>8__locals1.pos.Coordinate.Altitude.Value;
							BasicGeoposition basicGeoposition2 = basicGeoposition;
							CS$<>8__locals1.<>4__this.MapPicker.put_ZoomLevel(10.0);
							CS$<>8__locals1.<>4__this.MapPicker.put_Center(new Geopoint(basicGeoposition2));
						});
						CS$<>8__locals1 = null;
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000024EC File Offset: 0x000006EC
		private async void ButtonOK_Tapped(object sender, TappedRoutedEventArgs e)
		{
			this.FilterAccepted = true;
			(this.Resources["MyFlyout"] as Flyout).Hide();
			WorkoutDataSource dataSource = WorkoutDataSource.DataSource;
			WorkoutFilterData workoutFilterData = new WorkoutFilterData();
			DateTimeOffset date = this.startDatePicker.Date;
			workoutFilterData.Start = this.startDatePicker.Date.DateTime;
			DateTimeOffset date2 = this.endDatePicker.Date;
			workoutFilterData.End = this.endDatePicker.Date.DateTime;
			workoutFilterData.IsBikingWorkout = this.chkBike.IsChecked;
			workoutFilterData.IsRunningWorkout = this.chkRun.IsChecked;
			workoutFilterData.IsWalkingWorkout = this.chkWalk.IsChecked;
			workoutFilterData.IsSleepingWorkout = this.chkSleep.IsChecked;
			dataSource.CurrentFilter = workoutFilterData;
			if (this.chkMap.IsChecked == true)
			{
				WorkoutDataSource.DataSource.CurrentFilter.SetBounds(this.MapPicker);
				WorkoutDataSource.DataSource.CurrentFilter.MapSelected = true;
			}
			else
			{
				WorkoutDataSource.DataSource.CurrentFilter.SetBounds(null);
			}
			WorkoutData workoutData = this.PageWorkoutData;
			IEnumerable<WorkoutItem> workouts = await WorkoutDataSource.GetWorkoutsAsync(true, WorkoutDataSource.DataSource.CurrentFilter);
			workoutData.Workouts = workouts;
			workoutData = null;
			workoutData = this.PageWorkoutData;
			workoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
			workoutData = null;
			if (this.DefaultViewModel.ContainsKey("WorkoutData"))
			{
				this.DefaultViewModel.Remove("WorkoutData");
			}
			this.DefaultViewModel["WorkoutData"] = this.PageWorkoutData;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002525 File Offset: 0x00000725
		private void ButtonCancel_Tapped(object sender, TappedRoutedEventArgs e)
		{
			(base.Resources["MyFlyout"] as Flyout).Hide();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002544 File Offset: 0x00000744
		private async void ToggleFilter_Unchecked(object sender, RoutedEventArgs e)
		{
			WorkoutDataSource.DataSource.CurrentFilter = null;
			WorkoutData workoutData = this.PageWorkoutData;
			IEnumerable<WorkoutItem> workouts = await WorkoutDataSource.GetWorkoutsAsync(true, null);
			workoutData.Workouts = workouts;
			workoutData = null;
			workoutData = this.PageWorkoutData;
			workoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
			workoutData = null;
			if (this.DefaultViewModel.ContainsKey("WorkoutData"))
			{
				this.DefaultViewModel.Remove("WorkoutData");
			}
			this.DefaultViewModel["WorkoutData"] = this.PageWorkoutData;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002580 File Offset: 0x00000780
		private async void Flyout_Closed(object sender, object e)
		{
			if (!this.FilterAccepted)
			{
				if (this.ToggleFilter != null)
				{
					this.ToggleFilter.put_IsChecked(new bool?(false));
				}
				WorkoutDataSource.DataSource.CurrentFilter = null;
				WorkoutData workoutData = this.PageWorkoutData;
				IEnumerable<WorkoutItem> workouts = await WorkoutDataSource.GetWorkoutsAsync(true, null);
				workoutData.Workouts = workouts;
				workoutData = null;
				workoutData = this.PageWorkoutData;
				workoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
				workoutData = null;
				if (this.DefaultViewModel.ContainsKey("WorkoutData"))
				{
					this.DefaultViewModel.Remove("WorkoutData");
				}
				this.DefaultViewModel["WorkoutData"] = this.PageWorkoutData;
			}
			this.FilterAccepted = false;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000025BC File Offset: 0x000007BC
		private async void PlusButton_Tapped(object sender, TappedRoutedEventArgs e)
		{
			FileOpenPicker fileOpenPicker = new FileOpenPicker();
			fileOpenPicker.put_SuggestedStartLocation(0);
			fileOpenPicker.FileTypeFilter.Add(".tcx");
			StorageFile storageFile = await fileOpenPicker.PickSingleFileAsync();
			if (storageFile != null)
			{
				List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
				WorkoutItem workoutItem = await WorkoutItem.ReadWorkoutFromTcx(storageFile.Path);
				if (workoutItem != null)
				{
					listWorkouts.Add(workoutItem);
					await WorkoutDataSource.StoreWorkouts(listWorkouts, null, 0UL);
					WorkoutData workoutData = this.PageWorkoutData;
					workoutData.Workouts = await WorkoutDataSource.GetWorkoutsAsync(true, null);
					workoutData = null;
					workoutData = this.PageWorkoutData;
					workoutData.WorkoutTitle = await WorkoutDataSource.GetWorkoutSummaryAsync();
					workoutData = null;
					if (this.DefaultViewModel.ContainsKey("WorkoutData"))
					{
						this.DefaultViewModel.Remove("WorkoutData");
					}
					this.DefaultViewModel["WorkoutData"] = this.PageWorkoutData;
				}
				listWorkouts = null;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000025F8 File Offset: 0x000007F8
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Application.LoadComponent(this, new Uri("ms-appx:///HubPage.xaml"), 0);
			this.startDatePicker = (DatePicker)base.FindName("startDatePicker");
			this.endDatePicker = (DatePicker)base.FindName("endDatePicker");
			this.MapPicker = (MapControl)base.FindName("MapPicker");
			this.chkMap = (CheckBox)base.FindName("chkMap");
			this.chkWalk = (CheckBox)base.FindName("chkWalk");
			this.chkSleep = (CheckBox)base.FindName("chkSleep");
			this.chkRun = (CheckBox)base.FindName("chkRun");
			this.chkBike = (CheckBox)base.FindName("chkBike");
			this.LayoutRoot = (Grid)base.FindName("LayoutRoot");
			this.Hub = (Hub)base.FindName("Hub");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002704 File Offset: 0x00000904
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
			{
				FlyoutBase @object = (FlyoutBase)target;
				WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(@object.add_Closed), new Action<EventRegistrationToken>(@object.remove_Closed), new EventHandler<object>(this.Flyout_Closed));
				break;
			}
			case 2:
			{
				UIElement object2 = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(object2.add_Tapped), new Action<EventRegistrationToken>(object2.remove_Tapped), new TappedEventHandler(this.PlusButton_Tapped));
				break;
			}
			case 3:
			{
				ToggleButton object3 = (ToggleButton)target;
				WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(object3.add_Checked), new Action<EventRegistrationToken>(object3.remove_Checked), new RoutedEventHandler(this.ToggleButton_Checked));
				object3 = (ToggleButton)target;
				WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(object3.add_Unchecked), new Action<EventRegistrationToken>(object3.remove_Unchecked), new RoutedEventHandler(this.ToggleFilter_Unchecked));
				break;
			}
			case 4:
			{
				UIElement object2 = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(object2.add_Tapped), new Action<EventRegistrationToken>(object2.remove_Tapped), new TappedEventHandler(this.BackupDatabase_Tapped));
				break;
			}
			case 5:
			{
				UIElement object2 = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(object2.add_Tapped), new Action<EventRegistrationToken>(object2.remove_Tapped), new TappedEventHandler(this.ButtonOK_Tapped));
				break;
			}
			case 6:
			{
				UIElement object2 = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(object2.add_Tapped), new Action<EventRegistrationToken>(object2.remove_Tapped), new TappedEventHandler(this.ButtonCancel_Tapped));
				break;
			}
			case 7:
			{
				ButtonBase object4 = (ButtonBase)target;
				WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(object4.add_Click), new Action<EventRegistrationToken>(object4.remove_Click), new RoutedEventHandler(this.btnSync_Click));
				break;
			}
			case 8:
			{
				ListViewBase object5 = (ListViewBase)target;
				WindowsRuntimeMarshal.AddEventHandler<ItemClickEventHandler>(new Func<ItemClickEventHandler, EventRegistrationToken>(object5.add_ItemClick), new Action<EventRegistrationToken>(object5.remove_ItemClick), new ItemClickEventHandler(this.WorkoutItem_ItemClick));
				break;
			}
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000004 RID: 4
		private readonly NavigationHelper navigationHelper;

		// Token: 0x04000005 RID: 5
		private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

		// Token: 0x04000006 RID: 6
		private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

		// Token: 0x04000007 RID: 7
		public WorkoutData PageWorkoutData = new WorkoutData();

		// Token: 0x0400000E RID: 14
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private DatePicker startDatePicker;

		// Token: 0x0400000F RID: 15
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private DatePicker endDatePicker;

		// Token: 0x04000010 RID: 16
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private MapControl MapPicker;

		// Token: 0x04000011 RID: 17
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private CheckBox chkMap;

		// Token: 0x04000012 RID: 18
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private CheckBox chkWalk;

		// Token: 0x04000013 RID: 19
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private CheckBox chkSleep;

		// Token: 0x04000014 RID: 20
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private CheckBox chkRun;

		// Token: 0x04000015 RID: 21
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private CheckBox chkBike;

		// Token: 0x04000016 RID: 22
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid LayoutRoot;

		// Token: 0x04000017 RID: 23
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Hub Hub;

		// Token: 0x04000018 RID: 24
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private bool _contentLoaded;
	}
}
