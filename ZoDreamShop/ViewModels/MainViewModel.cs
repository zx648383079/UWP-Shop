using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoDream.Shop.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {

        }
        private bool _isLoading = false;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private ObservableCollection<string> tips = new ObservableCollection<string>();

        public ObservableCollection<string> Tips
        {
            get { return tips; }
            set { Set(ref tips, value); }
        }

        public async Task LoadTipAsync(string keywords)
        {
            var data = await App.Repository.Product.GetTipsAsync(keywords);

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                tips.Clear();
                foreach (var item in data.Data)
                {
                    Tips.Add(item);
                }

            });
        }

        //public async Task LoadTipAsync()
        //{
        //    await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

        //    var customers = await App.Repository.Users.GetAsync();
        //    if (customers == null)
        //    {
        //        return;
        //    }

        //    await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
        //    {
        //        // TODO
        //        IsLoading = false;
        //    });
        //}
    }
}
