using DistLab2.Core;

namespace DistLab2.ViewModels
{
    public class BidViewModel
    {
        public string Username { get; set; }
        public DateTime DateOfBid { get; set; }
        public double BidAmount { get; set; }


        public static BidViewModel FromBid(Bid bid)
        {
            return new BidViewModel
            {
                Username = bid.Username,
                DateOfBid = bid.DateOfBid,
                BidAmount = bid.BidAmount
            };
        }
    }
}
