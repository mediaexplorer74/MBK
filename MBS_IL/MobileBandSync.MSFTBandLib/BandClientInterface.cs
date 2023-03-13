using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileBandSync.MSFTBandLib;

public interface BandClientInterface
{
	Task<List<BandInterface>> GetPairedBands();
}
