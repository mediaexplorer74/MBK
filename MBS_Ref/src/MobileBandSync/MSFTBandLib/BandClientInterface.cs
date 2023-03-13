namespace MobileBandSync.MSFTBandLib
{
    using System.Threading.Tasks;

    public interface BandClientInterface
    {
        Task<List<BandInterface>> GetPairedBands();
    }
}

