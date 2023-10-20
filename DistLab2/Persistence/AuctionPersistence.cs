using AutoMapper;
using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence.Interfaces;
using System.Diagnostics;

namespace DistLab2.Persistence
{
    public class AuctionPersistence : IAuctionPersistence
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AuctionPersistence(IUnitOfWork unitOfWork, IMapper mapper) 
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /*
        public List<Auction> GetAll2()
        {
            List<AuctionDb> auctionDbList = _unitOfWork.Auctions.GetAll().ToList();
            // utan automapper
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
        } */

        private List<Auction> convertAuctionDbToAuction(List<AuctionDb> auctionDbList)
        {
            List<Auction> auctions = new List<Auction>();
            foreach (var auctionDb in auctionDbList)
            {
                Auction auction = _mapper.Map<Auction>(auctionDb);  // Mapper
                foreach (BidDb dbBid in auctionDb.Bids)
                {
                    Bid bid = _mapper.Map<Bid>(dbBid);  // Mapper
                    auction.Bids.Add(bid);
                }
                auctions.Add(auction);
            }
            return auctions;
        }

        private AuctionDb convertAuctionToAuctionDb(Auction auction)
        {
            AuctionDb auctionDb =  _mapper.Map<AuctionDb>(auction);  // Mapper
            return auctionDb;
        }

        public List<Auction> GetAll()
        {
            List<AuctionDb> auctionDbList = _unitOfWork.Auctions.GetAll().ToList();
            return convertAuctionDbToAuction(auctionDbList);
        }


        public List<Auction> GetAllByUsername(string username)
        {
            List<AuctionDb> auctionDbList = _unitOfWork.Auctions
                .GetAll()
                .Where(p => p.Username.Equals(username))
                .ToList();

            return convertAuctionDbToAuction(auctionDbList);
        }

        public void Add(Auction auction)
        {
            AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);
            _unitOfWork.Auctions.Add(auctionDb);
            _unitOfWork.Complete();
        }

        public void editAuctionDescriptionById(string description, int id)
        {
            AuctionDb auctionDb= _unitOfWork.Auctions.Get(id);
            auctionDb.Description = description;
            _unitOfWork.Complete();
        }

        public bool userIsOwnerOfAuction(string username, int auctionId)
        {
            if (username == null || username.Length == 0) { return false; }
            AuctionDb auctionDb = _unitOfWork.Auctions.Get(auctionId);
            if(auctionDb == null) { return false;}
            if(auctionDb.Username == username) {
                _unitOfWork.Dispose();
                return true; }
            return false;
        }
    }
}
