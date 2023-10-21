using AutoMapper;
using DistLab2.Core;
using DistLab2.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence.Repositories
{
    public class AuctionRepository : Repository<AuctionDb>, IAuctionRepository
    {

        private List<Auction> auctions;
        //private Mapper _mapper;
     
        public AuctionRepository(AuctionDbContext context) : base(context)
        {
            auctions = new List<Auction>();
            //_mapper = mapper;
        }

        public IEnumerable<AuctionDb> GetMostExpensive(int count)
        {
            var auctionDbs = AuctionDbContext.AuctionDbs.OrderByDescending(c => c.StartingPrice).Take(count);


           return auctionDbs;

        }


        public IEnumerable<AuctionDb> GetAllByUsername(string username)
        {
            return AuctionDbContext.AuctionDbs.Where(p => p.Username.Equals(username));
        }

        public void EditAuction(Auction auction)
        {
            //var auctionDb = AuctionDbContext.AuctionDbs.F
        }

        public IEnumerable<AuctionDb> GetOngoing()
        {
            var auctionDbs = AuctionDbContext.AuctionDbs.Where(p => p.EndDate > DateTime.Now).OrderBy(p => p.EndDate);

            return auctionDbs;
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
