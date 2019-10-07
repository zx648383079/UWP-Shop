using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using ZoDream.Shop.Helpers;
using ZoDream.Shop.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ZoDream.Shop.Views.Member
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginPage : Page, ISubPage
    {
        public LoginViewModel ViewModel { get; private set; } = new LoginViewModel();

        public string NavTitile => "登录";

        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var tip = (sender as Button).Content.ToString();
            if (tip.IndexOf("邮箱") >= 0)
            {
                ViewModel.Mode = 2;
                return;
            }
            if (tip.IndexOf("手机") >= 0)
            {
                ViewModel.Mode = 1;
                return;
            }
            if (tip.IndexOf("其他") >= 0)
            {
                ViewModel.Mode = 0;
                return;
            }
        }

        private void CountDownButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (sender as CountDownButton).Start();
        }

        private void LoginButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _ = loginAsync();
        }

        private async Task loginAsync()
        {
            _ = await ViewModel.LoginAsync();
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                if (!App.IsLogin())
                {
                    Toast.Tip("登录失败！");
                    return;
                }
                Frame.Navigate(typeof(MemberPage));
            });
            
        }
    }
}
