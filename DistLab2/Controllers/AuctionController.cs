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
        private readonly IUnitOfWork _worker;
        public AuctionController(IUnitOfWork worker) 
        {
            _worker = worker;
        }
        // GET: AuctionController
        public ActionResult Index()
        {
            List<Auction> auctions = (List<Auction>)_worker.Auctions.GetAll();
            List<AuctionViewModel> auctionVm = new();
            foreach(Auction a in auctions) {
                auctionVm.Add(AuctionViewModel.FromAuction(a));
            }
            return View(auctionVm);
        }

        [HttpGet]
        public ActionResult Sort()
        {
            List<Auction> auctions = (List<Auction>)_worker.Auctions.GetMostExpensive(2);
            List<AuctionViewModel> auctionVm = new();
            foreach (Auction a in auctions)
            {
                auctionVm.Add(AuctionViewModel.FromAuction(a));
            }
            return View("Index", auctionVm);
        }

        public ActionResult Add(AuctionViewModel vm)
        {

            Auction auction = new Auction(vm.Name, vm.Description, vm.StartingPrice, vm.EndDate);
            auction.CreationDate = DateTime.Now;

            _worker.Auctions.Add(auction);
            
            return View("Index", vm);
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
        public ActionResult Create(IFormCollection collection)
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
