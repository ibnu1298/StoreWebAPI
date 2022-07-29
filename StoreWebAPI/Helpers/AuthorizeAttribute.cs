using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreWebAPI.Models;

namespace StoreWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cust = (Customer)context.HttpContext.Items["User"];
            if (cust == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Membutuhkan Izin" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}