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

        public async Task<IEnumerable<User>> GetAsync(Action<HttpException> action = null) =>
            await _http.GetAsync<IEnumerable<User>>("customer", action);

        public async Task<User> GetAsync(uint id, Action<HttpException> action = null) =>
            await _http.GetAsync<User>($"customer/{id}", action);

        public async Task<User> ProfileAsync(Action<HttpException> action = null) =>
            await _http.GetAsync<User>("auth/user", action);

        public async Task<ResponseDataOne<bool>> DeleteAsync(uint id, Action<HttpException> action = null) =>
            await _http.DeleteAsync<ResponseDataOne<bool>>("customer", id, action);

        public async Task<User> LoginAsync(LoginForm login, Action<HttpException> action = null) =>
            await _http.PostAsync<LoginForm, User>("auth/login", login, action);

        public async Task<User> RegisterAsync(LoginForm login, Action<HttpException> action = null) =>
            await _http.PostAsync<LoginForm, User>("auth/register", login, action);

        public async Task<ResponseDataOne<bool>> LogoutAsync(Action<HttpException> action = null) =>
            await _http.GetAsync<ResponseDataOne<bool>>("auth/user", action);

        public async Task<ResponseDataOne<bool>> SendCodeAsync(LoginForm login, Action<HttpException> action = null) =>
            await _http.PostAsync<LoginForm, ResponseDataOne<bool>>("auth/send_code", login, action);

        public async Task<LoginQr> LoginQrAsync(string token, Action<HttpException> action = null)
        {
            return await _http.GetAsync<LoginQr>("auth/qr", "token", token, action);
        }

        public async Task<LoginQr> AuthorizeAsync(string token, bool confirm = false, bool reject = false, Action<HttpException> action = null)
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
