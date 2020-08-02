using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Promp.DAL;
using Promp.DAL.Entities;
using Promp.Extensions;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext Context;
        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Context = context;
            RoleManager = roleManager;
        }

        public async Task SignUp(SignUpModel model)
        {
            User user = new User
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await UserManager.FindByNameAsync(user.UserName);
                await UserManager.AddToRoleAsync(user, "User");
                // Send email for confirmation
            }
        }

        public async Task<string> SignIn(SignInModel model)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new Exception($"User with email {model.Email} does not exist.");
            }

            var result = await SignInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return await GenerateJwtTokenAsync(user);
            }
            else
            {
                throw new Exception($"Incorrect password.");
            }
        }

        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id),
                new Claim("email", user.Email),
                new Claim("role", (await UserManager.GetRolesAsync(user))[0])
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signinCredentials,
                expires: DateTime.UtcNow.AddDays(14)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
