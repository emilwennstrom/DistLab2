using DistLab2.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistLab2.Controllers
{
    public class AuctionController : Controller
    {
        private IUnitOfWork _worker;
        public AuctionController(IUnitOfWork worker) 
        {
            _worker = worker;
        }
        // GET: AuctionController
        public ActionResult Index()
        {
            return View();
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
