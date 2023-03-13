namespace MobileBandSync.MSFTBandLib
{
    using MobileBandSync.MSFTBandLib.Command;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.Devices.Bluetooth;
    using Windows.Storage.Streams;

    public class Band<T> : BandInterface where T: class, BandSocketInterface
    {
        internal BluetoothDevice _device;

        public Band(BluetoothDevice device);
        public Band(string mac, string name);
        public static byte[] Combine(byte[] first, byte[] second);
        [AsyncStateMachine(typeof(Band<>.<Command>d__23))]
        public Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(Band<>.<Command>d__24))]
        public Task<CommandResponse> Command(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs, uint uiBufferSize = 0x2000, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(Band<>.<CommandStore>d__25))]
        public Task CommandStore(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs = null, uint uiBufferSize = 0x2000, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(Band<>.<CommandStoreStatus>d__26))]
        public Task<CommandResponse> CommandStoreStatus(CommandEnum Command, Func<uint> BufferSize, byte[] btArgs = null, uint uiBufferSize = 0x2000, Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(Band<>.<Connect>d__21))]
        public Task Connect(Action<ulong, ulong> Progress = null);
        [AsyncStateMachine(typeof(Band<>.<DeleteChunkRange>d__36))]
        public Task<bool> DeleteChunkRange(BandMetadataRange metaData);
        [AsyncStateMachine(typeof(Band<>.<DeviceLogDataFlush>d__33))]
        public Task DeviceLogDataFlush();
        [AsyncStateMachine(typeof(Band<>.<Disconnect>d__22))]
        public Task Disconnect();
        [AsyncStateMachine(typeof(Band<>.<GetChunkRangeData>d__35))]
        public Task<byte[]> GetChunkRangeData(BandMetadataRange metaData, Action<ulong, ulong> Progress);
        [AsyncStateMachine(typeof(Band<>.<GetChunkRangeMetadata>d__34))]
        public Task<BandMetadataRange> GetChunkRangeMetadata(int chunkCount);
        public DataReader GetDataReader();
        public DataWriter GetDataWriter();
        public BluetoothDevice GetDevice();
        [AsyncStateMachine(typeof(Band<>.<GetDeviceTime>d__27))]
        public Task<DateTime> GetDeviceTime();
        [AsyncStateMachine(typeof(Band<>.<GetLastSleep>d__28))]
        public Task<Sleep> GetLastSleep();
        public string GetMac();
        public string GetName();
        [AsyncStateMachine(typeof(Band<>.<GetSensorLog>d__31))]
        public Task<byte[]> GetSensorLog(Action<string> Report, Action<ulong, ulong> Progress, bool bCleanupSensorLog, bool bStoreSensorLog);
        [AsyncStateMachine(typeof(Band<>.<GetSerialNumber>d__29))]
        public Task<string> GetSerialNumber();
        [AsyncStateMachine(typeof(Band<>.<GetVersion>d__37))]
        public Task<BandVersion> GetVersion();
        [AsyncStateMachine(typeof(Band<>.<RemainingDeviceLogDataChunks>d__32))]
        public Task<int> RemainingDeviceLogDataChunks();

        public string Mac { get; protected set; }

        public string Name { get; protected set; }

        public bool Connected { get; set; }

        public BandConnection<T> Connection { get; protected set; }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly Band<T>.<>c <>9;
            public static Func<uint> <>9__33_0;
            public static Func<uint> <>9__34_0;
            public static Func<uint> <>9__36_0;

            static <>c();
            internal uint <DeleteChunkRange>b__36_0();
            internal uint <DeviceLogDataFlush>b__33_0();
            internal uint <GetChunkRangeMetadata>b__34_0();
        }

        [CompilerGenerated]
        private struct <Command>d__23 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public Band<T> <>4__this;
            public CommandEnum Command;
            public Func<uint> BufferSize;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Command>d__24 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public Band<T> <>4__this;
            public CommandEnum Command;
            public Func<uint> BufferSize;
            public byte[] btArgs;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <CommandStore>d__25 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public Band<T> <>4__this;
            public CommandEnum Command;
            public Func<uint> BufferSize;
            public byte[] btArgs;
            public uint uiBufferSize;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <CommandStoreStatus>d__26 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<CommandResponse> <>t__builder;
            public Band<T> <>4__this;
            public CommandEnum Command;
            public Func<uint> BufferSize;
            public byte[] btArgs;
            public uint uiBufferSize;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Connect>d__21 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public Band<T> <>4__this;
            public Action<ulong, ulong> Progress;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <DeleteChunkRange>d__36 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<bool> <>t__builder;
            public BandMetadataRange metaData;
            public Band<T> <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <DeviceLogDataFlush>d__33 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public Band<T> <>4__this;
            private Func<uint> <BufferSize>5__1;
            private BandStatus <status>5__2;
            private int <iTries>5__3;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <Disconnect>d__22 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public Band<T> <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetChunkRangeData>d__35 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<byte[]> <>t__builder;
            public BandMetadataRange metaData;
            public Band<T> <>4__this;
            public Action<ulong, ulong> Progress;
            private byte[] <btResult>5__1;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetChunkRangeMetadata>d__34 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<BandMetadataRange> <>t__builder;
            public int chunkCount;
            public Band<T> <>4__this;
            private BandMetadataRange <metaResult>5__1;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetDeviceTime>d__27 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<DateTime> <>t__builder;
            public Band<T> <>4__this;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetLastSleep>d__28 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<Sleep> <>t__builder;
            public Band<T> <>4__this;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetSensorLog>d__31 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<byte[]> <>t__builder;
            public Action<ulong, ulong> Progress;
            public Band<T> <>4__this;
            private Band<T>.<>c__DisplayClass31_1 <>8__1;
            public Action<string> Report;
            public bool bStoreSensorLog;
            private string <uploadId>5__2;
            private byte[] <btSensorLog>5__3;
            public bool bCleanupSensorLog;
            private TaskAwaiter <>u__1;
            private TaskAwaiter<int> <>u__2;
            private Band<T>.<>c__DisplayClass31_1 <>7__wrap1;
            private TaskAwaiter<BandMetadataRange> <>u__3;
            private TaskAwaiter<byte[]> <>u__4;
            private TaskAwaiter<StorageFolder> <>u__5;
            private TaskAwaiter<StorageFile> <>u__6;
            private TaskAwaiter<bool> <>u__7;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetSerialNumber>d__29 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<string> <>t__builder;
            public Band<T> <>4__this;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <GetVersion>d__37 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<BandVersion> <>t__builder;
            public Band<T> <>4__this;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <RemainingDeviceLogDataChunks>d__32 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<int> <>t__builder;
            public Band<T> <>4__this;
            private TaskAwaiter<CommandResponse> <>u__1;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

