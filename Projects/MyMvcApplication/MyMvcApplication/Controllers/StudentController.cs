using MyMvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApplication.Controllers
{
    public class StudentController : Controller
    {
        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
        };
        public ActionResult Index()
        {

            // Get the students from the database in the real application
            return View(studentList.OrderBy(s => s.StudentId).ToList());
        }

        public ActionResult Create(string Name, int Age)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            Student newStd = new Student
            {
                StudentName = Name,
                Age = Age
            };
            studentList.Add(newStd);

            studentList.Add(std);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var std = studentList.Where(s => s.StudentId == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(std);

            return RedirectToAction("Index");
        }
    }
}