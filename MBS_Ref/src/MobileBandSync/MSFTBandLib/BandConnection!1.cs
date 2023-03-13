namespace MobileBandSync.MSFTBandLib
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class BandConnection<T> : BandConnectionInterface, IDisposable where T: class, BandSocketInterface
    {
        protected BandInterface Band;
        public readonly BandSocketInterface Cargo;
        public readonly BandSocketInterface Push;

        public BandConnection();
        public BandConnection(BandInterface Band);
        [AsyncStateMachine(typeof(BandConnection<>.<Command>d__18))]
        public Task<CommandResponse> Command(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 0x2000, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandConnection<>.<CommandStore>d__19))]
        public Task CommandStore(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 0x2000, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandConnection<>.<CommandStoreStatus>d__20))]
        public Task<CommandResponse> CommandStoreStatus(CommandEnum command, Func<uint> BufferSize, byte[] args = null, uint buffer = 0x2000, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandConnection<>.<Connect>d__16))]
        public Task Connect(BandInterface Band);
        [AsyncStateMachine(typeof(BandConnection<>.<Connect>d__15))]
        public Task Connect(Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandConnection<>.<Disconnect>d__17))]
        public Task Disconnect();
        public void Dispose();
        protected virtual void Dispose(bool disposing);

        public bool Connected { get; protected set; }

        public bool Disposed { get; protected set; }

        [CompilerGenerated]
        private struct <Command>d__18 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public BandConnection<T> <>4__this;
            public CommandEnum command;
            public Func<uint> BufferSize;
            public byte[] args;
            public uint buffer;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <CommandStore>d__19 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandConnection<T> <>4__this;
            public CommandEnum command;
            public Func<uint> BufferSize;
            public byte[] args;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <CommandStoreStatus>d__20 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public BandConnection<T> <>4__this;
            public CommandEnum command;
            public Func<uint> BufferSize;
            public uint buffer;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Connect>d__15 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandConnection<T> <>4__this;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Connect>d__16 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandConnection<T> <>4__this;
            public BandInterface Band;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Disconnect>d__17 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandConnection<T> <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

