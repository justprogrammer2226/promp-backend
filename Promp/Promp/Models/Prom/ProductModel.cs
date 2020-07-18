using System.Collections;
using System.Collections.Generic;

namespace Promp.Prom.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public long? External_id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Selling_type { get; set; }
        public string Presence { get; set; }
        public bool Presence_sure { get; set; }
        public double Price { get; set; }
        public int? Minimum_order_quantity { get; set; }
        public DiscountModel Discount { get; set; }
        public string Currency { get; set; }
        public GroupModel Group { get; set; }
        public CategoryModel Category { get; set; }
        public IEnumerable<PriceModel> Prices { get; set; }
        public string Main_image { get; set; }
        public IEnumerable<ImageModel> Images { get; set; }
        public string Status { get; set; }
        public string UsedToken { get; set; }
    }
}
