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
        public async Task<IActionResult>Add()
        {
            var students = await dbContext.Students.ToListAsync();
            var trips = await dbContext.Trips.ToListAsync();
            var lista = new List<int>();

            var model = new AddReservationViewModel(students, trips, lista);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddReservationViewModel viewModel)
        {
                var reservation = new Reservation
                {
                    TripID = viewModel.TripID,
                    PaymentStatus = viewModel.PaymentStatus,
                };

                await dbContext.Reservations.AddAsync(reservation);
                await dbContext.SaveChangesAsync();
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reservations = await dbContext.Reservations.ToListAsync();

            return View(reservations);
        }

    }
}
