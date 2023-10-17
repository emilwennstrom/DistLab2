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
        public List<Bid>? Bids { get; set; }

        public static AuctionViewModel FromAuction(Auction auction)
        {
            return new AuctionViewModel
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                StartingPrice = auction.StartingPrice,
                CreationDate = auction.CreationDate,
                EndDate = auction.EndDate,
                Bids = auction.Bids
            };
        }

      

    }
   
}
