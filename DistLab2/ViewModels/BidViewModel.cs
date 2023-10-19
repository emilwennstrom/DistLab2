using DistLab2.Core;

namespace DistLab2.ViewModels
{
    public class BidViewModel
    {
        public int AuctionId { get; set; }
        public DateTime DateOfBid { get; set; }
        public double BidAmount { get; set; }


        public static BidViewModel FromBid(Bid bid)
        {
            return new BidViewModel
            {
                AuctionId = bid.Id,
                DateOfBid = bid.DateOfBid,
                BidAmount = bid.BidAmount
            };
        }
    }
}
