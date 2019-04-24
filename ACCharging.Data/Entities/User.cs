using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Data.Entities
{
    public class User
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime LastLogonTime { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsSystemUser { get; set; }
    }
}
