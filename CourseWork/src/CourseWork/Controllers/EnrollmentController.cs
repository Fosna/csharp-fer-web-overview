using CourseWork.Models;
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

        public ActionResult AddStudent(int courseId)
        {
            var course = _dbContext.Courses.
                Include(x => x.Students).
                SingleOrDefault(x => x.Id == courseId);


            // Exclude students that are already enrolled in this course.
            var courseStudentIds = course.Students.Select(x => x.Id).ToList();

            var studentsToAdd = _dbContext.Students.
                Where(x => courseStudentIds.Contains(x.Id) == false).
                ToList();


            // Course class is used as "add student model". Students property has different meaning. It represents students that currently aren't enrolled in course - potential course candidates.
            // Replace enrolled students with course candidates.
            course.Students = studentsToAdd;
            var addStudentModel = course;


            return View(addStudentModel);
        }


        [HttpPost]
        public ActionResult AddStudent(int courseId, int studentId)
        {
            var course = _dbContext.Courses.Include(x => x.Students).Single(x => x.Id == courseId);
            var student = _dbContext.Students.Single(x => x.Id == studentId);

            course.Students.Add(student);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Message", 
                MessageVm.Create(
                    urlService: Url,
                    message: "Student was sucessfully enrolled in course.",
                    returnAction: "Index",
                    returnController: "Enrollment",
                    routeValues: new { CourseId = courseId }
                )
            );
        }
    }
}
