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
            var ongoingAuctions = _unitOfWork.Auctions.GetOngoingAuctions().ToList();

            return ConvertAuctionDbToAuction(ongoingAuctions);
        }

        public List<Bid> GetBids(int auctionId)
        {
            List<BidDb> bidDbs = _unitOfWork.Bids.GetOrderedBids(auctionId).ToList();
            List<Bid> bids = new();

            foreach (var bidDb in bidDbs) 
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                bids.Add(bid);
            }

            return bids;
        }


        public double GetHighestBid(int auctionId) 
        {

            //double highest = _unitOfWork.Bids.Find(p => p.AuctionId == (auctionId)).Max(p => p.BidAmount); Exception när inga bud är lagda
            var bids = _unitOfWork.Bids.Find(p => p.AuctionId == auctionId);
            if (!bids.Any()) // Om inga bud finns, sätt current till startingprice 
            {
                return _unitOfWork.Auctions.Get(auctionId).StartingPrice;   
            }

            double highestBid = 0;
            foreach(var bidDb in bids)
            {
                if(bidDb.BidAmount > highestBid)
                {
                    highestBid = bidDb.BidAmount;
                }
            }
            
           
            return highestBid;
        }

        // Hämtar alla auctions som en specifik användare lagt bud på.
        public List<Auction> GetAuctionsWithUserBids(string username)
        {
            var ids = _unitOfWork.Bids.GetAuctionIdsFromUsername(username).ToList();
            List<AuctionDb> auctionDbs = new();
            if (ids.Any())
            {
                auctionDbs = _unitOfWork.Auctions.GetOngoingAuctionsFromIds(ids).ToList();
            }
            return ConvertAuctionDbToAuction(auctionDbs);
        }


        public List<Auction> GetWonAuctions(string username)
        {
            var winningAuctionIds = _unitOfWork.Bids.FindLeadingAuctionIds(username).ToList();
            List<AuctionDb> auctionDbs = new();
            if (winningAuctionIds.Any())
            {
                auctionDbs = _unitOfWork.Auctions.GetWonAuctionsFromIds(winningAuctionIds).ToList();
            }
            return ConvertAuctionDbToAuction(auctionDbs);
        }


        public void AddBid(Bid bid)
        {
            BidDb bidDb = _mapper.Map<BidDb>(bid);
            _unitOfWork.Bids.Add(bidDb);
            _unitOfWork.Complete();
        }

        public void DeleteAuction(int id)
        {
            AuctionDb auctionDb = _unitOfWork.Auctions.Get(id);
            
            //automatic cascade delete of bidsDb related to Id of auction due to settings in EE databbase,
            //List<BidDb> bidsDBs= (List<BidDb>)_unitOfWork.Bids.Find(b => b.Id == id);
            //foreach(var bidDb in bidsDBs)
            //{ _unitOfWork.Bids.Remove(bidDb); };
            _unitOfWork.Auctions.Remove(auctionDb);
            _unitOfWork.Complete();
        }
    }
}
