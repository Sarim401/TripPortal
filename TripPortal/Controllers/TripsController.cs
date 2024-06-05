using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models;
using TripPortal.Models.Entities;
using TripPortal.Validators;

namespace TripPortal.Controllers
{
    [Authorize(Roles = "admin, employee")]
    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IMapper mapper;
        public TripsController(ITripService tripService, IMapper mapper)
        {
            this.tripService = tripService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTripViewModel viewModel)
        {
            var validator = new AddTripViewModelValidator();
            var validationResult = validator.Validate(viewModel);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(viewModel);
            }
            var trip = mapper.Map<Trip>(viewModel);
            await tripService.AddTripAsync(trip);
            await tripService.SaveChangesAsync();


            return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin, employee")]
        public async Task<IActionResult> List()
        {
            var trips = await tripService.GetAllTripsAsync();

            return View(trips);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var trip = await tripService.FindTripAsync(id);

            return View(trip);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Trip viewModel)
        {
            var trip = await tripService.FindTripAsync(viewModel.TripID);

            if (trip is not null)
            {
                var validator = new TripValidator();
                var validationResult = validator.Validate(viewModel);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View(viewModel);
                }
                mapper.Map(viewModel, trip);
                await tripService.SaveChangesAsync();
            }
            return RedirectToAction("List", "Trips");
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Trip viewModel)
        {
            var trip = await tripService.DeleteTripAsync(viewModel);
            if (trip is not null)
            {
                await tripService.DeleteTripAsync(viewModel);
                await tripService.SaveChangesAsync();
            }
            return RedirectToAction("List", "Trips");
        }
    }
}
