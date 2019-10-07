using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Product
    {
        public int Id { get; set; }
        public CategorySimple Category { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public int SeriesNumber { get; set; }
        public string Keywords { get; set; }
        public string Thumb { get; set; }
        public string Description { get; set; }
        public string Brief { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public int MarketPrice { get; set; }
        public int Stock { get; set; }
        public int Weight { get; set; }
        public int Sales { get; set; }
        [JsonProperty(PropertyName = "is_best")]
        public int IsBest { get; set; }
        public int IsHot { get; set; }
        public int IsNew { get; set; }
        public int Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Picture { get; set; }
        public string Shop { get; set; }
        public IEnumerable<Attribute> Properties { get; set; }
        [JsonProperty(PropertyName = "static_properties")]
        public IEnumerable<Attribute> StaticProperties { get; set; }
        public bool IsCollect { get; set; }
        public IEnumerable<Gallery> Gallery { get; set; }


    }
}
