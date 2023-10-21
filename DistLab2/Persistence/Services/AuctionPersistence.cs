using AutoMapper;
using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence.DAO;
using DistLab2.Persistence.Interfaces;
using System.Diagnostics;

namespace DistLab2.Persistence.Services
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



        private List<Auction> ConvertAuctionDbToAuction(List<AuctionDb> auctionDbList)
        {
            List<Auction> auctions = new List<Auction>();
            foreach (var auctionDb in auctionDbList)
            {
                Auction auction = _mapper.Map<Auction>(auctionDb);  // Mapper
                foreach (BidDb dbBid in auctionDb.Bids)
                {
                    Bid bid = _mapper.Map<Bid>(dbBid);  // Mapper
                    Debug.WriteLine(bid.Username);
                    auction.Bids.Add(bid);
                }
                auctions.Add(auction);
            }
            return auctions;
        }

        private AuctionDb ConvertAuctionToAuctionDb(Auction auction)
        {
            AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);  // Mapper
            return auctionDb;
        }

        public List<Auction> GetAll()
        {
            List<AuctionDb> auctionDbList = _unitOfWork.Auctions.GetAll().ToList();

            foreach (AuctionDb adb in auctionDbList)
            {
                Debug.WriteLine(adb.ToString());
            }
            return ConvertAuctionDbToAuction(auctionDbList);
        }


        public List<Auction> GetAllByUsername(string username)
        {
            List<AuctionDb> dbList = _unitOfWork.Auctions.Find(p => p.Username.Equals(username)).ToList();
            return ConvertAuctionDbToAuction(dbList);
        }

        public void Add(Auction auction)
        {
            AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);
            _unitOfWork.Auctions.Add(auctionDb);
            _unitOfWork.Complete();
        }

        public void EditDescription(string description, int id)
        {
            AuctionDb auctionDb = _unitOfWork.Auctions.Get(id);
            auctionDb.Description = description;
            _unitOfWork.Complete();
        }

        public bool UserIsOwner(string username, int auctionId)
        {
            if (username == null || username.Length == 0) { return false; }
            AuctionDb auctionDb = _unitOfWork.Auctions.Get(auctionId);
            if (auctionDb == null) { return false; }
            if (auctionDb.Username == username)
            {
                _unitOfWork.Dispose();
                return true;
            }
            return false;
        }

        public List<Auction> GetOngoing()
        {
            var ongoingAuctions = _unitOfWork.Auctions
                .Find(p => p.EndDate > DateTime.Now)
                .OrderBy(p => p.EndDate).ToList();


            return ConvertAuctionDbToAuction(ongoingAuctions);
        }

        public List<Bid> GetBids(int auctionId)
        {
            List<BidDb> bidDbs = _unitOfWork.Bids.Find(p => p.AuctionId == auctionId)
                .OrderByDescending(p => p.BidAmount)
                .ToList();
            List<Bid> bids = new();

            foreach (var bidDb in bidDbs) 
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                bids.Add(bid);
            }

            return bids;
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

    }
}
