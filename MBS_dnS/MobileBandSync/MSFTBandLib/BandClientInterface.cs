using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x02000056 RID: 86
	public interface BandClientInterface
	{
		// Token: 0x06000330 RID: 816
		Task<List<BandInterface>> GetPairedBands();
	}
}
