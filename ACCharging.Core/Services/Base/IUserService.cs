using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ACCharging.Core.Models;

namespace ACCharging.Core.Services
{
    public interface IUserService
    {
        Task<ObservableCollection<UserModel>> GetAllUsers();
        Task<UserModel> GetUserInfoByName(string userName);
        Task NewUser(UserModel userModel);
    }
}