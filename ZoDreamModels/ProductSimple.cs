using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class ProductSimple
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SeriesNumber { get; set; }

        public string Thumb { get; set; }

        public float Price { get; set; }

        public float MarketPrice { get; set; }

        public int Stock { get; set; }

        public string Shop { get; set; }

        public bool IsCollect { get; set; }


    }
}
