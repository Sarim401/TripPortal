using TripPortal.Interfaces;
using TripPortal.Models.Entities;

namespace TripPortal.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {

            _studentRepository = studentRepository;

        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<List<Student>> GetFirstFourStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Take(4).ToList();
        }

        public async Task<Student> GetFirstStudentAsync(Student viewModel)
        {
            return await _studentRepository.FindFirst(viewModel);
        }

        public async Task<List<Student>> GetSortedStudentsByIdAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.OrderBy(s => s.StudentID).ToList();
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            return await _studentRepository.FindAsync(id);
        }

        public async Task<List<Student>> GetStudentsSortedByBirthDateAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.OrderBy(s => s.BirthDate).ToList();
        }
    }
}
