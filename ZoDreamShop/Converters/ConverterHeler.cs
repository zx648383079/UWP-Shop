using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using ZoDream.Models;

namespace ZoDream.Shop.Converters
{
    public static class ConverterHeler
    {
        /// <summary>
        /// Returns the reverse of the provided value.
        /// </summary>
        public static bool Not(bool value) => !value;

        /// <summary>
        /// Returns true if the specified value is not null; otherwise, returns false.
        /// </summary>
        public static bool IsNotNull(object value) => value != null;

        /// <summary>
        /// Returns Visibility.Collapsed if the specified value is true; otherwise, returns Visibility.Visible.
        /// </summary>
        public static Visibility CollapsedIf(bool value) =>
            value ? Visibility.Collapsed : Visibility.Visible;

        public static Visibility VisibleIf(bool value) =>
            CollapsedIf(!value);

        /// <summary>
        /// Returns Visibility.Collapsed if the specified value is null; otherwise, returns Visibility.Visible.
        /// </summary>
        public static Visibility CollapsedIfNull(object value) =>
            value == null ? Visibility.Collapsed : Visibility.Visible;

        /// <summary>
        /// Returns Visibility.Collapsed if the specified string is null or empty; otherwise, returns Visibility.Visible.
        /// </summary>
        public static Visibility CollapsedIfNullOrEmpty(string value) =>
            string.IsNullOrEmpty(value) ? Visibility.Collapsed : Visibility.Visible;

        public static Visibility CollapsedIfEmpty(ObservableCollection<Product> value)
            => CollapsedIf(value == null || value.Count < 1);

        public static Visibility Visible0(int value) =>
            CollapsedIf(value != 0);
        public static Visibility Visible1(int value) =>
            CollapsedIf(value != 1);
        public static Visibility Visible2(int value) =>
            CollapsedIf(value != 2);
        public static Visibility Visible3(int value) =>
            CollapsedIf(value != 3);
        public static Visibility Visible4(int value) =>
            CollapsedIf(value != 4);


        public static string Icon(string name)
        {
            switch (name)
            {
                case "qq":
                case "fa-qq":
                    return "\ue69e";
                case "weixin":
                case "wechat":
                case "fa-weixin":
                    return "\ue600";
                case "alipay":
                case "fa-alipay":
                    return "\ue602";
                case "weibo":
                case "fa-weibo":
                    return "\ue6b4";
                case "paypal":
                case "fa-paypal":
                    return "\ue905";
                case "github":
                case "fa-github":
                    return "\ue691";
                case "google":
                case "fa-google":
                    return "\ue8f1";
                default:
                    break;
            }
            return "";
        }
    }
}
