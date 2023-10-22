using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence;
using DistLab2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DistLab2.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService AuctionService;
        public AuctionController(IAuctionService service) 
        {
            AuctionService = service;

        }

        //visar alla auctions
        // GET: AuctionController
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                List<Auction> auctions = AuctionService.GetOngoing();
                List<AuctionViewModel> auctionVm = new();
                foreach (Auction a in auctions)
                {
                    auctionVm.Add(AuctionViewModel.FromAuction(a));
                }
                return View(auctionVm);
            }else return View();
        }

        //visar alla auctions som usern har själv lagt upp
        // GET: AuctionController
        public ActionResult MyAuctions()
        {
            string currentUser = GetCurrentUser(); //name måste vara unikt. Dubbelkolla att det är så.
            if (currentUser != null)
            {
                List<Auction> auctions = AuctionService.GetAllByUsername(currentUser);
                List<AuctionViewModel> auctionVm = new();

                List<Auction> winned = AuctionService.GetWonAuctions(currentUser);

                List<AuctionViewModel> winnedVm = new();

                foreach (Auction a in auctions)
                {
                    auctionVm.Add(AuctionViewModel.FromAuction(a));
                }

                foreach (Auction b in winned)
                {
                    winnedVm.Add(AuctionViewModel.FromAuction(b));
                }


                MyAuctionsViewModel viewModel = new MyAuctionsViewModel();
                viewModel.UserWinnedAuctions.AddRange(winnedVm);
                viewModel.UserOwnedAuctions.AddRange(auctionVm);


                return View(viewModel);
            }
            return View();
        }

        //Hämtar Auctions som en användare lagt bud på
        public ActionResult MyAuctionBids()
        {

            string currentUser = GetCurrentUser();
            if (currentUser == null) return RedirectToAction("Index");

            List<Auction> userBiddedAuctions = AuctionService.GetAuctionsWithUserBids(currentUser);
            Debug.WriteLine(userBiddedAuctions.Count);


            List<AuctionViewModel> auctionViews = new();

            foreach (Auction auction in userBiddedAuctions)
            {
                AuctionViewModel auctionViewModel = AuctionViewModel.FromAuction(auction);
                auctionViews.Add(auctionViewModel);
            }
            return View(auctionViews);
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id, string name)
        {
            List<Bid> bids = AuctionService.GetBids(id);
            Debug.WriteLine(bids.Count);
            if (bids.Count > 0)
            {
                BidDetailViewModel vm = BidDetailViewModel.FromBid(bids, name);
                return View(vm);

            }
            return Redirect(Request.Headers["Referer"].ToString()); // Returns to previous page if there are no bids
        }

        // GET: AuctionController/Create. Detta visas första gången användare går in på sidan. Då är formuläret tomt. 
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionController/Create. Det som händer när användaren har fyllt i formuläret och tryckt på submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction(vm.Name, vm.Description, vm.StartingPrice);
                auction.Username = GetCurrentUser();
                auction.Name = vm.Name;
                auction.Description = vm.Description;
                auction.StartingPrice = vm.StartingPrice;
                AuctionService.Add(auction);
                return RedirectToAction("Index");
            } else return View();
        }

        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            if(AuctionService.UserIsOwner(GetCurrentUser(), id))
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, AuctionViewModel auction)
        {
            //if (!AuctionService.userIsOwnerOfAuction(User.Identity.Name, id)) return RedirectToAction("Index");
           //TODO: man borde validera här också. Den ovan funkar inte av någon anledning
            //måste man ha en IFormCollection????
            try
            {
                //TODO: kollar inte om ModelState är valid. Det funkade inte för mig när jag testade med det.
                AuctionService.EditDescription(auction.Description, id);
                return RedirectToAction("Index");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuctionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult AddBid(int id, string username, string auctionName)
        {
            
            string? currentUser = GetCurrentUser();

            if (currentUser == null || currentUser == username)
            {
                var referer = Request.Headers["Referer"].ToString(); // If no user or current user auction
                return Redirect(referer);
            }

            CreateBidViewModel vm = new CreateBidViewModel();
            vm.CurrentHighestBid = AuctionService.GetHighestBid(id);
            Debug.WriteLine(vm.CurrentHighestBid);
            vm.AuctionId = id;
            vm.AuctionName = auctionName;
            

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid(CreateBidViewModel vm)
        {
            if (User.Identity.Name != null)
            {
                if (ModelState.IsValid)
                {
                    Bid bid = new Bid(DateTime.Now, vm.BidAmount, User.Identity.Name, vm.AuctionId);
                    Debug.WriteLine("Valid");
                    AuctionService.AddBid(bid);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("AddBid", vm);
                }
            }

            return RedirectToAction("Index");   
        }

        

        private string GetCurrentUser()
        {
            return User.Identity.Name;
        }


       
    }


}
