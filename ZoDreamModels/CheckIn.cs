using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class CheckIn
    {
        public int Id { get; set; }

        public string CreatedAt { get; set; }

        public int Running { get; set; }

        public int Type { get; set; }
    }
}
