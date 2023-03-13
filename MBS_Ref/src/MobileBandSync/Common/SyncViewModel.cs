namespace MobileBandSync.Common
{
    using MobileBandSync.MSFTBandLib;
    using MobileBandSync.MSFTBandLib.UWP;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Resources;

    public class SyncViewModel : INotifyPropertyChanged
    {
        private bool _bEnabled;
        private bool _bCleanupSensorLog;
        private bool _bStoreSensorLogLocally;
        private double _dProgress;
        private string _strStatusText;
        private string _strConnectionText;
        private string _strDeviceText;
        private string _strConnectionLog;
        private BandClientUWP _bandClient;

        public event PropertyChangedEventHandler PropertyChanged;

        public SyncViewModel();
        public void OnPropertyChanged(string propertyName = null);
        [AsyncStateMachine(typeof(SyncViewModel.<Progress>d__40))]
        public void Progress(ulong uiCompleted, ulong uiTotal);
        public void Report(string strReport);
        [AsyncStateMachine(typeof(SyncViewModel.<StartDeviceSearch>d__35))]
        public Task<bool> StartDeviceSearch();
        [AsyncStateMachine(typeof(SyncViewModel.<StartDeviceSync>d__38))]
        public Task<IEnumerable<WorkoutItem>> StartDeviceSync();
        [AsyncStateMachine(typeof(SyncViewModel.<StartSyncFromLogs>d__39))]
        public Task<IEnumerable<WorkoutItem>> StartSyncFromLogs();
        public void Status(string strStatus);

        public Windows.ApplicationModel.Resources.ResourceLoader ResourceLoader { get; private set; }

        public bool Enabled { get; set; }

        public double SyncProgress { get; set; }

        public string StatusText { get; set; }

        public string ConnectionText { get; set; }

        public string ConnectionLog { get; set; }

        public string DeviceText { get; set; }

        public bool CleanupSensorLog { get; set; }

        public bool StoreSensorLogLocally { get; set; }

        public BandClientUWP BandClient { get; }

        public bool Connected { get; set; }

        public BandInterface CurrentBand { get; set; }

        public ulong TotalProgress { get; private set; }

        public ulong CompletedProgress { get; private set; }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly SyncViewModel.<>c <>9;
            public static PropertyChangedEventHandler <>9__3_0;

            static <>c();
            internal void <.ctor>b__3_0(object <sender>, PropertyChangedEventArgs <e>);
        }

        [CompilerGenerated]
        private struct <Progress>d__40 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncVoidMethodBuilder <>t__builder;
            public ulong uiTotal;
            public SyncViewModel <>4__this;
            public ulong uiCompleted;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <StartDeviceSearch>d__35 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public SyncViewModel <>4__this;
            private BandInterface <band>5__1;
            private TaskAwaiter<List<BandInterface>> <>u__1;
            private List<BandInterface>.Enumerator <>7__wrap1;
            private TaskAwaiter <>u__2;
            private string <>7__wrap2;
            private TaskAwaiter<string> <>u__3;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <StartDeviceSync>d__38 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<IEnumerable<WorkoutItem>> <>t__builder;
            public SyncViewModel <>4__this;
            private TaskAwaiter<byte[]> <>u__1;
            private TaskAwaiter<List<WorkoutItem>> <>u__2;
            private TaskAwaiter<List<long>> <>u__3;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__4;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <StartSyncFromLogs>d__39 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<IEnumerable<WorkoutItem>> <>t__builder;
            public SyncViewModel <>4__this;
            private List<WorkoutItem> <listWorkouts>5__1;
            private TaskAwaiter<StorageFolder> <>u__1;
            private TaskAwaiter<List<WorkoutItem>> <>u__2;
            private TaskAwaiter<List<long>> <>u__3;
            private TaskAwaiter<IEnumerable<WorkoutItem>> <>u__4;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

