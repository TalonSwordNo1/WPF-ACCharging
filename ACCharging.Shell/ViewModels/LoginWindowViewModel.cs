using ACCharging.Common;
using ACCharging.Core.Services;
using ACCharging.Shell.Views;
using Prism.Commands;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Unity.Attributes;

namespace ACCharging.Shell.ViewModels
{
    public class LoginWindowViewModel: BaseWindowViewModel
    {
        private string _userName = "admin";
        [Required(ErrorMessage = "User name is required")]
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password = "admin";
        [Required(ErrorMessage = "Password is required")]
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private bool _rememberPassword;
        public bool RememberPassword
        {
            get { return _rememberPassword; }
            set { SetProperty(ref _rememberPassword, value); }
        }

        [Dependency]
        public IUserService UserService { get; set; }

        public DelegateCommand<object> LoginCommand { get; set; }

        public LoginWindowViewModel()
        {
            LoginCommand = new DelegateCommand<object>(UserLogin, CanUserLogin)
                .ObservesProperty(() => UserName)
                .ObservesProperty(() => Password);
        }

        private async void UserLogin(object window)
        {
            bool isLogin = await CheckLoginInfo(UserName, Password);
            if (isLogin)
            {
                LoginWindow loginWindow = window as LoginWindow;
                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                loginWindow.Close();
            }
        }

        private bool CanUserLogin(object arg)
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

        private async Task<bool> CheckLoginInfo(string userName, string password)
        {
            var user = await UserService.GetUserInfoByName(userName);
            if (user != null)
            {
                if (user.Password == CryptographyHelper.Encrypt(password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
