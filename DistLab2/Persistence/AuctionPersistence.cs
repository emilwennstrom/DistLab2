using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence.Interfaces;

namespace DistLab2.Persistence
{
    public class AuctionPersistence : IAuctionPersistence
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuctionPersistence(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }


        public List<Auction> GetAll()
        {
            List<AuctionDb> auctionDbList = _unitOfWork.Auctions.GetAll().ToList();
            // Mapper
            List<Auction> auctions = new List<Auction>();
            foreach (var auctionDb in auctionDbList)
            {
                Auction auction = new Auction();
                auction.Id = auctionDb.Id;
                auction.Name = auctionDb.Name;
                auction.CreationDate = auctionDb.CreationDate;
                auction.EndDate = auctionDb.EndDate;
                auction.Username = auctionDb.Username;
                auction.Description = auctionDb.Description;

                foreach(BidDb dbBid in auctionDb.Bids) 
                {
                    auction.Bids.Add(new Bid(dbBid.Id, dbBid.DateOfBid, dbBid.BidAmount, dbBid.Username));
                }

                auctions.Add(auction);
            }
            return auctions;
        }
    }
}
