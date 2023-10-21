using Azure.Identity;
using DistLab2.Core;
using System.Diagnostics;

namespace DistLab2.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO: lägg till user
        public int StartingPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }
        public List<BidViewModel> Bids { get; set; } = new();

        public static AuctionViewModel FromAuction(Auction auction)
        {
            var vm = new AuctionViewModel
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                StartingPrice = auction.StartingPrice,
                CreationDate = auction.CreationDate,
                EndDate = auction.EndDate,
                Username = auction.Username,
            };
            if (auction.Bids != null ) 
            {
                foreach(var bid in auction.Bids) // Ska en lista skapas när man skapar en auction från 
                {                               // Eller ska den skapas när första budet läggs till
                    vm.Bids.Add(BidViewModel.FromBid(bid));
                    Debug.WriteLine(bid.Username);
                }
            }
            return vm;
        }

      

    }
   
}
