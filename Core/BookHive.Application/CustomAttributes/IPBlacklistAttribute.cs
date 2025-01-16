
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes;

public class IPBlacklistAttribute : Attribute, IActionFilter
{
    private readonly List<string> blackListIPs;
    public IPBlacklistAttribute()
    {
        blackListIPs = new List<string> { "192.168.1.100", "10.0.0.1", "192.168.1.69" };
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var ipAddress = context.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

        if (string.IsNullOrEmpty(ipAddress))
        {
            context.Result = new ContentResult
            {
                Content = "Your IP is blacklisted.",
                StatusCode = 403
            };
        }
    }
}
