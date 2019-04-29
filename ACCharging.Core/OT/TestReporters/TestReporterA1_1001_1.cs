using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCharging.Core.Models;

namespace ACCharging.Core.OT.TestReporters
{
    [TestNo("A1.1001.1", CaseName = "Test A1 1001.1")]
    public class TestReporterA1_1001_1 : BaseTestReporter
    {
        public override async Task<TestCaseResultModel> GetResult()
        {
            TestCaseResultModel tcrModel = new TestCaseResultModel();
            tcrModel.CaseNo = "A1.1001.1";
            return await Task.FromResult(tcrModel);
        }
    }
}
