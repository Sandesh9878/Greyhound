using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Greyhound.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Greyhound.Web.Areas.Identity.Pages.Account;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Greyhound.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginController(
            SignInManager<IdentityUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ResponseModel> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return new ResponseModel(true, "User logged in.");
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return new ResponseModel(false, "Login failed");
                    }
                    if (result.IsLockedOut)
                    {
                        return new ResponseModel(false, "User account locked out.");
                    }
                    else
                    {
                        return new ResponseModel(false, "Invalid login attempt.");
                    }
                }
                return new ResponseModel(true, "Login Successful");
            }
            catch (Exception ex)
            {
                return new ResponseModel(false, "Login failed");
            }
        }

        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public async Task<ResponseModel> Logout()
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
