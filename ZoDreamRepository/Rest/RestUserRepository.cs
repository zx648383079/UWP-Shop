using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository.Rest
{
    public class RestUserRepository: IUserRepository
    {
        private readonly HttpHelper _http;

        public RestUserRepository(string baseUrl)
        {
            _http = new HttpHelper(baseUrl);
        }

        public async Task<IEnumerable<User>> GetAsync() =>
            await _http.GetAsync<IEnumerable<User>>("customer");

        public async Task<User> GetAsync(uint id) =>
            await _http.GetAsync<User>($"customer/{id}");

        public async Task DeleteAsync(uint id) =>
            await _http.DeleteAsync("customer", id);
    }
}
