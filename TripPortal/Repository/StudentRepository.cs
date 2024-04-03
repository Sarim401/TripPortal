using Microsoft.EntityFrameworkCore;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models.Entities;

namespace TripPortal.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext dbContext;
        public StudentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Student student)
        {
            return dbContext.Students.AddAsync(student).AsTask();
        }

        public Task<Student> FindFirst(Student viewModel)
        {
            return dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StudentID == viewModel.StudentID);
        }

        public Task<Student> FindAsync(Guid id)
        {
            return dbContext.Students.FindAsync(id).AsTask();
        }

        public Task<List<Student>> GetAllAsync()
        {
            return dbContext.Students.ToListAsync();
        }

        public Task<int> Save()
        {
            return dbContext.SaveChangesAsync();
        }


    }
}
