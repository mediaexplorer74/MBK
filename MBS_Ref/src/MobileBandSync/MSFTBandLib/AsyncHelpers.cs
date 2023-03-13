namespace MobileBandSync.MSFTBandLib
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public static class AsyncHelpers
    {
        public static void RunSync(Func<Task> task);
        public static T RunSync<T>(Func<Task<T>> task);

        private class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private bool done;
            private readonly AutoResetEvent workItemsWaiting;
            private readonly Queue<Tuple<SendOrPostCallback, object>> items;

            public ExclusiveSynchronizationContext();
            public void BeginMessageLoop();
            public override SynchronizationContext CreateCopy();
            public void EndMessageLoop();
            public override void Post(SendOrPostCallback d, object state);
            public override void Send(SendOrPostCallback d, object state);

            public Exception InnerException { get; set; }
        }
    }
}

