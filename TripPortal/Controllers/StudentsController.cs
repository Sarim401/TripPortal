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
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;

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
            await studentService.AddStudentAsync(student);
            await studentService.SaveChangesAsync();


            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await studentService.GetAllStudentsAsync();

            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await studentService.GetStudentByIdAsync(id);

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await studentService.GetStudentByIdAsync(viewModel.StudentID);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Surname = viewModel.Surname;
                student.Phone = viewModel.Phone;
                student.Email = viewModel.Email;
                student.PESEL = viewModel.PESEL;
                student.BirthDate = viewModel.BirthDate;

                await studentService.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await studentService.GetFirstStudentAsync(viewModel);
            if (student is not null)
            {
                await studentService.DeleteStudentAsync(viewModel);
                await studentService.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
