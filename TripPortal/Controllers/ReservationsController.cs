using Microsoft.AspNetCore.Mvc;
using TripPortal.Data;
using TripPortal.Models.Entities;
using TripPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TripPortal.Interfaces;

namespace TripPortal.Controllers
{
    public class ReservationsController : Controller
    {

        private readonly IReservationService reservationService;
        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
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

            var reservation = new Reservation
            {
                ReservationID = Guid.NewGuid(),
                TripID = viewModel.TripID,
                StudentID = viewModel.SelectedStudentID,
                ReservationDate = viewModel.ReservationDate,
                PaymentDate = viewModel.PaymentDate,
                PriceForAll = viewModel.PriceForAll
            };

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
                reservation.TripID = viewModel.TripID;
                reservation.StudentID = viewModel.StudentID;
                reservation.ReservationDate = viewModel.ReservationDate;
                reservation.PaymentDate = viewModel.PaymentDate;

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
