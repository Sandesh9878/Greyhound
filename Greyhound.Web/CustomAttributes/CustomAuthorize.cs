using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Greyhound.Web.CustomAttributes
{
    public class CustomAuthorize : AuthorizeAttribute,IAuthorizationFilter
    {
        private readonly bool _authorize;

        public CustomAuthorize()
        {
            _authorize = true;
        }

        public CustomAuthorize(bool authorize)
        {
            _authorize = authorize;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var a = context.HttpContext.Request;
            
        }
    }
}
