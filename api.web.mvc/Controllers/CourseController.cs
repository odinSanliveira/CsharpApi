using api.web.mvc.Models.Course;
using api.web.mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Threading.Tasks;

namespace api.web.mvc.Controllers
{

    [Microsoft.AspNetCore.Authorization.Authorize]
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
        public async Task<IActionResult> List()
        {
            var course = await _courseService.List();

            
            return View(course);
        }
    }
}
