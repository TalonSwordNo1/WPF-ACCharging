using ACCharging.Core.OT.TestReporters;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Core.Services
{
    public class TestService : BaseService
    {
        public IContainerProvider _container;

        public TestService(IContainerProvider container)
        {
            _container = container;
        }



        public static void RegisterTestReporter(IContainerRegistry containerRegistry)
        {
            if (containerRegistry != null)
            {
                //var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.BaseType == typeof(BaseTestReporter) 
                //            && t.GetInterfaces().Contains(typeof(ITestReporter)))).ToArray();
                var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => 
                    !t.IsAbstract 
                    && typeof(BaseTestReporter).IsAssignableFrom(t) 
                    && t.BaseType == typeof(BaseTestReporter));
                foreach (Type myType in types)
                {
                    //var tnAttr = myType.GetCustomAttributes(typeof(TestNoAttribute), false).FirstOrDefault();
                    var testNoAttr = Attribute.GetCustomAttribute(myType, typeof(TestNoAttribute)) as TestNoAttribute;
                    if (testNoAttr != null)
                    {
                        containerRegistry.Register(typeof(ITestReporter), myType, testNoAttr.CaseNo);
                    }
                }
            }
        }

        public Dictionary<string, ITestReporter> GetAllTestReporters()
        {
            var reporters = new Dictionary<string, ITestReporter>();
            //var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.BaseType == typeof(BaseTestReporter)
            //            && t.GetInterfaces().Contains(typeof(ITestReporter)))).ToArray();
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                    !t.IsAbstract
                    && typeof(BaseTestReporter).IsAssignableFrom(t)
                    && t.BaseType == typeof(BaseTestReporter));
            foreach (Type myType in types)
            {
                //var tnAttr = myType.GetCustomAttributes(typeof(TestNoAttribute), false).FirstOrDefault();
                var testNoAttr = Attribute.GetCustomAttribute(myType, typeof(TestNoAttribute)) as TestNoAttribute;
                if (testNoAttr != null)
                {
                    var reporter = _container.Resolve<ITestReporter>(testNoAttr.CaseNo);
                    reporters.Add(testNoAttr.CaseNo, reporter);
                }
            }


            //foreach (Type mytype in Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(t => !t.IsAbstract && typeof(ITestReporter).IsAssignableFrom(t)))
            //{
            //    var attrs = System.Attribute.GetCustomAttributes(mytype);
            //    var caseAttr = attrs.OfType<TestNoAttribute>().FirstOrDefault();
            //    if (caseAttr != null)
            //    {
            //        var reporter = _container?.Resolve<ITestReporter>(caseAttr.CaseNo);

            //        if (reporter != null)
            //        {
            //            reporters.Add(caseAttr.CaseNo, reporter);
            //        }

            //    }

            //}

            return reporters;
        }
    }
}
