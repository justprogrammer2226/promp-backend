using Promp.Models.Prom;
using Promp.Models.Prom.Search;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Extensions
{
    public static class PromExtension
    {
        /// <summary>
        /// Filter products using search model.
        /// Attention, no tokens are used for filtering.
        /// This method should be used on an already selected array of products using tokens.
        /// </summary>
        public static IEnumerable<ProductModel> FilterProducts(this IEnumerable<ProductModel> products, SearchProductsModel searchModel)
        {
            if (string.IsNullOrEmpty(searchModel.SearchText))
            {
                return products;
            }

            switch (searchModel.SearchBy)
            {
                case SearchProductsBy.Name:
                    return products.Where(_ => _.Name.Contains(searchModel.SearchText));
                case SearchProductsBy.Description:
                    return products.Where(_ => _.Description.Contains(searchModel.SearchText));
                case SearchProductsBy.Sku:
                    return products.Where(_ => _.Sku.Contains(searchModel.SearchText));
                case SearchProductsBy.Keywords:
                    return products.Where(_ => _.Keywords.Contains(searchModel.SearchText));
                default:
                    throw new ArgumentException("Incorrect value of 'searchBy' field.");
            }
        }
    }
}
