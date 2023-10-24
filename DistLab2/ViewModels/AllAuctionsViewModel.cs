using DistLab2.Core;

namespace DistLab2.ViewModels
{
    public class AllAuctionsViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double highestBid { get; set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }

        public static AllAuctionsViewModel FromAuction(Auction auction, double highestBid)
        {
            var vm = new AllAuctionsViewModel
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                highestBid = highestBid,
                EndDate = auction.EndDate,
                Username = auction.Username,
            };

            return vm;
        }
    }
}
