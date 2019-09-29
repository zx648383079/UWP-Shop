using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoDream.Shop.Helpers;

namespace ZoDream.Shop.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public LoginViewModel()
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

        private int _mode = 0;

        public int Mode
        {
            get { return _mode; }
            set { Set(ref _mode, value); }
        }

        private string _mobile = string.Empty;

        public string Mobile
        {
            get => _mobile;
            set => Set(ref _mobile, value);
        }


        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        private string _password = string.Empty;

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        private string _code = string.Empty;

        public string Code
        {
            get => _code;
            set => Set(ref _code, value);
        }

        public async Task<bool> LoginAsync()
        {
            var user = await App.Repository.Users.LoginAsync(new Models.LoginForm() { Email = Email, Password = Password }, res =>
            {
                Toast.ShowWarning(res.Message);
            });
            if (user == null)
            {
                return false;
            }
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                App.Login(user);
            });
            return true;
        }


    }
}
