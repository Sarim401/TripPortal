using TripPortal.Interfaces;
using TripPortal.Models.Entities;

namespace TripPortal.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid id)
        {
            return await _reservationRepository.FindAsync(id);
        }

        public async Task<List<Reservation>> GetSortedReservationsByReservationIDAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return reservations.OrderBy(r => r.ReservationID).ToList();
        }

        public async Task<List<Reservation>> GetSortedReservationsByTripIDAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return reservations.OrderBy(r => r.TripID).ToList();
        }

        public async Task<List<Reservation>> GetSortedReservationsByStudentIDAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return reservations.OrderBy(r => r.StudentID).ToList();
        }

        public async Task<List<Reservation>> GetSortedReservationsByReservationDateAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return reservations.OrderBy(r => r.ReservationDate).ToList();
        }
<<<<<<< HEAD
        public Task<int> SaveChangesAsync()
        {
            return _reservationRepository.Save();
        }

        public Task AddAndSaveReservationAsync(Reservation reservation)
        {
            return _reservationRepository.AddAndSaveAsync(reservation);
        }

        public Task RemoveReservationAsync(Reservation viewModel)
        {
            return _reservationRepository.Remove(viewModel);
        }

        public Task<List<Student>> GetAllStudentsAsync()
        {
            return _reservationRepository.GetAllStudents();
        }

        public Task<List<Trip>> GetAllTripsAsync()
        {
            return _reservationRepository.GetAllTrip();
=======

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _reservationRepository.AddAndSaveAsync(reservation);
        }

        public async Task RemoveReservationAsync(Guid id)
        {
            var reservation = await _reservationRepository.FindAsync(id);
            if (reservation != null)
            {
                await _reservationRepository.Remove(reservation);
                await _reservationRepository.Save();
            }
>>>>>>> 26ea54b012ded3bc5ed5bd72ed91d91d556e3db6
        }
    }
}
