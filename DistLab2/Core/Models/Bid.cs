namespace DistLab2.Core
{
    public class Bid
    {


        public Bid(DateTime now, double bidAmount, string name, int auctionId)
        {
            DateOfBid = now;
            BidAmount = bidAmount;
            Username = name;
            AuctionId = auctionId;
        }

        public Bid() { }


        public int Id { get; set; }
        public DateTime DateOfBid { get; set; }
        public double BidAmount { get; set; }
        public string Username { get; set; }
        public int AuctionId { get; set; }
    }
}
