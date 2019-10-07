using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        [JsonProperty(PropertyName = "attr_items")]
        public IEnumerable<AttributeItem> AttrItems { get; set; }

        public AttributeItem AttrItem { get; set; }
    }
}
