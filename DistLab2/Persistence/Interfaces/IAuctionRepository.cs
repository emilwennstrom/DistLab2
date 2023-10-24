using DistLab2.Persistence.DAO;

namespace DistLab2.Persistence.Interfaces
{
    public interface IAuctionRepository : IRepository<AuctionDb>
    {
        IEnumerable<AuctionDb> GetWonAuctionsFromIds(List<int> ids);

        IEnumerable<AuctionDb> GetOngoingAuctions();

        IEnumerable<AuctionDb> GetOngoingAuctionsFromIds(List<int> ids);

    }
}
