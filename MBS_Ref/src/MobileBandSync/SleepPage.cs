namespace MobileBandSync
{
    using MobileBandSync.Common;
    using MobileBandSync.Data;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Markup;
    using Windows.UI.Xaml.Navigation;

    public sealed class SleepPage : Page, IComponentConnector
    {
        private readonly MobileBandSync.Common.NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel;
        private TimeSpan awakeTimeSpan;
        private TimeSpan sleepTimeSpan;
        private Color colAwakeBar;
        private Color colLightBar;
        private Color colRestfulBar;
        private Color colHeaderBackground;
        private Color colHeaderSummaryDate;
        private Color colHeaderSummaryTime;
        private Color colHeaderSummaryText;
        private Color colDiagramHeader;
        private Color colDiagramXAxisText;
        private Color colDiagramYAxisText;
        private Color colDiagramFooterTitle;
        private Color colDiagramFooterSubtitle;
        private Color colDiagramFooterDuration;
        private Color colDiagramGrid;
        private List<string> slCadence;
        private CultureInfo sleepPageCultureInfo;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Page pageRoot;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid DiagramGrid;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock Summary;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock Date;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock LightHours;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock LightMinutes;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock RestfulHours;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock RestfulMinutes;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock Hours;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock Minutes;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock AsleepTime;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private TextBlock AwakeTime;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid XAxis;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid BarPanel;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Canvas SleepDiagrams;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid LineHour;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private Grid HourText;
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
        private bool _contentLoaded;

        public SleepPage();
        private bool AddAwakeBar(TimeSpan dtLength);
        private bool AddBar(SleepPage.SleepType sleepType, TimeSpan tsLength);
        private bool AddLightBar(TimeSpan dtLength);
        private bool AddRestfulBar(TimeSpan dtLength);
        private void AddSleepItem(TrackItem item, ref uint lastSleepType, ref uint lastSegmentType, ref DateTime lastSegmentDate);
        private bool AddXAxis(DateTime dtStart, DateTime dtEnd);
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void Connect(int connectionId, object target);
        private bool DrawSleepDiagram();
        [AsyncStateMachine(typeof(SleepPage.<Grid_Tapped>d__50))]
        private void Grid_Tapped(object sender, TappedRoutedEventArgs e);
        [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0"), DebuggerNonUserCode]
        public void InitializeComponent();
        [AsyncStateMachine(typeof(SleepPage.<Left_Tapped>d__47))]
        private void Left_Tapped(object sender, TappedRoutedEventArgs e);
        [AsyncStateMachine(typeof(SleepPage.<NavigationHelper_LoadState>d__42))]
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e);
        [AsyncStateMachine(typeof(SleepPage.<NavigationHelper_SaveState>d__43))]
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e);
        protected override void OnNavigatedFrom(NavigationEventArgs e);
        protected override void OnNavigatedTo(NavigationEventArgs e);
        [AsyncStateMachine(typeof(SleepPage.<Right_Tapped>d__48))]
        private void Right_Tapped(object sender, TappedRoutedEventArgs e);
        private void RunIfSelected(UIElement element, Action action);
        [AsyncStateMachine(typeof(SleepPage.<Share_Tapped>d__49))]
        private void Share_Tapped(object sender, TappedRoutedEventArgs e);
        [AsyncStateMachine(typeof(SleepPage.<ShowChart>d__61))]
        public Task ShowChart(double width, double height, WorkoutItem workout);
        [AsyncStateMachine(typeof(SleepPage.<ShowWorkout>d__44))]
        private Task ShowWorkout(WorkoutItem workout);
        [AsyncStateMachine(typeof(SleepPage.<SleepDiagrams_SizeChanged>d__62))]
        private void SleepDiagrams_SizeChanged(object sender, SizeChangedEventArgs e);
        private bool TryGoBack();
        [AsyncStateMachine(typeof(SleepPage.<WorkoutTracks_Loaded>d__59))]
        private void WorkoutTracks_Loaded(object sender, TracksLoadedEventArgs e);

        public MobileBandSync.Common.NavigationHelper NavigationHelper { get; }

        public ObservableDictionary DefaultViewModel { get; }

        public int currentWorkoutId { get; private set; }

        public CancellationTokenSource CancelTokenSource { get; private set; }

        public WorkoutItem CurrentWorkout { get; private set; }

        public Size CanvasSize { get; private set; }

        [CompilerGenerated]
        private struct <Grid_Tapped>d__50 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public object sender;
            public TappedRoutedEventArgs e;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Left_Tapped>d__47 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SleepPage <>4__this;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <NavigationHelper_LoadState>d__42 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SleepPage <>4__this;
            public LoadStateEventArgs e;
            private TaskAwaiter<WorkoutItem> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <NavigationHelper_SaveState>d__43 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SleepPage <>4__this;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Right_Tapped>d__48 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SleepPage <>4__this;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Share_Tapped>d__49 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SleepPage <>4__this;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ShowChart>d__61 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public SleepPage <>4__this;
            public double height;
            public double width;
            public WorkoutItem workout;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ShowWorkout>d__44 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public WorkoutItem workout;
            public SleepPage <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <SleepDiagrams_SizeChanged>d__62 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public SizeChangedEventArgs e;
            public SleepPage <>4__this;
            public object sender;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <WorkoutTracks_Loaded>d__59 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public TracksLoadedEventArgs e;
            public SleepPage <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        public enum SleepType
        {
            public const SleepPage.SleepType Unknown = SleepPage.SleepType.Unknown;,
            public const SleepPage.SleepType Awake = SleepPage.SleepType.Awake;,
            public const SleepPage.SleepType LightSleep = SleepPage.SleepType.LightSleep;,
            public const SleepPage.SleepType RestfulSleep = SleepPage.SleepType.RestfulSleep;
        }
    }
}

