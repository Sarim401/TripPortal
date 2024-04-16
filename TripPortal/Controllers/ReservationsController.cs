using Microsoft.AspNetCore.Mvc;
using TripPortal.Data;
using TripPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TripPortal.Interfaces;
using TripPortal.Models.ViewModel;
using AutoMapper;
using TripPortal.Validators;
using FluentValidation;

namespace TripPortal.Controllers
{
    public class ReservationsController : Controller
    {

        private readonly IReservationService reservationService;
        private readonly IMapper mapper;
        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            this.reservationService = reservationService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewmodel = new AddReservationViewModel
            {
                Students = await reservationService.GetAllStudentsAsync(),
                Trips = await reservationService.GetAllTripsAsync()
            };

            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddReservationViewModel viewModel)
        {
            var validator = new AddReservationViewModelValidator();
            var validationResult = validator.Validate(viewModel);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(viewModel);
            }

            var reservation = mapper.Map<Reservation>(viewModel);
            await reservationService.AddAndSaveReservationAsync(reservation);

            return RedirectToAction("List", "Reservations");

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reservations = await reservationService.GetAllReservationsAsync();

            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var Reservation = await reservationService.GetReservationByIdAsync(id);

            return View(Reservation);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Reservation viewModel)
        {
            var reservation = await reservationService.GetReservationByIdAsync(viewModel.ReservationID);

            if (reservation is not null)
            {
                var validator = new ReservationValidator();
                var validationResult = validator.Validate(viewModel);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View(viewModel);
                }
                mapper.Map(viewModel, reservation);
                await reservationService.SaveChangesAsync();
            }
            return RedirectToAction("List", "Reservations");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Reservation viewModel)
        {
            var reservation = await reservationService.FindFirstReservationAsync(viewModel);
            if (reservation is not null)
            {
                await reservationService.RemoveReservationAsync(viewModel);
                await reservationService.SaveChangesAsync();
            }
            return RedirectToAction("List", "Reservations");
        }

    }
}
