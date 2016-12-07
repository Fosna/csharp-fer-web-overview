using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWork.Models.Db;

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
            return View();
        }

        public IActionResult Monkey()
        {
            // Test student seed procedure. 
            var val = _dbContext.Students.Count();
            return Content(val.ToString());
        }
    }
}
