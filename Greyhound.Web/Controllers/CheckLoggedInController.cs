using Greyhound.Web.CustomAttributes;
using Greyhound.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Greyhound.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CheckLoggedInController : ControllerBase
    {
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ResponseModel> RegisterUser([FromBody] RegisterUserModel model)
        {
            try
            {
                return new ResponseModel(true, "Authorized");
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, "Registration failed");
            }
        }
    }
}
