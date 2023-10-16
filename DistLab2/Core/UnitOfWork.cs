using DistLab2.Core.Repositories;
using DistLab2.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Core
{

    public class UnitOfWork
    {   

        private readonly DbContext _context;

        public UnitOfWork(DbContext context) 
        {
            _context = context;
            Auctions = new AuctionRepository(context);
            Bids = new BidRepository(context);
        }

        public IAuctionRepository Auctions { get; set; }
        public IBidRepository Bids { get; set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
