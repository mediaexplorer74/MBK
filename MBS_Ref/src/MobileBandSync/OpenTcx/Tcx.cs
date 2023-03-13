namespace MobileBandSync.OpenTcx
{
    using MobileBandSync.OpenTcx.Entities;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class Tcx
    {
        [AsyncStateMachine(typeof(Tcx.<AnalyzeTcxFile>d__0))]
        public Task<TrainingCenterDatabase_t> AnalyzeTcxFile(string tcxFile);
        public TrainingCenterDatabase_t AnalyzeTcxStream(Stream fs);
        public async Task<string> CopyLocally(string tcxFile);
        public string GenerateTcx(TrainingCenterDatabase_t data);
        public bool ValidateTcx(string tckFile);

        [CompilerGenerated]
        private struct <AnalyzeTcxFile>d__0 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<TrainingCenterDatabase_t> <>t__builder;
            public Tcx <>4__this;
            public string tcxFile;
            private TaskAwaiter<string> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

    }
}

