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
using ZoDream.Shop.Controls;
using ZoDream.Shop.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ZoDream.Shop.Views.Member
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MemberPage : Page, ISubPage
    {
        public MemberPage()
        {
            this.InitializeComponent();
        }

        public MemberViewModel ViewModel { get; private set; } = new MemberViewModel();

        public string NavTitile => "个人中心";

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.User = App.ViewModel.User;
        }

        private void IconMenuItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var label = (sender as IconMenuItem).Label;
            if (label == "签到")
            {
                Frame.Navigate(typeof(CheckInPage));
            }
        }

        private void IconButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var label = (sender as IconButton).Label;
            if (label == "安全")
            {
                Frame.Navigate(typeof(Account.CenterPage));
                return;
            }
            if (label == "设置")
            {
                Frame.Navigate(typeof(ProfilePage));
                return;
            }
        }
    }
}
