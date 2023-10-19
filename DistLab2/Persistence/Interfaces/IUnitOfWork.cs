namespace DistLab2.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        IAuctionRepository Auctions { get; }
        IBidRepository Bids { get; }

    }
}
