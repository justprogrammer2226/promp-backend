using System.Collections;
using System.Collections.Generic;

namespace Promp.Prom.Models
{
    public class ProductListModel
    {
        public long Group_id { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
