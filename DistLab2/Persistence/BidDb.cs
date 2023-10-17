using System.ComponentModel.DataAnnotations;

namespace DistLab2.Persistence
{
    public class BidDb
    {
        [Key]
        public int AuctionId { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DateOfBid { get; set; }
        //TODO: lägg till user
    }
}
