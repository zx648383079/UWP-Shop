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
    public sealed partial class IconButton : UserControl
    {
        public IconButton()
        {
            this.InitializeComponent();
        }



        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(IconButton), new PropertyMetadata(null));



        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(IconButton), new PropertyMetadata(null));




        public bool HasRightBorder
        {
            get { return (bool)GetValue(HasRightBorderProperty); }
            set { SetValue(HasRightBorderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasRightBorder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasRightBorderProperty =
            DependencyProperty.Register("HasRightBorder", typeof(bool), typeof(IconButton), new PropertyMetadata(false));




        public bool HasBottomBorder
        {
            get { return (bool)GetValue(HasBottomBorderProperty); }
            set { SetValue(HasBottomBorderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasBottomBorder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasBottomBorderProperty =
            DependencyProperty.Register("HasBottomBorder", typeof(bool), typeof(IconButton), new PropertyMetadata(false));




    }
}
