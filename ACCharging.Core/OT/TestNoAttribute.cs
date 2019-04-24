using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class TestNoAttribute : Attribute
    {
        public string CaseNo { get; set; }
        public string CaseName { get; set; }

        public TestNoAttribute(string caseNo)
        {
            CaseNo = caseNo;
        }
    }
}
