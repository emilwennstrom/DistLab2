using DistLab2.Core;
using DistLab2.Persistence.DAO;

namespace DistLab2.Persistence.Interfaces
{
    public interface IAuctionRepository : IRepository<AuctionDb>
    {
        public IEnumerable<AuctionDb> GetMostExpensive(int count);

        //public IEnumerable<AuctionDb> GetOngoing();
    }
}
