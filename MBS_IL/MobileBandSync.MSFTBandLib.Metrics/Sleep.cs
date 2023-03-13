using System;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Metrics;

public class Sleep
{
	public uint Calories { get; protected set; }

	public uint Duration { get; protected set; }

	public uint Feeling { get; protected set; }

	public uint RestingHR { get; protected set; }

	public uint TimeAsleep { get; protected set; }

	public uint TimeAwake { get; protected set; }

	public uint TimeToSleep { get; protected set; }

	public uint TimesAwoke { get; protected set; }

	public DateTime Timestamp { get; protected set; }

	public DateTime WokeUp { get; protected set; }

	public ushort Version { get; protected set; }

	public Sleep()
	{
	}

	public Sleep(CommandResponse response)
	{
		ByteStream byteStream = response.GetByteStream();
		Calories = byteStream.GetUint32(26);
		Duration = byteStream.GetUint32(10) / 1000u;
		Feeling = byteStream.GetUint32(50);
		RestingHR = byteStream.GetUint32(30);
		TimeAsleep = byteStream.GetUint32(22) / 1000u;
		TimeAwake = byteStream.GetUint32(18) / 1000u;
		TimeToSleep = byteStream.GetUint32(46) / 1000u;
		TimesAwoke = byteStream.GetUint32(14);
		Timestamp = DateTime.FromFileTime((long)byteStream.GetUint64());
		WokeUp = DateTime.FromFileTime((long)byteStream.GetUint64(38));
		Version = byteStream.GetUshort(8);
	}
}
