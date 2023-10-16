using DistLab2.Core.Repositories;

namespace DistLab2.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        IAuctionRepository Auctions { get; }
        IBidRepository Bids { get; }

    }
}
