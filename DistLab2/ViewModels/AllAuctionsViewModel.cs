using DistLab2.Core;
using System.Diagnostics;

namespace DistLab2.ViewModels
{
    public class AllAuctionsViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double highestBid { get;set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }
        public List<BidViewModel> Bids { get; set; } = new();

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
            if (auction.Bids != null)
            {

                foreach (var bid in auction.Bids) // Ska en lista skapas när man skapar en auction från 
                {                               // Eller ska den skapas när första budet läggs till
                    vm.Bids.Add(BidViewModel.FromBid(bid));
                    Debug.WriteLine(bid.Username);
                }
            }
            return vm;
        }
    }
}
