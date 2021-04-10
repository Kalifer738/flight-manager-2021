using flight_manager_2021.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight_manager_2021.Shared;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;
using Microsoft.Extensions.Logging;

namespace flight_manager_2021.Controllers
{
    public class LoginController : Controller
    {
        private ILogger<LoginIndexViewModel> _logger;
        private readonly ConnectionDB _context;
        private SignInManager<User> _signInManager;

        public LoginController(ILogger<LoginIndexViewModel> logger, SignInManager<User> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = new ConnectionDB();
        }


        public IActionResult Index(LoginIndexViewModel model)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            string returnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstAsync(x => x.UserName == userName && x.Password == password);
                var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User Logged in");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            
            return View();
        }
    }
}
