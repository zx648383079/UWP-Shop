using System;
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

        public async Task<ResponseData<Ad>> GetAsync(string position, Action<HttpException> action) 
            => await _http.GetAsync<ResponseData<Ad>>("shop/ad", "position", position, action);

        public async Task<ResponseData<Ad>> GetAsync(int position, Action<HttpException> action)
            => await GetAsync(position.ToString(), action);

        public async Task<ResponseData<Ad>> GetBannersAsync(Action<HttpException> action)
            => await _http.GetAsync<ResponseData<Ad>>("shop/ad/banner", action);
    }
}
