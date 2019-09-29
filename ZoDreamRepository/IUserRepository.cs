using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;
using ZoDream.Repository.Rest;

namespace ZoDream.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<IEnumerable<User>> GetAsync(Action<HttpException> action = null);

        Task<User> GetAsync(uint id, Action<HttpException> action = null);

        Task<User> ProfileAsync(Action<HttpException> action = null);

        Task<ResponseDataOne<bool>> DeleteAsync(uint id, Action<HttpException> action = null);

        Task<User> LoginAsync(LoginForm login, Action<HttpException> action = null);

        Task<User> RegisterAsync(LoginForm login, Action<HttpException> action = null);

        Task<ResponseDataOne<bool>> LogoutAsync(Action<HttpException> action = null);

        Task<ResponseDataOne<bool>> SendCodeAsync(LoginForm login, Action<HttpException> action = null);

        Task<LoginQr> LoginQrAsync(string token, Action<HttpException> action = null);

        Task<LoginQr> AuthorizeAsync(string token, bool confirm = false, bool reject = false, Action<HttpException> action = null);

    }
}
