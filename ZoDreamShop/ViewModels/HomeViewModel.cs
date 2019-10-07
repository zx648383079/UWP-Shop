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
    public class HomeViewModel: BindableBase
    {
        public HomeViewModel()
        {
            IsLoading = false;
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

        private ObservableCollection<Ad> banners = new ObservableCollection<Ad>();

        public ObservableCollection<Ad> Banners
        {
            get { return banners; }
            set { Set(ref banners, value); }
        }

        private ObservableCollection<Category> categories = new ObservableCollection<Category>();

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { Set(ref categories, value); }
        }


        private ObservableCollection<ProductSimple> hotProducts = new ObservableCollection<ProductSimple>();

        public ObservableCollection<ProductSimple> HotProducts
        {
            get { return hotProducts; }
            set { Set(ref hotProducts, value); }
        }

        private ObservableCollection<ProductSimple> newProducts = new ObservableCollection<ProductSimple>();

        public ObservableCollection<ProductSimple> NewProducts
        {
            get { return newProducts; }
            set { Set(ref newProducts, value); }
        }

        private ObservableCollection<ProductSimple> bestProducts = new ObservableCollection<ProductSimple>();

        public ObservableCollection<ProductSimple> BestProducts
        {
            get { return bestProducts; }
            set { Set(ref bestProducts, value); }
        }

        public async void Load()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
                Banners.Clear();
            });
            var ads = await App.Repository.Ads.GetBannersAsync();
            var cats = await App.Repository.Category.GetAsync(0);
            var products = await App.Repository.Product.GetHomeAsync();
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var item in ads.Data)
                {
                    Banners.Add(item);
                }
                foreach (var item in cats.Data)
                {
                    Categories.Add(item);
                }
                foreach (var item in products.BestProducts)
                {
                    BestProducts.Add(item);
                }
                foreach (var item in products.NewProducts)
                {
                    NewProducts.Add(item);
                }
                foreach (var item in products.HotProducts)
                {
                    HotProducts.Add(item);
                }
                IsLoading = false;
            });
        }

    }
}
