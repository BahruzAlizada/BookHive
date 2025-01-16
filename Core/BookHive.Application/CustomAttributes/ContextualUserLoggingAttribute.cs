

using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace BookHive.Application.CustomAttributes;

public class ContextualUserLoggingAttribute : Attribute, IActionFilter
{
    private ILogger logger;


    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userId = context.HttpContext.User.Identity.Name;

        // İstifadəçi IP ünvanı
        var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();

        // User-Agent (brauzer haqqında məlumat)
        var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

        // Log məlumatı
        logger.Information($"User: {userId}, IP: {ip}, User-Agent: {userAgent}, Accessed: {context.ActionDescriptor.DisplayName}, Time: {DateTime.UtcNow}");
    }
}
