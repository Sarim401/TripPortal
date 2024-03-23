using TripPortal.Models.Entities;

namespace TripPortal.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> FindAsync(Guid id);
        Task<Reservation> FindFirst(Reservation viewModel);
        Task<int> Save();
        Task AddAndSaveAsync(Reservation reservation);
        Task Remove(Reservation viewModel);
        Task<List<Student>> GetAllStudents();
        Task<List<Trip>> GetAllTrip();
    }
}
