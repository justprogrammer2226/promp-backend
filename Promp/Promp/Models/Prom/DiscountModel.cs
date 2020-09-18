using Newtonsoft.Json;

namespace Promp.Models.Prom
{
    public class DiscountModel
    {
        public double Value { get; set; }
        public string Type { get; set; }
        [JsonProperty(PropertyName = "Date_start")]
        public string DateStart { get; set; }
        [JsonProperty(PropertyName = "Date_end")]
        public string DateEnd { get; set; }
    }
}
