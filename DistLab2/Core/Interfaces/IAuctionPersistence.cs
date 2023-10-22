﻿namespace DistLab2.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();
        List<Auction> GetAllByUsername(string username);
        void EditDescription(string description, int id);
        bool UserIsOwner(string username, int auctionId);
        void Add(Auction auction);

        List<Auction> GetOngoing();

        List<Bid> GetBids(int auctionId);

        double GetHighestBid(int auctionId);
        void AddBid(Bid bid);
        List<Auction> GetAuctionsWithUserBids(string username);
        List<Auction> GetWonAuctions(string username);
    }
}
