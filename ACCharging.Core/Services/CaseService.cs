using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Core.Services
{
    public class CaseService : BaseService
    {
        public IContainerProvider _container;

        public CaseService(IContainerProvider containerProvider)
        {
            _container = containerProvider;
        }

        public string GetTestCaseNo()
        {
            return "A1.1001.1";
        }
    }
}
