// Decompiled with JetBrains decompiler
// Type: MobileBandSync.HubPage
// Assembly: MobileBandSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AE79C20-CD20-4792-8F76-8817DEB4DE21
// Assembly location: C:\Users\Admin\Desktop\re\mobile\MobileBandSync.exe

using MobileBandSync.Common;
using MobileBandSync.Data;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace MobileBandSync
{
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

    public HubPage()
    {
      this.InitializeComponent();
      DisplayInformation.put_AutoRotationPreferences((DisplayOrientations) 2);
      this.put_NavigationCacheMode((NavigationCacheMode) 1);
      this.navigationHelper = new NavigationHelper((Page) this);
      this.navigationHelper.LoadState += new LoadStateEventHandler(this.NavigationHelper_LoadState);
      this.navigationHelper.SaveState += new SaveStateEventHandler(this.NavigationHelper_SaveState);
      this.SyncView = new SyncViewModel();
      this.MapServiceToken = "AobMbD2yKlST1QB_mh1mPfpnJGDtpm0lefHMTVPqU0NQR58-xEVO3KhAaOaqJL6y";
      WorkoutDataSource.SetMapServiceToken(this.MapServiceToken);
    }

    public NavigationHelper NavigationHelper => this.navigationHelper;

    public ObservableDictionary DefaultViewModel => this.defaultViewModel;

    public SyncViewModel SyncView { get; set; }

    public DispatcherTimer DeviceTimer { get; private set; }

    public string MapServiceToken { get; private set; }

    public bool FilterAccepted { get; private set; }

    public bool MapPickerInitialized { get; private set; }

    public ToggleButton ToggleFilter { get; private set; }

    private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
    {
      if (this.DefaultViewModel.ContainsKey("WorkoutData"))
        this.DefaultViewModel.Remove("WorkoutData");
      WorkoutData workoutData = this.PageWorkoutData;
      IEnumerable<WorkoutItem> workoutsAsync = await WorkoutDataSource.GetWorkoutsAsync(true);
      workoutData.Workouts = workoutsAsync;
      workoutData = (WorkoutData) null;
      workoutData = this.PageWorkoutData;
      string workoutSummaryAsync = await WorkoutDataSource.GetWorkoutSummaryAsync();
      workoutData.WorkoutTitle = workoutSummaryAsync;
      workoutData = (WorkoutData) null;
      this.DefaultViewModel["WorkoutData"] = (object) this.PageWorkoutData;
      if (this.DefaultViewModel.ContainsKey("SyncView"))
        return;
      this.SyncView.Enabled = false;
      this.SyncView.Connected = false;
      this.DefaultViewModel["SyncView"] = (object) this.SyncView;
      this.SyncView.ConnectionText = "Disconnected";
      this.SyncView.DeviceText = "";
      this.SyncView.StatusText = "";
      this.SyncView.ConnectionLog = "";
      if (await this.SyncView.StartDeviceSearch())
        return;
      this.DeviceTimer = new DispatcherTimer();
      this.DeviceTimer.put_Interval(new TimeSpan(0, 0, 10));
      DispatcherTimer deviceTimer = this.DeviceTimer;
      WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(deviceTimer.add_Tick), new Action<EventRegistrationToken>(deviceTimer.remove_Tick), new EventHandler<object>(this.OnDeviceTimer));
      this.DeviceTimer.Start();
    }

    private async void OnDeviceTimer(object sender, object e)
    {
      this.DeviceTimer.Stop();
      if (await this.SyncView.StartDeviceSearch())
        return;
      this.DeviceTimer.Start();
    }

    private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
    {
    }

    private void WorkoutItem_ItemClick(object sender, ItemClickEventArgs e)
    {
      try
      {
        if (e.ClickedItem == null)
          return;
        int workoutId = ((WorkoutItem) e.ClickedItem).WorkoutId;
        if (!(e.ClickedItem is WorkoutItem clickedItem))
          return;
        Type type = typeof (SectionPage);
        if (clickedItem.WorkoutType == (byte) 21)
          type = typeof (SleepPage);
        this.Frame.Navigate(type, (object) workoutId);
      }
      catch
      {
      }
    }

    private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (!this.Frame.Navigate(typeof (ItemPage), (object) ((TrackItem) e.ClickedItem).UniqueId))
        throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
    }

    public async void btnSync_Click(object sender, RoutedEventArgs e)
    {
      IEnumerable<WorkoutItem> workoutItems = await this.SyncView.StartDeviceSync();
      this.PageWorkoutData.Workouts = (IEnumerable<WorkoutItem>) WorkoutDataSource.GetWorkouts();
      WorkoutData workoutData = this.PageWorkoutData;
      string workoutSummaryAsync = await WorkoutDataSource.GetWorkoutSummaryAsync();
      workoutData.WorkoutTitle = workoutSummaryAsync;
      workoutData = (WorkoutData) null;
      if (this.PageWorkoutData.Workouts == null)
        return;
      if (this.DefaultViewModel.ContainsKey("WorkoutData"))
        this.DefaultViewModel.Remove("WorkoutData");
      this.DefaultViewModel["WorkoutData"] = (object) this.PageWorkoutData;
    }

    protected virtual void OnNavigatedTo(NavigationEventArgs e) => this.navigationHelper.OnNavigatedTo(e);

    protected virtual void OnNavigatedFrom(NavigationEventArgs e) => this.navigationHelper.OnNavigatedFrom(e);

    private async void BackupDatabase_Tapped(object sender, TappedRoutedEventArgs e)
    {
      FolderPicker folderPicker = new FolderPicker();
      folderPicker.put_SuggestedStartLocation((PickerLocationId) 0);
      folderPicker.FileTypeFilter.Add("*");
      StorageFolder targetFolder = await folderPicker.PickSingleFolderAsync();
      if (targetFolder == null)
        return;
      int num = await WorkoutDataSource.BackupDatabase(targetFolder) ? 1 : 0;
    }

    private async void ToggleButton_Checked(object sender, RoutedEventArgs e)
    {
      Flyout resource = ((IDictionary<object, object>) ((FrameworkElement) this).Resources)[(object) "MyFlyout"] as Flyout;
      if (!(sender is ToggleButton toggleButton))
        return;
      this.ToggleFilter = toggleButton;
      if ((DateTimeOffset) DateTime.Now - this.startDatePicker.Date < new TimeSpan(1, 0, 0))
        this.startDatePicker.put_Date((DateTimeOffset) (DateTime.Now - new TimeSpan(5475, 0, 0, 0, 0)));
      if ((DateTimeOffset) DateTime.Now - this.endDatePicker.Date < new TimeSpan(1, 0, 0))
        this.endDatePicker.put_Date((DateTimeOffset) DateTime.Now);
      ((FlyoutBase) resource).ShowAt((FrameworkElement) toggleButton);
      if (this.MapPickerInitialized)
        return;
      this.MapPickerInitialized = true;
      try
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        HubPage.\u003C\u003Ec__DisplayClass42_0 cDisplayClass420 = new HubPage.\u003C\u003Ec__DisplayClass42_0();
        // ISSUE: reference to a compiler-generated field
        cDisplayClass420.\u003C\u003E4__this = this;
        Geolocator geolocator = new Geolocator();
        geolocator.put_DesiredAccuracyInMeters(new uint?(500U));
        // ISSUE: reference to a compiler-generated field
        Geoposition pos = cDisplayClass420.pos;
        Geoposition geopositionAsync = await geolocator.GetGeopositionAsync();
        // ISSUE: reference to a compiler-generated field
        cDisplayClass420.pos = geopositionAsync;
        // ISSUE: method pointer
        ((DependencyObject) this).Dispatcher.RunAsync((CoreDispatcherPriority) 1, new DispatchedHandler((object) cDisplayClass420, __methodptr(\u003CToggleButton_Checked\u003Eb__0)));
        cDisplayClass420 = (HubPage.\u003C\u003Ec__DisplayClass42_0) null;
      }
      catch
      {
      }
    }

    private async void ButtonOK_Tapped(object sender, TappedRoutedEventArgs e)
    {
      this.FilterAccepted = true;
      ((FlyoutBase) (((IDictionary<object, object>) ((FrameworkElement) this).Resources)[(object) "MyFlyout"] as Flyout)).Hide();
      WorkoutDataSource dataSource = WorkoutDataSource.DataSource;
      WorkoutFilterData workoutFilterData = new WorkoutFilterData();
      DateTimeOffset date1 = this.startDatePicker.Date;
      workoutFilterData.Start = this.startDatePicker.Date.DateTime;
      DateTimeOffset date2 = this.endDatePicker.Date;
      workoutFilterData.End = this.endDatePicker.Date.DateTime;
      workoutFilterData.IsBikingWorkout = ((ToggleButton) this.chkBike).IsChecked;
      workoutFilterData.IsRunningWorkout = ((ToggleButton) this.chkRun).IsChecked;
      workoutFilterData.IsWalkingWorkout = ((ToggleButton) this.chkWalk).IsChecked;
      workoutFilterData.IsSleepingWorkout = ((ToggleButton) this.chkSleep).IsChecked;
      dataSource.CurrentFilter = workoutFilterData;
      bool? isChecked = ((ToggleButton) this.chkMap).IsChecked;
      bool flag = true;
      if ((isChecked.GetValueOrDefault() == flag ? (isChecked.HasValue ? 1 : 0) : 0) != 0)
      {
        WorkoutDataSource.DataSource.CurrentFilter.SetBounds(this.MapPicker);
        WorkoutDataSource.DataSource.CurrentFilter.MapSelected = true;
      }
      else
        WorkoutDataSource.DataSource.CurrentFilter.SetBounds((MapControl) null);
      WorkoutData workoutData = this.PageWorkoutData;
      IEnumerable<WorkoutItem> workoutsAsync = await WorkoutDataSource.GetWorkoutsAsync(true, WorkoutDataSource.DataSource.CurrentFilter);
      workoutData.Workouts = workoutsAsync;
      workoutData = (WorkoutData) null;
      workoutData = this.PageWorkoutData;
      string workoutSummaryAsync = await WorkoutDataSource.GetWorkoutSummaryAsync();
      workoutData.WorkoutTitle = workoutSummaryAsync;
      workoutData = (WorkoutData) null;
      if (this.DefaultViewModel.ContainsKey("WorkoutData"))
        this.DefaultViewModel.Remove("WorkoutData");
      this.DefaultViewModel["WorkoutData"] = (object) this.PageWorkoutData;
    }

    private void ButtonCancel_Tapped(object sender, TappedRoutedEventArgs e) => ((FlyoutBase) (((IDictionary<object, object>) ((FrameworkElement) this).Resources)[(object) "MyFlyout"] as Flyout)).Hide();

    private async void ToggleFilter_Unchecked(object sender, RoutedEventArgs e)
    {
      WorkoutDataSource.DataSource.CurrentFilter = (WorkoutFilterData) null;
      WorkoutData workoutData = this.PageWorkoutData;
      IEnumerable<WorkoutItem> workoutsAsync = await WorkoutDataSource.GetWorkoutsAsync(true);
      workoutData.Workouts = workoutsAsync;
      workoutData = (WorkoutData) null;
      workoutData = this.PageWorkoutData;
      string workoutSummaryAsync = await WorkoutDataSource.GetWorkoutSummaryAsync();
      workoutData.WorkoutTitle = workoutSummaryAsync;
      workoutData = (WorkoutData) null;
      if (this.DefaultViewModel.ContainsKey("WorkoutData"))
        this.DefaultViewModel.Remove("WorkoutData");
      this.DefaultViewModel["WorkoutData"] = (object) this.PageWorkoutData;
    }

    private async void Flyout_Closed(object sender, object e)
    {
      if (!this.FilterAccepted)
      {
        if (this.ToggleFilter != null)
          this.ToggleFilter.put_IsChecked(new bool?(false));
        WorkoutDataSource.DataSource.CurrentFilter = (WorkoutFilterData) null;
        WorkoutData workoutData = this.PageWorkoutData;
        IEnumerable<WorkoutItem> workoutsAsync = await WorkoutDataSource.GetWorkoutsAsync(true);
        workoutData.Workouts = workoutsAsync;
        workoutData = (WorkoutData) null;
        workoutData = this.PageWorkoutData;
        string workoutSummaryAsync = await WorkoutDataSource.GetWorkoutSummaryAsync();
        workoutData.WorkoutTitle = workoutSummaryAsync;
        workoutData = (WorkoutData) null;
        if (this.DefaultViewModel.ContainsKey("WorkoutData"))
          this.DefaultViewModel.Remove("WorkoutData");
        this.DefaultViewModel["WorkoutData"] = (object) this.PageWorkoutData;
      }
      this.FilterAccepted = false;
    }

    private async void PlusButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
      FileOpenPicker fileOpenPicker = new FileOpenPicker();
      fileOpenPicker.put_SuggestedStartLocation((PickerLocationId) 0);
      fileOpenPicker.FileTypeFilter.Add(".tcx");
      StorageFile storageFile = await fileOpenPicker.PickSingleFileAsync();
      if (storageFile == null)
        return;
      List<WorkoutItem> listWorkouts = new List<WorkoutItem>();
      WorkoutItem workoutItem = await WorkoutItem.ReadWorkoutFromTcx(storageFile.Path);
      if (workoutItem != null)
      {
        listWorkouts.Add(workoutItem);
        List<long> longList = await WorkoutDataSource.StoreWorkouts(listWorkouts);
        WorkoutData workoutData = this.PageWorkoutData;
        IEnumerable<WorkoutItem> workoutsAsync = await WorkoutDataSource.GetWorkoutsAsync(true);
        workoutData.Workouts = workoutsAsync;
        workoutData = (WorkoutData) null;
        workoutData = this.PageWorkoutData;
        string workoutSummaryAsync = await WorkoutDataSource.GetWorkoutSummaryAsync();
        workoutData.WorkoutTitle = workoutSummaryAsync;
        workoutData = (WorkoutData) null;
        if (this.DefaultViewModel.ContainsKey("WorkoutData"))
          this.DefaultViewModel.Remove("WorkoutData");
        this.DefaultViewModel["WorkoutData"] = (object) this.PageWorkoutData;
      }
      listWorkouts = (List<WorkoutItem>) null;
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("ms-appx:///HubPage.xaml"), (ComponentResourceLocation) 0);
      this.startDatePicker = (DatePicker) ((FrameworkElement) this).FindName("startDatePicker");
      this.endDatePicker = (DatePicker) ((FrameworkElement) this).FindName("endDatePicker");
      this.MapPicker = (MapControl) ((FrameworkElement) this).FindName("MapPicker");
      this.chkMap = (CheckBox) ((FrameworkElement) this).FindName("chkMap");
      this.chkWalk = (CheckBox) ((FrameworkElement) this).FindName("chkWalk");
      this.chkSleep = (CheckBox) ((FrameworkElement) this).FindName("chkSleep");
      this.chkRun = (CheckBox) ((FrameworkElement) this).FindName("chkRun");
      this.chkBike = (CheckBox) ((FrameworkElement) this).FindName("chkBike");
      this.LayoutRoot = (Grid) ((FrameworkElement) this).FindName("LayoutRoot");
      this.Hub = (Hub) ((FrameworkElement) this).FindName("Hub");
    }

    [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
    [DebuggerNonUserCode]
    public void Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          FlyoutBase flyoutBase = (FlyoutBase) target;
          WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(flyoutBase.add_Closed), new Action<EventRegistrationToken>(flyoutBase.remove_Closed), new EventHandler<object>(this.Flyout_Closed));
          break;
        case 2:
          UIElement uiElement1 = (UIElement) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(uiElement1.add_Tapped), new Action<EventRegistrationToken>(uiElement1.remove_Tapped), new TappedEventHandler((object) this, __methodptr(PlusButton_Tapped)));
          break;
        case 3:
          ToggleButton toggleButton1 = (ToggleButton) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(toggleButton1.add_Checked), new Action<EventRegistrationToken>(toggleButton1.remove_Checked), new RoutedEventHandler((object) this, __methodptr(ToggleButton_Checked)));
          ToggleButton toggleButton2 = (ToggleButton) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(toggleButton2.add_Unchecked), new Action<EventRegistrationToken>(toggleButton2.remove_Unchecked), new RoutedEventHandler((object) this, __methodptr(ToggleFilter_Unchecked)));
          break;
        case 4:
          UIElement uiElement2 = (UIElement) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(uiElement2.add_Tapped), new Action<EventRegistrationToken>(uiElement2.remove_Tapped), new TappedEventHandler((object) this, __methodptr(BackupDatabase_Tapped)));
          break;
        case 5:
          UIElement uiElement3 = (UIElement) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(uiElement3.add_Tapped), new Action<EventRegistrationToken>(uiElement3.remove_Tapped), new TappedEventHandler((object) this, __methodptr(ButtonOK_Tapped)));
          break;
        case 6:
          UIElement uiElement4 = (UIElement) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(uiElement4.add_Tapped), new Action<EventRegistrationToken>(uiElement4.remove_Tapped), new TappedEventHandler((object) this, __methodptr(ButtonCancel_Tapped)));
          break;
        case 7:
          ButtonBase buttonBase = (ButtonBase) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(buttonBase.add_Click), new Action<EventRegistrationToken>(buttonBase.remove_Click), new RoutedEventHandler((object) this, __methodptr(btnSync_Click)));
          break;
        case 8:
          ListViewBase listViewBase = (ListViewBase) target;
          // ISSUE: method pointer
          WindowsRuntimeMarshal.AddEventHandler<ItemClickEventHandler>(new Func<ItemClickEventHandler, EventRegistrationToken>(listViewBase.add_ItemClick), new Action<EventRegistrationToken>(listViewBase.remove_ItemClick), new ItemClickEventHandler((object) this, __methodptr(WorkoutItem_ItemClick)));
          break;
      }
      this._contentLoaded = true;
    }
  }
}
