using Newtonsoft.Json;

namespace Promp.Prom.Models
{
    public class PriceModel
    {
        public double Price { get; set; }
        [JsonProperty(PropertyName = "Minimum_order_quantity")]
        public int MinimumOrderQuantity { get; set; }
    }
}
