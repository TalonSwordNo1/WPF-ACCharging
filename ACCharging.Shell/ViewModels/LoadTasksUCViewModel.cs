using System;
using ACCharging.Core;
using ACCharging.Core.Services;
using Prism.Commands;
using Prism.Ioc;
using Unity.Attributes;

namespace ACCharging.Shell.ViewModels
{
    public class LoadTasksUCViewModel: BaseDialogViewModel
    {
        [Dependency]
        public TestService TestService { get; set; }

        public DelegateCommand InitializeViewModelCommand { get; set; }
        public DelegateCommand LoadTaskCommand { get; set; }

        public LoadTasksUCViewModel()
        {
            InitializeViewModelCommand = new DelegateCommand(InitViewModel);
            LoadTaskCommand = new DelegateCommand(LoadTask);
        }

        private void InitViewModel()
        {
            LoadTask();
        }

        private void LoadTask()
        {
            var allTestReporters = TestService.GetAllTestReporters();
        }
    }
}
