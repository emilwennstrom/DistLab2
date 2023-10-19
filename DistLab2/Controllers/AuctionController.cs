using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.Persistence;
using DistLab2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DistLab2.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IUnitOfWork Worker;
        public AuctionController(IUnitOfWork worker) 
        {
            Worker = worker;
        }
        // GET: AuctionController
        public ActionResult Index()
        {
            List<Auction> auctions = Worker.Auctions.GetAll().ToList();
            List<AuctionViewModel> auctionVm = new();
            foreach(Auction a in auctions) {
                auctionVm.Add(AuctionViewModel.FromAuction(a));
            }
            return View(auctionVm);
        }

        [HttpGet]
        public ActionResult Sort()
        {
            List<Auction> auctions = (List<Auction>)Worker.Auctions.GetMostExpensive(2);
            List<AuctionViewModel> auctionVm = new();
            foreach (Auction a in auctions)
            {
                auctionVm.Add(AuctionViewModel.FromAuction(a));
            }
            return View("Index", auctionVm);
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
                Worker.Auctions.Add(auction);
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
