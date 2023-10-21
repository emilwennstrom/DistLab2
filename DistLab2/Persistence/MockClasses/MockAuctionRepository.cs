using DistLab2.Core;
using DistLab2.Persistence.DAO;
using DistLab2.Persistence.Interfaces;
using DistLab2.Persistence.Repositories;

namespace DistLab2.Persistence.MockClasses
{
    public class MockAuctionRepository : Repository<AuctionDb>
    {


        public MockAuctionRepository(AuctionDbContext context) : base(context)
        {



        }

        public void EditAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuctionDb> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuctionDb> GetOngoing()
        {
            throw new NotImplementedException();
        }

       
    }
}
