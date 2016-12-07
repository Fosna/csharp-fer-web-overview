using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWork.Models.Db;
using CourseWork.Models;

namespace CourseWork.Controllers
{
    public class StudentController : Controller
    {
        private CourseWorkDbContext _dbContext;

        public StudentController(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var students = _dbContext.Students.ToList();

            return View(students);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {

            var deleteMe = _dbContext.Students.Single(x => x.Id == id);
            _dbContext.Students.Remove(deleteMe);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Message", new MessageVm
            {
                Message = "Student is removed.",
                ReturnAction = "Index",
                ReturnController = "Student"
            });

        }

    }
}
