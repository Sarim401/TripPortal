using TripPortal.Models.Entities;

namespace TripPortal.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> FindAsync(Guid id);
        Task<Student> FindFirst(Student viewModel);
        Task<int> Save();
        Task AddAsync(Student student);
    }
}
