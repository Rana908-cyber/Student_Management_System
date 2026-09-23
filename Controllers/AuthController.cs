using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Models;

namespace Student.Controllers
{
    public class AuthController : Controller
    {
        private readonly StdDBcontext context;
        public AuthController(StdDBcontext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(User user)
        {
            var user1 = context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (user1 != null)
            {
                ModelState.AddModelError(string.Empty, "User already exists");
                return View(user);
            }
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("login", "Auth");
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var User1 = context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (User1 == null)
            {
                ModelState.AddModelError(string.Empty,"Invalid email or password");
                return View(user);
            }
            HttpContext.Session.SetInt32("UserId", User1.Id);
            if (User1.Role == "Admin")
            {
                return RedirectToAction("V_courses", "Admin");
            }
            else if (User1.Role == "Student")
            {
                return RedirectToAction("V_courses", "Std");
            }
            return RedirectToAction("index", "StdController");

        }
    }
}
