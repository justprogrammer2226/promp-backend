using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promp.DAL.Entities;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using Promp.Services.PromService;
using Microsoft.AspNetCore.Http.Extensions;
using System.Web;

namespace Promp.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService AuthService;
        private readonly IEmailService EmailService;
        private readonly UserManager<User> UserManager;

        public AuthController(IAuthService authService, IEmailService emailService, UserManager<User> userManager)
        {
            AuthService = authService;
            EmailService = emailService;
            UserManager = userManager;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var token = await AuthService.SignIn(model);
            return Ok(new { Token = token });
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            await AuthService.SignUp(model);
            return Ok();
        }

        [HttpPost("recovery-password/{email}")]
        public async Task<IActionResult> SendRecoveryPasswordEmail(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            var token = HttpUtility.UrlEncode(await UserManager.GeneratePasswordResetTokenAsync(user));
            var resetLink = HttpContext.Request.Headers["Origin"] + "/auth/reset-password/?email=" + email + "&token=" + token;
            await EmailService.SendRecoveryPasswordMessageAsync(user.Email, user.FirstName + " " + user.LastName, resetLink);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);
            var result = await UserManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                await EmailService.SendPasswordResetMessageAsync(user.Email, user.FirstName + " " + user.LastName);
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
