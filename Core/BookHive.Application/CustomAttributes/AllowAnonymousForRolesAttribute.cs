
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookHive.Application.CustomAttributes
{
    public class AllowAnonymousForRolesAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] roles;
        public AllowAnonymousForRolesAttribute(params string[] roles)
        {
            this.roles = roles;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated && roles.Any(role => user.IsInRole(role)))
            {
                // Rol ilə uyğun gələn istifadəçilər icazə verilmişdir
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
