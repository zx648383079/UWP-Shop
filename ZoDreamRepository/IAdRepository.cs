using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository
{
    public interface IAdRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<ResponseData<Ad>> GetAsync(string position);

        Task<ResponseData<Ad>> GetAsync(int position);

        Task<ResponseData<Ad>> GetBannersAsync();
    }
}
