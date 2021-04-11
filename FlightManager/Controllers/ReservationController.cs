using Data.Entity;
using FlightManager.Data.Entity;
using FlightManager.Models.Reservations;
using FlightManager.Services;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
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
