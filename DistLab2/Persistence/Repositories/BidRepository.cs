using DistLab2.Core;
using DistLab2.Persistence.DAO;
using DistLab2.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DistLab2.Persistence.Repositories
{
    public class BidRepository : Repository<BidDb>, IBidRepository
    {


        

        public BidRepository(AuctionDbContext context) : base(context)
        {



        }

        public IEnumerable<int> FindLeadingAuctionIds(string username)
        {
            var groupedBids = AuctionDbContext.BidDbs.GroupBy(bid => bid.AuctionId).ToList(); // Grupperar buden efter Id
            var highestBids = groupedBids.Select(group => group.OrderByDescending(bid => bid.BidAmount).FirstOrDefault()).ToList(); // Hämtar högsta budet för varje auktion
            var userHighestBids = highestBids.Where(bid => bid.Username == username); // Väljer högsta budet om användarnamnet är samma som parametern
            var auctionIds = userHighestBids.Select(bid => bid.AuctionId);      // Väljer det id:et
            return auctionIds;
        }

        public IEnumerable<BidDb> GetOrderedBids(int auctionId)
        {
            var items = AuctionDbContext.BidDbs.Where(p => p.AuctionId == auctionId)
                .OrderByDescending(p => p.BidAmount);
            return items;
        }

        public IEnumerable<int> GetAuctionIdsFromUsername(string username)
        {
            var items = AuctionDbContext.BidDbs.Where(p => p.Username == username).Select(p => p.AuctionId);
            return items;
        }

        public AuctionDbContext? AuctionDbContext
        {
            get
            {
                return _context as AuctionDbContext;
            }
        }


    }
}
