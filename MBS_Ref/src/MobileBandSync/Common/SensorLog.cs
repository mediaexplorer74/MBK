namespace MobileBandSync.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class SensorLog
    {
        private Stream DataStream;
        public Dictionary<uint, Dictionary<uint, uint>> IdOccurencies;

        public SensorLog();
        public bool AddTcxExport(ref List<Workout> Workouts, ExportType type);
        public bool AddWorkoutData(ref Workout currenWorkout, Dictionary<DateTime, int> heartRateList, Dictionary<DateTime, double> elevationList, Dictionary<DateTime, GpsPosition> positionList, Dictionary<DateTime, uint> galvanicList, Dictionary<DateTime, double> temperatureList, Dictionary<DateTime, uint> stepsList);
        [AsyncStateMachine(typeof(SensorLog.<CreateWorkouts>d__5))]
        public Task<List<Workout>> CreateWorkouts(ExportType type = 0x1a);
        public static bool IsSensorLog(Stream stream, out DateTime dtStartDate);
        [AsyncStateMachine(typeof(SensorLog.<Read>d__4))]
        public Task<bool> Read(Stream stream);
        public static string ToBinaryString(uint num);

        public List<SensorLogSequence> Sequences { get; }

        public ulong BufferSize { get; set; }

        public ulong StepLength { get; internal set; }

        public string BandName { get; set; }

        [CompilerGenerated]
        private struct <CreateWorkouts>d__5 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<Workout>> <>t__builder;
            public SensorLog <>4__this;
            public ExportType type;
            private SensorLog.<>c__DisplayClass5_0 <>8__1;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Read>d__4 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public SensorLog <>4__this;
            public Stream stream;
            private SensorLog.<>c__DisplayClass4_0 <>8__1;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

