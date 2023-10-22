using DistLab2.Core;
using DistLab2.Persistence.DAO;

namespace DistLab2.Persistence.Interfaces
{
    public interface IBidRepository : IRepository<BidDb>
    {

        IEnumerable<int> FindLeadingAuctionIds(string username);

    }
}
