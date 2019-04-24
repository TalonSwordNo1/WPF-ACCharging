using ACCharging.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Core.OT.TestReporters
{
    public class BaseTestReporter : ITestReporter
    {
        public virtual async Task<TestCaseResultModel> GetResult()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            return await Task.FromResult(new TestCaseResultModel());
        }
    }
}
