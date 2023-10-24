using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DistLab2.ViewModels
{
    public class CreateBidViewModel : IValidatableObject
    {

        [ScaffoldColumn(false)]
        public int AuctionId { get; set; }

        [ScaffoldColumn(false)]
        public string AuctionName { get; set; }

        [ScaffoldColumn(false)]
        public double CurrentHighestBid { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public double BidAmount { get; set; }





        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            Debug.WriteLine("Validation method called");
            if (BidAmount <= CurrentHighestBid)
            {
                yield return new ValidationResult(
                    $"BidAmount must be greater than current price: ({CurrentHighestBid}).",
                    new[] { nameof(BidAmount) }
                );
            }
        }


    }
}
