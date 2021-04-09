using flight_manager_2021.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight_manager_2021.Controllers
{
    public class LoginController : Controller
    {
        //private readonly SignInManager<IdentityUser> signInManager;

        /*public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }*/

        public LoginController()
        {

        }

        public IActionResult Index(LoginViewModel model)
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");*/
            }

            return View(model);
        }
    }
}
