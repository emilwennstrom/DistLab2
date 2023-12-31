﻿using DistLab2.Persistence.DAO;
using DistLab2.Persistence.Interfaces;

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
            var items = AuctionDbContext.AuctionDbs.Where(p => p.EndDate > DateTime.Now && !string.IsNullOrEmpty(p.Username))
                .OrderBy(p => p.EndDate);

            return items;

        }

        public IEnumerable<AuctionDb> GetOngoingAuctionsFromIds(List<int> ids)
        {
            ids = ids.Distinct().ToList(); // så endast en auktion hämtas per id
            var items = AuctionDbContext.AuctionDbs.Where(p => ids.Contains(p.Id)).Where(p => p.EndDate > DateTime.Now);
            return items;
        }

        public IEnumerable<AuctionDb> GetWonAuctionsFromIds(List<int> ids)
        {

            var items = AuctionDbContext.AuctionDbs.Where(p => ids.Contains(p.Id)).Where(p => p.EndDate < DateTime.Now);

            return items;
        }
    }
}
