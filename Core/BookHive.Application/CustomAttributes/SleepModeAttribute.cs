
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes;

public class SleepModeAttribute : Attribute, IActionFilter
{
    public int StartHour { get; }
    public int EndHour { get; }

    public SleepModeAttribute(int startHour, int endHour)
    {
        StartHour = startHour;
        EndHour = endHour;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
       
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var currentHour = DateTime.UtcNow.AddHours(4).Hour;

        if ((StartHour > EndHour && (currentHour >= StartHour || currentHour < EndHour)) ||
            (StartHour <= EndHour && (currentHour >= StartHour && currentHour < EndHour)))
        {
            context.Result = new ContentResult
            {
                Content = "This endpoint is not available during sleep mode.",
                StatusCode = 403 // Forbidden
            };
        }
    }
}
