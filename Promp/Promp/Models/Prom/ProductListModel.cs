using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Promp.Models.Prom
{
    public class ProductListModel
    {
        [JsonProperty(PropertyName = "Group_id")]
        public long GroupId { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
