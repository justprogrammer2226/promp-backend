using Microsoft.AspNetCore.Http;
using Promp.Models.Prom;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetCurrentUserId(this HttpContext httpContext)
        {
            var userId = httpContext.User.Claims.SingleOrDefault(_ => _.Type == "userId");
            if (userId == null)
            {
                throw new ArgumentException("Http context does not have claim with \"userId\" type");
            }
            else
            {
                return userId.Value;
            }
        }
    }
}
