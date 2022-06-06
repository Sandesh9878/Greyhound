using Greyhound.Web.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using Greyhound.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greyhound.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginController> _logger;
        private readonly IEmailSender _emailSender;

        public LoginController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<LoginController> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("Login")]
        public ResponseModel Login(LoginUserModel model)
        {
            try
            {
                return new ResponseModel(true, "Login Successful");
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, "Login failed");
            }
        }
    }
}
