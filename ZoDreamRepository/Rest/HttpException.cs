using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Repository.Rest
{
    public class HttpException: Exception
    {
        public int Code { get; set; } = 0;

        public object Errors { get; set; }

        public string Description { get; set; }

        public HttpException()
        {

        }

        public HttpException(string message): base(message)
        {

        }

        public HttpException(int code, string message): base(message)
        {
            Code = code;
        }


    }
}
