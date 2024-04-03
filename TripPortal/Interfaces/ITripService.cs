using TripPortal.Models.Entities;

namespace TripPortal.Interfaces
{
    public interface ITripService
    {
        Task<List<Trip>> GetAllTripsAsync();
        Task<Trip> GetTripByIdAsync(Guid id);
        Task<List<Trip>> GetSortedTripsByIdAsync();
        Task<List<Trip>> GetSortedTripsByCountryAsync();
        Task<List<Trip>> GetSortedTripsByPriceAsync();
        Task<List<Trip>> GetSortedTripsByStartDateAsync();
        Task<List<Trip>> GetFirstFiveTripsSortedByIdAsync();
        Task<Trip> DeleteTripAsync(Trip viewModel);
        Task<int> SaveChangesAsync();
        Task AddTripAsync(Trip trip);
        Task<Trip> FindTripAsync(Guid id);
    }
}
