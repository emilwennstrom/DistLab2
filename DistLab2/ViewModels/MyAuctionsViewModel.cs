namespace DistLab2.ViewModels
{
    public class MyAuctionsViewModel
    {

        public List<AuctionViewModel> UserOwnedAuctions { get; set; }  = new List<AuctionViewModel>();
        public List<AuctionViewModel> UserWinnedAuctions { get; set; } = new List<AuctionViewModel>();


    }
}
