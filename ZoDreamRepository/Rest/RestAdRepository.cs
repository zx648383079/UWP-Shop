﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository.Rest
{
    public class RestAdRepository: IAdRepository
    {
        private readonly HttpHelper _http;

        public RestAdRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        public async Task<ResponseData<Ad>> GetAsync(string position) 
            => await _http.GetAsync<ResponseData<Ad>>("shop/ad", "position", position);

        public async Task<ResponseData<Ad>> GetAsync(int position)
            => await GetAsync(position.ToString());

        public async Task<ResponseData<Ad>> GetBannersAsync()
            => await _http.GetAsync<ResponseData<Ad>>("shop/ad/banner");
    }
}