using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Models;

namespace ZoDream.Shop.ViewModels
{
    public class AuthorizeViewModel : BindableBase
    {
        public AuthorizeViewModel()
        {
            IsLoading = false;
        }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that specifies whether orders are being loaded.
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set { Set(ref _user, value); }
        }

        private string _token;

        public string Token
        {
            get => _token;
            set => Set(ref _token, value);
        }

    }
}
