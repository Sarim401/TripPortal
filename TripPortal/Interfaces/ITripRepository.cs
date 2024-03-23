using Microsoft.AspNetCore.Mvc;
using TripPortal.Models;
using TripPortal.Models.Entities;

namespace TripPortal.Interfaces
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAllAsync();
        Task<Trip> FindAsync(Guid id);
        Task<Trip> Delete(Trip viewModel);
        Task<int> Save();
        Task AddAsync(Trip Trip);
    }
}
