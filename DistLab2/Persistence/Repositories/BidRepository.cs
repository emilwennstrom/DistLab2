using DistLab2.Core;
using DistLab2.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DistLab2.Persistence.Repositories
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        public BidRepository(DbContext context) : base(context)
        {



        }
    }
}
