namespace DistLab2.Core.Interfaces
{
    public interface IAuctionService
    {
        public List<Auction> GetAll();
        public List<Auction> GetAllByUsername(string username);
    }
}
