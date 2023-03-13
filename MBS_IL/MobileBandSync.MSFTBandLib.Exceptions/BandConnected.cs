using System;

namespace MobileBandSync.MSFTBandLib.Exceptions;

public class BandConnected : Exception
{
	public BandConnected()
		: base("Band is already connected.")
	{
	}
}
