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

        public async Task<User> ProfileAsync() =>
            await _http.GetAsync<User>("auth/user");

        public async Task DeleteAsync(uint id) =>
            await _http.DeleteAsync("customer", id);

        public async Task<User> LoginAsync(LoginForm login) =>
            await _http.PostAsync<LoginForm, User>("auth/login", login);

        public async Task<User> RegisterAsync(LoginForm login) =>
            await _http.PostAsync<LoginForm, User>("auth/register", login);

        public async Task<ResponseDataOne<bool>> LogoutAsync() =>
            await _http.GetAsync<ResponseDataOne<bool>>("auth/user");

        public async Task<ResponseDataOne<bool>> SendCodeAsync(LoginForm login) =>
            await _http.PostAsync<LoginForm, ResponseDataOne<bool>>("auth/send_code", login);

        public async Task<LoginQr> LoginQrAsync(string token)
        {
            return await _http.GetAsync<LoginQr>("auth/qr", "token", token);
        }

        public async Task<LoginQr> AuthorizeAsync(string token, bool confirm = false, bool reject = false)
        {
            var data = new Dictionary<string, string>();
            data.Add("token", token);
            if (confirm)
            {
                data.Add("confirm", "true");
            } else if (reject)
            {
                data.Add("reject", "true");
            }
            return await _http.GetAsync<LoginQr>("auth/qr/authorize", data);
        }
    }
}
