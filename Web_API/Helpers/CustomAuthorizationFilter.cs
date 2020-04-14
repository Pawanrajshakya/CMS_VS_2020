using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_API.Helpers
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;
        }
    }
}