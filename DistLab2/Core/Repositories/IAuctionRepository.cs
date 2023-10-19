namespace DistLab2.Core.Repositories
{
    public interface IAuctionRepository : IRepository<Auction>
    {
        public void EditAuction(Auction auction);
        public IEnumerable<Auction> GetMostExpensive(int count);
    }
}
