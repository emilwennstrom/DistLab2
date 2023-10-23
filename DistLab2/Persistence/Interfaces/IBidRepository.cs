using DistLab2.Persistence.DAO;

namespace DistLab2.Persistence.Interfaces
{
    public interface IBidRepository : IRepository<BidDb>
    {

        IEnumerable<int> FindLeadingAuctionIds(string username);

        IEnumerable<BidDb> GetOrderedBids(int auctionId);

        IEnumerable<int> GetAuctionIdsFromUsername(string username);

    }
}
