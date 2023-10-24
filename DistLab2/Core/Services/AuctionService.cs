using DistLab2.Core.Interfaces;

namespace DistLab2.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionPersistence _persistence;
        public AuctionService(IAuctionPersistence persistence)
        {
            _persistence = persistence;
        }
        public List<Auction> GetAllByUsername(string username)
        {
            return _persistence.GetAllByUsername(username);
        }

        public void Add(Auction auction)
        {
            //asume no bids on new auction.
            //assume Username , title, description and starting price set.
            if (auction == null || auction.Id != 0) { throw new InvalidDataException(); } //om id är satt till 0 kommer EntityFramework att auto-increment:a Idt i databasen automatiskt (pga id är satt till primary key)
            auction.CreationDate = DateTime.Now;
            auction.EndDate = DateTime.Now.AddMonths(1);
            auction.Id = 0;
            auction.Bids = new List<Bid>();
            _persistence.Add(auction);
        }

        public void EditDescription(string description, int id)
        {
            _persistence.EditDescription(description, id);
        }

        public bool UserIsOwner(string username, int auctionId)
        {
            if (username == null || username.Length == 0) { return false; }
            return _persistence.UserIsOwner(username, auctionId);
        }

        public List<Auction> GetOngoing()
        {
            return _persistence.GetOngoing();
        }

        public List<Bid> GetBids(int auctionId)
        {
            return _persistence.GetBids(auctionId);
        }

        public double GetHighestBid(int id)
        {
            return _persistence.GetHighestBid(id);
        }

        public void AddBid(Bid bid)
        {
            bid.DateOfBid = DateTime.Now;




            _persistence.AddBid(bid);
        }

        public List<Auction> GetAuctionsWithUserBids(string username)
        {
            return _persistence.GetAuctionsWithUserBids(username);
        }

        public List<Auction> GetWonAuctions(string username)
        {
            return _persistence.GetWonAuctions(username);
        }

        public bool CheckIfOngoing(DateTime endDate)
        {
            return (endDate > DateTime.Now);
        }

        public void DeleteAuction(int id)
        {
            _persistence.DeleteAuction(id);
        }
    }
}
