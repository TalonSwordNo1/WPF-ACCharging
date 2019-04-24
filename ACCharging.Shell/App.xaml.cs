using ACCharging.Core.Services;
using ACCharging.Data;
using ACCharging.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ACCharging.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        #region Implement of PrismApplication

        protected override Window CreateShell()
        {
            return Container.Resolve<LoginWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<LoadTasksUC>();

            containerRegistry.RegisterInstance(typeof(IContainerProvider), Container);
            //containerRegistry.Register<BaseService, TestService>("TestService");
            //containerRegistry.Register<BaseService, CaseService>("CaseService");
            TestService.RegisterTestReporter(containerRegistry);

            containerRegistry.RegisterSingleton<DbDataContext>();

            base.RegisterRequiredTypes(containerRegistry);
        }

        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        #region Handle Exception

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowUnhandleException(e.ExceptionObject as Exception);
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            ShowUnhandleException(e.Exception);
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            ShowUnhandleException(e.Exception);
        }

        private void ShowUnhandleException(Exception ex)
        {
            string errorMessage = string.Format(
                "An application error occurred.\nPlease check whether your data is correct and repeat the action. If this error occurs again there seems to be a more serious malfunction in the application, and you better close it.\n\nError: {0}\n\nDo you want to continue?\n(if you click Yes you will continue with your work, if you click No the application will close)",
                ex.Message + (ex.InnerException != null
                    ? "\n" +
                      ex.InnerException.Message
                    : null));

            if (MessageBox.Show(errorMessage, "Application Error", MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Error) == MessageBoxResult.No)
            {
                if (MessageBox.Show(
                        "WARNING: The application will close. Any changes will not be saved!\nDo you really want to close it?",
                        "Close the application!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) ==
                    MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        #endregion
    }
}
