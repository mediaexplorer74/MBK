using System;

namespace MSFTBandLib {

/// <summary>Band socket connected exception</summary>
public class BandSocketConnected : Exception {

	/// <summary>Constructor.</summary>
	public BandSocketConnected() : 
	base("Band socket is already connected.") {}

}

}