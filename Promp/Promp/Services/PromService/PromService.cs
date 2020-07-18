using Promp.Prom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public class PromService : IPromService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private List<PromApiTokenModel> PromApiTokens = new List<PromApiTokenModel>() {
            new PromApiTokenModel()
            {
                Token = "ec030be1b678240463273d428448e69d00f9ffb0",
            }
        };

        public PromService(IHttpClientFactory рttpClientFactory)
        {
            HttpClientFactory = рttpClientFactory;
        }

        public async Task<IEnumerable<PromApiTokenModel>> GetAllTokens()
        {
            foreach (var token in PromApiTokens)
            {
                token.isValid = await IsValidToken(token.Token);
            }
            return PromApiTokens;
        }

        public async Task<PromApiTokenModel> AddToken(PromApiTokenModel token)
        {
            token.isValid = await IsValidToken(token.Token);
            PromApiTokens.Add(token);
            return token;
        }

        public async Task RemoveToken(string token)
        {
            PromApiTokens = PromApiTokens.Where(_ => _.Token != token).ToList();
        }

        private async Task<bool> IsValidToken(string token)
        {
            HttpClient httpClient = HttpClientFactory.CreateClient("prom");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.GetAsync("products/list?limit=1");
            return response.IsSuccessStatusCode;
        }
    }
}
