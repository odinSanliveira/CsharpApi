using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Business.Entities
{
    public class Course
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserCode { get; set; }
        public virtual User User { get; set; }
    }
}
