using DistLab2.Core;

namespace DistLab2.ViewModels
{
    public class BidDetailViewModel
    {


        public string AuctionName { get; set; }
        public List<BidViewModel> BidsVm { get; set; } = new List<BidViewModel>();



        public static BidDetailViewModel FromBid(List<Bid> bids, string name)
        {
            var vm = new BidDetailViewModel
            {
                AuctionName = name,
            };
            foreach (var bid in bids)
            {
                vm.BidsVm.Add(BidViewModel.FromBid(bid));
            }

            return vm;
        }


    }
}
