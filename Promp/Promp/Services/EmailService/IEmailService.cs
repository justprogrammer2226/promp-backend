using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public interface IEmailService
    {
        Task SendMessageAsync(string email, string name, string subject, string message);
        Task SendRecoveryPasswordMessageAsync(string email, string name, string resetLink);
        Task SendPasswordResetMessageAsync(string email, string name);
    }
}
