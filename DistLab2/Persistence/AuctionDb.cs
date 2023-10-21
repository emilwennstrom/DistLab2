using DistLab2.Core;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        
        [Required]
        public string Username { get; set; }
       
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public List<BidDb> Bids { get; set; } = new List<BidDb>();


        public override string? ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Id: " + Id)
                .AppendLine("Name " + Name);

            return stringBuilder.ToString();

        }
    }
}
