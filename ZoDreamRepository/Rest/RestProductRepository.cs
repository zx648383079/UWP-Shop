﻿using System;
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

        public async Task<Page<Product>> GetAsync(Dictionary<string, string> args, Action<HttpException> action = null) 
            => await _http.GetAsync<Page<Product>>("shop/goods", args, action);

        public async Task<Product> GetAsync(int id, Action<HttpException> action = null)
            => await _http.GetAsync<Product>("shop/goods", "id", id, action);

        public async Task<HomeProduct> GetHomeAsync(Action<HttpException> action = null)
            => await _http.GetAsync<HomeProduct>("shop/goods/home", action);

        public async Task<ResponseData<string>> GetHotKeywordsAsync(Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<string>>("shop/search/keywords", action);

        public async Task<ResponseData<Product>> GetRecommendAsync(int id, Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<Product>>("shop/goods/recommend", "id", id, action);

        public async Task<ResponseData<string>> GetSubtotalAsync(Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<string>>("shop/goods/count", action);

        public async Task<ResponseData<string>> GetTipsAsync(string keywords, Action<HttpException> action = null)
            => await _http.GetAsync<ResponseData<string>>("shop/search/tips", "keywords", keywords, action);
    }
}
