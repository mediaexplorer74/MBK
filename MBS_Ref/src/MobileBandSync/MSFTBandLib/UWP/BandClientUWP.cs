namespace MobileBandSync.MSFTBandLib.UWP
{
    using MobileBandSync.MSFTBandLib;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class BandClientUWP : BandClientInterface
    {
        [AsyncStateMachine(typeof(BandClientUWP.<GetPairedBands>d__0))]
        public Task<List<BandInterface>> GetPairedBands();

        [CompilerGenerated]
        private struct <GetPairedBands>d__0 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<List<BandInterface>> <>t__builder;
            private List<BandInterface> <bands>5__1;
            private TaskAwaiter<DeviceInformationCollection> <>u__1;
            private IEnumerator<DeviceInformation> <>7__wrap1;
            private TaskAwaiter<BluetoothDevice> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

