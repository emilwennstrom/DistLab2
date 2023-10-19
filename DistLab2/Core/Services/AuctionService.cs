using DistLab2.Core.Interfaces;

namespace DistLab2.Core.Services
{
    public class AuctionService : IAuctionService
    {
        IAuctionPersistence _persistence;
        public AuctionService(IAuctionPersistence persistence)
        {
            _persistence = persistence;
        }

        public List<Auction> GetAll()
        {
            return _persistence.GetAll();
        }
    }
}
