using Newtonsoft.Json;

namespace Promp.Prom.Models
{
    public class ImageModel
    {
        public long Id { get; set; }
        public string Url { get; set; }
        [JsonProperty(PropertyName = "Thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}
