using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemType { get; set; }
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Rank { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public User User { get; set; }
        public IEnumerable<Gallery> Images { get; set; }
    }
}
