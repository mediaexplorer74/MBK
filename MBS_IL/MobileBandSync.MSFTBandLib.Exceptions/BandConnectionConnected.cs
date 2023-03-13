using System;

namespace MobileBandSync.MSFTBandLib.Exceptions;

public class BandConnectionConnected : Exception
{
	public BandConnectionConnected()
		: base("Band connection is already connected.")
	{
	}
}
