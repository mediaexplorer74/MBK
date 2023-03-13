namespace MobileBandSync.Data
{
    using Microsoft.Data.Sqlite;
    using MobileBandSync.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.UI.Xaml;

    public class WorkoutItem
    {
        private EventRegistrationTokenTable<EventHandler<TracksLoadedEventArgs>> m_currentWorkout;
        private string _title;

        public event EventHandler<TracksLoadedEventArgs> TracksLoaded;

        public WorkoutItem();
        public WorkoutItem(string uniqueId, string title, string subtitle, string imagePath, string description);
        [AsyncStateMachine(typeof(WorkoutItem.<CopyToExternal>d__178))]
        public Task CopyToExternal(string tcxFile);
        [AsyncStateMachine(typeof(WorkoutItem.<ExportWorkout>d__179))]
        public Task<bool> ExportWorkout(StorageFile tcxFile);
        public string GenerateTcxBuffer();
        public double GetDistMeter(double lat1, double long1, double lat2, double long2);
        public WorkoutItem GetNextSibling();
        public WorkoutItem GetPrevSibling();
        internal void OnTracksLoaded(WorkoutItem workout);
        [AsyncStateMachine(typeof(WorkoutItem.<ReadSleepData>d__185))]
        public Task ReadSleepData(CancellationToken token);
        [AsyncStateMachine(typeof(WorkoutItem.<ReadTrackData>d__184))]
        public Task ReadTrackData(CancellationToken token);
        [AsyncStateMachine(typeof(WorkoutItem.<ReadWorkoutFromTcx>d__183))]
        public static Task<WorkoutItem> ReadWorkoutFromTcx(string strTcxPath);
        [AsyncStateMachine(typeof(WorkoutItem.<ReadWorkouts>d__182))]
        public static Task<ObservableCollection<WorkoutItem>> ReadWorkouts(WorkoutFilterData filterData = null);
        [AsyncStateMachine(typeof(WorkoutItem.<StoreWorkout>d__177))]
        public Task<bool> StoreWorkout();
        [AsyncStateMachine(typeof(WorkoutItem.<StoreWorkout>d__181))]
        public Task<long> StoreWorkout(SqliteConnection dbParam, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0UL);
        public override string ToString();
        [AsyncStateMachine(typeof(WorkoutItem.<UpdateWorkout>d__180))]
        public Task UpdateWorkout();

        public string UniqueId { get; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; private set; }

        public ObservableCollection<TrackItem> Items { get; set; }

        public ObservableCollection<SleepItem> SleepItems { get; set; }

        public int WorkoutId { get; set; }

        public byte WorkoutType { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public byte AvgHR { get; set; }

        public byte MaxHR { get; set; }

        public int Calories { get; set; }

        public int AvgSpeed { get; set; }

        public int MaxSpeed { get; set; }

        public int DurationSec { get; set; }

        public long DistanceMeters { get; set; }

        public long LongitudeStart { get; set; }

        public long LatitudeStart { get; set; }

        public int LongDeltaRectSW { get; set; }

        public int LatDeltaRectSW { get; set; }

        public int LongDeltaRectNE { get; set; }

        public int LatDeltaRectNE { get; set; }

        public string DbPath { get; set; }

        public string FilenameTCX { get; set; }

        public string TCXBuffer { get; set; }

        public int Index { get; set; }

        public TimeSpan AwakeDuration { get; set; }

        public TimeSpan SleepDuration { get; set; }

        public int NumberOfWakeups { get; set; }

        public TimeSpan FallAsleepDuration { get; set; }

        public int SleepEfficiencyPercentage { get; set; }

        public TimeSpan TotalRestlessSleepDuration { get; set; }

        public TimeSpan TotalRestfulSleepDuration { get; set; }

        public uint Feeling { get; set; }

        public string WorkoutImageSource { get; }

        public Visibility DownVisibility { get; }

        public Visibility UpVisibility { get; }

        public ObservableCollection<WorkoutItem> Parent { get; set; }

        public ObservableCollection<DiagramData> HeartRateChart { get; private set; }

        public ObservableCollection<DiagramData> ElevationChart { get; private set; }

        public ObservableCollection<DiagramData> CadenceNormChart { get; private set; }

        public ObservableCollection<DiagramData> SpeedChart { get; private set; }

        public bool Modified { get; set; }

        [CompilerGenerated]
        private struct <CopyToExternal>d__178 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public string tcxFile;
            private string <targetFile>5__1;
            private StorageFolder <targetPath>5__2;
            private TaskAwaiter<StorageFolder> <>u__1;
            private TaskAwaiter<StorageFile> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ExportWorkout>d__179 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public StorageFile tcxFile;
            public WorkoutItem <>4__this;
            private StorageFile <createFile>5__1;
            private bool <bResult>5__2;
            private object <>7__wrap1;
            private int <>7__wrap2;
            private TaskAwaiter<StorageFile> <>u__1;
            private TaskAwaiter <>u__2;
            private TaskAwaiter<IUICommand> <>u__3;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ReadSleepData>d__185 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public WorkoutItem <>4__this;
            public CancellationToken token;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ReadTrackData>d__184 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public WorkoutItem <>4__this;
            public CancellationToken token;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ReadWorkoutFromTcx>d__183 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<WorkoutItem> <>t__builder;
            public string strTcxPath;
            private StorageFile <fileTcx>5__1;
            private WorkoutItem <workout>5__2;
            private TaskAwaiter<StorageFile> <>u__1;
            private TaskAwaiter<TrainingCenterDatabase_t> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ReadWorkouts>d__182 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ObservableCollection<WorkoutItem>> <>t__builder;
            private SqliteConnection <db>5__1;
            public WorkoutFilterData filterData;
            private SqliteDataReader <reader>5__2;
            private ObservableCollection<WorkoutItem> <workouts>5__3;
            private int <iIndex>5__4;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<SqliteDataReader> <>u__2;
            private TaskAwaiter<bool> <>u__3;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <StoreWorkout>d__177 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public WorkoutItem <>4__this;
            private SqliteConnection <db>5__1;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<long> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <StoreWorkout>d__181 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<long> <>t__builder;
            public WorkoutItem <>4__this;
            public SqliteConnection dbParam;
            private WorkoutItem.<>c__DisplayClass181_1 <>8__1;
            public Action<ulong, ulong> Progress;
            public ulong ulStepLength;
            private WorkoutItem.<>c__DisplayClass181_0 <>8__2;
            private TaskAwaiter <>u__1;
            private IEnumerator<TrackItem> <>7__wrap1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <UpdateWorkout>d__180 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            private SqliteConnection <db>5__1;
            public WorkoutItem <>4__this;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<SqliteDataReader> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

