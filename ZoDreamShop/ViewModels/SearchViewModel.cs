using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Shop.ViewModels
{
    public class SearchViewModel: BindableBase
    {

        public SearchViewModel()
        {
            IsLoading = false;
            Products = new IncrementalLoadingCollection<Product>(count =>
            {
                return Task.Run(async () =>
                {
                    Query.Page++;
                    var products = await App.Repository.Product.GetAsync(Query.ToQueries());
                    return Tuple.Create(products.Data, products.Paging.More);
                });
            });
        }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that specifies whether orders are being loaded.
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        public SearchQuery Query { get; set; }

        private bool hasMore = true;

        private IncrementalLoadingCollection<Product> products;

        public IncrementalLoadingCollection<Product> Products
        {
            get { return products; }
            set { Set(ref products, value); }
        }

        public void Load(SearchQuery query)
        {
            Query = query;
            RefreshAsync();

        }

        public async void RefreshAsync()
        {
            Query.Page = 1;
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
                Products.Clear();
            });
            var products = await App.Repository.Product.GetAsync(Query.ToQueries());
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var item in products.Data)
                {
                    Products.Add(item);
                }
                hasMore = products.Paging.More;
                IsLoading = false;
            });
        }

        public async void MoreAsync()
        {
            if (!hasMore)
            {
                return;
            }
            Query.Page ++;
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
            });
            var products = await App.Repository.Product.GetAsync(Query.ToQueries());
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var item in products.Data)
                {
                    Products.Add(item);
                }
                hasMore = products.Paging.More;
                IsLoading = false;
            });
        }
    }

    public class SearchQuery
    {
        public string Keywords { get; set; } = string.Empty;

        public int Category { get; set; } = 0;

        public int Brand { get; set; } = 0;

        public int Page { get; set; } = 1;

        public int PerPage { get; set; } = 20;

        public Dictionary<string, string> ToQueries()
        {
            var data = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(Keywords))
            {
                data.Add("keywords", Keywords);
            }
            if (Category > 0)
            {
                data.Add("category", Category.ToString());
            }
            if (Brand > 0)
            {
                data.Add("brand", Brand.ToString());
            }
            if (Page < 1)
            {
                Page = 1;
            }
            if (PerPage < 1)
            {
                PerPage = 20;
            }
            data.Add("page", Page.ToString());
            data.Add("per_page", PerPage.ToString());
            return data;
        }
    }
}
