using System;

namespace MobileBandSync.MSFTBandLib.Exceptions
{
	// Token: 0x02000070 RID: 112
	public class BandConnectionConnected : Exception
	{
		// Token: 0x060003C5 RID: 965 RVA: 0x0000BB33 File Offset: 0x00009D33
		public BandConnectionConnected() : base("Band connection is already connected.")
		{
		}
	}
}
