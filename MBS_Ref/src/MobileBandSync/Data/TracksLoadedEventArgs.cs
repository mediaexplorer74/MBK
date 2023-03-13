namespace MobileBandSync.Data
{
    using System;
    using System.Runtime.CompilerServices;

    public class TracksLoadedEventArgs : EventArgs
    {
        public TracksLoadedEventArgs(WorkoutItem workout);

        public WorkoutItem Workout { get; private set; }
    }
}

