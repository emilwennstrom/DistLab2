using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistLab2.Persistence.DAO
{
    public class BidDb
    {
        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DateOfBid { get; set; }

        [Required]
        public double BidAmount { get; set; }

        [Required]
        public string Username { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDb AuctionDb { get; set; }
        public int AuctionId { get; set; }
    }
}
