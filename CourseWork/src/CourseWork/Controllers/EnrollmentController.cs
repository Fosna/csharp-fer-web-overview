using CourseWork.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly CourseWorkDbContext _dbContext;

        public EnrollmentController(CourseWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index(int courseId)
        {
            var course = _dbContext.Courses.Include(x => x.Students).Single(x => x.Id == courseId);
            return View(course);
        }
    }
}
