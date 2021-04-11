﻿using FlightManager.Data.Entity;
using FlightManager.Models;
using FlightManager.Models.Flights;
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
    public class HomeController : Controller
    {
        private const int PageSize = 10;
        private readonly ILogger<HomeController> _logger;
        FlightContextService _context;
        UserManager<User> userManager;
        SignInManager<User> signInManager;

        public HomeController(ILogger<HomeController> logger, FlightContextService context, UserManager<User> userManager, SignInManager<User> signInManager)
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

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(FlightsCreateViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
