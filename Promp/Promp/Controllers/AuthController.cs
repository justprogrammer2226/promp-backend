using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using Promp.Services.PromService;

namespace Promp.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService AuthService;

        public AuthController(IAuthService authService)
        {
            AuthService = authService;
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
    }
}
