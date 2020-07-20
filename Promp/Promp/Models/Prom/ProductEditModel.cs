using Newtonsoft.Json;
using System.Collections.Generic;

namespace Promp.Prom.Models
{
    public class ProductEditModel
    {
        public long Id { get; set; }
        public string Presence { get; set; }
        [JsonProperty(PropertyName = "Presence_sure")]
        public bool PresenceSure { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public List<PriceModel> Prices { get; set; }
        public DiscountModel Discount { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string UsedToken { get; set; }
    }
}
