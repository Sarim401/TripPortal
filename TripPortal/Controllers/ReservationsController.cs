using Microsoft.AspNetCore.Mvc;
using TripPortal.Data;
using TripPortal.Models.Entities;
using TripPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace TripPortal.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ReservationsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid TripID, Guid StudentID)
        {
            var viewmodel = new AddReservationViewModel
            {
                Students = dbContext.Students.ToList(),
                Trips = dbContext.Trips.ToList(),
            };

            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddReservationViewModel viewModel)
        {
            if (viewModel.SelectedStudentID == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "Please select a student.");
                return View(viewModel);
            }

            if (viewModel.TripID == Guid.Empty)
            {
                ModelState.AddModelError(string.Empty, "Please select a trip.");
                return View(viewModel);
            }

            if (viewModel.ReservationDate > viewModel.PaymentDate)
            {
                ModelState.AddModelError(string.Empty, "Reservation date cannot be later than payment date.");
                return View(viewModel);
            }

            var reservation = new Reservation
            {
                ReservationID = Guid.NewGuid(),
                TripID = viewModel.TripID,
                StudentID = viewModel.SelectedStudentID,
                ReservationDate = viewModel.ReservationDate,
                PaymentDate = viewModel.PaymentDate,
                PriceForAll = viewModel.PriceForAll
            };

            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();

            return RedirectToAction("List", "Reservations");

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reservations = await dbContext.Reservations.ToListAsync();

            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var Reservation = await dbContext.Reservations.FindAsync(id);



            return View(Reservation);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Reservation viewModel)
        {
            var reservation = await dbContext.Reservations.FindAsync(viewModel.ReservationID);

            if (reservation is not null)
            {
                reservation.TripID = viewModel.TripID;
                reservation.StudentID = viewModel.StudentID;
                reservation.ReservationDate = viewModel.ReservationDate;
                reservation.PaymentDate = viewModel.PaymentDate;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Reservations");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Reservation viewModel)
        {
            var reservation = await dbContext.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ReservationID == viewModel.ReservationID);
            if (reservation is not null)
            {
                dbContext.Reservations.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Reservations");
        }

    }
}
