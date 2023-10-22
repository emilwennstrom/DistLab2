
using DistLab2.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence
{

    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _context;

        public UnitOfWork(AuctionDbContext context, IAuctionRepository auctionRepository, IBidRepository bidRepository)
        {
            _context = context;
            Auctions = auctionRepository;
            Bids = bidRepository;
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
