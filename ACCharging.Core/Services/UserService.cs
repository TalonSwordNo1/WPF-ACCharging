using ACCharging.Common;
using ACCharging.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Core.Services
{
    public class UserService : BaseService
    {
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
    }
}
