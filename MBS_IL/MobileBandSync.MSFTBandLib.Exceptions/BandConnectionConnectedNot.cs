using System;

namespace MobileBandSync.MSFTBandLib.Exceptions;

public class BandConnectionConnectedNot : Exception
{
	public BandConnectionConnectedNot()
		: base("Band connection is not connected.")
	{
	}
}
