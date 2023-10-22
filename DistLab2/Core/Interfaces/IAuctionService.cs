namespace DistLab2.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        List<Auction> GetAllByUsername(string username);
        void EditDescription(string description, int id);
        bool UserIsOwner(string username, int auctionId);
        void Add(Auction auction);

        List<Auction> GetOngoing();

        List<Bid> GetBids(int auctionId);

        double GetHighestBid(int id);
        void AddBid(Bid bid);
        List<Auction> GetAuctionsWithUserBids(string username);

        List<Auction> GetWonAuctions(string username);

        bool CheckIfOngoing(DateTime endDate);

    }
}
