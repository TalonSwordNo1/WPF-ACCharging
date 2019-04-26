using ACCharging.Core.Services;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace ACCharging.Shell.ViewModels
{
    public class NewTaskWindowViewModel: BaseWindowViewModel
    {
        [Dependency]
        public CaseService CaseService { get; set; }

        public DelegateCommand ConfirmCommand { get; set; }

        public NewTaskWindowViewModel()
        {
            ConfirmCommand = new DelegateCommand(ConfirmNewTask);
        }

        private void ConfirmNewTask()
        {
            //
            var no = CaseService.GetTestCaseNo();
        }
    }
}
