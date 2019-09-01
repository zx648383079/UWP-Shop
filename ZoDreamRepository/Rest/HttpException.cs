using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Repository.Rest
{
    public class HttpException: Exception
    {
        public int Code { get; set; }

        public object Errors { get; set; }

        public string Description { get; set; }
    }
}
