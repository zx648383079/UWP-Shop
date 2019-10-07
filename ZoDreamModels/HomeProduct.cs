using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class HomeProduct: BaseResponse
    {
        [JsonProperty(PropertyName = "hot_products")]
        public IEnumerable<ProductSimple> HotProducts { get; set; }
        [JsonProperty(PropertyName = "new_products")]
        public IEnumerable<ProductSimple> NewProducts { get; set; }
        [JsonProperty(PropertyName = "best_products")]
        public IEnumerable<ProductSimple> BestProducts { get; set; }
    }
}
