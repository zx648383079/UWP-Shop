using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository.Rest
{
    public class RestCategoryRepository: ICategoryRepository
    {
        private readonly HttpHelper _http;

        public RestCategoryRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        public async Task<ResponseData<Category>> GetAsync(int parent, Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<Category>>("shop/category", action);

        public async Task<Category> GetInfoAsync(int id, string extra = null, Action<HttpException> action = null)
        {
            var data = new Dictionary<string, string>();
            data.Add("id", id.ToString());
            data.Add("extra", extra);
            return await _http.GetAsync<Category>("shop/category", data, action);
        }

        public async Task<ResponseData<Category>> GetLevelAsync(Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<Category>>("shop/category/level", action);

        public async Task<ResponseData<Category>> GetTreeAsync(Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<Category>>("shop/category/tree", action);
    }
}
