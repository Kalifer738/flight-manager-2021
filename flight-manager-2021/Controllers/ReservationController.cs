using Microsoft.AspNetCore.Mvc;
using System;
using flight_manager_2021.Models.Reservations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight_manager_2021.Shared;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;

namespace flight_manager_2021.Controllers
{
    public class ReservationController : Controller
    {
        private const int PageSize = 10;
        private readonly ConnectionDB _context;

        public ReservationController()
        {
            _context = new ConnectionDB();
        }

        //GET : Reservation
        public async Task<IActionResult> Index(ReservationsIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<ReservationsViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationsViewModel()
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

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Reservations.CountAsync() / (double)PageSize);

            return View(model);
        }

        //GET: Reservation/Create
        [Route("/Reservation/Create", Name = "create")]
        public IActionResult Create(int id)
        {
            ReservationsCreateViewModel model = new ReservationsCreateViewModel();

            // TODO: Get the information about the wanted plane by using id and context, then fill the model wit the corresponding information.
            // You can use the "Index" method above for refrence.

            return View(model);
        }

        //Post: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationsCreateViewModel createModel)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    FirstName = createModel.FirstName,
                    SecondName = createModel.SecondName,
                    LastName = createModel.LastName,
                    EGN = createModel.EGN,
                    PhoneNumber = (char)createModel.PhoneNumber,
                    Nationality = createModel.Nationality,
                    TypeOfTicket = createModel.TypeOfTicket,
                    Email = createModel.Email
                };

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(createModel);
        }
        
        //GET: Reservation/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Reservation reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ReservationsEditViewModel model = new ReservationsEditViewModel
            {
                Id = reservation.Id,
                FirstName = reservation.FirstName,
                SecondName = reservation.SecondName,
                LastName = reservation.LastName,
                EGN = reservation.EGN,
                PhoneNumber = reservation.PhoneNumber,
                Nationality = reservation.Nationality,
                TypeOfTicket = reservation.TypeOfTicket,
                Email = reservation.Email
            };
            return View(model);
        }
       
        //POST : Reservation/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationsEditViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation()
                {
                    Id = editModel.Id,
                    FirstName = editModel.FirstName,
                    SecondName = editModel.SecondName,
                    LastName = editModel.LastName,
                    EGN = editModel.EGN,
                    PhoneNumber = (char)editModel.PhoneNumber,
                    Nationality = editModel.Nationality,
                    TypeOfTicket = editModel.TypeOfTicket,
                    Email = editModel.Email
                };
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }

        //GET : Reservation/Delete
        public async Task<IActionResult> Delete(int id)
        {
            Reservation reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
