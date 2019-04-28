using System.Collections.Generic;

namespace ACCharging.Core.Services
{
    public interface ITestService
    {
        Dictionary<string, ITestReporter> GetAllTestReporters();
    }
}