using DistLab2.Areas.Identity.Data;
using DistLab2.Core.Interfaces;
using DistLab2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        //hämtar info en specific användares auctions
        public ActionResult ShowAuctions()
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

        //deletes a user
        public ActionResult DeleteUser()
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
        


        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
