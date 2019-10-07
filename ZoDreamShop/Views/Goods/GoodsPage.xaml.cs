using System;
using System.Collections.Generic;
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
using ZoDream.Shop.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ZoDream.Shop.Views.Goods
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GoodsPage : Page, ISubPage
    {
        public GoodsPage()
        {
            this.InitializeComponent();
        }

        public GoodsViewModel ViewModel { get; private set; } = new GoodsViewModel();

        public string NavTitile => "商品详情";

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter == null)
            {
                Frame.GoBack();
                return;
            }
            var id = Convert.ToInt32(e.Parameter);
            _ = ViewModel.LoadAsync(id);
        }

    }
}
