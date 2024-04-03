using TripPortal.Models.Entities;

namespace TripPortal.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(Guid id);
        Task<List<Reservation>> GetSortedReservationsByReservationIDAsync();
        Task<List<Reservation>> GetSortedReservationsByTripIDAsync();
        Task<List<Reservation>> GetSortedReservationsByStudentIDAsync();
        Task<List<Reservation>> GetSortedReservationsByReservationDateAsync();
<<<<<<< HEAD
        Task<int> SaveChangesAsync();
        Task AddAndSaveReservationAsync(Reservation reservation);
        Task RemoveReservationAsync(Reservation viewModel);
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Trip>> GetAllTripsAsync();
        Task<Reservation> FindFirstReservationAsync(Reservation viewModel);
=======
        Task AddReservationAsync(Reservation reservation);
        Task RemoveReservationAsync(Guid id);
>>>>>>> 26ea54b012ded3bc5ed5bd72ed91d91d556e3db6
    }
}
