using Data.Entity;
using FlightManager.Data.Entity;
using FlightManager.Models.Reservations;
using FlightManager.Services;
using FlightManager.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class ReservationController : Controller
    {
        private const int PageSize = 10;
        private readonly ILogger<HomeController> _logger;
        FlightContextService flightContext;
        ReservationContextService reservationContext;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;

        public ReservationController(ILogger<HomeController> logger, FlightContextService fContext, ReservationContextService rContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            flightContext = fContext;
            reservationContext = rContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: ReservationController
        [Authorize]
        public IActionResult Index(ReservationsIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            ReservationsViewModel[] items = reservationContext.GetNPaged((model.Pager.CurrentPage - 1) * PageSize, PageSize).Select(c => new ReservationsViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                SecondName = c.SecondName,
                LastName = c.LastName,
                EGN = c.EGN,
                PhoneNumber = c.PhoneNumber,
                Nationality = c.Nationality,
                TypeOfTicket = c.TypeOfTicket,
                Email = c.Email

            }).ToArray();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(reservationContext.Count() / (double)PageSize);

            return View(model);
        }

        // POST: ReservationController/Create
        [HttpGet]
        [Route("/Reservation/Create", Name = "createReservation")]
        public ActionResult Create(int id, string from, string to, DateTime takeOffTime, DateTime landingTime, int bCapacity, int bCount, int sCapacity, int sCount)
        {
            ReservationsCreateViewModel model = new ReservationsCreateViewModel();

            Flight flightInformation = new Flight()
            {
                LocationFrom = from,
                LocationTo = to,
                TakeOffTime = takeOffTime,
                LandingTime = landingTime,
                CapacityOfBusinessClass = bCapacity,
                CountOfBusinessClass = bCount,
                CapacityOfStandartClass = sCapacity,
                CountOfStandartClass = sCount,
            };

            model.FlightInformation = flightInformation;
            model.PlaneId = id;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReservation(string FirstName, string SecondName, string LastName, string EGN, string PhoneNumber, string Nationality, string TypeOfTicket, string Email, int PlaneId)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    FirstName = FirstName,
                    SecondName = SecondName,
                    LastName = LastName,
                    EGN = EGN,
                    PhoneNumber = PhoneNumber,
                    Nationality = Nationality,
                    TypeOfTicket = TypeOfTicket,
                    Email = Email,
                    PlaneId = PlaneId
                };

                if (reservation.IsNotNull() && CanOrderTickets(PlaneId, TypeOfTicket))
                {
                    IncrementFlightCount(PlaneId, TypeOfTicket);
                    reservationContext.Add(reservation);
                    return RedirectToAction("Success");
                }
            }

            return RedirectToAction("Failed");
        }

        // GET: ReservationController/Edit/5
        [Authorize]
        [HttpGet]
        [Route("/Reservation/Edit", Name = "editReservationView")]
        public ActionResult Edit(int id)
        {
            Reservation reservation = reservationContext.GetOne(id);
            ReservationsEditViewModel model = new ReservationsEditViewModel(reservation);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Route("/Reservation/EditReservation", Name = "editReservation")]
        public IActionResult EditReservation(string FirstName, string SecondName, string LastName, string PhoneNumber, string EGN, string Nationality, string TypeOfTicket, string Email, int Id)
        {
            if (ModelState.IsValid)
            {
                var reservation = reservationContext.GetOne(Id);

                reservation.FirstName = FirstName;
                reservation.SecondName = SecondName;
                reservation.LastName = LastName;
                reservation.PhoneNumber = PhoneNumber;
                reservation.EGN = EGN;
                reservation.Nationality = Nationality;
                reservation.TypeOfTicket = TypeOfTicket;
                reservation.Email = Email;

                reservationContext.Update(reservation);
                return RedirectToAction("Success");
            }
            return RedirectToAction("Error");
        }

        // GET: ReservationController/Delete/5
        [Authorize]
        [Route("Reservation/Delete", Name = "deleteReservation")]
        public IActionResult Delete(int id)
        {
            reservationContext.Remove(id);
            return RedirectToAction("");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failed()
        {
            return View();
        }

        private void IncrementFlightCount(int id, string typeOfTicket)
        {
            var flight = flightContext.GetOne(id);

            if (typeOfTicket == "Standart Ticket")
            {
                flight.CountOfStandartClass++;
            }
            else if (typeOfTicket == "Business Ticket")
            {
                flight.CountOfBusinessClass++;
            }

            flightContext.Update(flight);
        }

        private bool CanOrderTickets(int id, string typeOfticket)
        {
            var flight = flightContext.GetOne(id);
            if (typeOfticket == "Standart Ticket" && flight.CountOfStandartClass < flight.CapacityOfStandartClass)
            {
                return true;
            }
            else if (typeOfticket == "Business Ticket" && flight.CountOfBusinessClass < flight.CapacityOfBusinessClass)
            {
                return true;
            }
            return false;
        }
    }
}
