using DistLab2.Core;

namespace DistLab2.Persistence.Interfaces
{
    public interface IAuctionRepository : IRepository<AuctionDb>
    {
        public void EditAuction(Auction auction);
        public IEnumerable<AuctionDb> GetMostExpensive(int count);
    }
}
