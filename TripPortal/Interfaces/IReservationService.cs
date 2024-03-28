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
        Task AddReservationAsync(Reservation reservation);
        Task RemoveReservationAsync(Guid id);
    }
}
