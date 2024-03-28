﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ApplicationDbContext dbContext;
        private readonly IReservationRepository reservationRepo;
        public ReservationsController(ApplicationDbContext dbContext, IReservationRepository reservationRepo)
        {
            this.dbContext = dbContext;
            this.reservationRepo = reservationRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid TripID, Guid StudentID)
        {
            var viewmodel = new AddReservationViewModel
            {
                Students = await reservationRepo.GetAllStudents(),
                Trips = await reservationRepo.GetAllTrip()
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

            reservationRepo.AddAndSaveAsync(reservation);

            return RedirectToAction("List", "Reservations");

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var reservations = await reservationRepo.GetAllAsync();

            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var Reservation = await reservationRepo.FindAsync(id);



            return View(Reservation);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Reservation viewModel)
        {
            var reservation = await reservationRepo.FindAsync(viewModel.ReservationID);

            if (reservation is not null)
            {
                reservation.TripID = viewModel.TripID;
                reservation.StudentID = viewModel.StudentID;
                reservation.ReservationDate = viewModel.ReservationDate;
                reservation.PaymentDate = viewModel.PaymentDate;

                await reservationRepo.Save();
            }
            return RedirectToAction("List", "Reservations");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Reservation viewModel)
        {
            var reservation = await reservationRepo.FindFirst(viewModel);
            if (reservation is not null)
            {
                reservationRepo.Remove(viewModel);
                await reservationRepo.Save();
            }
            return RedirectToAction("List", "Reservations");
        }

    }
}
