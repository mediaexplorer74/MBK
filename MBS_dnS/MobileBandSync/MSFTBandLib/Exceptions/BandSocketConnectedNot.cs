using System;

namespace MobileBandSync.MSFTBandLib.Exceptions
{
	// Token: 0x02000073 RID: 115
	public class BandSocketConnectedNot : Exception
	{
		// Token: 0x060003C8 RID: 968 RVA: 0x0000BB5A File Offset: 0x00009D5A
		public BandSocketConnectedNot() : base("Band socket is not connected.")
		{
		}
	}
}
