using ACCharging.Common;
using ACCharging.Core.Models;
using ACCharging.Core.Services;
using ACCharging.Shell.Views;
using Prism.Commands;
using Prism.Ioc;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Unity.Attributes;

namespace ACCharging.Shell.ViewModels
{
    public class UserManagementWinViewModel: BaseWindowViewModel
    {
        private ObservableCollection<UserModel> _userList;
        public ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        [Dependency]
        public UserService UserService { get; set; }

        public DelegateCommand ShowNewUserCommand { get; set; }
        public DelegateCommand<object> DeleteUserCommand { get; set; }

        public UserManagementWinViewModel()
        {
            ShowNewUserCommand = new DelegateCommand(ShowNewUserWin);
            DeleteUserCommand = new DelegateCommand<object>(DeleteUser);
        }

        public override void InitViewModel()
        {
            base.InitViewModel();
            UserList = new ObservableCollection<UserModel>(GetAllUsers().Result);
        }

        private void ShowNewUserWin()
        {
            var newUserWindow = new NewUserWindow();
            newUserWindow.ShowDialog();
        }

        private void DeleteUser(object obj)
        {
            UserModel user = obj as UserModel;
            if (user != null)
            {
            }
        }

        private async Task<ObservableCollection<UserModel>> GetAllUsers()
        {
            return await UserService.GetAllUsers();
        }
    }
}
