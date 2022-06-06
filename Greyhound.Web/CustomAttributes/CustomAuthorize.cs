using Microsoft.AspNetCore.Authorization;

namespace Greyhound.Web.CustomAttributes
{
    public class CustomAuthorize : AuthorizeAttribute
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
        
    }
}
