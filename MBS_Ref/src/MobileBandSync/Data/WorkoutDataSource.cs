namespace MobileBandSync.Data
{
    using Microsoft.Data.Sqlite;
    using MobileBandSync.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Resources;
    using Windows.Storage;
    using Windows.Storage.FileProperties;
    using Windows.UI.Popups;

    public sealed class WorkoutDataSource
    {
        public const bool _offlineTest = false;
        public static CultureInfo AppCultureInfo;
        public static string BandName;
        private const string WorkoutDbName = "workouts.db";
        private const string WorkoutFolderName = "Workouts";
        private const string WorkoutDbFolderName = "WorkoutDB";
        private static WorkoutDataSource _workoutDataSource;
        public ulong TotalDistance;
        public ulong NumHRWorkouts;
        public ulong TotalHR;
        public ulong TotalAvgSpeed;
        private ObservableCollection<WorkoutItem> _workouts;

        static WorkoutDataSource();
        public WorkoutDataSource();
        [AsyncStateMachine(typeof(WorkoutDataSource.<AddWorkouts>d__64))]
        public Task<List<WorkoutItem>> AddWorkouts(List<Workout> Workouts, bool bAddToDb = false, Action<string> Status = null, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0UL);
        [AsyncStateMachine(typeof(WorkoutDataSource.<BackupDatabase>d__61))]
        public static Task<bool> BackupDatabase(StorageFolder targetFolder = null);
        [AsyncStateMachine(typeof(WorkoutDataSource.<GetItemAsync>d__67))]
        public static Task<TrackItem> GetItemAsync(string uniqueId);
        public static string GetMapServiceToken();
        [AsyncStateMachine(typeof(WorkoutDataSource.<GetWorkoutAsync>d__65))]
        public static Task<WorkoutItem> GetWorkoutAsync(int workoutId);
        [AsyncStateMachine(typeof(WorkoutDataSource.<GetWorkoutDataAsync>d__68))]
        private Task GetWorkoutDataAsync(bool bForceReload = false, WorkoutFilterData filterData = null);
        public static ObservableCollection<WorkoutItem> GetWorkouts();
        [AsyncStateMachine(typeof(WorkoutDataSource.<GetWorkoutsAsync>d__49))]
        public static Task<IEnumerable<WorkoutItem>> GetWorkoutsAsync(bool bForceReload = false, WorkoutFilterData workoutFilter = null);
        public async static Task<string> GetWorkoutSummaryAsync();
        [AsyncStateMachine(typeof(WorkoutDataSource.<ImportFromSensorlog>d__57))]
        public static Task<List<WorkoutItem>> ImportFromSensorlog(StorageFolder sensorLogFolder, Action<string> Status, Action<ulong, ulong> Progress);
        [AsyncStateMachine(typeof(WorkoutDataSource.<ImportFromSensorlog>d__58))]
        public static Task<List<WorkoutItem>> ImportFromSensorlog(byte[] btSensorLog, Action<string> Status, Action<ulong, ulong> Progress);
        [AsyncStateMachine(typeof(WorkoutDataSource.<InitDatabase>d__59))]
        public Task<bool> InitDatabase(bool bDeleteOldDb = false);
        [AsyncStateMachine(typeof(WorkoutDataSource.<ReadWorkoutsFromSensorLogBuffer>d__62))]
        public Task<List<Workout>> ReadWorkoutsFromSensorLogBuffer(byte[] btSensorLog);
        [AsyncStateMachine(typeof(WorkoutDataSource.<ReadWorkoutsFromSensorLogs>d__63))]
        public Task<List<Workout>> ReadWorkoutsFromSensorLogs(StorageFolder SensorLogFolder);
        public static void SetMapServiceToken(string strServiceToken);
        [AsyncStateMachine(typeof(WorkoutDataSource.<StoreWorkouts>d__60))]
        public static Task<List<long>> StoreWorkouts(List<WorkoutItem> workouts, Action<ulong, ulong> Progress = null, ulong ulStepLength = 0UL);
        [AsyncStateMachine(typeof(WorkoutDataSource.<UpdateWorkoutAsync>d__66))]
        public static Task UpdateWorkoutAsync(int workoutId, string strTitle, string strNotes);

        public ObservableCollection<WorkoutItem> Workouts { get; set; }

        public StorageFolder WorkoutsFolder { get; private set; }

        public WorkoutFilterData CurrentFilter { get; set; }

        public static WorkoutDataSource DataSource { get; }

        public StorageFolder DatabaseFolder { get; private set; }

        public SensorLog SensorLogEngine { get; private set; }

        public static bool DbInitialized { get; private set; }

        public StorageFolder WorkoutDbFolder { get; private set; }

        public string MapServiceToken { get; set; }

        public static ObservableCollection<WorkoutItem> WorkoutList { get; }

        public string Summary { get; set; }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly WorkoutDataSource.<>c <>9;
            public static UICommandInvokedHandler <>9__59_0;
            public static UICommandInvokedHandler <>9__59_1;
            public static Func<DateTime, DateTime> <>9__63_0;
            public static Func<WorkoutItem, IEnumerable<TrackItem>> <>9__67_0;

            static <>c();
            internal IEnumerable<TrackItem> <GetItemAsync>b__67_0(WorkoutItem workout);
            internal void <InitDatabase>b__59_0(IUICommand cmd);
            internal void <InitDatabase>b__59_1(IUICommand cmd);
            internal DateTime <ReadWorkoutsFromSensorLogs>b__63_0(DateTime d);
        }

        [CompilerGenerated]
        private struct <AddWorkouts>d__64 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<WorkoutItem>> <>t__builder;
            public List<Workout> Workouts;
            private string <dbpath>5__1;
            private int <iIndex>5__2;
            private ExportType <type>5__3;
            private ResourceLoader <resourceLoader>5__4;
            public bool bAddToDb;
            private List<WorkoutItem> <listWorkouts>5__5;
            private WorkoutItem <workoutData>5__6;
            private object <>7__wrap1;
            private int <>7__wrap2;
            private List<Workout>.Enumerator <>7__wrap3;
            private TaskAwaiter<bool> <>u__1;
            private TaskAwaiter<IUICommand> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <BackupDatabase>d__61 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public StorageFolder targetFolder;
            private StorageFile <database>5__1;
            private bool <bResult>5__2;
            private TaskAwaiter<StorageFile> <>u__1;
            private TaskAwaiter<StorageFolder> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetItemAsync>d__67 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<TrackItem> <>t__builder;
            public string uniqueId;
            private WorkoutDataSource.<>c__DisplayClass67_0 <>8__1;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetWorkoutAsync>d__65 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<WorkoutItem> <>t__builder;
            public int workoutId;
            private WorkoutDataSource.<>c__DisplayClass65_0 <>8__1;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetWorkoutDataAsync>d__68 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public bool bForceReload;
            public WorkoutDataSource <>4__this;
            public WorkoutFilterData filterData;
            private TaskAwaiter<ObservableCollection<WorkoutItem>> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetWorkoutsAsync>d__49 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<IEnumerable<WorkoutItem>> <>t__builder;
            public bool bForceReload;
            public WorkoutFilterData workoutFilter;
            private TaskAwaiter<bool> <>u__1;
            private TaskAwaiter <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }


        [CompilerGenerated]
        private struct <ImportFromSensorlog>d__57 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<WorkoutItem>> <>t__builder;
            public StorageFolder sensorLogFolder;
            public Action<string> Status;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<List<Workout>> <>u__1;
            private TaskAwaiter<List<WorkoutItem>> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ImportFromSensorlog>d__58 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<WorkoutItem>> <>t__builder;
            public byte[] btSensorLog;
            public Action<string> Status;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<bool> <>u__1;
            private TaskAwaiter<List<Workout>> <>u__2;
            private TaskAwaiter<List<WorkoutItem>> <>u__3;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <InitDatabase>d__59 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public WorkoutDataSource <>4__this;
            public bool bDeleteOldDb;
            private StorageFile <oldDb>5__1;
            private StorageFile <databaseFile>5__2;
            private BasicProperties <oldProp>5__3;
            private MessageDialog <dialog>5__4;
            private UICommand <yesCommand>5__5;
            private SqliteConnection <db>5__6;
            private TaskAwaiter<StorageFolder> <>u__1;
            private int <>7__wrap1;
            private TaskAwaiter<StorageFile> <>u__2;
            private TaskAwaiter <>u__3;
            private TaskAwaiter<BasicProperties> <>u__4;
            private TaskAwaiter<IUICommand> <>u__5;
            private object <>7__wrap2;
            private TaskAwaiter<SqliteDataReader> <>u__6;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ReadWorkoutsFromSensorLogBuffer>d__62 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<Workout>> <>t__builder;
            public WorkoutDataSource <>4__this;
            public byte[] btSensorLog;
            private MemoryStream <memStream>5__1;
            private TaskAwaiter<bool> <>u__1;
            private TaskAwaiter<List<Workout>> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <ReadWorkoutsFromSensorLogs>d__63 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<Workout>> <>t__builder;
            public WorkoutDataSource <>4__this;
            public StorageFolder SensorLogFolder;
            private StorageFile <file>5__1;
            private string <strTempDir>5__2;
            private Dictionary<DateTime, string> <dictFiles>5__3;
            private Stream <fileStream>5__4;
            private TaskAwaiter<IReadOnlyList<StorageFile>> <>u__1;
            private IEnumerator<StorageFile> <>7__wrap1;
            private TaskAwaiter<BasicProperties> <>u__2;
            private IEnumerator<DateTime> <>7__wrap2;
            private TaskAwaiter<Stream> <>u__3;
            private TaskAwaiter<bool> <>u__4;
            private TaskAwaiter<List<Workout>> <>u__5;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <StoreWorkouts>d__60 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<long>> <>t__builder;
            public List<WorkoutItem> workouts;
            private List<long> <listResult>5__1;
            private SqliteConnection <db>5__2;
            public Action<ulong, ulong> Progress;
            public ulong ulStepLength;
            private TaskAwaiter <>u__1;
            private List<WorkoutItem>.Enumerator <>7__wrap1;
            private List<long> <>7__wrap2;
            private TaskAwaiter<long> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <UpdateWorkoutAsync>d__66 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public int workoutId;
            private WorkoutDataSource.<>c__DisplayClass66_0 <>8__1;
            public string strTitle;
            public string strNotes;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

