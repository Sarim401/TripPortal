using TripPortal.Models.Entities;

namespace TripPortal.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(Guid id);
        Task<Student> GetFirstStudentAsync(Student viewModel);
        Task<List<Student>> GetSortedStudentsByIdAsync();
        Task<List<Student>> GetFirstFourStudentsAsync();
        Task<List<Student>> GetStudentsSortedByBirthDateAsync();
        Task<int> SaveChangesAsync();
        Task AddStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(Student viewModel);
    }
}
