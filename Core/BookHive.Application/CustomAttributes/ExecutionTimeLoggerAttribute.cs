
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes
{
    public class ExecutionTimeLoggerAttribute : Attribute, IActionFilter
    {
        private  Stopwatch stopwatch;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} executed in {elapsed} ms.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
        }
    }
}
