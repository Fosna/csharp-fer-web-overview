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
            // Test database access. 
            var val = _dbContext.Database.SqlQuery<int>("select 1").ToList().First();

            // 1 should be displayed on screen at url: Student/Monkey
            return Content(val.ToString());
        }
    }
}
