using ChallengeProject.Data;
using ChallengeProject.Models;
using ChallengeProject.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeProject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student(viewModel.Name, viewModel.Email, viewModel.Phone);

                try
                {
                    await dbContext.Students.AddAsync(student);
                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred saving the student.");
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await dbContext.Students.ToListAsync();

            return View(students);
        }
    }
}
