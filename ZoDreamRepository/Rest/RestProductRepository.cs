using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository.Rest
{
    public class RestProductRepository: IProductRepository
    {
        private readonly HttpHelper _http;

        public RestProductRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        public async Task<Page<Product>> GetAsync(Dictionary<string, string> args) 
            => await _http.GetAsync<Page<Product>>("shop/goods", args);

        public async Task<Product> GetAsync(int id)
            => await _http.GetAsync<Product>("shop/goods", "id", id);

        public async Task<HomeProduct> GetHomeAsync()
            => await _http.GetAsync<HomeProduct>("shop/goods/home");

        public async Task<ResponseData<string>> GetHotKeywordsAsync()
            => await _http.GetAsync<ResponseData<string>>("shop/search/keywords");

        public async Task<ResponseData<Product>> GetRecommendAsync(int id)
            => await _http.GetAsync<ResponseData<Product>>("shop/goods/recommend", "id", id);

        public async Task<ResponseData<string>> GetSubtotalAsync()
            => await _http.GetAsync<ResponseData<string>>("shop/goods/count");

        public async Task<ResponseData<string>> GetTipsAsync(string keywords)
            => await _http.GetAsync<ResponseData<string>>("shop/search/tips", "keywords", keywords);
    }
}
