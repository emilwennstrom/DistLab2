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
        // GET: AuctionController
        public ActionResult Index()
        {
            List<Auction> auctions = AuctionService.GetAll();
            List<AuctionViewModel> auctionVm = new();
            foreach(Auction a in auctions) {
                auctionVm.Add(AuctionViewModel.FromAuction(a));
            }
            return View(auctionVm);
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuctionCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction(vm.Name, vm.Description, vm.StartingPrice);
                auction.CreationDate = DateTime.Now;
                auction.EndDate = DateTime.Now.AddMonths(1);
                auction.Username = "Username";
               // Worker.Auctions.Add(auction);
                //_worker.Complete(); Saves the db
                return RedirectToAction("Index");
            } else return View();
        }

        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
