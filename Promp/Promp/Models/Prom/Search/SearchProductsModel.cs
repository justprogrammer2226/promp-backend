using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Models.Prom.Search
{
    public class SearchProductsModel
    {
        public string SearchText { get; set; }
        public SearchProductsBy SearchBy { get; set; }
        public IEnumerable<string> SelectedPromTokens { get; set; }

        public SearchProductsModel(IEnumerable<string> selectedPromTokens, string searchText, SearchProductsBy searchBy)
        {
            SelectedPromTokens = selectedPromTokens;
            SearchText = searchText;
            SearchBy = searchBy;
        }
    }

    public enum SearchProductsBy
    {
        Name,
        Description,
        Sku,
        Keywords,
    }
}
