using System.ComponentModel.DataAnnotations;

namespace DistLab2.ViewModels
{
    public class AuctionCreateViewModel
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length is 128 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        //TODO: lägg till user
        [Required]
        public int StartingPrice { get; set; }


        //[Required]
        //public DateTime DateTime {  get; set; } 




    }
}
