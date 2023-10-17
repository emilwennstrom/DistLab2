using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Core.Repositories;
using DistLab2.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DistLab2.Persistence.Repositories
{
    public class MockAuctionRepository : Repository<Auction>, IAuctionRepository
    {

        List<Auction> auctions;
        public MockAuctionRepository(AuctionDbContext context) : base(context)
        {
            var a1 = new Auction(1, "A1");
            var a2 = new Auction(2, "A2");

            a1.Bids.Add(new Bid(a1.Id, DateTime.Now.AddDays(1)));
            a2.Bids.Add(new Bid(a2.Id, DateTime.Now.AddDays(2)));


            auctions = new List<Auction>
            {
                a1,
                a2
            };
        }


        public new IEnumerable<Auction> GetAll()
        {

            return auctions;
        }

        public void EditAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auction> GetMostExpensive(int count)
        {
            auctions.Sort(new StartingPriceComparator());
            return auctions.ToList();
        }

        public new void Add(Auction auction)
        {
            auctions.Add(auction);
        }
    }
}
