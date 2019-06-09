using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Thumb { get; set; }

        public ArticleCategory Category { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }
    }
}
