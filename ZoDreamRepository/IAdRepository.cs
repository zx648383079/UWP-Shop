using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;
using ZoDream.Repository.Rest;

namespace ZoDream.Repository
{
    public interface IAdRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<ResponseData<Ad>> GetAsync(string position, Action<HttpException> action = null);

        Task<ResponseData<Ad>> GetAsync(int position, Action<HttpException> action = null);

        Task<ResponseData<Ad>> GetBannersAsync(Action<HttpException> action = null);
    }
}
