using System;

namespace MobileBandSync.Data
{
	// Token: 0x0200007C RID: 124
	public class TracksLoadedEventArgs : EventArgs
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x0000D7AC File Offset: 0x0000B9AC
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x0000D7B4 File Offset: 0x0000B9B4
		public WorkoutItem Workout { get; private set; }

		// Token: 0x06000481 RID: 1153 RVA: 0x0000D7BD File Offset: 0x0000B9BD
		public TracksLoadedEventArgs(WorkoutItem workout)
		{
			this.Workout = workout;
		}
	}
}
