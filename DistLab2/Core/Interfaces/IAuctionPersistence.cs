namespace DistLab2.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAll();
        public List<Auction> GetAllByUsername(string username);

    }
}
