using ACCharging.Common;
using ACCharging.Core.Models;
using Prism.Commands;
using Prism.Ioc;
using System.Collections.ObjectModel;

namespace ACCharging.Shell.ViewModels
{
    public class UserManagementWinViewModel: BaseViewModel
    {
        private ObservableCollection<UserModel> _userList;
        public ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        public DelegateCommand ShowNewUserCommand { get; set; }
        public DelegateCommand<object> DeleteUserCommand { get; set; }

        public UserManagementWinViewModel()
        {
            ShowNewUserCommand = new DelegateCommand(ShowNewUserWin);
            DeleteUserCommand = new DelegateCommand<object>(DeleteUser);

            UserList = GetAllUsers();
        }

        private void ShowNewUserWin()
        {
            
        }

        private void DeleteUser(object obj)
        {
            UserModel user = obj as UserModel;
            if (user != null)
            {

            }
        }

        private ObservableCollection<UserModel> GetAllUsers()
        {
            ObservableCollection<UserModel> allUsers = new ObservableCollection<UserModel>();
            for(int i = 1; i <= 55; i++)
            {
                UserModel user = new UserModel()
                {
                    UserName = "Name-" + i,
                    Password = "pass-" + i,
                    Gender = UserGender.Female,
                    Mobile = "139223455" + i,
                    Email = "QAWEe-" + i + "@q.com"
                };
                allUsers.Add(user);
            }

            return allUsers;
        }
    }
}
