using ACCharging.Common;
using ACCharging.Core.Models;
using ACCharging.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ACCharging.Core.Services
{
    public class UserService : BaseService, IUserService
    {
        public async Task NewUser(UserModel userModel)
        {
            DbDataContext.Users.Add(
                new User
                {
                    UserName = userModel.UserName,
                    Password = userModel.Password,
                    Gender = ((int)userModel.Gender).ToString(),
                    Mobile = userModel.Mobile,
                    Email = userModel.Email,
                    CreateTime = DateTime.Now,
                    LastLogonTime = DateTime.Now
                });

            await DbDataContext.SaveChangesAsync();
        }

        public async Task<UserModel> GetUserInfoByName(string userName)
        {
            var user = await DbDataContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user != null)
            {
                var userModel = new UserModel
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Gender = (UserGender)Convert.ToInt32(user.Gender),
                    Mobile = user.Mobile,
                    Email = user.Email
                };
                return userModel;
            }

            return null;
        }

        public async Task<ObservableCollection<UserModel>> GetAllUsers()
        {
            var users = await DbDataContext.Users.ToListAsync();
            var result = new ObservableCollection<UserModel>();
            foreach (var user in users)
            {
                result.Add(new UserModel
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Gender = (UserGender)Enum.Parse(typeof(UserGender), user.Gender),
                    Mobile = user.Mobile,
                    Email = user.Email
                });
            }

            return result;
        }
    }
}
