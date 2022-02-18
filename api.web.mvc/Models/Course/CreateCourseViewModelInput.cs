using System.ComponentModel.DataAnnotations;

namespace api.web.mvc.Models.Course
{
    public class CreateCourseViewModelInput
    {
        [Required(ErrorMessage = "A Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please talk a little what will be covered in the course.")]
        public string Description { get; set; }
    }
}
