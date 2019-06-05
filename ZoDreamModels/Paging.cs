using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Paging
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public int Total { get; set; }

        public bool More { get; set; }
    }

    public class Page<T>
    {
        public Paging Paging { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
