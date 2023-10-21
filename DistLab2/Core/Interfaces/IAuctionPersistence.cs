namespace DistLab2.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAll();
        public List<Auction> GetAllByUsername(string username);

        public void EditDescription(string description, int id);
        public bool UserIsOwner(string username, int auctionId);
        public void Add(Auction auction);

        public List<Auction> GetOngoing();
    }
}
