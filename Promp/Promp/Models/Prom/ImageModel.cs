using Newtonsoft.Json;

namespace Promp.Models.Prom
{
    public class ImageModel
    {
        public long Id { get; set; }
        public string Url { get; set; }
        [JsonProperty(PropertyName = "Thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}
