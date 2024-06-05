using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPortal.Data;
using TripPortal.Interfaces;
using TripPortal.Models.Entities;
using TripPortal.Models.ViewModel;
using TripPortal.Validators;

namespace TripPortal.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var validator = new AddStudentViewModelValidator();
            var validationResult = validator.Validate(viewModel);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(viewModel);
            }

            var student = mapper.Map<Student>(viewModel);
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
                var validator = new StudentValidator();
                var validationResult = validator.Validate(viewModel);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    return View(viewModel);
                }
                mapper.Map(viewModel, student);
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
