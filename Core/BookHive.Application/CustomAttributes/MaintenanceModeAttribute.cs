using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes;

public class MaintenanceModeAttribute : Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
            context.Result = new ContentResult
            {
                Content = "This service is currently under maintenance. Please try again later.",
                StatusCode = 503
            };
    }
}
