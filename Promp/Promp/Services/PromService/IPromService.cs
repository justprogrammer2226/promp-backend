using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public interface IPromService
    {
        Task<IEnumerable<PromApiTokenModel>> GetAllTokens();
        Task<PromApiTokenModel> AddToken(PromApiTokenModel token);
        Task RemoveToken(string token);
    }
}
