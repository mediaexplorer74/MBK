namespace MobileBandSync.MSFTBandLib.UWP
{
    using MobileBandSync.MSFTBandLib;
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.Networking;
    using Windows.Networking.Sockets;
    using Windows.Storage.Streams;

    public class BandSocketUWP : BandSocketInterface, IDisposable
    {
        protected StreamSocket Socket;
        protected Windows.Storage.Streams.DataReader DataReader;
        protected Windows.Storage.Streams.DataWriter DataWriter;

        [AsyncStateMachine(typeof(BandSocketUWP.<Connect>d__13))]
        public Task Connect(string mac, Guid uuid, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandSocketUWP.<Disconnect>d__14))]
        public Task Disconnect();
        public void Dispose();
        protected virtual void Dispose(bool disposing);
        public Windows.Storage.Streams.DataReader GetDataReader();
        public Windows.Storage.Streams.DataWriter GetDataWriter();
        [AsyncStateMachine(typeof(BandSocketUWP.<GetRfcommDeviceServiceForHostFromUuid>d__22))]
        public static Task<RfcommDeviceService> GetRfcommDeviceServiceForHostFromUuid(HostName host, Guid uuid);
        [AsyncStateMachine(typeof(BandSocketUWP.<Put>d__20))]
        public Task<CommandResponse> Put(CommandPacket packet, uint buffer);
        protected byte[] ReadBytes(uint count);
        [AsyncStateMachine(typeof(BandSocketUWP.<Receive>d__18))]
        public Task<CommandResponse> Receive(uint buffer, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandSocketUWP.<Request>d__19))]
        public Task<CommandResponse> Request(CommandPacket packet, uint buffer, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(BandSocketUWP.<Send>d__15))]
        public Task Send(CommandPacket packet);
        [AsyncStateMachine(typeof(BandSocketUWP.<Send>d__16))]
        public Task Send(CommandPacket packet, byte[] bytesToSend);
        [AsyncStateMachine(typeof(BandSocketUWP.<SendStatus>d__17))]
        public Task<int> SendStatus(CommandPacket packet, byte[] bytesToSend);

        public bool Connected { get; protected set; }

        public bool Disposed { get; protected set; }

        [CompilerGenerated]
        private struct <Connect>d__13 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public Action<ulong, ulong> Progress;
            public BandSocketUWP <>4__this;
            public string mac;
            public Guid uuid;
            private HostName <host>5__1;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<RfcommDeviceService> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Disconnect>d__14 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandSocketUWP <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetRfcommDeviceServiceForHostFromUuid>d__22 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<RfcommDeviceService> <>t__builder;
            public Guid uuid;
            public HostName host;
            private TaskAwaiter<BluetoothDevice> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Put>d__20 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public BandSocketUWP <>4__this;
            public CommandPacket packet;
            public uint buffer;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<CommandResponse> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Receive>d__18 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public BandSocketUWP <>4__this;
            public uint buffer;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Request>d__19 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public BandSocketUWP <>4__this;
            public CommandPacket packet;
            public uint buffer;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<CommandResponse> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Send>d__15 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandSocketUWP <>4__this;
            public CommandPacket packet;
            private TaskAwaiter<uint> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Send>d__16 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public BandSocketUWP <>4__this;
            public CommandPacket packet;
            public byte[] bytesToSend;
            private TaskAwaiter<uint> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <SendStatus>d__17 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<int> <>t__builder;
            public BandSocketUWP <>4__this;
            public CommandPacket packet;
            public byte[] bytesToSend;
            private TaskAwaiter<uint> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

