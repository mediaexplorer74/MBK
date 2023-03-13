using System;

namespace MobileBandSync.Common;

public class WorkoutPoint
{
	public DateTime Time { get; set; }

	public int HeartRateBpm { get; set; }

	public GpsPosition Position { get; set; }

	public double Elevation { get; set; }

	public uint GalvanicSkinResponse { get; set; }

	public double SkinTemperature { get; set; }

	public uint Cadence { get; set; }
}
