using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class CommentCount
    {
        public int Total { get; set; }
        public int Good { get; set; }
        public int Middle { get; set; }
        public int Bad { get; set; }
        public int Avg { get; set; }
        public int FavorableRate { get; set; }
        public IEnumerable<CommentTag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
