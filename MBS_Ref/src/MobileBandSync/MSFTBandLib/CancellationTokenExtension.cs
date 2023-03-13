namespace MobileBandSync.MSFTBandLib
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal static class CancellationTokenExtension
    {
        public static void WaitAndThrowIfCancellationRequested(this CancellationToken token, int timeout);
        public static void WaitAndThrowIfCancellationRequested(this CancellationToken token, TimeSpan timeout);
    }
}

