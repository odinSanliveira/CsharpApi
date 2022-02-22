using api.web.mvc.Models.Course;
using api.web.mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.web.mvc.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService CourseService)
        {
            _courseService = CourseService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(CreateCourseViewModelInput creatingCourse)
        {
            try 
            {
                var course = await _courseService.Create(creatingCourse);
                ModelState.AddModelError("", $"Your course name is {course.Title}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

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
