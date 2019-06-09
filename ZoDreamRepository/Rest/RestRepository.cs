using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Repository.Rest
{
    public class RestRepository : IRepository
    {
        private readonly string _url;

        public RestRepository()
        {
            _url = Constants.ApiEndpoint;
        }

        public RestRepository(string url)
        {
            _url = url;
        }

        public IUserRepository Users => new RestUserRepository(_url);

        public IAdRepository Ads => new RestAdRepository(_url);

        public ICategoryRepository Category => new RestCategoryRepository(_url);

        public IProductRepository Product => new RestProductRepository(_url);
    }
}
