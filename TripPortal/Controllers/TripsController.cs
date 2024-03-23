using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models;
using TripPortal.Models.Entities;

namespace TripPortal.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ITripRepository tripRepo;
        public TripsController(ApplicationDbContext dbContext, ITripRepository tripRepo)
        {
            this.dbContext = dbContext;
            this.tripRepo = tripRepo;
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
            await tripRepo.AddAsync(Trip);
            await tripRepo.Save();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var trips = await tripRepo.GetAllAsync();

            return View(trips);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var trip = await tripRepo.FindAsync(id);

            return View(trip);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Trip viewModel)
        {
            var trip = await tripRepo.FindAsync(viewModel.TripID);

            if (trip is not null)
            {
                trip.Country = viewModel.Country;
                trip.City = viewModel.City;
                trip.Price = viewModel.Price;
                trip.StartDate = viewModel.StartDate;
                trip.EndDate = viewModel.EndDate;

                await tripRepo.Save();
            }
            return RedirectToAction("List", "Trips");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Trip viewModel)
        {
            var trip = await tripRepo.Delete(viewModel);
            if (trip is not null)
            {
                dbContext.Trips.Remove(viewModel);
                await tripRepo.Save();
            }
            return RedirectToAction("List", "Trips");
        }
    }
}
