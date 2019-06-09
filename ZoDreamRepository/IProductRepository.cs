using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<Page<Product>> GetAsync(Dictionary<string, string> args);

        Task<Product> GetAsync(int id);

        Task<ResponseData<Product>> GetRecommendAsync(int id);

        Task<HomeProduct> GetHomeAsync();

        Task<ResponseData<string>> GetHotKeywordsAsync();

        Task<ResponseData<string>> GetTipsAsync(string keywords);

        Task<ResponseData<string>> GetSubtotalAsync();


    }
}
