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
        public List<Auction> GetAllByUsername(string username)
        {
            return _persistence.GetAllByUsername(username);
        }

        public List<Auction> GetAll()
        {
            return _persistence.GetAll();
        }

        public void Add(Auction auction)
        {
            //asume no bids on new auction.
            //assume Username , title, description and starting price set.
            if (auction == null || auction.Id!=0) { throw new InvalidDataException(); } //om id är satt till 0 kommer EntityFramework att auto-increment:a Idt i databasen automatiskt (pga id är satt till primary key)
            auction.CreationDate= DateTime.Now;
            auction.EndDate = DateTime.Now.AddMonths(1);
            auction.Id = 0;
            auction.Bids = new List<Bid>();
            _persistence.Add(auction);
        }

        public void editAuctionDescriptionById(string description, int id)
        {
            _persistence.editAuctionDescriptionById(description, id);
        }

        public bool userIsOwnerOfAuction(string username, int auctionId)
        {
            if(username==null || username.Length==0) { return false; }
            return _persistence.userIsOwnerOfAuction(username, auctionId);
        }
    }
}
