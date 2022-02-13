using CsharpApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CsharpApi.Filters
{
    public class CustomModelStateValidation : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var fieldValidationModel = new FieldValidationViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                // loop all through all error list
                context.Result = new BadRequestObjectResult(fieldValidationModel);
            }
        }

    }
}
