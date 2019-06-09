using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class InvoiceTitle
    {
        public int Id { get; set; }

        public int TitleType { get; set; }

        public int Type { get; set; }

        public string Title { get; set; }

        public string TaxNo { get; set; }

        public string Tel { get; set; }

        public string Bank { get; set; }

        public string Account { get; set; }

        public string Address { get; set; }

        public int UserId { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }
    }
}
