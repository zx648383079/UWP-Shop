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
    public class GoodsViewModel: BindableBase
    {


        private Product goods;

        public Product Goods
        {
            get => goods;
            set => Set(ref goods, value);
        }

        private ObservableCollection<Gallery> galleries = new ObservableCollection<Gallery>();

        public ObservableCollection<Gallery> Galleries
        {
            get => galleries;
            set => Set(ref galleries, value);
        }



        public async Task LoadAsync(int id)
        {
            var data = await App.Repository.Product.GetAsync(id);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Galleries.Clear();
                Goods = data;
                if (data.Gallery == null)
                {
                    Galleries.Add(new Gallery() { Image = data.Picture });
                    return;
                }
                foreach (var item in data.Gallery)
                {
                    Galleries.Add(item);
                }
                if (Galleries.Count < 1)
                {
                    Galleries.Add(new Gallery() { Image = data.Picture });
                    return;
                }

            });

        }

    }
}
