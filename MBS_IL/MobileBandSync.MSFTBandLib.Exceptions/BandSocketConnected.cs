using System;

namespace MobileBandSync.MSFTBandLib.Exceptions;

public class BandSocketConnected : Exception
{
	public BandSocketConnected()
		: base("Band socket is already connected.")
	{
	}
}
