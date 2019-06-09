using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Repository
{
    public interface ICategoryRepository
    {

        Task<ResponseData<Category>> GetAsync(int parent);

        Task<ResponseData<Category>> GetLevelAsync();

        Task<ResponseData<Category>> GetTreeAsync();

        Task<Category> GetInfoAsync(int id, string extra = null);


    }
}
