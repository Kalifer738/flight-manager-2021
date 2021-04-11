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
        public async Task<IActionResult> Index(UsersIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<UsersViewModel> items = await _context.Users.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new UsersViewModel()
            {
                Id = c.Id,
                UserName = c.UserName,
                Password = c.Password,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                EGN = c.EGN,
                Address = c.Address,
                PhoneNumber = c.PhoneNumber,
                Role = c.Role

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Users.CountAsync() / (double)PageSize);

            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        [HttpGet]
        public ActionResult Create(UsersCreateViewModel)
        {
            
            return View();
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
