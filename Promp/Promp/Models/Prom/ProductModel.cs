using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Promp.Prom.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        [JsonProperty(PropertyName = "External_id")]
        public long? ExternalId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Selling_type")]
        public string SellingType { get; set; }
        public string Presence { get; set; }
        [JsonProperty(PropertyName = "Presence_sure")]
        public bool PresenceSure { get; set; }
        public double Price { get; set; }
        [JsonProperty(PropertyName = "Minimum_order_quantity")]
        public float? MinimumOrderQuantity { get; set; }
        public DiscountModel Discount { get; set; }
        public string Currency { get; set; }
        public GroupModel Group { get; set; }
        public CategoryModel Category { get; set; }
        public IEnumerable<PriceModel> Prices { get; set; }
        [JsonProperty(PropertyName = "Main_image")]
        public string MainImage { get; set; }
        public IEnumerable<ImageModel> Images { get; set; }
        public string Status { get; set; }
        public string UsedToken { get; set; }
        public int AvailableInShops { get; set; }
    }
}
