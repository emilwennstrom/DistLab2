using DistLab2.Core;
using System.ComponentModel.DataAnnotations;

namespace DistLab2.Persistence
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //TODO: lägg till user
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public List<BidDb> Bids { get; set; }
    }
}
