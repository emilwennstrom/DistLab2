using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence.Interfaces;
using DistLab2.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DistLab2.Persistence.MockClasses
{
    public class MockAuctionRepository : Repository<AuctionDb>, IAuctionRepository
    {


        public MockAuctionRepository(AuctionDbContext context) : base(context)
        {



        }

        public void EditAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AuctionDb> IAuctionRepository.GetMostExpensive(int count)
        {
            throw new NotImplementedException();
        }
    }
}
