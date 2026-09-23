using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    public class StdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly StdDBcontext context;
        public StdController(StdDBcontext context)
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
        public IActionResult Details(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost]
        public IActionResult Enroll(int courseId)
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            var student = context.Users.FirstOrDefault(u => u.Id == userId);

            if (student == null)
            {
                return RedirectToAction("login", "Auth");
            }

            bool exist = context.Enrollments.Any(e => e.UserId == student.Id && e.CourseId == courseId);

            if (!exist)
            {
                var enrollment = new Enrollment
                {
                    UserId = student.Id,
                    CourseId = courseId
                };
                context.Enrollments.Add(enrollment);
                context.SaveChanges();
            }

            return RedirectToAction("MyCourses","Std");
        }

        [HttpGet]
        public IActionResult MyCourses()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var student = context.Users.FirstOrDefault(u => u.Id == userId);

            if (student == null)
            {
                return RedirectToAction("login", "Auth");
            }

            var myCourses = context.Enrollments.Where(e => e.UserId == student.Id).Include(e => e.Course).Select(e => e.Course).ToList();
            return View(myCourses);
        }

    }
}
