using DistLab2.Areas.Identity.Data;
using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence;
using DistLab2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DistLab2.Controllers
{
    [Authorize]
    //[Authorize(Roles = "Admin")] //endast admin har access till dessa resurser
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
                List<AllAuctionsViewModel> auctionVm = new();
                foreach (Auction a in auctions)
                {
                    double highestBid= AuctionService.GetHighestBid(a.Id);
                    auctionVm.Add(AllAuctionsViewModel.FromAuction(a,highestBid));
                }
                return View(auctionVm);
            }else return View();
        }

        //visar alla auctions som usern har själv lagt upp, samt vilka auktioner användaren har vunnit.
        // GET: AuctionController
        public ActionResult MyAuctions()
        {
            string currentUser = GetCurrentUser(); //name måste vara unikt. Dubbelkolla att det är så.
            if (currentUser != null)
            {
                List<Auction> auctions = AuctionService.GetAllByUsername(currentUser);
                List<AllAuctionsViewModel> auctionVm = new();

                List<Auction> wonAuctions = AuctionService.GetWonAuctions(currentUser);

                List<AllAuctionsViewModel> wonAuctionsVm = new();

                foreach (Auction a in auctions)
                {
                    double highestBid = AuctionService.GetHighestBid(a.Id);
                    auctionVm.Add(AllAuctionsViewModel.FromAuction(a, highestBid));
                }

                foreach (Auction b in wonAuctions)
                {
                    double highestBid = AuctionService.GetHighestBid(b.Id);
                    wonAuctionsVm.Add(AllAuctionsViewModel.FromAuction(b, highestBid));
                }


                MyAuctionsViewModel viewModel = new MyAuctionsViewModel();
                viewModel.UserWinnedAuctions.AddRange(wonAuctionsVm);
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


            List<AllAuctionsViewModel> auctionViews = new();

            foreach (Auction auction in userBiddedAuctions)
            {
                double highestBid = AuctionService.GetHighestBid(auction.Id);
                AllAuctionsViewModel auctionViewModel = AllAuctionsViewModel.FromAuction(auction, highestBid);
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
                Auction auction = new();
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
            //måste man ha en IFormCollection
            
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBid(int id, string username, string auctionName, DateTime endDate)
        {

            string? currentUser = GetCurrentUser();
            
            if (currentUser == null || currentUser == username)
            {
                var referer = Request.Headers["Referer"].ToString(); // If no user or current user auction
                return Redirect(referer);
            }

            CreateBidViewModel vm = new CreateBidViewModel();
            vm.CurrentHighestBid = AuctionService.GetHighestBid(id);
            vm.AuctionId = id;
            vm.AuctionName = auctionName;
            vm.EndDate = endDate;
            

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid(CreateBidViewModel vm)
        {
            if (GetCurrentUser() != null)
            {
                if (ModelState.IsValid && AuctionService.CheckIfOngoing(vm.EndDate))
                {
                    Bid bid = new();
                    bid.BidAmount = vm.BidAmount;
                    bid.Username = GetCurrentUser();
                    bid.AuctionId = vm.AuctionId;
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
