using Promp.Models.Prom;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public interface IPromService
    {
        Task<IEnumerable<PromApiTokenModel>> GetAllTokens(string userId);
        Task<PromApiTokenModel> SaveToken(PromApiTokenModel token);
        Task RemoveToken(string token, string userId);
        Task<IEnumerable<ProductModel>> GetProducts(SearchProductsModel searchModel);
        Task EditProducts(IEnumerable<ProductEditModel> products);
    }
}
