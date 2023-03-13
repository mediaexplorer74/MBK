namespace MobileBandSync.MSFTBandLib
{
    using System;
    using System.Runtime.CompilerServices;

    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(ulong uiCompleted, ulong uiTotal, string strStatusText);

        public ulong Completed { get; private set; }

        public ulong Total { get; private set; }

        public string StatusText { get; private set; }
    }
}

