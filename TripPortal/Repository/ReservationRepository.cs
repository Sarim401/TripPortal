using Microsoft.EntityFrameworkCore;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models.Entities;

namespace TripPortal.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ReservationRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAndSaveAsync(Reservation reservation)
        {
            await dbContext.Reservations.AddAsync(reservation);
            await dbContext.SaveChangesAsync();
        }

        public Task<Reservation> FindAsync(Guid id)
        {
            return dbContext.Reservations.FindAsync(id).AsTask();
        }

        public Task<Reservation> FindFirst(Reservation viewModel)
        {
           return dbContext.Reservations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ReservationID == viewModel.ReservationID);
        }

        public Task<List<Reservation>> GetAllAsync()
        {
            return dbContext.Reservations.ToListAsync();
        }

        public Task<List<Student>> GetAllStudents()
        {
            return dbContext.Students.ToListAsync();
        }

        public Task<List<Trip>> GetAllTrip()
        {
            return dbContext.Trips.ToListAsync();
        }

        public async Task Remove(Reservation viewModel)
        {
            dbContext.Reservations.Remove(viewModel);
        }

        public Task<int> Save()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
