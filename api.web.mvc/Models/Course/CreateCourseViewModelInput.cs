using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.web.mvc.Models.Course
{
    public class CreateCourseViewModelInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
