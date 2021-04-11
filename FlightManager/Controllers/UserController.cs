using FlightManager.Data.Entity;
using FlightManager.Models;
using FlightManager.Models.Flights;
using FlightManager.Models.Users;
using FlightManager.Services;
using FlightManager.Shared;
using Microsoft.AspNetCore.Authorization;
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
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public UserController(ILogger<UserController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: UserController
        [Authorize]
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

        // GET: UserController/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return RedirectToRoute("Identity/Account/Register");
        }

        // POST: UserController/Create
        [HttpPost]
        [Authorize]
        [Route("/User/EditUser", Name = "editUser")]
        public ActionResult EditUser(string id, string userName, string phoneNumber, string email)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = userManager.Users.First(x => x.Id == id);
                user.UserName = userName;
                user.PhoneNumber = phoneNumber;
                user.Email = email;
                userManager.UpdateAsync(user);
                return RedirectToAction("Success");
            }

            return RedirectToAction("Error");
        }


        [HttpGet]
        [Authorize]
        [Route("/Home/Edit", Name = "editFlightView")]
        // GET: UserController/Edit/5
        public IActionResult Edit(string id)
        {
            IdentityUser user = userManager.Users.First(x => x.Id == id);
            UsersEditViewModel model = new UsersEditViewModel(user);
            return View(model);
        }

        [Authorize]
        [Route("User/Delete", Name = "deleteUser")]
        public ActionResult Delete(string id)
        {
            userManager.DeleteAsync(userManager.Users.First(x => x.Id == id));
            return RedirectToAction("");
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
