using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models;
using TripPortal.Models.Entities;

namespace TripPortal.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDbContext dbContext;
        public TripRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<List<Trip>> GetAllAsync()
        {
            return dbContext.Trips.ToListAsync();
        }
        public Task<Trip> FindAsync(Guid id)
        {
            return dbContext.Trips.FindAsync(id).AsTask();
        }
        public Task<Trip> Delete(Trip viewModel)
        {
            return dbContext.Trips
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TripID == viewModel.TripID);
        }
        public Task<int> Save()
        {
            return dbContext.SaveChangesAsync();
        }
        public Task AddAsync(Trip Trip)
        {
            return dbContext.Trips.AddAsync(Trip).AsTask();
        }
    }
}
