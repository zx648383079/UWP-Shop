using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;
using ZoDream.Repository.Rest;

namespace ZoDream.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<Page<Product>> GetAsync(Dictionary<string, string> args, Action<HttpException> action = null);

        Task<Product> GetAsync(int id, Action<HttpException> action = null);

        Task<ResponseData<Product>> GetRecommendAsync(int id, Action<HttpException> action = null);

        Task<HomeProduct> GetHomeAsync(Action<HttpException> action = null);

        Task<ResponseData<string>> GetHotKeywordsAsync(Action<HttpException> action = null);

        Task<ResponseData<string>> GetTipsAsync(string keywords, Action<HttpException> action = null);

        Task<ResponseData<string>> GetSubtotalAsync(Action<HttpException> action = null);


    }
}
