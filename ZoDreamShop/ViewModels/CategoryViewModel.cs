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
    public class CategoryViewModel: BindableBase
    {
        public CategoryViewModel()
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

        private ObservableCollection<Category> categories = new ObservableCollection<Category>();

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { Set(ref categories, value); }
        }

        private Category subCategory;

        public Category SubCategory
        {
            get { return subCategory; }
            set { Set(ref subCategory, value); }
        }

        public async void LoadLeftAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
                Categories.Clear();
            });
            var cats = await App.Repository.Category.GetAsync(0);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var item in cats.Data)
                {
                    Categories.Add(item);
                }
                
                IsLoading = false;
            });
        }

        public async void ChangeMenu(Category category)
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
            });
            var cat = await App.Repository.Category.GetInfoAsync(category.Id);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                SubCategory = cat;
                IsLoading = false;
            });
        }
    }
}
