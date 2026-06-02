using LibraryManagement.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagement.API.Filters;
public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            var response = ResponseModel.ValidationFailure<object>(errors);
            context.Result = new ObjectResult(response) { StatusCode = 422 };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
