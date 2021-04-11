using FlightManager.Data.Entity;
using FlightManager.Models;
using FlightManager.Models.Flights;
using FlightManager.Models.Users;
using FlightManager.Services;
using FlightManager.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class UserController : Controller
    {
        //https://localhost:44357/Identity/Account/Register
        private const int PageSize = 10;
        private readonly ILogger<UserController> _logger;
        UserManager<User> userManager;
        SignInManager<User> signInManager;

        public UserController(ILogger<UserController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: UserController
        [HttpGet]
        public IActionResult Index(UsersIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            UsersViewModel[] items = GetPagedUserViewModel((model.Pager.CurrentPage - 1) * PageSize, PageSize);

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(userManager.Users.Count() / (double)PageSize);

            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        [HttpGet]
        public ActionResult Create(UsersViewModel model)
        {
            return View(model);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersEditViewModel collection)
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

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
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

        private UsersViewModel[] GetPagedUserViewModel(int pageNumber, int numberofElements)
        {
            IdentityUser[] returnedUsers = userManager.Users.Skip(pageNumber).Take(numberofElements).ToArray();
            UsersViewModel[] preparedUsers = new UsersViewModel[returnedUsers.Length];

            for (int i = 0; i < returnedUsers.Length; i++)
            {
                preparedUsers[i] = new UsersViewModel()
                {
                    Email = returnedUsers[i].Email,
                    Id = returnedUsers[i].Id,
                    PhoneNumber = returnedUsers[i].PhoneNumber,
                    Role = "User",
                    UserName = returnedUsers[i].UserName,
                };
            }

            return preparedUsers;
        }
    }
}
