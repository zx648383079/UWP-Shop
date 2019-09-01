using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Returns all customers. 
        /// </summary>
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(uint id);

        Task<User> ProfileAsync();

        Task DeleteAsync(uint id);

        Task<User> LoginAsync(LoginForm login);

        Task<User> RegisterAsync(LoginForm login);

        Task<ResponseDataOne<bool>> LogoutAsync();

        Task<ResponseDataOne<bool>> SendCodeAsync(LoginForm login);

        Task<LoginQr> LoginQrAsync(string token);

        Task<LoginQr> AuthorizeAsync(string token, bool confirm = false, bool reject = false);

    }
}
