namespace DistLab2.ViewModels
{
    public class MyAuctionsViewModel
    {

        public List<AllAuctionsViewModel> UserOwnedAuctions { get; set; }  = new List<AllAuctionsViewModel>();
        public List<AllAuctionsViewModel> UserWinnedAuctions { get; set; } = new List<AllAuctionsViewModel>();


    }
}
