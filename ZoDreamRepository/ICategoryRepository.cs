using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;
using ZoDream.Repository.Rest;

namespace ZoDream.Repository
{
    public interface ICategoryRepository
    {

        Task<ResponseData<Category>> GetAsync(int parent, Action<HttpException> action = null);

        Task<ResponseData<Category>> GetLevelAsync(Action<HttpException> action = null);

        Task<ResponseData<Category>> GetTreeAsync(Action<HttpException> action = null);

        Task<Category> GetInfoAsync(int id, string extra = null, Action<HttpException> action = null);


    }
}
