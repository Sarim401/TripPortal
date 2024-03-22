using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TripPortal.Data;
using TripPortal.Models;
using TripPortal.Models.Entities;

namespace TripPortal.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public TripsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTripViewModel viewModel)
        {
            var Trip = new Trip
            {
                Country = viewModel.Country,
                City = viewModel.City,
                Price = viewModel.Price,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
            };
            await dbContext.Trips.AddAsync(Trip);
            await dbContext.SaveChangesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var trips = await dbContext.Trips.ToListAsync();

            return View(trips);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var trip = await dbContext.Trips.FindAsync(id);

            return View(trip);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Trip viewModel)
        {
            var trip = await dbContext.Trips.FindAsync(viewModel.TripID);

            if (trip is not null)
            {
                trip.Country = viewModel.Country;
                trip.City = viewModel.City;
                trip.Price = viewModel.Price;
                trip.StartDate = viewModel.StartDate;
                trip.EndDate = viewModel.EndDate;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Trips");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Trip viewModel)
        {
            var trip = await dbContext.Trips
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TripID == viewModel.TripID);
            if (trip is not null)
            {
                dbContext.Trips.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Trips");
        }
    }
}
