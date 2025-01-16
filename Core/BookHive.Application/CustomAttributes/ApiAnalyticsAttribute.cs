

using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes
{
    public class ApiAnalyticsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var method = context.HttpContext.Request.Method;
            var endpoint = context.HttpContext.Request.Path;
            var timestamp = DateTime.UtcNow;

            // Log statistics for analytics (could be to a database, file, etc.)
            Console.WriteLine($"[{timestamp}] {method} request to {endpoint}");

            base.OnActionExecuting(context);
        }
    }
}
