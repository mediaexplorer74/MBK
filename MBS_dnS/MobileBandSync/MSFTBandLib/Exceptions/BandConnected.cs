using System;

namespace MobileBandSync.MSFTBandLib.Exceptions
{
	// Token: 0x0200006E RID: 110
	public class BandConnected : Exception
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x0000BB19 File Offset: 0x00009D19
		public BandConnected() : base("Band is already connected.")
		{
		}
	}
}
