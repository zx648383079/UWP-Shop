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

        Task DeleteAsync(uint id);
    }
}
