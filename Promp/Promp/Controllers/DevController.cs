using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Promp.DAL;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using Promp.Services.PromService;

namespace Promp.Controllers
{
    [ApiController]
    [Route("dev")]
    public class DevController : ControllerBase
    {
        private readonly ApplicationContext Context;
        private readonly RoleManager<IdentityRole> RoleManager;

        public DevController(ApplicationContext context, RoleManager<IdentityRole> roleManager)
        {
            Context = context;
            RoleManager = roleManager;
        }

        [HttpGet("seed/roles")]
        public async Task<IActionResult> SeedRoles()
        {
            await RoleManager.CreateAsync(new IdentityRole("User"));
            return Ok("Roles was created");
        }
    }
}
