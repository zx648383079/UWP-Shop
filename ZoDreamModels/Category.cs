using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Banner { get; set; }

        public string AppBanner { get; set; }

        public int ParentId { get; set; }

        public IEnumerable<Category> Children { get; set; }

        [JsonProperty(PropertyName = "goods_list")]
        public IEnumerable<Product> GoodsList { get; set; }
    }
}
