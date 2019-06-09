using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class InvoiceLog: InvoiceTitle
    {
        public float Money { get; set; }

        public int status { get; set; }
    }
}
