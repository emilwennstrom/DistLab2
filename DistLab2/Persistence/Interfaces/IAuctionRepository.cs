using DistLab2.Core;
using DistLab2.Persistence.DAO;

namespace DistLab2.Persistence.Interfaces
{
    public interface IAuctionRepository : IRepository<AuctionDb>
    {
        IEnumerable<AuctionDb> GetWonAuctionsFromId(List<int> ids);

        IEnumerable<AuctionDb> GetOngoingAuctions();

    }
}
