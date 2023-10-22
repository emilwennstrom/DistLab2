using AutoMapper;
using DistLab2.Core;
using DistLab2.Persistence.DAO;
using DistLab2.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace DistLab2.Persistence.Repositories
{
    public class AuctionRepository : Repository<AuctionDb>, IAuctionRepository
    {


        public AuctionRepository(AuctionDbContext context) : base(context)
        {
            
        }

        

        public AuctionDbContext? AuctionDbContext 
        { 
            get 
            {
                return _context as AuctionDbContext;  
            }
        }

        public IEnumerable<AuctionDb> GetOngoingAuctions()
        {
            var items = AuctionDbContext.AuctionDbs.Where(p => p.EndDate > DateTime.Now)
                .OrderBy(p => p.EndDate);

            return items;
            
        }

        public IEnumerable<AuctionDb> GetWonAuctionsFromId(List<int> ids)
        {

            var items = AuctionDbContext.AuctionDbs.Where(p => ids.Contains(p.Id)).Where(p => p.EndDate < DateTime.Now);

            return items;
        }
    }
}
