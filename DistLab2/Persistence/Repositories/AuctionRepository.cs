using DistLab2.Core.Models;
using DistLab2.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence.Repositories
{
    public class AuctionRepository : Repository<Auction>, IAuctionRepository
    {

        private readonly DbContext _dbContext;
        public AuctionRepository(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void EditAuction(Auction auction)
        {
            throw new NotImplementedException();
        }
    }
}
