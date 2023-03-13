using System;

namespace MobileBandSync.MSFTBandLib.Exceptions;

public class BandConnectedNot : Exception
{
	public BandConnectedNot()
		: base("Band is not connected.")
	{
	}
}
