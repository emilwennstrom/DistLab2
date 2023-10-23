using Azure.Identity;
using DistLab2.Core;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DistLab2.ViewModels
{
    public class AuctionViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO: lägg till user
        public int StartingPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }

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
           
            return vm;
        }

      

    }
   
}
