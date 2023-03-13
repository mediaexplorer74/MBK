namespace MobileBandSync
{
    using MobileBandSync.Common;
    using MobileBandSync.Data;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
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

    public sealed class HubPage : Page, IComponentConnector
    {
        private readonly MobileBandSync.Common.NavigationHelper navigationHelper;
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
        private Windows.UI.Xaml.Controls.Hub Hub;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private bool _contentLoaded;

        public HubPage()
        {
            this.InitializeComponent();
            DisplayInformation.put_AutoRotationPreferences(2);
            base.put_NavigationCacheMode(1);
            this.navigationHelper = new MobileBandSync.Common.NavigationHelper(this);
            this.navigationHelper.LoadState += new LoadStateEventHandler(this.NavigationHelper_LoadState);
            this.navigationHelper.SaveState += new SaveStateEventHandler(this.NavigationHelper_SaveState);
            this.SyncView = new SyncViewModel();
            this.MapServiceToken = "AobMbD2yKlST1QB_mh1mPfpnJGDtpm0lefHMTVPqU0NQR58-xEVO3KhAaOaqJL6y";
            WorkoutDataSource.SetMapServiceToken(this.MapServiceToken);
        }

        [AsyncStateMachine(typeof(<BackupDatabase_Tapped>d__41))]
        private void BackupDatabase_Tapped(object sender, TappedRoutedEventArgs e)
        {
            <BackupDatabase_Tapped>d__41 d__;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<BackupDatabase_Tapped>d__41>(ref d__);
        }

        [AsyncStateMachine(typeof(<btnSync_Click>d__38))]
        public void btnSync_Click(object sender, RoutedEventArgs e)
        {
            <btnSync_Click>d__38 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<btnSync_Click>d__38>(ref d__);
        }

        private void ButtonCancel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (base.get_Resources().get_Item("MyFlyout") as Flyout).Hide();
        }

        [AsyncStateMachine(typeof(<ButtonOK_Tapped>d__43))]
        private void ButtonOK_Tapped(object sender, TappedRoutedEventArgs e)
        {
            <ButtonOK_Tapped>d__43 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<ButtonOK_Tapped>d__43>(ref d__);
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void Connect(int connectionId, object target)
        {
            UIElement element;
            switch (connectionId)
            {
                case 1:
                {
                    FlyoutBase base2 = (FlyoutBase) target;
                    WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(base2, base2.add_Closed), new Action<EventRegistrationToken>(base2, base2.remove_Closed), new EventHandler<object>(this, this.Flyout_Closed));
                    break;
                }
                case 2:
                    element = (UIElement) target;
                    WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(element, element.add_Tapped), new Action<EventRegistrationToken>(element, element.remove_Tapped), new TappedEventHandler(this, this.PlusButton_Tapped));
                    break;

                case 3:
                {
                    ToggleButton button = (ToggleButton) target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(button, button.add_Checked), new Action<EventRegistrationToken>(button, button.remove_Checked), new RoutedEventHandler(this, this.ToggleButton_Checked));
                    button = (ToggleButton) target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(button, button.add_Unchecked), new Action<EventRegistrationToken>(button, button.remove_Unchecked), new RoutedEventHandler(this, this.ToggleFilter_Unchecked));
                    break;
                }
                case 4:
                    element = (UIElement) target;
                    WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(element, element.add_Tapped), new Action<EventRegistrationToken>(element, element.remove_Tapped), new TappedEventHandler(this, this.BackupDatabase_Tapped));
                    break;

                case 5:
                    element = (UIElement) target;
                    WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(element, element.add_Tapped), new Action<EventRegistrationToken>(element, element.remove_Tapped), new TappedEventHandler(this, this.ButtonOK_Tapped));
                    break;

                case 6:
                    element = (UIElement) target;
                    WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(element, element.add_Tapped), new Action<EventRegistrationToken>(element, element.remove_Tapped), new TappedEventHandler(this, this.ButtonCancel_Tapped));
                    break;

                case 7:
                {
                    ButtonBase base3 = (ButtonBase) target;
                    WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(base3, base3.add_Click), new Action<EventRegistrationToken>(base3, base3.remove_Click), new RoutedEventHandler(this, this.btnSync_Click));
                    break;
                }
                case 8:
                {
                    ListViewBase base4 = (ListViewBase) target;
                    WindowsRuntimeMarshal.AddEventHandler<ItemClickEventHandler>(new Func<ItemClickEventHandler, EventRegistrationToken>(base4, base4.add_ItemClick), new Action<EventRegistrationToken>(base4, base4.remove_ItemClick), new ItemClickEventHandler(this, this.WorkoutItem_ItemClick));
                    break;
                }
                default:
                    break;
            }
            this._contentLoaded = true;
        }

        [AsyncStateMachine(typeof(<Flyout_Closed>d__46))]
        private void Flyout_Closed(object sender, object e)
        {
            <Flyout_Closed>d__46 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<Flyout_Closed>d__46>(ref d__);
        }

        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Application.LoadComponent(this, new Uri("ms-appx:///HubPage.xaml"), 0);
                this.startDatePicker = (DatePicker) base.FindName("startDatePicker");
                this.endDatePicker = (DatePicker) base.FindName("endDatePicker");
                this.MapPicker = (MapControl) base.FindName("MapPicker");
                this.chkMap = (CheckBox) base.FindName("chkMap");
                this.chkWalk = (CheckBox) base.FindName("chkWalk");
                this.chkSleep = (CheckBox) base.FindName("chkSleep");
                this.chkRun = (CheckBox) base.FindName("chkRun");
                this.chkBike = (CheckBox) base.FindName("chkBike");
                this.LayoutRoot = (Grid) base.FindName("LayoutRoot");
                this.Hub = (Windows.UI.Xaml.Controls.Hub) base.FindName("Hub");
            }
        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            string uniqueId = ((TrackItem) e.get_ClickedItem()).UniqueId;
            if (!base.get_Frame().Navigate(typeof(ItemPage), uniqueId))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        [AsyncStateMachine(typeof(<NavigationHelper_LoadState>d__33))]
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            <NavigationHelper_LoadState>d__33 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<NavigationHelper_LoadState>d__33>(ref d__);
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        [AsyncStateMachine(typeof(<OnDeviceTimer>d__34))]
        private void OnDeviceTimer(object sender, object e)
        {
            <OnDeviceTimer>d__34 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnDeviceTimer>d__34>(ref d__);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        [AsyncStateMachine(typeof(<PlusButton_Tapped>d__47))]
        private void PlusButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            <PlusButton_Tapped>d__47 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<PlusButton_Tapped>d__47>(ref d__);
        }

        [AsyncStateMachine(typeof(<ToggleButton_Checked>d__42))]
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            <ToggleButton_Checked>d__42 d__;
            d__.<>4__this = this;
            d__.sender = sender;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<ToggleButton_Checked>d__42>(ref d__);
        }

        [AsyncStateMachine(typeof(<ToggleFilter_Unchecked>d__45))]
        private void ToggleFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            <ToggleFilter_Unchecked>d__45 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncVoidMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<ToggleFilter_Unchecked>d__45>(ref d__);
        }

        private void WorkoutItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.get_ClickedItem() != null)
                {
                    int workoutId = ((WorkoutItem) e.get_ClickedItem()).WorkoutId;
                    WorkoutItem item = e.get_ClickedItem() as WorkoutItem;
                    if (item != null)
                    {
                        Type type = typeof(SectionPage);
                        if (item.WorkoutType == 0x15)
                        {
                            type = typeof(SleepPage);
                        }
                        base.get_Frame().Navigate(type, (int) workoutId);
                    }
                }
            }
            catch
            {
            }
        }

        public MobileBandSync.Common.NavigationHelper NavigationHelper =>
            this.navigationHelper;

        public ObservableDictionary DefaultViewModel =>
            this.defaultViewModel;

        public SyncViewModel SyncView { get; set; }

        public DispatcherTimer DeviceTimer { get; private set; }

        public string MapServiceToken { get; private set; }

        public bool FilterAccepted { get; private set; }

        public bool MapPickerInitialized { get; private set; }

        public ToggleButton ToggleFilter { get; private set; }

        [CompilerGenerated]
        private struct <BackupDatabase_Tapped>d__41 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            private TaskAwaiter<StorageFolder> <>u__1;
            private TaskAwaiter<bool> <>u__2;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<StorageFolder> awaiter;
                    TaskAwaiter<bool> awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<StorageFolder>();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__2;
                        this.<>u__2 = new TaskAwaiter<bool>();
                        this.<>1__state = num = -1;
                        goto TR_0005;
                    }
                    else
                    {
                        FolderPicker picker1 = new FolderPicker();
                        picker1.put_SuggestedStartLocation(0);
                        picker1.get_FileTypeFilter().Add("*");
                        awaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFolder>(picker1.PickSingleFolderAsync());
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<StorageFolder>, HubPage.<BackupDatabase_Tapped>d__41>(ref awaiter, ref this);
                            return;
                        }
                    }
                    StorageFolder result = new TaskAwaiter<StorageFolder>().GetResult();
                    if (result == null)
                    {
                        goto TR_0004;
                    }
                    else
                    {
                        awaiter2 = WorkoutDataSource.BackupDatabase(result).GetAwaiter();
                        if (awaiter2.IsCompleted)
                        {
                            goto TR_0005;
                        }
                        else
                        {
                            this.<>1__state = num = 1;
                            this.<>u__2 = awaiter2;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, HubPage.<BackupDatabase_Tapped>d__41>(ref awaiter2, ref this);
                        }
                    }
                    return;
                TR_0005:
                    awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<bool>();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            TR_0004:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <btnSync_Click>d__38 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__1;
            private WorkoutData <>7__wrap1;
            private TaskAwaiter<string> <>u__2;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IEnumerable<WorkoutItem>> awaiter;
                    TaskAwaiter<string> awaiter2;
                    switch (num)
                    {
                        case 0:
                            awaiter = this.<>u__1;
                            this.<>u__1 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                            this.<>1__state = num = -1;
                            goto TR_000C;

                        case 1:
                            awaiter = this.<>u__1;
                            this.<>u__1 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                            this.<>1__state = num = -1;
                            awaiter.GetResult();
                            awaiter = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                            break;

                        case 2:
                            awaiter2 = this.<>u__2;
                            this.<>u__2 = new TaskAwaiter<string>();
                            this.<>1__state = num = -1;
                            goto TR_0008;

                        default:
                            awaiter = this.<>4__this.SyncView.StartDeviceSync().GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto TR_000C;
                            }
                            else
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IEnumerable<WorkoutItem>>, HubPage.<btnSync_Click>d__38>(ref awaiter, ref this);
                            }
                            return;
                    }
                    goto TR_000A;
                TR_0008:
                    awaiter2 = new TaskAwaiter<string>();
                    string result = awaiter2.GetResult();
                    this.<>7__wrap1.WorkoutTitle = result;
                    this.<>7__wrap1 = null;
                    if (this.<>4__this.PageWorkoutData.Workouts != null)
                    {
                        if (this.<>4__this.DefaultViewModel.ContainsKey("WorkoutData"))
                        {
                            this.<>4__this.DefaultViewModel.Remove("WorkoutData");
                        }
                        this.<>4__this.DefaultViewModel["WorkoutData"] = this.<>4__this.PageWorkoutData;
                    }
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                    return;
                TR_000A:
                    this.<>4__this.PageWorkoutData.Workouts = (IEnumerable<WorkoutItem>) WorkoutDataSource.GetWorkouts();
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter2 = WorkoutDataSource.GetWorkoutSummaryAsync().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0008;
                    }
                    else
                    {
                        this.<>1__state = num = 2;
                        this.<>u__2 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, HubPage.<btnSync_Click>d__38>(ref awaiter2, ref this);
                    }
                    return;
                TR_000C:
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                    goto TR_000A;
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <ButtonOK_Tapped>d__43 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            private WorkoutData <>7__wrap1;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__1;
            private TaskAwaiter<string> <>u__2;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IEnumerable<WorkoutItem>> awaiter;
                    TaskAwaiter<string> awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__2;
                        this.<>u__2 = new TaskAwaiter<string>();
                        this.<>1__state = num = -1;
                        goto TR_0007;
                    }
                    else
                    {
                        this.<>4__this.FilterAccepted = true;
                        (this.<>4__this.get_Resources().get_Item("MyFlyout") as Flyout).Hide();
                        this.<>4__this.startDatePicker.get_Date();
                        WorkoutFilterData data1 = new WorkoutFilterData();
                        data1.Start = this.<>4__this.startDatePicker.get_Date().get_DateTime();
                        this.<>4__this.endDatePicker.get_Date();
                        data1.End = this.<>4__this.endDatePicker.get_Date().get_DateTime();
                        data1.IsBikingWorkout = this.<>4__this.chkBike.get_IsChecked();
                        data1.IsRunningWorkout = this.<>4__this.chkRun.get_IsChecked();
                        data1.IsWalkingWorkout = this.<>4__this.chkWalk.get_IsChecked();
                        data1.IsSleepingWorkout = this.<>4__this.chkSleep.get_IsChecked();
                        WorkoutDataSource.DataSource.CurrentFilter = data1;
                        bool? nullable = this.<>4__this.chkMap.get_IsChecked();
                        bool flag = true;
                        if (!((nullable.GetValueOrDefault() == flag) ? ((bool) nullable.get_HasValue()) : false))
                        {
                            WorkoutDataSource.DataSource.CurrentFilter.SetBounds(null);
                        }
                        else
                        {
                            WorkoutDataSource.DataSource.CurrentFilter.SetBounds(this.<>4__this.MapPicker);
                            WorkoutDataSource.DataSource.CurrentFilter.MapSelected = true;
                        }
                        this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                        awaiter = WorkoutDataSource.GetWorkoutsAsync(true, WorkoutDataSource.DataSource.CurrentFilter).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IEnumerable<WorkoutItem>>, HubPage.<ButtonOK_Tapped>d__43>(ref awaiter, ref this);
                            return;
                        }
                    }
                    IEnumerable<WorkoutItem> result = new TaskAwaiter<IEnumerable<WorkoutItem>>().GetResult();
                    this.<>7__wrap1.Workouts = result;
                    this.<>7__wrap1 = null;
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter2 = WorkoutDataSource.GetWorkoutSummaryAsync().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0007;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__2 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, HubPage.<ButtonOK_Tapped>d__43>(ref awaiter2, ref this);
                    }
                    return;
                TR_0007:
                    awaiter2 = new TaskAwaiter<string>();
                    string str = awaiter2.GetResult();
                    this.<>7__wrap1.WorkoutTitle = str;
                    this.<>7__wrap1 = null;
                    if (this.<>4__this.DefaultViewModel.ContainsKey("WorkoutData"))
                    {
                        this.<>4__this.DefaultViewModel.Remove("WorkoutData");
                    }
                    this.<>4__this.DefaultViewModel["WorkoutData"] = this.<>4__this.PageWorkoutData;
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <Flyout_Closed>d__46 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            private WorkoutData <>7__wrap1;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__1;
            private TaskAwaiter<string> <>u__2;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IEnumerable<WorkoutItem>> awaiter;
                    TaskAwaiter<string> awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__2;
                        this.<>u__2 = new TaskAwaiter<string>();
                        this.<>1__state = num = -1;
                        goto TR_0008;
                    }
                    else if (this.<>4__this.FilterAccepted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        if (this.<>4__this.ToggleFilter != null)
                        {
                            this.<>4__this.ToggleFilter.put_IsChecked(false);
                        }
                        WorkoutDataSource.DataSource.CurrentFilter = null;
                        this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                        awaiter = WorkoutDataSource.GetWorkoutsAsync(true, null).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IEnumerable<WorkoutItem>>, HubPage.<Flyout_Closed>d__46>(ref awaiter, ref this);
                            return;
                        }
                    }
                    IEnumerable<WorkoutItem> result = new TaskAwaiter<IEnumerable<WorkoutItem>>().GetResult();
                    this.<>7__wrap1.Workouts = result;
                    this.<>7__wrap1 = null;
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter2 = WorkoutDataSource.GetWorkoutSummaryAsync().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0008;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__2 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, HubPage.<Flyout_Closed>d__46>(ref awaiter2, ref this);
                    }
                    return;
                TR_0005:
                    this.<>4__this.FilterAccepted = false;
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                    return;
                TR_0008:
                    awaiter2 = new TaskAwaiter<string>();
                    string str = awaiter2.GetResult();
                    this.<>7__wrap1.WorkoutTitle = str;
                    this.<>7__wrap1 = null;
                    if (this.<>4__this.DefaultViewModel.ContainsKey("WorkoutData"))
                    {
                        this.<>4__this.DefaultViewModel.Remove("WorkoutData");
                    }
                    this.<>4__this.DefaultViewModel["WorkoutData"] = this.<>4__this.PageWorkoutData;
                    goto TR_0005;
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <NavigationHelper_LoadState>d__33 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            private WorkoutData <>7__wrap1;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__1;
            private TaskAwaiter<string> <>u__2;
            private TaskAwaiter<bool> <>u__3;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IEnumerable<WorkoutItem>> awaiter;
                    TaskAwaiter<string> awaiter2;
                    TaskAwaiter<bool> awaiter3;
                    switch (num)
                    {
                        case 0:
                            awaiter = this.<>u__1;
                            this.<>u__1 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                            this.<>1__state = num = -1;
                            break;

                        case 1:
                            awaiter2 = this.<>u__2;
                            this.<>u__2 = new TaskAwaiter<string>();
                            this.<>1__state = num = -1;
                            goto TR_000B;

                        case 2:
                            awaiter3 = this.<>u__3;
                            this.<>u__3 = new TaskAwaiter<bool>();
                            this.<>1__state = num = -1;
                            goto TR_0007;

                        default:
                            if (this.<>4__this.DefaultViewModel.ContainsKey("WorkoutData"))
                            {
                                this.<>4__this.DefaultViewModel.Remove("WorkoutData");
                            }
                            this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                            awaiter = WorkoutDataSource.GetWorkoutsAsync(true, null).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                break;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IEnumerable<WorkoutItem>>, HubPage.<NavigationHelper_LoadState>d__33>(ref awaiter, ref this);
                            return;
                    }
                    IEnumerable<WorkoutItem> result = new TaskAwaiter<IEnumerable<WorkoutItem>>().GetResult();
                    this.<>7__wrap1.Workouts = result;
                    this.<>7__wrap1 = null;
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter2 = WorkoutDataSource.GetWorkoutSummaryAsync().GetAwaiter();
                    if (!awaiter2.IsCompleted)
                    {
                        this.<>1__state = num = 1;
                        this.<>u__2 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, HubPage.<NavigationHelper_LoadState>d__33>(ref awaiter2, ref this);
                        return;
                    }
                    goto TR_000B;
                TR_0007:
                    awaiter3 = new TaskAwaiter<bool>();
                    if (!awaiter3.GetResult())
                    {
                        this.<>4__this.DeviceTimer = new DispatcherTimer();
                        this.<>4__this.DeviceTimer.put_Interval(new TimeSpan(0, 0, 10));
                        DispatcherTimer deviceTimer = this.<>4__this.DeviceTimer;
                        WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(deviceTimer, deviceTimer.add_Tick), new Action<EventRegistrationToken>(deviceTimer, deviceTimer.remove_Tick), new EventHandler<object>(this.<>4__this, this.OnDeviceTimer));
                        this.<>4__this.DeviceTimer.Start();
                    }
                    goto TR_0005;
                TR_000B:
                    awaiter2 = new TaskAwaiter<string>();
                    string str = awaiter2.GetResult();
                    this.<>7__wrap1.WorkoutTitle = str;
                    this.<>7__wrap1 = null;
                    this.<>4__this.DefaultViewModel["WorkoutData"] = this.<>4__this.PageWorkoutData;
                    if (this.<>4__this.DefaultViewModel.ContainsKey("SyncView"))
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>4__this.SyncView.Enabled = false;
                        this.<>4__this.SyncView.Connected = false;
                        this.<>4__this.DefaultViewModel["SyncView"] = this.<>4__this.SyncView;
                        this.<>4__this.SyncView.ConnectionText = "Disconnected";
                        this.<>4__this.SyncView.DeviceText = "";
                        this.<>4__this.SyncView.StatusText = "";
                        this.<>4__this.SyncView.ConnectionLog = "";
                        awaiter3 = this.<>4__this.SyncView.StartDeviceSearch().GetAwaiter();
                        if (awaiter3.IsCompleted)
                        {
                            goto TR_0007;
                        }
                        else
                        {
                            this.<>1__state = num = 2;
                            this.<>u__3 = awaiter3;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, HubPage.<NavigationHelper_LoadState>d__33>(ref awaiter3, ref this);
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
                return;
            TR_0005:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <OnDeviceTimer>d__34 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            private TaskAwaiter<bool> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<bool> awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<bool>();
                        this.<>1__state = num = -1;
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>4__this.DeviceTimer.Stop();
                        awaiter = this.<>4__this.SyncView.StartDeviceSearch().GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0005;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, HubPage.<OnDeviceTimer>d__34>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0005:
                    awaiter = new TaskAwaiter<bool>();
                    if (!awaiter.GetResult())
                    {
                        this.<>4__this.DeviceTimer.Start();
                    }
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <PlusButton_Tapped>d__47 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            private List<WorkoutItem> <listWorkouts>5__1;
            public HubPage <>4__this;
            private TaskAwaiter<StorageFile> <>u__1;
            private TaskAwaiter<WorkoutItem> <>u__2;
            private TaskAwaiter<List<long>> <>u__3;
            private WorkoutData <>7__wrap1;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__4;
            private TaskAwaiter<string> <>u__5;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<StorageFile> awaiter;
                    TaskAwaiter<WorkoutItem> awaiter2;
                    TaskAwaiter<List<long>> awaiter3;
                    TaskAwaiter<IEnumerable<WorkoutItem>> awaiter4;
                    TaskAwaiter<string> awaiter5;
                    switch (num)
                    {
                        case 0:
                            awaiter = this.<>u__1;
                            this.<>u__1 = new TaskAwaiter<StorageFile>();
                            this.<>1__state = num = -1;
                            break;

                        case 1:
                            awaiter2 = this.<>u__2;
                            this.<>u__2 = new TaskAwaiter<WorkoutItem>();
                            this.<>1__state = num = -1;
                            goto TR_0013;

                        case 2:
                            awaiter3 = this.<>u__3;
                            this.<>u__3 = new TaskAwaiter<List<long>>();
                            this.<>1__state = num = -1;
                            goto TR_000F;

                        case 3:
                            awaiter4 = this.<>u__4;
                            this.<>u__4 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                            this.<>1__state = num = -1;
                            goto TR_000D;

                        case 4:
                            awaiter5 = this.<>u__5;
                            this.<>u__5 = new TaskAwaiter<string>();
                            this.<>1__state = num = -1;
                            goto TR_000B;

                        default:
                        {
                            FileOpenPicker picker1 = new FileOpenPicker();
                            picker1.put_SuggestedStartLocation(0);
                            picker1.get_FileTypeFilter().Add(".tcx");
                            awaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(picker1.PickSingleFileAsync());
                            if (awaiter.IsCompleted)
                            {
                                break;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<StorageFile>, HubPage.<PlusButton_Tapped>d__47>(ref awaiter, ref this);
                            return;
                        }
                    }
                    StorageFile result = new TaskAwaiter<StorageFile>().GetResult();
                    if (result == null)
                    {
                        goto TR_0007;
                    }
                    else
                    {
                        this.<listWorkouts>5__1 = new List<WorkoutItem>();
                        awaiter2 = WorkoutItem.ReadWorkoutFromTcx(result.get_Path()).GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            this.<>1__state = num = 1;
                            this.<>u__2 = awaiter2;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<WorkoutItem>, HubPage.<PlusButton_Tapped>d__47>(ref awaiter2, ref this);
                            return;
                        }
                    }
                    goto TR_0013;
                TR_0008:
                    this.<listWorkouts>5__1 = null;
                    goto TR_0007;
                TR_000B:
                    awaiter5 = new TaskAwaiter<string>();
                    string str = awaiter5.GetResult();
                    this.<>7__wrap1.WorkoutTitle = str;
                    this.<>7__wrap1 = null;
                    if (this.<>4__this.DefaultViewModel.ContainsKey("WorkoutData"))
                    {
                        this.<>4__this.DefaultViewModel.Remove("WorkoutData");
                    }
                    this.<>4__this.DefaultViewModel["WorkoutData"] = this.<>4__this.PageWorkoutData;
                    goto TR_0008;
                TR_000D:
                    awaiter4 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                    IEnumerable<WorkoutItem> enumerable = awaiter4.GetResult();
                    this.<>7__wrap1.Workouts = enumerable;
                    this.<>7__wrap1 = null;
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter5 = WorkoutDataSource.GetWorkoutSummaryAsync().GetAwaiter();
                    if (awaiter5.IsCompleted)
                    {
                        goto TR_000B;
                    }
                    else
                    {
                        this.<>1__state = num = 4;
                        this.<>u__5 = awaiter5;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, HubPage.<PlusButton_Tapped>d__47>(ref awaiter5, ref this);
                    }
                    return;
                TR_000F:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter<List<long>>();
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter4 = WorkoutDataSource.GetWorkoutsAsync(true, null).GetAwaiter();
                    if (!awaiter4.IsCompleted)
                    {
                        this.<>1__state = num = 3;
                        this.<>u__4 = awaiter4;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IEnumerable<WorkoutItem>>, HubPage.<PlusButton_Tapped>d__47>(ref awaiter4, ref this);
                        return;
                    }
                    goto TR_000D;
                TR_0013:
                    awaiter2 = new TaskAwaiter<WorkoutItem>();
                    WorkoutItem item = awaiter2.GetResult();
                    if (item == null)
                    {
                        goto TR_0008;
                    }
                    else
                    {
                        this.<listWorkouts>5__1.Add(item);
                        awaiter3 = WorkoutDataSource.StoreWorkouts(this.<listWorkouts>5__1, null, 0UL).GetAwaiter();
                        if (!awaiter3.IsCompleted)
                        {
                            this.<>1__state = num = 2;
                            this.<>u__3 = awaiter3;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<long>>, HubPage.<PlusButton_Tapped>d__47>(ref awaiter3, ref this);
                            return;
                        }
                    }
                    goto TR_000F;
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            TR_0007:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <ToggleButton_Checked>d__42 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            public object sender;
            private HubPage.<>c__DisplayClass42_0 <>8__1;
            private HubPage.<>c__DisplayClass42_0 <>7__wrap1;
            private TaskAwaiter<Geoposition> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    if (num != 0)
                    {
                        Flyout flyout = this.<>4__this.get_Resources().get_Item("MyFlyout") as Flyout;
                        ToggleButton sender = this.sender as ToggleButton;
                        if (sender == null)
                        {
                            goto TR_0002;
                        }
                        else
                        {
                            this.<>4__this.ToggleFilter = sender;
                            if ((DateTime.get_Now() - this.<>4__this.startDatePicker.get_Date()) < new TimeSpan(1, 0, 0))
                            {
                                this.<>4__this.startDatePicker.put_Date(DateTime.get_Now() - new TimeSpan(0x1563, 0, 0, 0, 0));
                            }
                            if ((DateTime.get_Now() - this.<>4__this.endDatePicker.get_Date()) < new TimeSpan(1, 0, 0))
                            {
                                this.<>4__this.endDatePicker.put_Date(DateTime.get_Now());
                            }
                            flyout.ShowAt(sender);
                            if (this.<>4__this.MapPickerInitialized)
                            {
                                goto TR_0002;
                            }
                            else
                            {
                                this.<>4__this.MapPickerInitialized = true;
                            }
                        }
                    }
                    try
                    {
                        TaskAwaiter<Geoposition> awaiter;
                        if (num == 0)
                        {
                            awaiter = this.<>u__1;
                            this.<>u__1 = new TaskAwaiter<Geoposition>();
                            this.<>1__state = num = -1;
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>8__1 = new HubPage.<>c__DisplayClass42_0();
                            this.<>8__1.<>4__this = this.<>4__this;
                            Geolocator geolocator1 = new Geolocator();
                            geolocator1.put_DesiredAccuracyInMeters(500);
                            this.<>7__wrap1 = this.<>8__1;
                            Geoposition pos = this.<>7__wrap1.pos;
                            awaiter = WindowsRuntimeSystemExtensions.GetAwaiter<Geoposition>(geolocator1.GetGeopositionAsync());
                            if (awaiter.IsCompleted)
                            {
                                goto TR_0004;
                            }
                            else
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Geoposition>, HubPage.<ToggleButton_Checked>d__42>(ref awaiter, ref this);
                            }
                        }
                        return;
                    TR_0004:
                        awaiter = new TaskAwaiter<Geoposition>();
                        Geoposition result = awaiter.GetResult();
                        this.<>7__wrap1.pos = result;
                        this.<>7__wrap1 = null;
                        this.<>4__this.get_Dispatcher().RunAsync(1, new DispatchedHandler(this.<>8__1, this.<ToggleButton_Checked>b__0));
                        this.<>8__1 = null;
                    }
                    catch
                    {
                    }
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            TR_0002:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <ToggleFilter_Unchecked>d__45 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public HubPage <>4__this;
            private WorkoutData <>7__wrap1;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__1;
            private TaskAwaiter<string> <>u__2;

            private void MoveNext()
            {
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IEnumerable<WorkoutItem>> awaiter;
                    TaskAwaiter<string> awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<IEnumerable<WorkoutItem>>();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__2;
                        this.<>u__2 = new TaskAwaiter<string>();
                        this.<>1__state = num = -1;
                        goto TR_0007;
                    }
                    else
                    {
                        WorkoutDataSource.DataSource.CurrentFilter = null;
                        this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                        awaiter = WorkoutDataSource.GetWorkoutsAsync(true, null).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IEnumerable<WorkoutItem>>, HubPage.<ToggleFilter_Unchecked>d__45>(ref awaiter, ref this);
                            return;
                        }
                    }
                    IEnumerable<WorkoutItem> result = new TaskAwaiter<IEnumerable<WorkoutItem>>().GetResult();
                    this.<>7__wrap1.Workouts = result;
                    this.<>7__wrap1 = null;
                    this.<>7__wrap1 = this.<>4__this.PageWorkoutData;
                    awaiter2 = WorkoutDataSource.GetWorkoutSummaryAsync().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0007;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__2 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, HubPage.<ToggleFilter_Unchecked>d__45>(ref awaiter2, ref this);
                    }
                    return;
                TR_0007:
                    awaiter2 = new TaskAwaiter<string>();
                    string str = awaiter2.GetResult();
                    this.<>7__wrap1.WorkoutTitle = str;
                    this.<>7__wrap1 = null;
                    if (this.<>4__this.DefaultViewModel.ContainsKey("WorkoutData"))
                    {
                        this.<>4__this.DefaultViewModel.Remove("WorkoutData");
                    }
                    this.<>4__this.DefaultViewModel["WorkoutData"] = this.<>4__this.PageWorkoutData;
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }
    }
}

