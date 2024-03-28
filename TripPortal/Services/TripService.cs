using TripPortal.Interfaces;
using TripPortal.Models.Entities;

namespace TripPortal.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _tripRepository.GetAllAsync();
        }

        public async Task<Trip> GetTripByIdAsync(Guid id)
        {
            return await _tripRepository.FindAsync(id);
        }

        public async Task<List<Trip>> GetSortedTripsByIdAsync()
        {
            var trips = await _tripRepository.GetAllAsync();
            return trips.OrderBy(t => t.TripID).ToList();
        }

        public async Task<List<Trip>> GetSortedTripsByCountryAsync()
        {
            var trips = await _tripRepository.GetAllAsync();
            return trips.OrderBy(t => t.Country).ToList();
        }

        public async Task<List<Trip>> GetSortedTripsByPriceAsync()
        {
            var trips = await _tripRepository.GetAllAsync();
            return trips.OrderBy(t => t.Price).ToList();
        }

        public async Task<List<Trip>> GetSortedTripsByStartDateAsync()
        {
            var trips = await _tripRepository.GetAllAsync();
            return trips.OrderBy(t => t.StartDate).ToList();
        }

        public async Task<List<Trip>> GetFirstFiveTripsSortedByIdAsync()
        {
            var trips = await GetSortedTripsByIdAsync();
            return trips.Take(5).ToList();
        }
    }
}
