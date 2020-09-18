using Newtonsoft.Json;

namespace Promp.Models.Prom
{
    public class PriceModel
    {
        public double Price { get; set; }
        [JsonProperty(PropertyName = "Minimum_order_quantity")]
        public float MinimumOrderQuantity { get; set; }
    }
}
