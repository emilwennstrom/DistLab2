namespace DistLab2.Core
{
    public class Bid
    {
        public Bid(int auctionId, DateTime dateOfBid)
        {
            AuctionId = auctionId;
            DateOfBid = dateOfBid;
        }

        public int AuctionId { get; set; }

        public DateTime DateOfBid { get; set; }
        //TODO: lägg till user

    }
}
