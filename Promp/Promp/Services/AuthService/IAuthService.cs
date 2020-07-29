using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public interface IAuthService
    {
        Task SignUp(SignUpModel model);
        Task<string> SignIn(SignInModel model);
    }
}
