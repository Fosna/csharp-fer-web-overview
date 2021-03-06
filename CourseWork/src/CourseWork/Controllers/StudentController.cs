﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseWork.Models.Db;
using CourseWork.Models;
using System.Data.Entity;

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

            return RedirectToAction("Index", "Message", 
                MessageVm.Create(
                    urlService: Url,
                    message: "Student is removed.",
                    returnAction: "Index",
                    returnController: "Student"
                )
            );

        }

        public ActionResult Details(int id)
        {
            var student = _dbContext.Students.Single(x => x.Id == id);

            return View(student);
        }


        public ActionResult Edit(int id)
        {
            var student = _dbContext.Students.Single(x => x.Id == id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student editMe)
        {
            if (ModelState.IsValid == false)
            {
                return View(editMe);
            }

            _dbContext.Students.Attach(editMe);
            _dbContext.Entry(editMe).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = editMe.Id });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student createMe)
        {
            if (ModelState.IsValid == false)
            {
                return View(createMe);
            }

            _dbContext.Students.Add(createMe);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = createMe.Id });
        }

    }
}
