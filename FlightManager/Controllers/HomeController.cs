using Data.Entity;
using FlightManager.Data.Entity;
using FlightManager.Models;
using FlightManager.Models.Flights;
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
    public class HomeController : Controller
    {
        private const int PageSize = 10;
        private readonly ILogger<HomeController> _logger;
        FlightContextService _context;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public HomeController(ILogger<HomeController> logger, FlightContextService context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(FlightsIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            FlightsViewModel[] items = _context.GetNPaged((model.Pager.CurrentPage - 1) * PageSize, PageSize).Select(c => new FlightsViewModel()
            {
                Id = c.Id,
                LocationFrom = c.LocationFrom,
                LocationTo = c.LocationTo,
                Going = c.TakeOffTime,
                Return = c.LandingTime,
                TypeOfPlane = c.TypeOfPlane,
                NameOfAviator = c.NameOfAviator,
                CapacityOfStandartClass = c.CapacityOfStandartClass,
                CapacityOfBusinessClass = c.CapacityOfBusinessClass,
                CountOfStandartClass = c.CountOfStandartClass,
                CountOfBusinessClass = c.CountOfBusinessClass

            }).ToArray();

            model.Items = items;

            return View(model);
        }

        [Authorize][HttpGet][Route("/Home/Edit", Name = "editFlightView")]
        public IActionResult Edit(int id)
        {
            Flight flight = _context.GetOne(id);
            FlightsEditViewModel model = new FlightsEditViewModel(flight);
            return View(model);
        }

        [Authorize][HttpPost][Route("/Home/EditFlight", Name = "editFlight")]
        public IActionResult EditFlight(string LocationFrom, string LocationTo, int CapacityOfStandartClass, int CapacityOfBusinessClass, int CountOfBusinessClass, int CountOfStandartClass, DateTime Going, DateTime Return, string TypeOfPlane, string NameOfAviator, int id)
        {
            if (ModelState.IsValid)
            {
                var flight = _context.GetOne(id);
                flight.LocationFrom = LocationFrom;
                flight.LocationTo = LocationTo;
                flight.CapacityOfStandartClass = CapacityOfStandartClass;
                flight.CapacityOfBusinessClass = CapacityOfBusinessClass;
                flight.CountOfBusinessClass = CountOfBusinessClass;
                flight.CountOfStandartClass = CountOfStandartClass;
                flight.TakeOffTime = Going;
                flight.LandingTime = Return;
                flight.TypeOfPlane = TypeOfPlane;
                flight.NameOfAviator = NameOfAviator;

                //flight = new Flight(LocationFrom, LocationTo, Going, Return, TypeOfPlane, NameOfAviator, CapacityOfBusinessClass, CapacityOfStandartClass, CountOfBusinessClass, CountOfStandartClass);
                _context.Update(flight);
                return RedirectToAction("Success");
            }
            return RedirectToAction("Error");
        }

        [Authorize][HttpPost][Route("/Home/Create", Name = "createFlight")]
        public IActionResult CreateFlight(string LocationFrom, string LocationTo, DateTime Going, DateTime Return, string TypeOfPlane, string NameOfAviator, int CapacityOfStandartClass, int CapacityOfBusinessClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Flight(LocationFrom, LocationTo, Going, Return, TypeOfPlane, NameOfAviator, CapacityOfBusinessClass, CapacityOfStandartClass));
                return RedirectToAction("Success");
            }
            return RedirectToAction("Error");
        }

        [Authorize][Route("Home/Delete", Name = "deleteFlight")]
        public IActionResult Delete(int id)
        {
            _context.Remove(id);
            return RedirectToAction("");
        }

        [Authorize][HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failed()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
