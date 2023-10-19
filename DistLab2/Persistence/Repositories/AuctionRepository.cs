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
            var auctionDbs = AuctionDbContext.AuctionDbs.OrderByDescending(c => c.StartingPrice).Take(count).ToList();


           return auctionDbs;

        }

        public void EditAuction(Auction auction)
        {
            //_context.Set<Auction>().Add(auction);
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
