using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Repository
{
    public interface IRepository
    {
        IUserRepository Users { get; }

        IAdRepository Ads { get;  }

        ICategoryRepository Category { get; }

        IProductRepository Product { get; }
    }
}
