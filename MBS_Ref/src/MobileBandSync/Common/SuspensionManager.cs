namespace MobileBandSync.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    internal sealed class SuspensionManager
    {
        private static Dictionary<string, object> _sessionState;
        private static List<Type> _knownTypes;
        private const string sessionStateFilename = "_sessionState.xml";
        private static DependencyProperty FrameSessionStateKeyProperty;
        private static DependencyProperty FrameSessionBaseKeyProperty;
        private static DependencyProperty FrameSessionStateProperty;
        private static List<WeakReference<Frame>> _registeredFrames;

        static SuspensionManager();
        public static void RegisterFrame(Frame frame, string sessionStateKey, string sessionBaseKey = null);
        [AsyncStateMachine(typeof(SuspensionManager.<RestoreAsync>d__8))]
        public static Task RestoreAsync(string sessionBaseKey = null);
        private static void RestoreFrameNavigationState(Frame frame);
        [AsyncStateMachine(typeof(SuspensionManager.<SaveAsync>d__7))]
        public static Task SaveAsync();
        private static void SaveFrameNavigationState(Frame frame);
        public static Dictionary<string, object> SessionStateForFrame(Frame frame);
        public static void UnregisterFrame(Frame frame);

        public static Dictionary<string, object> SessionState { get; }

        public static List<Type> KnownTypes { get; }

        [CompilerGenerated]
        private struct <RestoreAsync>d__8 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public string sessionBaseKey;
            private TaskAwaiter<StorageFile> <>u__1;
            private TaskAwaiter<IInputStream> <>u__2;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }

        [CompilerGenerated]
        private struct <SaveAsync>d__7 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            private MemoryStream <sessionData>5__1;
            private Stream <fileStream>5__2;
            private TaskAwaiter<StorageFile> <>u__1;
            private TaskAwaiter<Stream> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext();
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine);
        }
    }
}

