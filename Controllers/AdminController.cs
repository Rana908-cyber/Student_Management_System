using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly StdDBcontext context;
        public AdminController(StdDBcontext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult V_courses()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Course Course)
        {
            context.Courses.Add(Course);
            context.SaveChanges();
            return RedirectToAction("V_courses", "Admin");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if(course== null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Course");
            }
            return View(course);

        }
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
            return RedirectToAction("V_courses");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
            return RedirectToAction("V_courses");
        }

    }
}
