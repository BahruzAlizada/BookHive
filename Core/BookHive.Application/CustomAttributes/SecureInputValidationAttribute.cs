using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes
{
    public class SecureInputValidationAttribute : Attribute, IActionFilter
    {
        private readonly string[] bannerWords = new string[] { "SELECT", "--", "DROP" };
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var parameter in context.ActionArguments)
            {
                if (parameter.Value is string str && bannerWords.Any(bw => str.ToUpper().Contains(bw)))
                {
                    context.Result = new ContentResult
                    {
                        Content = "Invalid input detected.",
                        StatusCode = 400
                    };
                }
            }
        }
    }
}
