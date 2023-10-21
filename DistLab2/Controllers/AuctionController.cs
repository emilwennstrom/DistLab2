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

            string Username = User.Identity.Name; //name måste vara unikt. Dubbelkolla att det är så.
            if (Username != null)
            {
                List<Auction> auctions = AuctionService.GetAllByUsername(Username);
                List<AuctionViewModel> auctionVm = new();
                foreach (Auction a in auctions)
                {
                    auctionVm.Add(AuctionViewModel.FromAuction(a));
                }
                return View(auctionVm);
            }
            return View();
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id, string name)
        {
            List<Bid> bids = AuctionService.GetBids(id);
            Debug.WriteLine(bids.Count);
            if (bids is not null)
            {
                BidDetailViewModel vm = BidDetailViewModel.FromBid(bids, name);
                return View(vm);

            }

            return RedirectToAction("Index");
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
                auction.Username = User.Identity.Name;
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

            if(AuctionService.UserIsOwner(User.Identity.Name, id))
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



        


    }


}
