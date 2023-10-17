using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Core.Repositories;
using DistLab2.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DistLab2.Persistence.MockClasses
{
    public class MockAuctionRepository : Repository<Auction>, IAuctionRepository
    {


        public MockAuctionRepository(AuctionDbContext context) : base(context)
        {



        }


        public new IEnumerable<Auction> GetAll()
        {
            return MockAuctionDb.GetAuctions();
        }

        public void EditAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auction> GetMostExpensive(int count)
        {
            List<Auction> auctions = MockAuctionDb.GetAuctions();
            auctions.Sort(new StartingPriceComparator());
            return auctions;
        }

        public new void Add(Auction auction)
        {
            MockAuctionDb.AddAuction(auction);
        }
    }
}
