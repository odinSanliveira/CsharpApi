using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpApi.Models.User
{
    public class FieldValidationViewModelOutput
    {
        public IEnumerable<string> Errors { get; set; }

        public FieldValidationViewModelOutput(IEnumerable<string> Error)
        {
            Errors = Error;
        }

    }
}
