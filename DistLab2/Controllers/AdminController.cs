using DistLab2.Areas.Identity.Data;
using DistLab2.Core;
using DistLab2.Core.Interfaces;
using DistLab2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DistLab2.Controllers
{

    [Authorize(Roles = "Admin")] //endast admin har access till dessa resurser
    public class AdminController : Controller
    {
        private readonly IAuctionService AuctionService;
        private readonly UserManager<DistUser> _userManager;

        public AdminController(IAuctionService service, UserManager<DistUser> userManager)
        {
            AuctionService = service;
            _userManager = userManager;

        }

        //hämtar info om användare och dess auctions
        public ActionResult UserInfo()
        {
            if (ModelState.IsValid)
            {
                var users = _userManager.Users.ToList();
                List<UserViewModel> userVm = new();
                foreach (var u in users)
                {
                    userVm.Add(UserViewModel.FromUser(u));
                }
                return View(userVm);
            }
            else return View();
        }


        public ActionResult ShowAuctions(string UserName)
        {
            //TODO: sätt ihop getAllByUsername med GetHighestBid metod i AuctionServices.
            List<Auction> auctions = AuctionService.GetAllByUsername(UserName);
            if (auctions != null)
            {
                List<AuctionViewModel> auctionVm = new();
                foreach (Auction a in auctions)
                {
                    auctionVm.Add(AuctionViewModel.FromAuction(a));
                }
                return View(auctionVm);
            }
            return RedirectToAction("UserInfo");
            //TODO: redirect när användare inte har auction
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                // User not found
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {

                return RedirectToAction("UserInfo"); // Assuming you have a ListUsers action to show all users
            }

            // Handle any errors here by adding them to the ModelState and returning the view
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View("UserInfo"); // Return to the list with error messages
        }




        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }


        // GET: AdminController/Details/5
        //shows bids on auctions for specific user
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





        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuction(int Id, IFormCollection collection)
        {
            try
            {
                AuctionService.DeleteAuction(Id);

                return RedirectToAction(nameof(UserInfo));
            }
            catch
            {
                return View();
            }
        }


        /* 
        // POST: AdminController/Delete/5
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
        */
    }
}
