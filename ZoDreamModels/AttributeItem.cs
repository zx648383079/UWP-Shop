using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class AttributeItem
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
        public int Price { get; set; }
    }
}
