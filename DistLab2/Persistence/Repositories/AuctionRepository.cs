using AutoMapper;
using DistLab2.Core;
using DistLab2.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence.Repositories
{
    public class AuctionRepository : Repository<Auction>, IAuctionRepository
    {

        private List<Auction> auctions;
        private Mapper _mapper;
     
        public AuctionRepository(AuctionDbContext context, Mapper mapper) : base(context)
        {
            auctions = new List<Auction>();
            _mapper = mapper;
        }

        public IEnumerable<Auction> GetMostExpensive(int count)
        {
            var auctionDbs = AuctionDbContext.AuctionDbs.OrderByDescending(c => c.StartingPrice).Take(count).ToList();


            var result = new List<Auction>();
            if (auctionDbs != null)
            {
                foreach (var adb in auctionDbs) 
                {
                    var auction = _mapper.Map<Auction>(adb);
                    result.Add(auction);
                }
            }


            return result;


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
