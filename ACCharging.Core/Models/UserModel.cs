using ACCharging.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Core.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserGender Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public bool IsSelected { get; set; }
    }
}
