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
using ZoDream.Shop.Helpers;
using ZoDream.Shop.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ZoDream.Shop.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AuthorizePage : Page
    {
        public AuthorizePage()
        {
            this.InitializeComponent();
        }

        public AuthorizeViewModel ViewModel { get; private set; } = new AuthorizeViewModel();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!App.IsLogin())
            {
                Frame.Navigate(typeof(LoginPage));
                return;
            }
            ViewModel.User = App.ViewModel.User;
            _ = checkTokenAsync(e.Parameter as string);
        }

        private async Task checkTokenAsync(string v)
        {
            var model = await App.Repository.Users.AuthorizeAsync(v);
            if (model == null)
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    Toast.Tip("二维码已失效！");
                    Frame.GoBack();
                });
            }
            ViewModel.Token = v;
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _ = confirm();
        }

        private async Task confirm()
        {
            var model = await App.Repository.Users.AuthorizeAsync(ViewModel.Token, true);
            if (model == null)
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    Toast.Tip("二维码已失效！");
                    Frame.GoBack();
                });
                return;
            }
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Frame.Navigate(typeof(HomePage));
            });
        }

        private async Task reject()
        {
            var model = await App.Repository.Users.AuthorizeAsync(ViewModel.Token, true);
            if (model == null)
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    Toast.Tip("二维码已失效！");
                    Frame.GoBack();
                });
                return;
            }
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Frame.GoBack();
            });
        }

        private void CancelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _ = reject();
        }
    }
}
