using System;

namespace MobileBandSync.Common;

public class SleepSummary
{
	public DateTime StartDate { get; set; }

	public TimeSpan Duration { get; set; }

	public double TimesAwoke { get; set; }

	public TimeSpan TotalRestlessSleepDuration { get; set; }

	public int CaloriesBurned { get; set; }

	public int HFAverage { get; set; }

	public int HFMax { get; set; }

	public DateTime IntermediateDate { get; set; }

	public TimeSpan FallAsleepTime { get; set; }

	public uint Feeling { get; set; }

	public double Version { get; internal set; }

	public TimeSpan TotalRestfulSleepDuration { get; internal set; }
}
