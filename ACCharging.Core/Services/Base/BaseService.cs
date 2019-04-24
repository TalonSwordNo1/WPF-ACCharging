using ACCharging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace ACCharging.Core.Services
{
    public class BaseService
    {
        [Dependency]
        public DbDataContext DbDataContext { get; set; }
    }
}
