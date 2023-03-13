using System;

namespace MobileBandSync.MSFTBandLib.Exceptions
{
	// Token: 0x02000072 RID: 114
	public class BandSocketConnected : Exception
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x0000BB4D File Offset: 0x00009D4D
		public BandSocketConnected() : base("Band socket is already connected.")
		{
		}
	}
}
