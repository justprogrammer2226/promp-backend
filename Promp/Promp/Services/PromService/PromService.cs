﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Promp.Extensions;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<IEnumerable<ProductModel>> GetProducts(SearchProductsModel searchModel)
        {
            var products = new List<ProductModel>();
            //if (!tokens.Any())
            //{
            //    tokens = (await GetAllTokens()).Select(_ => _.Token);
            //}
            HttpClient httpClient = HttpClientFactory.CreateClient("prom");
            foreach (var token in searchModel.SelectedPromTokens)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.GetAsync("products/list");
                string content = await response.Content.ReadAsStringAsync();
                var deserializedProductList = JsonConvert.DeserializeObject<ProductListModel>(content);
                var deserializedProducts = deserializedProductList.Products;
                foreach (var deserializedProduct in deserializedProducts)
                {
                    deserializedProduct.UsedToken = token;
                }
                products.AddRange(deserializedProducts);
            }
            return products.FilterProducts(searchModel);
        }

        public async Task EditProducts(IEnumerable<ProductEditModel> products)
        {
            var groups = products.GroupBy(_ => _.UsedToken, (key, group) => new { Key = key, Products = group.ToList() });
            HttpClient httpClient = HttpClientFactory.CreateClient("prom");
            foreach (var group in groups)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", group.Products[0].UsedToken);
                var json = JsonConvert.SerializeObject(group.Products, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore });
                var response = await httpClient.PostAsync("products/edit", new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
    }
}