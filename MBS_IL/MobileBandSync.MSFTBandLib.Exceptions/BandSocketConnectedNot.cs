using System;

namespace MobileBandSync.MSFTBandLib.Exceptions;

public class BandSocketConnectedNot : Exception
{
	public BandSocketConnectedNot()
		: base("Band socket is not connected.")
	{
	}
}
