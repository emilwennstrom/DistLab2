using DistLab2.Core;
using DistLab2.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence.Repositories
{
    public class BidRepository : Repository<BidDb>, IBidRepository
    {
        public BidRepository(DbContext context) : base(context)
        {



        }
    }
}
