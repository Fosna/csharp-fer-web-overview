using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWork.Models.Db;
using CourseWork.Models;
using System.Data.Entity;

namespace CourseWork.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseWorkDbContext _dbContext;

        public CourseController(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var courses = _dbContext.Courses.ToList();

            return View(courses);
        }

        public ActionResult Details(int id)
        {
            var course = _dbContext.Courses.Single(x => x.Id == id);
            
            return View(course);
        }

    }

}
