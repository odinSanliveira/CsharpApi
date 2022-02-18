using api.web.mvc.Models.Course;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.web.mvc.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseViewModelInput createCouseViewModelInput)
        {

            return View();
        }

        public IActionResult List()
        {
            var course = new List<ListCourseViewModelOutput>();

            course.Add(new ListCourseViewModelOutput
            {
                Title = "MVC with .NET CORE",
                Description = "You'll learn build a MVC website with .NET",
                Login = "DiegoBeans"
 
            });
            course.Add(new ListCourseViewModelOutput
            {
                Title = "Singing with Cheryl Porter",
                Description = "You'll learn to sing with the vocal coach Cheryl Porter",
                Login = "CherylPorter"

            });
            return View(course);
        }
    }
}
