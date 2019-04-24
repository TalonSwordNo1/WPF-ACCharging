using ACCharging.Shell.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Windows.Threading;

namespace ACCharging.Shell.ViewModels
{
    public class MainWindowViewModel: BaseViewModel
    {
        private readonly IRegionManager _regionManager;
        private DispatcherTimer dispatcherTimer;

        private string _systemStatus;
        public string SystemStatus
        {
            get { return _systemStatus; }
            set { SetProperty(ref _systemStatus, value); }
        }

        private int _currentProgress;
        public int CurrentProgress
        {
            get { return _currentProgress; }
            set { SetProperty(ref _currentProgress, value); }
        }

        private string _currentDatetime;
        public string CurrentDatetime
        {
            get { return _currentDatetime; }
            set { SetProperty(ref _currentDatetime, value); }
        }

        public DelegateCommand NewTaskCommand { get; set; }
        public DelegateCommand LoadTaskCommand { get; set; }
        public DelegateCommand ViewReportCommand { get; set; }

        public DelegateCommand ShowUserManageCommand { get; set; }
        public DelegateCommand RestartCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitData();

            NewTaskCommand = new DelegateCommand(NewTask);
            LoadTaskCommand = new DelegateCommand(LoadTask);
            ViewReportCommand = new DelegateCommand(ViewReport);

            ShowUserManageCommand = new DelegateCommand(ShowUserManagement);
            RestartCommand = new DelegateCommand(ReStart);
        }

        private void InitData()
        {
            SystemStatus = "System running normal";
            CurrentProgress = 56;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            CurrentDatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss dddd");
        }

        private void NewTask()
        {
            NewTaskWindow newTaskList = new NewTaskWindow();
            newTaskList.ShowDialog();
        }

        private void LoadTask()
        {
            var viewModel = (App.Current as PrismApplication).Container.Resolve<LoadTasksUCViewModel>();
            _regionManager.RegisterViewWithRegion("MainContentRegion", typeof(LoadTasksUC));
        }
        
        private void ViewReport()
        {
        }

        private void ShowUserManagement()
        {
            UserManagementWin userManagement = new UserManagementWin();
            userManagement.ShowDialog();
        }

        private void ReStart()
        {
            // for Winform
            //Application.Exit();
            //System.Diagnostics.Process.Start(Application.ExecutablePath);
        }
    }
}
