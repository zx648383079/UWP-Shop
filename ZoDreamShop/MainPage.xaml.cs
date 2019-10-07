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
using ZoDream.Shop.Views;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ZoDream.Shop
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public Frame AppFrame => frame;
        public MainViewModel ViewModel = App.ViewModel;

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (e.SourcePageType == typeof(SettingPage))
                {
                    NavView.SelectedItem = NavView.SettingsItem;
                }
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            var pageType =
                args.IsSettingsInvoked ? typeof(SettingPage) :
                label == "分类" ? typeof(CategoryPage) :
                label == "扫一扫" ? typeof(ScanPage) : 
                label == "购物车" ? typeof(CartPage) :
                label == "我的" ? (App.IsLogin() ? typeof(Views.Member.MemberPage) : typeof(Views.Member.LoginPage)) :
                typeof(HomePage);
            if (pageType != null && pageType != AppFrame.CurrentSourcePageType)
            {
                AppFrame.Navigate(pageType);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                AppFrame.Navigate(typeof(HomePage));
            }
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Navigates the frame to the previous page.
        /// </summary>
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            search(args.QueryText);
        }

        private void SearchBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var s = args.SelectedItem as string;
            // 将从下拉列表中选择的项放入输入框
            sender.Text += s ?? string.Empty;
            search(s);
        }

        private void search(string keywords)
        {
            if (string.IsNullOrWhiteSpace(keywords))
            {
                return;
            }
            AppFrame.Navigate(typeof(SearchPage), new SearchQuery() { Keywords = keywords });
        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            _ = ViewModel.LoadTipAsync(sender.Text);
        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppFrame.Navigate(App.IsLogin() ? typeof(Views.Member.MemberPage) : typeof(Views.Member.LoginPage));
        }
    }
}
