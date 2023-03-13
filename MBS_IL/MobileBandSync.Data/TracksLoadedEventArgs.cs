using System;

namespace MobileBandSync.Data;

public class TracksLoadedEventArgs : EventArgs
{
	public WorkoutItem Workout { get; private set; }

	public TracksLoadedEventArgs(WorkoutItem workout)
	{
		Workout = workout;
	}
}
