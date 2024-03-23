using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models;
using TripPortal.Models.Entities;

namespace TripPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IStudentRepository studentRepo;
        public StudentsController(ApplicationDbContext dbContext, IStudentRepository studentRepo)
        {
            this.dbContext = dbContext;
            this.studentRepo = studentRepo;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                PESEL = viewModel.PESEL,
                BirthDate = viewModel.BirthDate,
            };

            await studentRepo.AddAsync(student);
            await studentRepo.Save();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await studentRepo.GetAllAsync();

            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await studentRepo.FindAsync(id);

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await studentRepo.FindAsync(viewModel.StudentID);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Surname = viewModel.Surname;
                student.Phone = viewModel.Phone;
                student.Email = viewModel.Email;
                student.PESEL = viewModel.PESEL;
                student.BirthDate = viewModel.BirthDate;

                await studentRepo.Save();
            }
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await studentRepo.FindFirst(viewModel);
            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await studentRepo.Save();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
