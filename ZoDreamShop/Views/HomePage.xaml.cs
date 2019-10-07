using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ZoDream.Models;
using ZoDream.Shop.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ZoDream.Shop.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page, ISubPage
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        public HomeViewModel ViewModel { get; } = new HomeViewModel();

        public string NavTitile => "首页";

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (ViewModel.Banners.Count < 1)
            {
                ViewModel.Load();
            }
        }

        private void BannerView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((FlipView)sender).Height = ((FlipView)sender).ActualWidth * 400 / 750;
        }

        private void AddToCart(object sender, TappedEventHandler e)
        {
            Debug.WriteLine(sender.ToString());
        }


        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as ProductSimple;
            Frame.Navigate(typeof(Goods.GoodsPage), item.Id);
        }
    }
}
