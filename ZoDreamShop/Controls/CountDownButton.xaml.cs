using Microsoft.Toolkit.Uwp.Helpers;
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

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace ZoDream.Shop.Controls
{
    public sealed partial class CountDownButton : UserControl
    {
        private int _time = 0;
        private DispatcherTimer _timer;

        public CountDownButton()
        {
            this.InitializeComponent();
            Tapped += CountDownButton_Tapped;
        }

        private void CountDownButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_time > 0)
            {
                e.Handled = true;
            }
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(CountDownButton), new PropertyMetadata("获取验证码"));



        public void Start(int time = 60)
        {
            _time = time;
            if (_timer != null)
            {
                _timer.Start();
                return;
            }
            _timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            _timer.Tick += new EventHandler<object>(async (sender, e) =>
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    _time--;
                    if (_time < 1)
                    {
                        Label = "重新获取";
                        return;
                    }
                    Label = _time.ToString("00");
                });
            });
            _timer.Start();
        }


    }
}
