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
    public class AccountCenterViewModel: BindableBase
    {

        public AccountCenterViewModel()
        {
            _ = LoadAsync();
        }

        private ObservableCollection<Connect> items = new ObservableCollection<Connect>();

        public ObservableCollection<Connect> Items
        {
            get => items;
            set => Set(ref items, value);
        }

        public async Task LoadAsync()
        {
            var data = await App.Repository.Users.GetConnectAsync();
            if (data == null)
            {
                return;
            }
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var item in data.Data)
                {
                    if (item.Id < 1)
                    {
                        item.Nickname = "未绑定";
                    }
                    Items.Add(item);
                }
            });
        }
    }
}
