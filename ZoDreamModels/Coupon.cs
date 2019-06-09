using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Thumb { get; set; }

        public int Type { get; set; }

        public int Rule { get; set; }

        public string RuleValue { get; set; }

        public float MinMoney { get; set; }

        public float Money { get; set; }

        public string StartAt { get; set; }

        public string EndAt { get; set; }
    }
}
